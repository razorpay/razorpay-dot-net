using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Razorpay.Api
{
    public class OAuthTokenClient : Entity
    {
        private readonly string clientId = "client_id";
        private readonly string clientSecret = "client_secret";
        private readonly string code = "code";
        private readonly string grantType = "grant_type";
        private readonly string refreshToken = "refresh_token";
        private readonly string token = "token";
        private readonly string tokenTypeHint = "token_type_hint";
        private readonly string redirectUri = "redirect_uri";
        private readonly string scopes = "scopes";
        private readonly string state = "state";
        private readonly string mode = "mode";

        private readonly PayloadValidator payloadValidator;

        public OAuthTokenClient()
        {
            payloadValidator = new PayloadValidator();
        }

        public string GetAuthUrl(Dictionary<string, object> data)
        {
            ValidateAuthUrlRequest(data);

            string clientId = (string)data["client_id"];
            string redirectUri = (string)data["redirect_uri"];
            string state = (string)data["state"];
            string[] scopes = (data["scopes"] as List<object>)
                          ?.OfType<string>()
                          .ToArray();

            string scopesArray = scopes.Length > 0 ?
                "&scope[]=" + string.Join("&scope[]=", scopes) : "";

            string authorizeUrl = RazorpayClient.DefaultAuthUrl
                                  + "/authorize"
                                  + "?response_type=code"
                                  + "&client_id=" + clientId
                                  + "&redirect_uri=" + redirectUri
                                  + scopesArray
                                  + "&state=" + state;

            return authorizeUrl;
        }

        public OAuthTokenClient GetAccessToken(Dictionary<string, object> data)
        {
            ValidateAccessTokenRequest(data);
            data.Add(grantType, "authorization_code");
            string relativeUrl = "/token";
            List<Entity> entities = AuthRequest(relativeUrl, HttpMethod.POST, data);
            return (OAuthTokenClient)entities[0];
        }

        public OAuthTokenClient RefreshToken(Dictionary<string, object> data)
        {
            ValidateRefreshTokenRequest(data);
            data.Add(grantType, "refresh_token");
            string relativeUrl = "/token";
            List<Entity> entities = AuthRequest(relativeUrl, HttpMethod.POST, data);
            return (OAuthTokenClient)entities[0];
        }

        public OAuthTokenClient RevokeToken(Dictionary<string, object> data)
        {
            ValidateRevokeTokenRequest(data);
            string relativeUrl = "/revoke";
            List<Entity> entities = AuthRequest(relativeUrl, HttpMethod.POST, data);
            return (OAuthTokenClient)entities[0];
        }

        public virtual List<Entity> AuthRequest(string relativeUrl, HttpMethod verb, Dictionary<string, object> data)
        {
            return Request(relativeUrl, verb, data, "AUTH");
        }

        private void ValidateAuthUrlRequest(Dictionary<string, object> request)
        {
            payloadValidator.Validate(request, GetValidationsForAuthRequestUrl());
        }

        private void ValidateAccessTokenRequest(Dictionary<string, object> request)
        {
            payloadValidator.Validate(request, GetValidationsForAccessTokenRequest());
        }

        private void ValidateRefreshTokenRequest(Dictionary<string, object> request)
        {
            payloadValidator.Validate(request, GetValidationsForRefreshTokenRequest());
        }

        private void ValidateRevokeTokenRequest(Dictionary<string, object> request)
        {
            payloadValidator.Validate(request, GetValidationsForRevokeTokenRequest());
        }

        private List<ValidationConfig> GetValidationsForAuthRequestUrl()
        {
            return new List<ValidationConfig>
            {
                new ValidationConfig(clientId, new List<ValidationType> { ValidationType.ID }),
                new ValidationConfig(redirectUri, new List<ValidationType> { ValidationType.NON_EMPTY_STRING, ValidationType.URL }),
                new ValidationConfig(scopes, new List<ValidationType> { ValidationType.NON_NULL }),
                new ValidationConfig(state, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING })
            };
        }

        private List<ValidationConfig> GetValidationsForAccessTokenRequest()
        {
            return new List<ValidationConfig>
            {
                new ValidationConfig(clientId, new List<ValidationType> { ValidationType.ID }),
                new ValidationConfig(clientSecret, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING }),
                new ValidationConfig(redirectUri, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING, ValidationType.URL }),
                new ValidationConfig(code, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING}),
                new ValidationConfig(mode, new List<ValidationType> { ValidationType.MODE })
            };
        }

        private List<ValidationConfig> GetValidationsForRefreshTokenRequest()
        {
            return new List<ValidationConfig>
            {
                new ValidationConfig(clientId, new List<ValidationType> { ValidationType.ID }),
                new ValidationConfig(clientSecret, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING }),
                new ValidationConfig(refreshToken, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING })
            };
        }

        private List<ValidationConfig> GetValidationsForRevokeTokenRequest()
        {
            return new List<ValidationConfig>
            {
                new ValidationConfig(clientId, new List<ValidationType> { ValidationType.ID }),
                new ValidationConfig(clientSecret, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING }),
                new ValidationConfig(token, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING }),
                new ValidationConfig(tokenTypeHint, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING })
            };
        }
    }
}

