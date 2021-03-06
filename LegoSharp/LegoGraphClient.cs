﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
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

        public async Task<PickABrickResult> pickABrick(PickABrickQuery query)
        {
            return await this.queryGraph(query);
        }

        public async Task<dynamic> productSearch(ProductSearchQuery query)
        {
            return await this.queryGraph(query);
        }

        public async Task<ResultT> queryGraph<ResultT>(IGraphQuery<ResultT> query)
        {
            if (this._needsReauthentication())
            {
                await this.authenticateAsync();
            }

            int retryCount = 10;
            HttpResponseMessage response = null;

            while (response == null)
            {
                ILegoRequest request = LegoGraphClient._makeGraphQueryRequest(query, this._authToken);
                response = await request.getResponseAsync();
                var statusCode = (int)response.StatusCode;
                if (statusCode > 299 || statusCode < 200)
                {
                    var errorMessage = $"Error while querying graph.\n" +
                        $"Retry count: {retryCount}\n" +
                        $"Request: {request}\n" +
                        $"Response status code: {statusCode}" +
                        $"Response body: {await response.Content.ReadAsStringAsync()}";
                    if (retryCount == 0)
                    {
                        throw new Exception(errorMessage);
                    }
                    else
                    {
                        Console.WriteLine(errorMessage);
                        retryCount--;
                        response = null;
                        await Task.Delay(1000);
                    }
                }
            }

            var body = await response.Content.ReadAsStringAsync();
            return query.parseResponse(body);
        }


        private bool _needsReauthentication()
        {
            if (string.IsNullOrEmpty(this._authToken))
            {
                return true;
            }
            else
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(this._authToken);
                var validTo = jsonToken.ValidTo;
                var nowMinusThirty = DateTime.Now.AddMinutes(-30);
                return validTo < nowMinusThirty; ;
            }
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
            request.headers["x-lego-request-id"] = LegoGraphClient._generateRequestId();
            request.headers["authorization"] = authToken;

            return request;
        }

        private static string _parseAuthTokenFromAuthenticateResponse(string authenticateResponseBody)
        {
            JsonElement parsedResponse = JsonSerializer.Deserialize<JsonElement>(authenticateResponseBody);
            JsonElement data = parsedResponse.GetProperty("data");
            return data.GetProperty("login").GetString();
        }

        private static string _generateRequestId()
        {
            string id = "";
            string[] hex = new string[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0a", "0b", "0c", "0d", "0e", "0f", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "1a", "1b", "1c", "1d", "1e", "1f", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "2a", "2b", "2c", "2d", "2e", "2f", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "3a", "3b", "3c", "3d", "3e", "3f", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "4a", "4b", "4c", "4d", "4e", "4f", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "5a", "5b", "5c", "5d", "5e", "5f", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "6a", "6b", "6c", "6d", "6e", "6f", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "7a", "7b", "7c", "7d", "7e", "7f", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "8a", "8b", "8c", "8d", "8e", "8f", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "9a", "9b", "9c", "9d", "9e", "9f", "a0", "a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8", "a9", "aa", "ab", "ac", "ad", "ae", "af", "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7", "b8", "b9", "ba", "bb", "bc", "bd", "be", "bf", "c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "ca", "cb", "cc", "cd", "ce", "cf", "d0", "d1", "d2", "d3", "d4", "d5", "d6", "d7", "d8", "d9", "da", "db", "dc", "dd", "de", "df", "e0", "e1", "e2", "e3", "e4", "e5", "e6", "e7", "e8", "e9", "ea", "eb", "ec", "ed", "ee", "ef", "f0", "f1", "f2", "f3", "f4", "f5", "f6", "f7", "f8", "f9", "fa", "fb", "fc", "fd", "fe", "ff" };

            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                int idx = rnd.Next(0, 256);
                id += hex[idx];

                if (i == 3 || i == 5 || i == 7 || i == 9)
                {
                    id += "-";
                }
            }

            id += "-c";

            return id;
        }
    }
}
