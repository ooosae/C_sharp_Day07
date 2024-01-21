using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace d07_ex00;
    
class Program
{
    static void Main()
    {
        Type defaultHttpContextType = typeof(DefaultHttpContext);

        Console.WriteLine($"Type: {defaultHttpContextType.FullName}");
        Console.WriteLine($"Assembly: {defaultHttpContextType.Assembly}");
        Console.WriteLine($"Based on: {defaultHttpContextType.BaseType}");

        FieldInfo[] fields = defaultHttpContextType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        Console.WriteLine("\nFields:");
        foreach (FieldInfo field in fields)
        {
            Console.WriteLine($"{field.FieldType} {field.Name}");
        }
        
        PropertyInfo[] properties = defaultHttpContextType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        Console.WriteLine("\nProperties:");
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"{property.PropertyType} {property.Name}");
        }
        
        MethodInfo[] methods = defaultHttpContextType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        Console.WriteLine("\nMethods:");
        foreach (MethodInfo method in methods)
        {
            Console.Write($"{method.ReturnType} {method.Name} ");
            ParameterInfo[] parameters = method.GetParameters();

            Console.Write("(");
            Console.Write(string.Join(", ", parameters.Select(p => $"{p.ParameterType} {p.Name}")));
            Console.Write(")");
            
            Console.WriteLine();
        }
    }
}