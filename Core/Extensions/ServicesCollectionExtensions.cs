﻿using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddDependencyResolvers
        (this IServiceCollection servicesCollection, ICoreModule[] modules) 
    {
        foreach (var module in modules) 
        {
            module.Load(servicesCollection);
        }
        return ServiceTool.Create(servicesCollection);
    }
}
