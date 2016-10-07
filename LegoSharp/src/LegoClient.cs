using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

using Newtonsoft.Json;

namespace LegoSharp
{
    public class LegoClient
    {
        private AuthTokens tokens;
        private ILegoRequestFactory requestFactory;

        public LegoClient() {
            requestFactory = new LegoRequest.LegoRequestFactory();
            getInitialAccessToken();
        }

        private void getInitialAccessToken()
        {
            ILegoRequest request = requestFactory.makeIntialAccessRequest();
            tokens = runRequest<AuthTokens>(request);
        }

        private void refreshAccessToken()
        {
            ILegoRequest request = requestFactory.makeRefreshAccessRequest(tokens);
            tokens = runRequest<AuthTokens>(request);
        }

        public Brick getBrickByElementId(string elementId)
        {
            ILegoRequest request = requestFactory.makeBrickByElementIdRequest(elementId, tokens.accessToken);
            List<Brick> result = unwrapJsonBrickList(runRequest<JsonBrickList>(request));
            if (result.Count > 0)
            {
                return result[0];
            }
            else
            {
                return null;
            }
        }

        public List<Brick> getBricksByDesignId(string designId)
        {
            ILegoRequest request = requestFactory.makeBrickByDesignIdRequest(designId, tokens.accessToken);
            return unwrapJsonBrickList(runRequest<JsonBrickList>(request));
        }

        private T runRequest<T>(ILegoRequest request)
        {
            return runRequestHelper<T>(request, 10);
        }

        private T runRequestHelper<T>(ILegoRequest request, int retryCount)
        {
            HttpResponseMessage response = request.getResponse();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                refreshAccessToken();
            }

            if (retryCount > 0)
            {
                return runRequestHelper<T>(request, retryCount - 1);
            }

            return default(T);
        }

        private List<Brick> unwrapJsonBrickList(JsonBrickList brickList)
        {
            return brickList.elements.Select(jsonBrick => new Brick(jsonBrick)).ToList();
        }
    }

    internal class AuthTokens
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
