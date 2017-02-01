using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LegoSharp
{
    internal class LegoRequest : ILegoRequest
    {
        public class LegoRequestFactory : ILegoRequestFactory
        {
            private LegoSession legoSession;

            public LegoRequestFactory(LegoSession session)
            {
                legoSession = session;
            }

            public ILegoRequest makeBrickByElementIdRequest(string elementId, string accessToken)
            {
                LegoRequest request = new LegoRequest(Constants.baseShopUri);
                request.parameters["element_id"] = elementId;

                request.uri = Constants.elementsUri;
                request.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                request.requestType = RequestType.Get;

                return request;
            }

            public ILegoRequest makeBrickSearchRequest(IBrickSearch brickSearch, string accessToken, int limit = 10)
            {
                LegoRequest request = new LegoRequest(Constants.baseShopUri);

                request.parameters["design_id"] = brickSearch.getDesignId();
                request.parameters["exact_color"] = Utilities.convertExactColorsToId(brickSearch.getExactColor());
                request.parameters["brick_name"] = brickSearch.getName();
                request.parameters["categories"] = Utilities.convertCategoriesToIds(brickSearch.getCategories());
                request.parameters["color_families"] = Utilities.convertColorFamiliesToIds(brickSearch.getColorFamilies());
                request.parameters["limit"] = limit.ToString();

                request.uri = Constants.elementsUri;
                request.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                request.requestType = RequestType.Get;

                return request;
            }

            public ILegoRequest makeIntialAccessRequest()
            {
                LegoRequest request = new LegoRequest(Constants.baseShopUri, legoSession.getCookies());
                request.uri = Constants.oAuthUri;
                request.requestType = RequestType.Post;

                return request;
            }

            public ILegoRequest makeRefreshAccessRequest(string refreshToken)
            {
                LegoRequest request = new LegoRequest(Constants.baseShopUri, legoSession.getCookies());
                request.uri = Constants.oAuthUri;
                request.requestType = RequestType.Post;
                request.payloadType = PayloadType.Json;
                request.payload = "{\"refreshToken\":\"" + refreshToken + "\"}";

                return request;
            }

            public ILegoRequest makeGetBasketRequest(string accessToken)
            {
                LegoRequest request = new LegoRequest(Constants.baseShopUri, legoSession.getCookies());
                request.uri = Constants.baskedUri;
                request.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                request.requestType = RequestType.Get;

                return request;
            }

            public ILegoRequest makeGetCurrentShopperRequest(string accessToken)
            {
                LegoRequest request = new LegoRequest(Constants.baseShopUri, legoSession.getCookies());
                request.uri = Constants.shopMeUri;
                request.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                request.requestType = RequestType.Get;

                return request;
            }

            public ILegoRequest makeGetCurrentUserRequest()
            {
                LegoRequest request = new LegoRequest(Constants.baseAuthenticationUri, legoSession.getCookies());
                request.uri = string.Format(Constants.currentUserUri, legoSession.getSessionId());
                request.requestType = RequestType.Get;

                return request;
            }

            public ILegoRequest makeAesPairRequest()
            {
                LegoRequest request = new LegoRequest(Constants.baseAuthenticationUri, legoSession.getCookies());
                if (legoSession.hasSessionGuid())
                {
                    request.uri = string.Format(Constants.aesPairUri, legoSession.getSessionId());
                }
                else
                {
                    request.uri = string.Format(Constants.aesPairUri, Constants.defaultSessionId);
                }
                request.requestType = RequestType.Get;

                return request;
            }

            public ILegoRequest getLoginCookieSettings()
            {
                return makeAesPairRequest();
            }

            public ILegoRequest makeLoginRequest(string username, string password)
            {
                LegoRequest request = new LegoRequest(Constants.baseAuthenticationUri, legoSession.getCookies());
                request.uri = Constants.loginUri;
                request.requestType = RequestType.Post;
                request.payloadType = PayloadType.WebForm;
                request.payload = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("rememberMe", "false"),
                    new KeyValuePair<string, string>("returnUrl", "https://www.lego.com/en-us"),
                    new KeyValuePair<string, string>("experience", "LegoCom"),
                    new KeyValuePair<string, string>("oauthProvider", ""),
                    new KeyValuePair<string, string>("oauthAccessToken", ""),
                    new KeyValuePair<string, string>("context", "modal"),
                    new KeyValuePair<string, string>("appcontext", "false"),
                    new KeyValuePair<string, string>("async", "false")
                });

                return request;
            }
        }

        private HttpClient httpClient;
        private string baseAddress;
        private string uri;
        private object payload;
        private RequestType requestType;
        private PayloadType payloadType;
        private Dictionary<string, string> parameters;

        private LegoRequest(string baseAddress, CookieContainer cookies = null)
        {
            if (cookies != null)
            {
                httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookies });
            }
            else
            {
                httpClient = new HttpClient();
            }

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.baseAddress = baseAddress;
            parameters = new Dictionary<string, string>();
        }

        public HttpResponseMessage getResponse()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.RequestUri = new Uri(this.buildFullUri());

            if (requestType == RequestType.Get)
            {
                requestMessage.Method = HttpMethod.Get;
            }
            else if (requestType == RequestType.Post)
            {
                requestMessage.Method = HttpMethod.Post;
                if (payloadType == PayloadType.Json)
                {
                    if (payload == null)
                    {
                        payload = "";
                    }
                    requestMessage.Content = new StringContent(payload.ToString(), Encoding.UTF8, "application/json");
                }
                else
                {
                    requestMessage.Content = (FormUrlEncodedContent)payload;
                }
            }

            return httpClient.SendAsync(requestMessage).Result;
        }

        public void addParameters(Dictionary<string, string> newArgs)
        {
            foreach (string argName in newArgs.Keys)
            {
                this.parameters[argName] = newArgs[argName];
            }
        }

        private string buildFullUri()
        {
            string fullUri = baseAddress + uri;

            foreach (string parameterName in parameters.Keys)
            {
                if (!string.IsNullOrEmpty(parameters[parameterName]))
                {
                    fullUri += "&" + parameterName + "=" + parameters[parameterName];
                }
            }

            return fullUri;
        }

        private enum RequestType
        {
            Get,
            Post,
            Put,
            Delete
        };

        private enum PayloadType
        {
            Json,
            WebForm
        };
    }
}
