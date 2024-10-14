using System.Reflection;
using AElf.ExceptionHandler.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AElf.ExceptionHandler.ABP;

public class AOPExceptionModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddExceptionHandler();
        context.Services.AddTransient<ExceptionHandlerInterceptor>();
                        
        context.Services.OnRegistered(options =>
        {
            var methodInfos = options.ImplementationType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            // Check if any of the class methods is decorated with the ExceptionHandlerAttribute
            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.IsDefined(typeof(ExceptionHandlerAttribute), true))
                {
                    var result = options.Interceptors.TryAdd<ExceptionHandlerInterceptor>();
                    break;
                }
            }
        });
    }
}