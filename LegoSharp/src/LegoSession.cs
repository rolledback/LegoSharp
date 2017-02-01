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
        public bool sessionAuthenticated;

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
