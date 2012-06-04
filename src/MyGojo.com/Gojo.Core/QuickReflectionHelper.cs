using System;
using System.Reflection;
using System.Text;

namespace Gojo.Core
{
    public class QuickReflectionHelper
    {
        public static string DisplayObjectProperties(Object o)
        {
            StringBuilder sb = new StringBuilder();
            Type type = o.GetType();
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (!p.CanRead) continue;

                object obj = p.GetValue(o, null);
                if (obj != null)
                {
                    sb.AppendLine(String.Concat("-Property name: ", p.Name));
                    sb.AppendLine(String.Concat("-Property value:", obj.ToString()));
                    sb.AppendLine();
                }
                else sb.AppendLine(String.Concat(p.Name, " # Value is null"));
            }
            return sb.ToString();
        }
 

    }
}
