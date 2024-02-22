using Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BlogAppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BlogDb")));
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
        }
    }
}
