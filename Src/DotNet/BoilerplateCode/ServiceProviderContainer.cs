using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlPlus.AvaloniaApplication
{
    public class ServiceProviderContainer : SingletonRegistrarBase<IServiceProvider, IServiceCollection>
    {
        private ServiceProviderContainer()
        {
        }

        public static Lazy<ServiceProviderContainer> Instance { get; } = new Lazy<ServiceProviderContainer>(() => new());

        public IServiceProvider SvcProv => Data;

        public IServiceCollection RegisterAll(IServiceCollection services)
        {
            return services;
        }

        protected override IServiceProvider Convert(
            IServiceCollection services) => services.BuildServiceProvider();
    }
}
