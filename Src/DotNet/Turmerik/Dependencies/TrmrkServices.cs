﻿using Turmerik.Actions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Turmerik.EqualityComparer;
using Turmerik.Reflection;
using Turmerik.Text;
using Turmerik.Utility;

namespace Turmerik.Dependencies
{
    public static class TrmrkServices
    {
        public static IServiceCollection RegisterAll(
            this IServiceCollection services)
        {
            services.AddSingleton<ITimeStampHelper, TimeStampHelper>();
            services.AddSingleton<ILambdaExprHelper, LambdaExprHelper>();
            services.AddSingleton<ILambdaExprHelperFactory, LambdaExprHelperFactory>();
            services.AddSingleton<IBasicEqualityComparerFactory, BasicEqualityComparerFactory>();
            services.AddSingleton<IActionErrorCatcherFactory, ActionErrorCatcherFactory>();

            return services;
        }
    }
}
