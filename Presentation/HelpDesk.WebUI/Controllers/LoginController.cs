﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using HelpDesk.DTO.UserAuthDtos;
using HelpDesk.WebUI.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace HelpDesk.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7099/api/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("helpDeskToken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    }
                    var userRole = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
                    if (userRole == "Member")
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    if (userRole == "Admin")
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }

                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(ResultCheckRegisterDto resultCheckRegister)
        {
            if (resultCheckRegister.Password == resultCheckRegister.ConfirmPassword)
            {
                var createAppUserDto = new CreateRegisterDto
                {
                    Name = resultCheckRegister.Name,
                    Surname = resultCheckRegister.Surname,
                    Username = resultCheckRegister.Username,
                    Email = resultCheckRegister.Email,
                    Password = resultCheckRegister.Password,
                    PhoneNumber = "",
                };
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createAppUserDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7099/api/Registers/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            Response.Cookies.Delete(".AspNetCore.Antiforgery");
            Response.Cookies.Delete(".AspNetCore.Antiforgery.jmjew95sMts");
            Response.Cookies.Delete("1P_JAR");
            Response.Cookies.Delete("MechanicServiceJwt", new CookieOptions
            {
                Domain = "localhost",
                Path = "/",
                Expires = DateTime.UtcNow.AddDays(-1), // reset cookie
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.Strict
            });
            await Task.Delay(500);
            return RedirectToAction("SignIn", "Login");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
