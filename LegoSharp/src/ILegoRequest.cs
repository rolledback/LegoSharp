using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace LegoSharp
{
    internal interface ILegoRequest
    {
        HttpResponseMessage getResponse();

        void addParameters(Dictionary<string, string> newArgs);
    }

    internal interface ILegoRequestFactory
    {
        ILegoRequest makeBrickByElementIdRequest(string elementId, string accessToken);

        ILegoRequest makeBricksByDesignIdRequest(string designId, string accessToken, int limit = 10);

        ILegoRequest makeBricksByNameRequest(string name, string accessToken, int limit = 10);

        ILegoRequest makeIntialAccessRequest();

        ILegoRequest makeRefreshAccessRequest(AuthTokens expiredTokens);
    }
}
