using Core.CrossCuttingConcerns.Cach;
using Core.CrossCuttingConcerns.Cach.Microsoft;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceColection)
        {
            serviceColection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceColection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceColection.AddSingleton<Stopwatch>();
        }
    }
}
