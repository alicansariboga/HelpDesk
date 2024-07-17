using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// JWT Configuration
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
//{
//    opt.LoginPath = "/Login/SignIn/";
//    opt.LogoutPath = "/Login/SignOut/";
//    opt.AccessDeniedPath = "/Pages/Error403/";
//    opt.Cookie.SameSite = SameSiteMode.Strict;
//    opt.Cookie.HttpOnly = true;
//    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//    opt.Cookie.Name = "HelpDeskJwt";
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// CORS
app.UseCors("AllowSpecificOrigin");

//404 error
app.UseStatusCodePagesWithReExecute("/Pages/Error404", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();

// Admin Area
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});