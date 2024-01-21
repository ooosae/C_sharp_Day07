namespace d07_ex03;

using System;
using System.Reflection;

public static class TypeFactory
{
    public static T CreateWithConstructor<T>() where T : class
    {
        ConstructorInfo? constructorInfo = typeof(T).GetConstructor(Type.EmptyTypes);

        if (constructorInfo == null)
        {
            throw new InvalidOperationException($"No parameterless constructor found for type {typeof(T).FullName}.");
        }

        return (T)constructorInfo.Invoke(null);
    }

    public static T CreateWithActivator<T>() where T : class
    {
        return Activator.CreateInstance<T>();
    }
    
    public static T? CreateWithParameters<T>(params object[] parameters) where T : class
    {
        return (T?)Activator.CreateInstance(typeof(T), parameters);
    }
}