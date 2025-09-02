using FluentValidation;
using linkly_url_shortener.Application.Services;
using linkly_url_shortener.Domain.Interfaces;
using linkly_url_shortener.Domain.Interfaces.Repositories;
using linkly_url_shortener.Infrastructure.Cryptography;
using linkly_url_shortener.Infrastructure.Database;
using linkly_url_shortener.Infrastructure.Database.Repositories;
using linkly_url_shortener.Presentation.Controllers;
using linkly_url_shortener.Presentation.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace linkly_url_shortener;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
        
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IRegisterUserRepository, RegisterUserRepository>();
        
        builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                var jwtSettings = builder.Configuration.GetSection("Jwt");
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey( System.Text.Encoding.UTF8.GetBytes(jwtSettings["Key"]!) )
                };
            });

        builder.Services.AddAuthorization();
        
        builder.Services.AddSingleton<ITokenGenerator>(new TokenGenerator(
            builder.Configuration.GetSection("Jwt")["Key"]!,
            builder.Configuration.GetSection("Jwt")["Issuer"]!,
            builder.Configuration.GetSection("Jwt")["Audience"]!,
            int.Parse(builder.Configuration.GetSection("Jwt")["ExpireMinutes"]!)
        ));
        
        builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        builder.Services.AddScoped<RegisterService>();
        builder.Services.AddScoped<AuthenticationService>();
        builder.Services.AddSingleton<IStringHasher, StringHasher>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        
        app.UseMiddleware<ExceptionMiddleware>();
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}