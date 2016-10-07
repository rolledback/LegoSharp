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
                LegoRequest request = (LegoRequest)makeGetBrickRequest(accessToken);
                request.uri = Constants.getBrickUri + "&element_id=" + elementId;

                return request;
            }

            public ILegoRequest makeBrickByDesignIdRequest(string designId, string accessToken)
            {
                LegoRequest request = (LegoRequest)makeGetBrickRequest(accessToken);
                request.uri = Constants.getBrickUri + "&design_id=" + designId;

                return request;
            }

            private ILegoRequest makeGetBrickRequest(string accessToken)
            {
                LegoRequest request = new LegoRequest();
                request.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                request.type = RequestType.Get;

                return request;
            }

            public ILegoRequest makeIntialAccessRequest()
            {
                LegoRequest request = new LegoRequest();
                request.uri = Constants.oAuthUri;
                request.payload = new object();
                request.type = RequestType.Post;

                return request;
            }

            public ILegoRequest makeRefreshAccessRequest(AuthTokens expiredTokens)
            {
                LegoRequest request = new LegoRequest();
                request.uri = Constants.oAuthUri;
                request.payload = expiredTokens;
                request.type = RequestType.Post;

                return request;
            }
        }

        private HttpClient httpClient;
        private string uri;
        private object payload;
        private RequestType type;

        private LegoRequest()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constants.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpResponseMessage getResponse()
        {
            HttpResponseMessage response = null;
            
            if (type == RequestType.Get)
            {
                response = httpClient.GetAsync(uri).Result;
            }
            else if (type == RequestType.Post)
            {
                response = httpClient.PostAsJsonAsync(uri, new object()).Result;
            }

            return response;
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
