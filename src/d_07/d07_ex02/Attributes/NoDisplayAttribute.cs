namespace d07_ex02.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class NoDisplayAttribute : Attribute
{
}