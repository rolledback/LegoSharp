using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Runtime.CompilerServices;

using Newtonsoft.Json;

[assembly: InternalsVisibleTo("LegoSharpTest")]

namespace LegoSharp
{
    public class PickABrickClient: LegoSharpClient
    {
        private ShopAuthTokens tokens;

        public PickABrickClient()
        {
            getInitialAccessToken();
        }

        public Brick getBrickByElementId(string elementId)
        {
            ILegoRequest request = requestFactory.makeBrickByElementIdRequest(elementId, tokens.accessToken);
            return handleSingleBrickRequest(request);
        }

        public List<Brick> searchForBricks(IBrickSearch brickSearch)
        {
            ILegoRequest request = requestFactory.makeBrickSearchRequest(brickSearch, tokens.accessToken);
            return handleMultiBrickRequest(request);
        }

        private void getInitialAccessToken()
        {
            ILegoRequest request = requestFactory.makeIntialAccessRequest();
            tokens = runRequest<ShopAuthTokens>(request);
        }

        private void refreshAccessToken()
        {
            ILegoRequest request = requestFactory.makeRefreshAccessRequest(tokens.refreshToken);
            tokens = runRequest<ShopAuthTokens>(request);
        }

        private Brick handleSingleBrickRequest(ILegoRequest request)
        {
            JsonBrickList requestResult = runRequest<JsonBrickList>(request);
            if (requestResult != null)
            {
                List<Brick> returnList = unwrapJsonBrickList(runRequest<JsonBrickList>(request));
                if (returnList.Count > 0)
                {
                    return returnList[0];
                }
            }
            return null;
        }

        private List<Brick> handleMultiBrickRequest(ILegoRequest request)
        {
            JsonBrickList requestResult = runRequest<JsonBrickList>(request);

            if (requestResult != null)
            {
                int viewAllLimit;
                if ((viewAllLimit = Utilities.resultHasViewAllLink(requestResult)) > -1)
                {
                    request.addParameters(new Dictionary<string, string>() { { "limit", viewAllLimit.ToString() } });
                    requestResult = runRequest<JsonBrickList>(request);
                }

                return unwrapJsonBrickList(runRequest<JsonBrickList>(request));
            }

            return new List<Brick>();
        }

        private new T runRequest<T>(ILegoRequest request)
        {
            return runRequestHelper<T>(request, 10);
        }

        private T runRequestHelper<T>(ILegoRequest request, int retryCount)
        {
            HttpResponseMessage response = request.getResponse();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
                catch (Exception)
                {
                    return default(T);
                }
            }

            if (retryCount > 0)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    refreshAccessToken();
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return default(T);
                }
                return runRequestHelper<T>(request, retryCount - 1);
            }

            return default(T);
        }

        private List<Brick> unwrapJsonBrickList(JsonBrickList brickList)
        {
            return brickList.elements.Select(jsonBrick => new Brick(jsonBrick)).ToList();
        }
    }

    internal class ShopAuthTokens
    {
        [JsonProperty("access_token")]
        public string accessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string refreshToken { get; set; }

        public override string ToString()
        {
            return string.Format("Access token: {0}{1}Refresh token: {2}", accessToken, Environment.NewLine, refreshToken);
        }
    }
}
