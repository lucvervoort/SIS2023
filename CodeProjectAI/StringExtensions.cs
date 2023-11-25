namespace CodeProjectAI
{
    public static class StringExtensions
    {
        /// <summary>
        /// Tests whether a string is equal to another string, case-insensitively
        /// </summary>
        /// <param name="source">This string</param>
        /// <param name="str">The string to test</param>
        /// <returns>True if they are the same (including null == null), false otherwise</returns>
        public static bool EqualsIgnoreCase(this string? source, string? str)
        {
            if (source is null)
                return str is null;

            if (str is null)
                return false;

            return source.Equals(str, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests whether a string contains another string, case-insensitively
        /// </summary>
        /// <param name="source">This string</param>
        /// <param name="str">The string to test</param>
        /// <returns>True if the string contains the given string, false otherwise</returns>
        public static bool ContainsIgnoreCase(this string? source, string? str)
        {
            if (source is null)
                return str is null;

            if (str is null)
                return false;

            return source.Contains(str, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests whether a string starts with another string, case-insensitively
        /// </summary>
        /// <param name="source">This string</param>
        /// <param name="str">The string to test</param>
        /// <returns>True if source starts with str (including null == null), false otherwise</returns>
        public static bool StartsWithIgnoreCase(this string? source, string str)
        {
            if (source is null)
                return str is null;

            if (str is null)
                return false;

            return source.StartsWith(str, StringComparison.OrdinalIgnoreCase);
        }
    }
}
