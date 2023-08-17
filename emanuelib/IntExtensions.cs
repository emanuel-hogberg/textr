namespace emanuel.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Returns true if a <= i <= b.
        /// </summary>
        /// <returns></returns>
        public static bool Between(this int i, int a, int b)
            => a <= i && i <= b;
    }
}
