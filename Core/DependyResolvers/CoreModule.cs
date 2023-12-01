using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Caching;
using Microsoft.Extensions.Caching.Memory;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using System.Diagnostics;

namespace Core.DependyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection serviceCollection)
    {
        serviceCollection.AddMemoryCache();
        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        serviceCollection.AddSingleton<Stopwatch>();
        
    }
}