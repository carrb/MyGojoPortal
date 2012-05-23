using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gojo.Core.Extensions
{
    public static class FunctionalExtensions
    {

        public static void ApplyTo<T>(this T arg, params Action<T>[] actions) {
            Array.ForEach(actions, action => action(arg));
        }

    }
}
