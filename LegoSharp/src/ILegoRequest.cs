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
        HttpResponseMessage getResponse();

        void addParameters(Dictionary<string, string> newArgs);
    }

    internal interface ILegoRequestFactory
    {
        ILegoRequest makeBrickByElementIdRequest(string elementId, string accessToken);

        ILegoRequest makeBrickSearchRequest(IBrickSearch brickSearch, string accessToken, int limit = 10);

        ILegoRequest makeIntialAccessRequest();

        ILegoRequest makeRefreshAccessRequest(string refreshToken);

        ILegoRequest makeGetBasketRequest(string accessToken);

        ILegoRequest makeGetCurrentShopperRequest(string accessToken);

        ILegoRequest getLoginCookieSettings();

        ILegoRequest makeAesPairRequest();

        ILegoRequest makeLoginRequest(string username, string password);

        ILegoRequest makeGetCurrentUserRequest();
    }
}
