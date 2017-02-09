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
        ILegoRequest makeBrickByElementIdRequest(string elementId);

        ILegoRequest makeBrickSearchRequest(IBrickSearch brickSearch, int limit = 10);

        ILegoRequest makeProductSearchRequest(IProductSearch productSearch);

        ILegoRequest makeIntialAccessRequest();

        ILegoRequest makeRefreshAccessRequest();

        ILegoRequest makeGetBasketRequest();

        ILegoRequest makeGetWishlistRequest();

        ILegoRequest makeGetCurrentShopperRequest();

        ILegoRequest getLoginCookieSettings();

        ILegoRequest makeAesPairRequest();

        ILegoRequest makeLoginRequest(string username, string password);

        ILegoRequest makeGetCurrentUserRequest();
    }
}
