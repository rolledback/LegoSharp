using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Collections;

using Newtonsoft.Json;

namespace LegoSharp
{
    public class LegoAccountClient: LegoSharpClient
    {
        string sessionGuid;
        CookieContainer cookies;

        public LegoAccountClient()
        {
            cookies = new CookieContainer();
        }

        public bool authenticate(string username, string password)
        {
            ILegoRequest loginCookieRequest = requestFactory.getLoginCookieSettings(cookies);
            if (runRequest(loginCookieRequest) && cookies.Capacity > 0)
            {
                setSessionId();

                if (sessionGuid != null)
                {
                    ILegoRequest aesPairRequest = requestFactory.makeAesPairRequest(sessionGuid, cookies);
                    AesPair aesPair = runRequest<AesPair>(aesPairRequest);

                    string encrpytedPassword = encrpytPassword(password, aesPair);
                    ILegoRequest loginRequest = requestFactory.makeLoginRequest(username, encrpytedPassword, cookies);
                    AuthenticationResult authenticationResult = runRequest<AuthenticationResult>(loginRequest);
                    setSessionId();

                    return authenticationResult.success;
                }
               
            }
            return false;
        }

        public LegoAccount getCurrentUser()
        {
            ILegoRequest currentUserRequest = requestFactory.makeGetCurrentUserRequest(sessionGuid, cookies);
            return runRequest<CurrentUserResult>(currentUserRequest).data;
        }

        private void setSessionId()
        {
            CookieCollection authCookies = cookies.GetCookies(new Uri("http://account.2.lego.com"));
            foreach(Cookie cookie in authCookies)
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

        internal string encrpytPassword(string password, AesPair aesPair)
        {
            string encryptedPassword;
            using (Aes myAes = Aes.Create())
            {
                myAes.Key = Utilities.stringToByteArray(aesPair.key);
                myAes.IV = Utilities.stringToByteArray(aesPair.initializationVector);
                byte[] encryptedByteArray = EncryptStringToBytes_Aes(password, myAes.Key, myAes.IV);
                encryptedPassword = BitConverter.ToString(encryptedByteArray);
                encryptedPassword = encryptedPassword.ToLower();
                encryptedPassword = encryptedPassword.Replace("-", "");
            }
            return encryptedPassword;
        }

        private byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.Zeros;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }
    }

    internal class AesPair
    {
        [JsonProperty("I")]
        public string initializationVector { get; set; }
        [JsonProperty("K")]
        public string key { get; set; }

        public override string ToString()
        {
            return string.Format("Initialization vector: {0}{1}Key: {2}", initializationVector, Environment.NewLine, key);
        }
    }

    internal class CurrentUserResult
    {
        [JsonProperty("Data")]
        public LegoAccount data { get; set; }
    }

    public class LegoAccount
    {
        [JsonProperty("UserName")]
        public string username { get; set; }

        [JsonProperty("Age")]
        public int age { get; set; }

        [JsonProperty("Email")]
        public string email { get; set; }

        [JsonProperty("PublicUserId")]
        public string publicUserId { get; set; }

        [JsonProperty("Avatar")]
        public string avatar { get; set; }

        public override string ToString()
        {
            return username;
        }
    }

    internal class AuthenticationResult
    {
        [JsonProperty("Success")]
        public bool success { get; set; }

        [JsonProperty("ErrorType")]
        public int errorNum { get; set; }
    }
}
