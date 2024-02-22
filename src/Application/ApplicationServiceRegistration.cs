using Application.Behaviors;
using Application.Features.Auth.Commands;
using Application.Features.Auth.Rules;
using Application.Features.Auth.Validators;
using Application.Features.BlogPosts.Rules;
using Application.Features.Blogs.Commands;
using Application.Utils.Aspects.Adapters;
using Application.Utils.Encryption;
using Application.Utils.Helpers;
using Application.Utils.Jwt;
using Application.Utils.Tools;
using Castle.DynamicProxy;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Runtime.CompilerServices;


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
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<BlogPostBusinessRules>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<FileHelper>();
            ServiceTool.Create(services);
        }
        
    }
}
