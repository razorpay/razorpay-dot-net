using System;

namespace Razorpay.Api.Http
{
    // Certificate DNS name matching per RFC 6125: exact match, or a wildcard
    // covering exactly one left-most label ("*.razorpay.com" matches
    // "api.razorpay.com" but not "razorpay.com" or "a.b.razorpay.com").
    internal static class HostnameMatcher
    {
        public static bool Matches(string pattern, string host)
        {
            if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(host))
            {
                return false;
            }

            pattern = pattern.TrimEnd('.');
            host = host.TrimEnd('.');

            if (!pattern.StartsWith("*.", StringComparison.Ordinal))
            {
                return pattern.IndexOf('*') < 0 && string.Equals(pattern, host, StringComparison.OrdinalIgnoreCase);
            }

            // ".razorpay.com": no further wildcards, and at least two labels after the wildcard.
            string suffix = pattern.Substring(1);
            if (suffix.IndexOf('*') >= 0 || suffix.Split('.').Length < 3)
            {
                return false;
            }

            int firstDot = host.IndexOf('.');
            return firstDot > 0 && string.Equals(host.Substring(firstDot), suffix, StringComparison.OrdinalIgnoreCase);
        }
    }
}
