
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IsubuSatis.FotografApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(x =>
              {
                  x.Authority = "https://localhost:5001";
                  x.Audience = "resource_fotografDepo";
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

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
