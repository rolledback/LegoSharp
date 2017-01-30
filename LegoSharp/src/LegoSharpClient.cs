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

[assembly: InternalsVisibleTo("LegoAccountTests")]

namespace LegoSharp
{
    public class LegoSharpClient
    {
        internal ILegoRequestFactory requestFactory;
        internal LegoSession legoSession;

        internal LegoSharpClient(LegoSession session)
        {
            legoSession = session;
            requestFactory = new LegoRequest.LegoRequestFactory(legoSession);
        }

        internal bool runRequest(ILegoRequest request)
        {
            return request.getResponse().IsSuccessStatusCode;
        }

        internal T runRequest<T>(ILegoRequest request)
        {
            return runRequestHelper<T>(request);
        }

        internal T runRequestHelper<T>(ILegoRequest request)
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

            return default(T);
        }
    }
}
