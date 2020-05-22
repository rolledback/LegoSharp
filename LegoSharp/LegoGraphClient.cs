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
            ILegoRequest request = LegoGraphClient._makeGraphQueryRequest(query, Constants.pickABrickUri);
            var response = await request.getResponseAsync();
            var body = await response.Content.ReadAsStringAsync();
            return LegoGraphClient._parseElementsFromGraphQueryResponse(body);
        }

        public bool isAuthenticated()
        {
            return !string.IsNullOrEmpty(this._authToken);
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

        private static ILegoRequest _makeGraphQueryRequest(PickABrickQuery query, string resource)
        {
            LegoRequest request = new LegoRequest(Constants.baseLegoUri);
            request.resource = resource;
            request.requestType = LegoRequest.RequestType.Post;
            request.payloadType = LegoRequest.PayloadType.Json;

            var payloadObj = new
            {
                operationName = "PickABrickQuery",
                variables = new
                {
                    page = 1,
                    perPage = 12,
                    query = query.query,
                    filters = query.getFiltersInQL()
                },
                query = Constants.pickABrickQuery
            };

            request.payload = JsonSerializer.Serialize(payloadObj);
            request.headers["x-locale"] = "en-US";

            return request;
        }

        private static string _parseAuthTokenFromAuthenticateResponse(string authenticateResponseBody)
        {
            JsonElement parsedResponse = JsonSerializer.Deserialize<JsonElement>(authenticateResponseBody);
            JsonElement data = parsedResponse.GetProperty("data");
            return data.GetProperty("login").GetString();
        }

        private static IEnumerable<Brick> _parseElementsFromGraphQueryResponse(string graphQueryResponseBody)
        {
            JsonElement parsedResponse = JsonSerializer.Deserialize<JsonElement>(graphQueryResponseBody);
            JsonElement data = parsedResponse.GetProperty("data");
            JsonElement elements = data.GetProperty("elements");
            JsonElement results = elements.GetProperty("results");
            
            var enumerator = results.EnumerateArray();
            var retValue = new List<Brick>();

            while (enumerator.MoveNext())
            {
                JsonElement brickEl = enumerator.Current;
                retValue.Add(JsonSerializer.Deserialize<Brick>(brickEl.ToString()));
            }

            return retValue;
        }
    }
}
