using System;
using System.Collections.Generic;
using System.Linq;

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
            payloadValidator.Validate(data, GetValidationsForAuthRequestUrl());

            string clientId = (string)data["client_id"];
            string redirectUri = (string)data["redirect_uri"];
            string state = (string)data["state"];
            string[] scopes = (data["scopes"] as List<string>)
                          ?.OfType<string>()
                          .ToArray();
            
            var uriBuilder = new UriBuilder(RazorpayClient.DefaultAuthUrl);
            uriBuilder.Path += "authorize";
            
            var queryParams = new List<string>();
            queryParams.Add($"response_type=code");
            queryParams.Add($"client_id={Uri.EscapeDataString(clientId)}");
            queryParams.Add($"redirect_uri={Uri.EscapeDataString(redirectUri)}");
            if (scopes != null && scopes.Length > 0)
            {
                queryParams.Add($"scope[]={string.Join("&scope[]=", scopes.Select(Uri.EscapeDataString))}");
            }
            queryParams.Add($"state={Uri.EscapeDataString(state)}");

            if (data.ContainsKey("onboarding_signature"))
            {
                string onboardingSignature = (string)data["onboarding_signature"];
                queryParams.Add( $"onboarding_signature={Uri.EscapeDataString(onboardingSignature)}");
            }
    
            uriBuilder.Query = string.Join("&", queryParams);

            return uriBuilder.Uri.ToString();
        }

        public OAuthTokenClient GetAccessToken(Dictionary<string, object> data)
        {
            payloadValidator.Validate(data, GetValidationsForAccessTokenRequest());
            string relativeUrl = "/token";
            List<Entity> entities = AuthRequest(relativeUrl, HttpMethod.POST, data);
            return (OAuthTokenClient)entities[0];
        }

        public OAuthTokenClient RefreshToken(Dictionary<string, object> data)
        {
            data.Add(grantType, "refresh_token");
            payloadValidator.Validate(data, GetValidationsForRefreshTokenRequest());
            string relativeUrl = "/token";
            List<Entity> entities = AuthRequest(relativeUrl, HttpMethod.POST, data);
            return (OAuthTokenClient)entities[0];
        }

        public OAuthTokenClient RevokeToken(Dictionary<string, object> data)
        {
            payloadValidator.Validate(data, GetValidationsForRevokeTokenRequest());
            string relativeUrl = "/revoke";
            List<Entity> entities = AuthRequest(relativeUrl, HttpMethod.POST, data);
            return (OAuthTokenClient)entities[0];
        }

        public virtual List<Entity> AuthRequest(string relativeUrl, HttpMethod verb, Dictionary<string, object> data)
        {
            return Request(relativeUrl, verb, data, "AUTH");
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
                new ValidationConfig(redirectUri, new List<ValidationType> { ValidationType.NON_EMPTY_STRING, ValidationType.URL }),
                new ValidationConfig(code, new List<ValidationType> { ValidationType.NON_EMPTY_STRING}),
                new ValidationConfig(mode, new List<ValidationType> { ValidationType.MODE }),
                new ValidationConfig(grantType, new List<ValidationType> { ValidationType.TOKEN_GRANT })
            };
        }

        private List<ValidationConfig> GetValidationsForRefreshTokenRequest()
        {
            return new List<ValidationConfig>
            {
                new ValidationConfig(clientId, new List<ValidationType> { ValidationType.ID }),
                new ValidationConfig(clientSecret, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING }),
                new ValidationConfig(refreshToken, new List<ValidationType> { ValidationType.NON_NULL, ValidationType.NON_EMPTY_STRING }),
                new ValidationConfig(grantType, new List<ValidationType> { ValidationType.TOKEN_GRANT })
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

