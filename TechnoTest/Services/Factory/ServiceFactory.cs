using System;
using Microsoft.Extensions.DependencyInjection;
using TechnoTest.Services.Factory.Abstraction;

namespace TechnoTest.Services.Factory
{
    public class ServiceFactory<TService> : IServiceFactory<TService>
    {
        public ServiceFactory(IServiceProvider service)
        {
            Service = (TService)service.GetService(typeof(TService)) ?? ActivatorUtilities.CreateInstance<TService>(service);
        }
        
        public TService Service { get; }
    }
}