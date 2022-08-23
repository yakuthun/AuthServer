using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Configurations;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Extensions
{//Extensions metotlar static olmalıdır.
    public static class CustomTokenAuth
    {
        public static void AddCustomTokenAuth(this IServiceCollection services,CustomTokenOption tokenOptions)
        {
            services.AddAuthentication(options =>
            {
                //bir üyelik sisteminde kullanıcı olarak gir bayi olarak gir gibi özellikler burada scheme olarak adlandırılır.
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
            {
               
                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {//validasyonu burada gerçekleştireceğiz.
                    ValidIssuer = tokenOptions.Issuer, //www.autserver.com
                    ValidAudience = tokenOptions.Audience[0],//www.authserver.com,www.miniapi1.com
                    IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),


                    ValidateIssuerSigningKey = true,//mutlaka bir imzası olması zorundadır.
                    ValidateAudience = true,//doğrulama
                    ValidateIssuer = true, //doğrula
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,//default eklenen vakti 0'a çeker. Tölerans değerini 0'a indirdim.
                };
            });

        }
    }
}
