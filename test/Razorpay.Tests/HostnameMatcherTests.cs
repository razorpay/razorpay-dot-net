using NUnit.Framework;
using Razorpay.Api.Http;

namespace Razorpay.Tests
{
    public class HostnameMatcherTests
    {
        [TestCase("api.razorpay.com", "api.razorpay.com", true)]
        [TestCase("API.Razorpay.COM", "api.razorpay.com", true)]
        [TestCase("api.razorpay.com.", "api.razorpay.com", true)]
        [TestCase("*.razorpay.com", "api.razorpay.com", true)]
        [TestCase("*.razorpay.com", "razorpay.com", false)]
        [TestCase("*.razorpay.com", "a.b.razorpay.com", false)]
        [TestCase("*.com", "razorpay.com", false)]
        [TestCase("a*.razorpay.com", "api.razorpay.com", false)]
        [TestCase("api.razorpay.com", "api.razorpay.com.evil.io", false)]
        [TestCase("", "api.razorpay.com", false)]
        public void MatchesPerRfc6125(string pattern, string host, bool expected)
        {
            Assert.AreEqual(expected, HostnameMatcher.Matches(pattern, host));
        }
    }
}
