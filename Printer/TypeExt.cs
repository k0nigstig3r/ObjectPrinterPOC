namespace Printer;

public static class TypeExt
{
    public static bool IsSimple(this Type type) =>  type.IsPrimitive || type == typeof(string);
}