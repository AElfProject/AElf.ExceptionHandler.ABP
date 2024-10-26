using System.Reflection;
using AElf.ExceptionHandler.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Castle;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;

namespace AElf.ExceptionHandler.ABP;

[DependsOn(
    typeof(AbpCastleCoreModule)
)]
public class AOPExceptionModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddExceptionHandler();
    }

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        base.PostConfigureServices(context);
        context.Services.OnRegistered(RegisterExceptionHandlerIfNeeded);
    }

    private static void RegisterExceptionHandlerIfNeeded(IOnServiceRegistredContext context)
    {
        if(ShouldIntercept(context.ImplementationType))
        {
            context.Interceptors.TryAdd<ExceptionHandlerInterceptor>();
        }
    }

    private static bool ShouldIntercept(Type type)
    {
        return ExceptionHandlerHelper.IsExceptionHandlerType(type.GetTypeInfo());
        //return !DynamicProxyIgnoreTypes.Contains(type) && ExceptionHandlerHelper.IsExceptionHandlerType(type.GetTypeInfo());
    }
}