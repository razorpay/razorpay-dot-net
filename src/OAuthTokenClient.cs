using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Razorpay.Api
{
    public class OAuthTokenClient : Entity
    {
        private readonly string AUTH_HOSTNAME = "auth.razorpay.com";
        private readonly string CLIENT_ID = "client_id";
        private readonly string CLIENT_SECRET = "client_secret";
        private readonly string GRANT_TYPE = "grant_type";
        private readonly string REFRESH_TOKEN = "refresh_token";
        private readonly string TOKEN = "token";
        private readonly string TOKEN_TYPE_HINT = "token_type_hint";
        private readonly string REDIRECT_URI = "redirect_uri";
        private readonly string SCOPES = "scopes";
        private readonly string STATE = "state";
        private readonly string MODE = "mode";

        private readonly PayloadValidator payloadValidator;

        public OAuthTokenClient()
        {
            this.payloadValidator = new PayloadValidator();
        }

        public string GetAuthUrl(Dictionary<string, object> data)
        {
            ValidateAuthURLRequest(data);

            string clientId = (string)data["client_id"];
            string redirectUri = (string)data["redirect_uri"];
            string state = (string)data["state"];
            string[] scopes = (data["scopes"] as List<object>)
                          ?.OfType<string>()
                          .ToArray();

            string scopesArray = scopes.Length > 0 ?
                "&scope[]=" + string.Join("&scope[]=", scopes) : "";

            string authorizeUrl = "https://"
                                  + AUTH_HOSTNAME
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
            string relativeUrl = "/token";
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (OAuthTokenClient)entities[0];
        }

        public OAuthTokenClient RefreshToken(Dictionary<string, object> data)
        {
            ValidateRefreshTokenRequest(data);
            string relativeUrl = "/token";
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (OAuthTokenClient)entities[0];
        }

        public OAuthTokenClient RevokeToken(Dictionary<string, object> data)
        {
            ValidateRevokeTokenRequest(data);
            string relativeUrl = "/revoke";
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (OAuthTokenClient)entities[0];
        }


        private void ValidateAuthURLRequest(Dictionary<string, object> request)
        {
            payloadValidator.Validate(request, GetValidationsForAuthRequestURL());
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

        private List<ValidationConfig> GetValidationsForAuthRequestURL()
        {
            return new List<ValidationConfig>
            {
                new ValidationConfig(CLIENT_ID, new List<ValidationType> { ValidationType.ID }),
                new ValidationConfig(REDIRECT_URI, new List<ValidationType> { ValidationType.NON_EMPTY_STRING, ValidationType.URL }),
                new ValidationConfig(SCOPES, new List<ValidationType> { ValidationType.NON_NULL }),
                new ValidationConfig(STATE, new List<ValidationType> { ValidationType.NON_EMPTY_STRING })
            };
        }

        private List<ValidationConfig> GetValidationsForAccessTokenRequest()
        {
            return new List<ValidationConfig>
            {
                new ValidationConfig(CLIENT_ID, new List<ValidationType> { ValidationType.ID }),
                new ValidationConfig(CLIENT_SECRET, new List<ValidationType> { ValidationType.NON_EMPTY_STRING }),
                new ValidationConfig(REDIRECT_URI, new List<ValidationType> { ValidationType.NON_EMPTY_STRING, ValidationType.URL }),
                new ValidationConfig(MODE, new List<ValidationType> { ValidationType.NON_EMPTY_STRING })
            };
        }

        private List<ValidationConfig> GetValidationsForRefreshTokenRequest()
        {
            return new List<ValidationConfig>
            {
                new ValidationConfig(CLIENT_ID, new List<ValidationType> { ValidationType.ID }),
                new ValidationConfig(CLIENT_SECRET, new List<ValidationType> { ValidationType.NON_EMPTY_STRING }),
                new ValidationConfig(REFRESH_TOKEN, new List<ValidationType> { ValidationType.NON_EMPTY_STRING })
            };
        }

        private List<ValidationConfig> GetValidationsForRevokeTokenRequest()
        {
            return new List<ValidationConfig>
            {
                new ValidationConfig(CLIENT_ID, new List<ValidationType> { ValidationType.ID }),
                new ValidationConfig(CLIENT_SECRET, new List<ValidationType> { ValidationType.NON_EMPTY_STRING }),
                new ValidationConfig(TOKEN, new List<ValidationType> { ValidationType.NON_EMPTY_STRING }),
                new ValidationConfig(TOKEN_TYPE_HINT, new List<ValidationType> { ValidationType.NON_EMPTY_STRING })
            };
        }
    }
}

