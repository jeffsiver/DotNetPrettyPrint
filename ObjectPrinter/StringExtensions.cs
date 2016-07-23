using System;

namespace JeffSiver.ObjectPrinter
{
    internal static class StringExtensions
    {
        public static bool CaseInsensitiveContains(this string source, string toCheck)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }
}
