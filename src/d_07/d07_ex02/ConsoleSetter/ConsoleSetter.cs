using d07_ex02.Attributes;

namespace d07_ex02.ConsoleSetter;

using System;
using System.ComponentModel;
using System.Reflection;

public class ConsoleSetter
{
    public void SetValues<T>(T input) where T : class
    {
        Console.WriteLine($"Let's set {typeof(T).Name}!");

        PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<NoDisplayAttribute>() != null)
                continue;
            
            var descriptionAttribute = property.GetCustomAttribute<DescriptionAttribute>();
            var defaultValueAttribute = property.GetCustomAttribute<DefaultValueAttribute>();

            Console.Write($"Set {descriptionAttribute?.Description ?? property.Name}:\n");

            object? defaultValue = defaultValueAttribute?.Value;
            string? userInput = Console.ReadLine();

            object? value = string.IsNullOrEmpty(userInput) ? defaultValue : userInput;

            try
            {
                property.SetValue(input, Convert.ChangeType(value, property.PropertyType));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Whoops! Erorr: {ex.Message}");
                return;
            }
        }

        Console.WriteLine("We've set our instance!");
        Console.WriteLine(input.ToString());
    }
}