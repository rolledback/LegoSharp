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
    }

    internal interface ILegoRequestFactory
    {
        ILegoRequest makeBrickByElementIdRequest(string elementId, string accessToken);

        ILegoRequest makeBrickByDesignIdRequest(string designId, string accessToken);

        ILegoRequest makeIntialAccessRequest();

        ILegoRequest makeRefreshAccessRequest(AuthTokens expiredTokens);
    }
}
