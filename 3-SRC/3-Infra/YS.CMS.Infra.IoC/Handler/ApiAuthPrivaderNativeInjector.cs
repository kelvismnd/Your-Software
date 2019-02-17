﻿using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.Data;

namespace YS.CMS.Infra.IoC.Handler
{
    public class ApiAuthPrivaderNativeInjector : NativeInjector
    {
        public override void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<CMSContext>(optionsAction => AddDbContextOptionsBuilder());
        }
    }
}