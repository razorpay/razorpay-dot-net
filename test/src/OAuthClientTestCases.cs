using System;
using NUnit.Framework;
using Razorpay.Api;
using System.Collections.Generic;
using Razorpay.Api.Errors;
using Moq;

namespace RazorpayClientTest
{
    public class OAuthClientTestCases
    {
        private static OAuthTokenClient oAuthTokenClient;
        
        public static void Init()
        {
            oAuthTokenClient = new OAuthTokenClient();
        }
        
        public static void GetAuthUrlTest()
        {
            oAuthTokenClient = new OAuthTokenClient();
            var request = new Dictionary<string, object>
            {
                { "client_id", "7rLhG3dsQqFeAd" },
                { "redirect_uri", "https://example.com/razorpay_callback" },
                { "state", "NOBYtv8r6c75ex6WZ" },
                { "scopes", new List<string> { "read_write" } }
            };

            string expectedAuthURL = "https://auth.razorpay.com/authorize?response_type=code&client_id=8DXCMTshWSWECc&redirect_uri=https:%2F%2Fexample.com%2Frazorpay_callback&scope[]=read_write&state=NOBYtv8r6c75ex6WZ";
            string authURL = oAuthTokenClient.GetAuthUrl(request);
            Assert.AreEqual(expectedAuthURL, authURL);
        }
        
        public static void RequestValidationFailureForGetAuthUrlTest()
        {
            var request = new Dictionary<string, object>
            {
                { "client_id", "7rLhG3dsQqFeAd" },
                { "redirect_uri", "https://example.com/razorpay_callback" },
                { "scopes", new List<object> { "read_write" } }
            };

            Assert.Throws<BadRequestError>(() => oAuthTokenClient.GetAuthUrl(request));
        }
        
        public static void GetAccessTokenTest()
        {
            var mockClient = new Mock<OAuthTokenClient> { CallBase = true };
            var mockEntities = new List<Entity> { new OAuthTokenClient { ["access_token"] = "SAMPLE_ACCESS_TOKEN", ["expires_in"] = 7862400, ["refresh_token"] = "SAMPLE_REFRESH_TOKEN" } };
            mockClient.Setup(x => x.AuthRequest(It.IsAny<string>(), HttpMethod.POST, It.IsAny<Dictionary<string, object>>()))
                .Returns(mockEntities);

            var data = new Dictionary<string, object>
            {
                { "client_id", "7rLhG3dsQqFeAd" },
                { "client_secret", "AESSECRETKEY" },
                { "redirect_uri", "http://example.com/razorpay_callback" },
                { "code", "def50200d844dc80cc44dce2c665d07a374d76802" },
                { "mode", "test" }
            };

            var result = mockClient.Object.GetAccessToken(data);

            Assert.AreEqual(mockEntities[0], result);
            Assert.NotNull(result);
        }
        
        public static void RequestValidationFailureForGetAccessTokenTest()
        {
            var request = new Dictionary<string, object>
            {
                { "client_id", "7rLhG3dsQqFeAd" },
                { "client_secret", "AESSECRETKEY" },
                { "redirect_uri", "http://example.com/razorpay_callback" },
                { "code", "def50200d844dc80cc44dce2c665d07a374d76802" },
                { "mode", "test1" }
            };

            Assert.Throws<BadRequestError>(() => oAuthTokenClient.GetAccessToken(request));
        }
        
        public static void RefreshTokenTest()
        {
            var mockClient = new Mock<OAuthTokenClient> { CallBase = true };
            var mockEntities = new List<Entity> { new OAuthTokenClient { ["access_token"] = "SAMPLE_ACCESS_TOKEN", ["expires_in"] = 7862400, ["refresh_token"] = "SAMPLE_REFRESH_TOKEN" } };
            mockClient.Setup(x => x.AuthRequest(It.IsAny<string>(), HttpMethod.POST, It.IsAny<Dictionary<string, object>>()))
                .Returns(mockEntities);

            var data = new Dictionary<string, object>
            {
                { "client_id", "7rLhG3dsQqFeAd" },
                { "client_secret", "SECRETKEY" },
                { "refresh_token", "REFRESHTOKEN" }
            };

            var result = mockClient.Object.RefreshToken(data);

            Assert.AreEqual(mockEntities[0], result);
            Assert.NotNull(result);
        }
        
        public static void RequestValidationFailureForRefreshTokenTest()
        {
            var request = new Dictionary<string, object>
            {
                { "client_id", "7rLhG3dsQqFeAd" },
                { "client_secret", "AESSECRETKEY" }
            };

            Assert.Throws<BadRequestError>(() => oAuthTokenClient.RefreshToken(request));
        }
        
        public static void RevokeTokenTest()
        {
            var mockClient = new Mock<OAuthTokenClient> { CallBase = true };
            var mockEntities = new List<Entity> { new OAuthTokenClient { ["message"] = "Token Revoked" } };
            mockClient.Setup(x => x.AuthRequest(It.IsAny<string>(), HttpMethod.POST, It.IsAny<Dictionary<string, object>>()))
                .Returns(mockEntities);

            var data = new Dictionary<string, object>
            {
                { "client_id", "7rLhG3dsQqFeAd" },
                { "client_secret", "SECRETKEY" },
                { "token", "ACCESSTOKEN" },
                { "token_type_hint", "access_token" }
            };

            var result = mockClient.Object.RevokeToken(data);

            Assert.AreEqual(mockEntities[0], result);
            Assert.NotNull(result);
        }
        
        public static void RequestValidationFailureForRevokeTokenTest()
        {
            var request = new Dictionary<string, object>
            {
                { "client_id", "7rLhG3dsQqFeAd" },
                { "client_secret", "AESSECRETKEY" },
                { "token_type_hint", "access_token" }
            };

            Assert.Throws<BadRequestError>(() => oAuthTokenClient.RevokeToken(request));
        }
    }
}