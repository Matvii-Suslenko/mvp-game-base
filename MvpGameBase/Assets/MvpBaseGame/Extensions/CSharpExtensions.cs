using System.Collections.Generic;
using System;

namespace MvpBaseGame.Extensions
{
    public static class CSharpExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach(T item in enumeration)
            {
                action(item);
            }
        }
    }
}
