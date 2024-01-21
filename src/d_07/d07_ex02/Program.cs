using d07_ex02.Models;

namespace d07_ex02;

class Program
{
    static void Main()
    {
        var identityUser = new IdentityUser();
        var consoleSetter = new ConsoleSetter.ConsoleSetter();
        consoleSetter.SetValues(identityUser);
        
        Console.WriteLine("\n");

        var identityRole = new IdentityRole();
        consoleSetter.SetValues(identityRole);
    }
}