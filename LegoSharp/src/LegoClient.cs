﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;

using Newtonsoft.Json;


[assembly: InternalsVisibleTo("LegoSharpTest")]

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

            JsonBrickList requestResult = runRequest<JsonBrickList>(request);
            if(requestResult != null)
            {
                List<Brick> returnList = unwrapJsonBrickList(runRequest<JsonBrickList>(request));
                if (returnList.Count > 0)
                {
                    return returnList[0];
                }
            }
            return null;
        }

        public List<Brick> getBricksByDesignId(string designId)
        {
            ILegoRequest request = requestFactory.makeBricksByDesignIdRequest(designId, tokens.accessToken);

            JsonBrickList requestResult = runRequest<JsonBrickList>(request);

            if (requestResult != null)
            {
                int viewAllLimit;
                if ((viewAllLimit = resultHasViewAllLink(requestResult)) > -1)
                {
                    request = requestFactory.makeBricksByDesignIdRequest(designId, tokens.accessToken, viewAllLimit);
                    requestResult = runRequest<JsonBrickList>(request);
                }

                return unwrapJsonBrickList(runRequest<JsonBrickList>(request));
            }
            return new List<Brick>();
        }

        public List<Brick> getBricksByName(string name)
        {
            ILegoRequest request = requestFactory.makeBricksByNameRequest(name, tokens.accessToken);

            JsonBrickList requestResult = runRequest<JsonBrickList>(request);

            if (requestResult != null)
            {
                int viewAllLimit;
                if ((viewAllLimit = resultHasViewAllLink(requestResult)) > -1)
                {
                    request = requestFactory.makeBricksByNameRequest(name, tokens.accessToken, viewAllLimit);
                    requestResult = runRequest<JsonBrickList>(request);
                }

                return unwrapJsonBrickList(runRequest<JsonBrickList>(request));
            }

            return null;
        }

        internal int resultHasViewAllLink(JsonBrickList result)
        {
            if (result.links.ContainsKey("view_all"))
            {
                Uri viewAllUri = new Uri(Constants.baseAddress + result.links["view_all"]["href"]);
                int neededLimit = int.Parse(HttpUtility.ParseQueryString(viewAllUri.Query).Get("limit"));
                return neededLimit;
            }
            else
            {
                return -1;
            }
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
