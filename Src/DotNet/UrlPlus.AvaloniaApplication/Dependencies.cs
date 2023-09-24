using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlPlus.AvaloniaApplication
{
    public static class Dependencies
    {
        public static IServiceProvider RegisterAll(
            IServiceCollection services)
        {
            services.AddSingleton<AppGlobals>();

            var svcProv = ServiceProviderContainer.Instance.Value.RegisterData(services);
            return svcProv;
        }
    }
}
