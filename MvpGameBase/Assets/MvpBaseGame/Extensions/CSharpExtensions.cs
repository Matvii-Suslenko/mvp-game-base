using System.Collections.Generic;
using System.Linq;
using System;

namespace MvpBaseGame.Extensions
{
    public static class CSharpExtensions
    {
        public static IEnumerable<T> GetEnumValues<T>() where T : struct
        {
            // Can't use type constraints on value types, so have to do check like this
            if (typeof(T).BaseType != typeof(Enum))
            {
                throw new ArgumentException("T must be of type System.Enum");
            }

            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach(T item in enumeration)
            {
                action(item);
            }
        }
    }
}
