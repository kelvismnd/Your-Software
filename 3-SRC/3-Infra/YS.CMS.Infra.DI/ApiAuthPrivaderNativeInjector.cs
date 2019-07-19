﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Infra.Security;
using YS.CMS.Infra.Security.Manager;

namespace YS.CMS.Infra.DI
{
    public static class ApiAuthPrivaderNativeInjector
    {
        public static void RegisterServices(IServiceCollection services, string connnectionString)
        {
            services.AddDbContext<CMSAuthContext>(options =>
            {
                options.UseSqlServer(connnectionString);
            });

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddSignInManager<UserManager>()
            .AddEntityFrameworkStores<CMSAuthContext>();
            
            // >_ api version
            services.AddApiVersioning();
        }
    }
}
