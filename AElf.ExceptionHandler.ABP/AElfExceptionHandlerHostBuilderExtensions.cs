using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AElf.ExceptionHandler.ABP;

public static class AElfExceptionHandlerHostBuilderExtensions
{
    public static IList<ServiceDescriptor> ExceptionHandlerServices { get; set; } = new List<ServiceDescriptor>();
    public static IHostBuilder UseAElfExceptionHandler(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices((_, services) =>
        {
            hostBuilder.ConfigureContainer<ContainerBuilder>((_, builder) =>
            {
                // Register the exception handler services
                foreach (var serviceDescriptor in ExceptionHandlerServices)
                {
                    services.Add(serviceDescriptor);
                }
                
                AutofacRegistration.Register(builder, services, null);
            });
        });
    }
}
