namespace Infrastructure.Extensions
{
    using System.Collections.Generic;

    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static bool IsNullOrWhitespace(this string str) => string.IsNullOrEmpty(str?.Trim());

        public static string NullIfNullOrEmpty(this string str) => str.IsNullOrEmpty() ? null : str;

        public static string NullIfNullOrWhitespace(this string str) => str.IsNullOrWhitespace() ? null : str;

        public static string Join<T>(this IEnumerable<T> source, string separator = ", ", string defaultResult = "")
        {
            return source is null ? defaultResult : string.Join(separator, source);
        }
    }
}
