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
    internal class LegoRequest : ILegoRequest { 
    
        public string baseUri;
        public string resource;
        public object payload;
        public RequestType requestType;
        public PayloadType payloadType;

        public Dictionary<string, string> parameters;
        public Dictionary<string, string> headers;

        private HttpClient _httpClient;

        public LegoRequest(string baseAddress)
        {
            _httpClient = new HttpClient();

            this.baseUri = baseAddress;
            parameters = new Dictionary<string, string>();
            headers = new Dictionary<string, string>();
        }

        public async Task<HttpResponseMessage> getResponseAsync()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();

            requestMessage.RequestUri = new Uri(this.buildFullUri());
            this._addHeaders();

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

            return await _httpClient.SendAsync(requestMessage);
        }

        private string buildFullUri()
        {
            string fullUri = baseUri + resource;

            foreach (string parameterName in parameters.Keys)
            {
                if (!string.IsNullOrEmpty(parameters[parameterName]))
                {
                    fullUri += "&" + parameterName + "=" + parameters[parameterName];
                }
            }

            return fullUri;
        }

        private void _addHeaders()
        {
            foreach (string headerName in this.headers.Keys)
            {
               this._httpClient.DefaultRequestHeaders.Add(headerName, this.headers[headerName]);
            }
        }

        public enum RequestType
        {
            Get,
            Post,
            Put,
            Delete
        };

        public enum PayloadType
        {
            Json,
            WebForm
        };
    }
}
