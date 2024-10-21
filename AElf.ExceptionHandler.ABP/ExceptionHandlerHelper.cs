using System.Reflection;

namespace AElf.ExceptionHandler.ABP;

public static class ExceptionHandlerHelper
{
    public static bool IsExceptionHandlerType(TypeInfo implementationType)
    {
        return HasExceptionHandlerAttribute(implementationType) || AnyMethodHasExceptionHandlerAttribute(implementationType);
    }
    
    private static bool HasExceptionHandlerAttribute(MemberInfo implementationType)
    {
        return implementationType.IsDefined(typeof(ExceptionHandlerAttribute), true);
    }
    
    private static bool AnyMethodHasExceptionHandlerAttribute(TypeInfo implementationType)
    {
        return implementationType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
            .Any(HasExceptionHandlerAttribute);
    }
}