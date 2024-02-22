using Application.Features.Auth.Rules;
using Application.Features.BlogPosts.Rules;
using Application.Utils.Aspects.Adapters;
using Application.Utils.Encryption;
using Application.Utils.Helpers;
using Application.Utils.Jwt;
using Application.Utils.Tools;
using Castle.DynamicProxy;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static void AddJwtConfigurations(this IServiceCollection services,IConfiguration configuration)
        {
            var tokenOptions = configuration.GetSection("JwtSettings").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
            });
        }
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<ITokenHelper, JwtHelper>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<BlogPostBusinessRules>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<FileHelper>();
            services.AddSingleton<IInterceptorSelector, AspectInterceptorSelector>();
            ServiceTool.Create(services);
        }
        
    }
}
