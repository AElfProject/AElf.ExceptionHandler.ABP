using Autofac;
using Microsoft.Extensions.Hosting;

namespace AElf.ExceptionHandler.ABP;

public static class AElfExceptionHandlerHostBuilderExtensions
{
    public static IHostBuilder UseAElfExceptionHandler(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices((_, services) =>
        {
            hostBuilder.ConfigureContainer<ContainerBuilder>((_, builder) =>
            {
                AutofacRegistration.Register(builder, services, null);
            });
        });
    }
}
