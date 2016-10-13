using System;
using System.Collections.Generic;
using System.Linq;
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
            public ILegoRequest makeBrickByElementIdRequest(string elementId, string accessToken)
            {
                LegoRequest request = new LegoRequest();
                request.parameters["element_id"] = elementId;

                request.baseUri = Constants.elementsUri;
                request.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                request.type = RequestType.Get;

                return request;
            }

            public ILegoRequest makeBrickSearchRequest(IBrickSearch brickSearch, string accessToken, int limit = 10)
            {
                LegoRequest request = new LegoRequest();

                request.parameters["design_id"] = brickSearch.getDesignId();
                request.parameters["exact_color"] = Utilities.exactColorToString(brickSearch.getExactColor());
                request.parameters["brick_name"] = brickSearch.getName();
                request.parameters["categories"] = Utilities.categoryListToString(brickSearch.getCategories());
                request.parameters["limit"] = limit.ToString();

                request.baseUri = Constants.elementsUri;
                request.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                request.type = RequestType.Get;

                return request;
            }

            public ILegoRequest makeIntialAccessRequest()
            {
                LegoRequest request = new LegoRequest();
                request.baseUri = Constants.oAuthUri;
                request.payload = new object();
                request.type = RequestType.Post;

                return request;
            }

            public ILegoRequest makeRefreshAccessRequest(string refreshToken)
            {
                LegoRequest request = new LegoRequest();
                request.baseUri = Constants.oAuthUri;
                request.payload = "{\"refreshToken\":\"" + refreshToken + "\"}";
                request.type = RequestType.Post;

                return request;
            }
        }

        private HttpClient httpClient;
        private string baseUri;
        private object payload;
        private RequestType type;
        private Dictionary<string, string> parameters;

        private LegoRequest()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constants.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            parameters = new Dictionary<string, string>();
        }

        public HttpResponseMessage getResponse()
        {
            HttpResponseMessage response = null;
            
            if (type == RequestType.Get)
            {
                response = httpClient.GetAsync(this.buildUri()).Result;
            }
            else if (type == RequestType.Post)
            {
                response = httpClient.PostAsJsonAsync(this.buildUri(), payload).Result;
            }

            return response;
        }

        public void addParameters(Dictionary<string, string> newArgs)
        {
            foreach(string argName in newArgs.Keys)
            {
                this.parameters[argName] = newArgs[argName];
            }
        }

        private string buildUri()
        {
            string fullUri = this.baseUri;

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
    }
}
