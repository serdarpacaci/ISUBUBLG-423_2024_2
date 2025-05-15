
using IsubuSatis.Sepet.Models;
using IsubuSatis.Sepet.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IsubuSatis.Sepet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<RedisService>();
            builder.Services.AddScoped<ISepetService, SepetService>();
            builder.Services.AddScoped<IIdentityHelperService, IdentityHelperService>();
            // Add services to the container.
            var redisSection = builder.Configuration.GetSection("RedisSettings");
            builder.Services.Configure<RedisSettings>(redisSection);

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddMemoryCache();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(x =>
             {
                 x.Authority = "https://localhost:5001";
                 x.Audience = "resource_sepet";
                 x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                 {
                     RequireExpirationTime = true,
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.FromSeconds(15)
                 };
             });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
