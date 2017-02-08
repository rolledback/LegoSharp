using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    public class LegoSession
    {
        private CookieContainer cookies;
        private string sessionGuid;
        private ShopAuthTokens shopAuthTokens;
        internal bool sessionAuthenticated;
        internal bool authenticatedWhenTokensRetrieved;

        public LegoSession()
        {
            cookies = new CookieContainer();
            sessionAuthenticated = false;
        }

        internal void updateSessionId()
        {
            CookieCollection authCookies = cookies.GetCookies(new Uri("http://account.2.lego.com"));
            foreach (Cookie cookie in authCookies)
            {
                if (cookie.Name.Equals("L.S") || cookie.Name.Equals("L.S.1"))
                {
                    if (sessionGuid == null || !sessionGuid.Equals(cookie.Value))
                    {
                        sessionGuid = cookie.Value;
                        return;
                    }
                }
            }
        }

        internal void updateShopAuthTokens(ShopAuthTokens tokens)
        {
            authenticatedWhenTokensRetrieved = sessionAuthenticated;
            shopAuthTokens = tokens;
        }

        internal string getShopAccessToken()
        {
            return shopAuthTokens.accessToken;
        }

        internal string getShopRefreshToken()
        {
            return shopAuthTokens.refreshToken;
        }

        internal bool hasSessionGuid()
        {
            return sessionGuid != null;
        }

        internal CookieContainer getCookies()
        {
            return cookies;
        }

        internal string getSessionId()
        {
            return sessionGuid.ToString();
        }

    }
}
