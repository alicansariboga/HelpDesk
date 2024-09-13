using HelpDesk.Application.Interfaces.AppUserInterfaces;
using HelpDesk.Application.Interfaces.FileInterfaces;
using HelpDesk.Application.Interfaces.MailInterfaces;
using HelpDesk.Application.Interfaces.StaffDepartmentInterfaces;
using HelpDesk.Application.Interfaces.TicketInterfaces;
using HelpDesk.Application.Tools;
using HelpDesk.Persistence.Repositories.AppUserRepositories;
using HelpDesk.Persistence.Repositories.FileRepositories;
using HelpDesk.Persistence.Repositories.MailRepositories;
using HelpDesk.Persistence.Repositories.StaffDepartmentRepositories;
using HelpDesk.Persistence.Repositories.TicketRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7099",
                                "http://localhost:7099")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddHttpClient();

// Add services to the container.

//Json Web Token(JWT)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero, // start time
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

#region Registrations
builder.Services.AddScoped<HelpDeskContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IAppUserRepository), typeof(AppUserRepository));
builder.Services.AddScoped(typeof(ITicketRepository), typeof(TicketRepository));
builder.Services.AddScoped(typeof(IStaffDepartmentRepository), typeof(StaffDepartmentRepository));
builder.Services.AddScoped(typeof(IMailRepository), typeof(MailRepository));
builder.Services.AddScoped(typeof(IFileRepository), typeof(FileRepository));
#endregion

// ServiceRegistration
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS Middleware
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
