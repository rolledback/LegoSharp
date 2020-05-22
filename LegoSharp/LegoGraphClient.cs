using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LegoSharp
{
    public class LegoGraphClient
    {

        private string _authToken;

        public async Task authenticateAsync()
        {
            ILegoRequest authenticateRequest = LegoGraphClient._makeGraphAuthenticateRequest();
            var response = await authenticateRequest.getResponseAsync();
            var body = await response.Content.ReadAsStringAsync();
            this._authToken = LegoGraphClient._parseAuthTokenFromAuthenticateResponse(body);
        }

        public async Task<IEnumerable<Brick>> pickABrick(PickABrickQuery query)
        {
            return await this.queryGraph(query);
        }

        public bool isAuthenticated()
        {
            return !string.IsNullOrEmpty(this._authToken);
        }

        public async Task<ResultT> queryGraph<ResultT>(IGraphQuery<ResultT> query)
        {
            if (!this.isAuthenticated())
            {
                throw new UnauthorizedAccessException();
            }

            ILegoRequest request = LegoGraphClient._makeGraphQueryRequest(query, this._authToken);
            var response = await request.getResponseAsync();
            var body = await response.Content.ReadAsStringAsync();
            return query.parseResponse(body);
        }

        private static ILegoRequest _makeGraphAuthenticateRequest()
        {
            LegoRequest request = new LegoRequest(Constants.baseLegoUri);
            request.resource = Constants.graphAuthUri;
            request.requestType = LegoRequest.RequestType.Post;
            request.payloadType = LegoRequest.PayloadType.Json;

            var payloadObj = new 
            {
                operationName = "Login",
                variables = new
                {
                    forceCtLogin = false
                },
                query = Constants.authenticateQuery
            };

            request.payload = JsonSerializer.Serialize(payloadObj);
            request.headers["x-locale"] = "en-US";

            return request;
        }

        private static ILegoRequest _makeGraphQueryRequest<ResultT>(IGraphQuery<ResultT> query, string authToken)
        {
            LegoRequest request = new LegoRequest(Constants.baseLegoUri);
            request.resource = query.endpoint;
            request.requestType = LegoRequest.RequestType.Post;
            request.payloadType = LegoRequest.PayloadType.Json;

            var payloadObj = query.getPayload();

            request.payload = JsonSerializer.Serialize(payloadObj);
            request.headers["x-locale"] = "en-US";
            request.headers["authorization"] = authToken;

            return request;
        }

        private static string _parseAuthTokenFromAuthenticateResponse(string authenticateResponseBody)
        {
            JsonElement parsedResponse = JsonSerializer.Deserialize<JsonElement>(authenticateResponseBody);
            JsonElement data = parsedResponse.GetProperty("data");
            return data.GetProperty("login").GetString();
        }
    }
}
