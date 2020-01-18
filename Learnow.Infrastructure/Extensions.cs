using Learnow.Infrastructure.Jwt;
using Learnow.Infrastructure.SendGrid;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Infrastructure
{
    public static class Extensions
    {
        public static void AddJwt(this IServiceCollection services, Action<JwtOptions> jwtOptions)
        {
            var options = new JwtOptions();
            jwtOptions.Invoke(options);

            Console.WriteLine($"Options: ${options.Issuer} ${options.SecretKey} : ${options.ExpiryMinutes}");

            services.AddSingleton<IJwtHandler, JwtHandler>(imp => new JwtHandler(options));

            services.AddAuthentication()
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidIssuer = options.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey))
                    };
                });
        }
        public static void AddSendGrid(this IServiceCollection services, Action<SendGridAdapterOptions> optionsBuilder = null)
        {
            var options = new SendGridAdapterOptions();
            optionsBuilder(options);

            services.AddSingleton<ISendGridAdapter, SendGridAdapter>(imp => new SendGridAdapter(options));
        }
    }
}
