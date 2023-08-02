using System;

namespace emanuel.Extensions
{
    public static class ObjectExtensions
    {
        public static TResult Forward<T, TResult>(this T t, Func<T, TResult> func)
            => func(t);

        public static T AssignForward<T>(this T t, out T assign)
        {
            assign = t;

            return t;
        }
        public static T AssignForward<T, TForward>(this T t, Func<T, TForward> select, out TForward assign)
        {
            assign = select(t);

            return t;
        }

        public static bool AssignForwardIf<T>(this T t, Func<T, bool> condition, out T assign)
        {
            assign = t;

            if (condition(t))
            {
                return true;
            }

            return false;
        }

        public static T With<T>(this T t, Action<T> action)
        {
            action(t);

            return t;
        }
        public static void DoAs<T>(this object t, Action<T> action)
        {
            action((T)t);
        }
        public static void Do<T>(this T t, Action<T> action)
        {
            action(t);
        }
    }
}
