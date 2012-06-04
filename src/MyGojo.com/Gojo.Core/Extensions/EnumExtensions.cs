using System;
using System.Linq;
using System.Text;

namespace Gojo.Core.Extensions
{
    public static class EnumExtensions
    {
        public static T Append<T>(this Enum type, T value)
        {
            return (T)(object)(((int)(object)type | (int)(object)value));
        }

        public static T Remove<T>(this Enum type, T value)
        {
            return (T)(object)(((int)(object)type & ~(int)(object)value));
        }

        public static bool Has<T>(this Enum type, T value)
        {
            return (((int)(object)type & (int)(object)value) == (int)(object)value);
        }
    }
}
