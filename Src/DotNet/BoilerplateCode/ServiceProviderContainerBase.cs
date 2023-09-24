using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlPlus.AvaloniaApplication
{
    public abstract class ServiceProviderContainerBase : SingletonRegistrarBase<IServiceProvider, IServiceCollection>
    {
        protected abstract void RegisterServices(
            IServiceCollection services);

        protected override IServiceProvider Convert(
            IServiceCollection services)
        {
            RegisterServices(services);
            var svcProv = services.BuildServiceProvider();

            return svcProv;
        }
    }
}
