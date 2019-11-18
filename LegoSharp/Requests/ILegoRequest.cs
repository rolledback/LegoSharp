using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace LegoSharp
{
    internal interface ILegoRequest
    {
        Task<HttpResponseMessage> getResponseAsync();
    }
}
