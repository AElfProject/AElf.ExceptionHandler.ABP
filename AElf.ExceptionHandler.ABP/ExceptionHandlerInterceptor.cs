using Volo.Abp.DependencyInjection;
using Volo.Abp.DynamicProxy;

namespace AElf.ExceptionHandler.ABP;

public class ExceptionHandlerInterceptor : AbpInterceptor, ITransientDependency
{
    private readonly IInterceptor _interceptor;

    public ExceptionHandlerInterceptor(IInterceptor interceptor)
    {
        _interceptor = interceptor;
    }

    public override async Task InterceptAsync(IAbpMethodInvocation invocation)
    {
        var methodExecutionArgs = new MethodExecutionArgs
        {
            TargetObject = invocation.TargetObject,
            MethodInfo = invocation.Method,
            Arguments = invocation.Arguments,
            ReturnValue = null,
            Invocation = invocation.ProceedAsync
        };
        
        await _interceptor.InterceptAsync(methodExecutionArgs);

        if (methodExecutionArgs.ReturnValue != null)
        {
            invocation.ReturnValue = methodExecutionArgs.ReturnValue;
        }
    }
}