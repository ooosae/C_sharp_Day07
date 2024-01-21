using System.ComponentModel;

namespace d07_ex03.Models;

public class IdentityRole
{
    public IdentityRole() {}
    
    [DefaultValue("User")]
    public string Name { get; set; }
    
    [DefaultValue("Default role description")]
    public string Description { get; set; }

    public override string ToString()
        => $"Role: {Name}, {Description}";
}
