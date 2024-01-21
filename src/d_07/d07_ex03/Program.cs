using d07_ex03.Models;

namespace d07_ex03;

class Program
{
    static void Main()
    {
        var user1 = TypeFactory.CreateWithConstructor<IdentityUser>();
        var user2 = TypeFactory.CreateWithConstructor<IdentityUser>();

        Console.WriteLine(typeof(IdentityUser).FullName);
        Console.WriteLine(user1 == user2 ? "user1 == user2" : "user1 != user2");

        var role1 = TypeFactory.CreateWithActivator<IdentityRole>();
        var role2 = TypeFactory.CreateWithActivator<IdentityRole>();

        Console.WriteLine(typeof(IdentityRole).FullName);
        Console.WriteLine(role1 == role2 ? "role1 == role2\n" : "role1 != role2\n");
        
        Console.WriteLine(typeof(IdentityUser).FullName);
        Console.Write("Set name:\n");
        string? userName = Console.ReadLine();
        var activatedUser = TypeFactory.CreateWithParameters<IdentityUser>(userName ?? "");
        
        Console.WriteLine($"Username set: {activatedUser?.UserName ?? "null"}");
    }
}
