using System;

namespace MvpBaseGame.Extensions
{
    internal static class ActionExtensions
    {
        public static void SafeInvoke<T>(this Action<T> action, T p1, Action<Exception> onException)
        {
            try
            {
                action.Invoke(p1);
            }
            catch (Exception ex)
            {
                onException?.Invoke(ex);
            }
        }

        public static void SafeInvoke<T, U>(this Action<T, U> action, T p1, U p2, Action<Exception> onException)
        {
            try
            {
                action.Invoke(p1, p2);
            }
            catch (Exception ex)
            {
                onException?.Invoke(ex);
            }
        }

        public static void SafeInvoke<T, U, V>(this Action<T, U, V> action, T p1, U p2, V p3, Action<Exception> onException)
        {
            try
            {
                action.Invoke(p1, p2, p3);
            }
            catch (Exception ex)
            {
                onException?.Invoke(ex);
            }
        }

        public static void SafeInvoke<T, U, V, W>(this Action<T, U, V, W> action, T p1, U p2, V p3, W p4, Action<Exception> onException)
        {
            try
            {
                action.Invoke(p1, p2, p3, p4);
            }
            catch (Exception ex)
            {
                onException?.Invoke(ex);
            }
        }

        public static void SafeInvoke(this Action action, Action<Exception> onException)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                onException?.Invoke(ex);
            }
        }
    }
}