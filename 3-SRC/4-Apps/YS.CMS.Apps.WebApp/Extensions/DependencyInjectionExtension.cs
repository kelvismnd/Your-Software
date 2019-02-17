﻿using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.IoC.Handler;

namespace YS.CMS.Apps.WebApp.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjecion(this IServiceCollection services)
        {
            var injector = new WebAppNativeInjector();
            injector.RegisterServices(services);
        }
    }
}