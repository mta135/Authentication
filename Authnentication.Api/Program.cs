
using Auth.Models.DbSetup.DbSetupConnection;
using Auth.Models.DbSetup.MigratorSetup;
using Authentication.Api.Injection;
using Authentication.Api.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
         {
             options.AddPolicy("AllowAll", builder =>
             {
                 builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
             });
         });

        #region Initializer

        ConnectionStringSettings.InitializeSettings(builder.Configuration);

        FluentMigratorSetup.ConfigureAndRunMigrations(builder.Services);

        JwtTokenSettings.InitializeSettings(builder.Configuration);

        #endregion

        #region Jwt Token

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,

                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = JwtTokenSettings.JwtIssuer,
                    ValidAudience = JwtTokenSettings.JwtIssuer,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.JwtKey ?? string.Empty))
                };
            });
        //Jwt configuration ends here

        #endregion;

        builder.Services.AddAuthorization();

        builder.Services.AddControllers();

        #region Register Dependecy Injection

        DependencyInjectionResolver.DependecyInjection(builder.Services);

        #endregion

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

        app.UseCors("AllowAll");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

