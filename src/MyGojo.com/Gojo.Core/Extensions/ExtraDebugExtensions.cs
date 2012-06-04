using System.Reflection;

namespace Gojo.Core.Extensions
{
    public static class ExtraDebugExtensions
    {
        // Allow any object to display its defining assembly
        public static void DisplayDefiningAssembly(this object obj)
        {
            System.Console.WriteLine("{0} defined in: => {1}\n", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }



    }
}
