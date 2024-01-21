using System;
using System.Reflection;

namespace d07_ex01;

class Program
{
    static void Main()
    {
        var defaultHttpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext();

        Console.WriteLine($"Old Response value: {defaultHttpContext.Response}");

        FieldInfo? responseField = typeof(Microsoft.AspNetCore.Http.DefaultHttpContext).GetField("_response", BindingFlags.NonPublic | BindingFlags.Instance);

        if (responseField != null)
            responseField.SetValue(defaultHttpContext, null);

        Console.WriteLine($"New Response value: {defaultHttpContext.Response}");
    }
}
