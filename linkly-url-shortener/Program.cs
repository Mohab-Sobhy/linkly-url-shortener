using FluentValidation;
using linkly_url_shortener.Application;
using linkly_url_shortener.Domain.Interfaces.Repositories;
using linkly_url_shortener.Infrastructure.Database;
using linkly_url_shortener.Presentation.Middlewares;
using Microsoft.EntityFrameworkCore;

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
        
        builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        builder.Services.AddScoped<UserService>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        
        app.UseMiddleware<ValidationExceptionMiddleware>();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}