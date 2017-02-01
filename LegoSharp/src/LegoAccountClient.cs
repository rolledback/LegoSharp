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
        public LegoAccountClient(LegoSession session): base(session)
        {
        }

        public AuthenticationResult authenticate(string username, string password)
        {
            ILegoRequest loginCookieRequest = requestFactory.getLoginCookieSettings();
            if (runRequest(loginCookieRequest))
            {
                legoSession.updateSessionId();

                if (legoSession.hasSessionGuid())
                {
                    ILegoRequest aesPairRequest = requestFactory.makeAesPairRequest();
                    AesPair aesPair = runRequest<AesPair>(aesPairRequest);

                    string encrpytedPassword = encrpytPassword(password, aesPair);
                    ILegoRequest loginRequest = requestFactory.makeLoginRequest(username, encrpytedPassword);
                    AuthenticationResponse authenticationResponse = runRequest<AuthenticationResponse>(loginRequest);

                    if (authenticationResponse.success)
                    {
                        legoSession.updateSessionId();
                        legoSession.sessionAuthenticated = true;
                        return AuthenticationResult.Success;
                    }
                    else
                    {
                        return convertErrorNumberToResult(authenticationResponse.errorNum);
                    }

                }
               
            }
            return AuthenticationResult.Failure;
        }

        public LegoAccount getCurrentUser()
        {
            ILegoRequest currentUserRequest = requestFactory.makeGetCurrentUserRequest();
            return runRequest<CurrentUserResult>(currentUserRequest).data;
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

        private AuthenticationResult convertErrorNumberToResult(int errorNum)
        {
            switch(errorNum)
            {
                case 2:
                case 3:
                case 7:
                case 149:
                    return AuthenticationResult.InvalidUsernameOrPassowrd;
                case 4:
                    return AuthenticationResult.UnactivatedUsername;
                case 5:
                    return AuthenticationResult.AccountLocked;
                case 6:
                    return AuthenticationResult.AccountDisabled;
                case 8:
                    return AuthenticationResult.NeedToChooseUsername;
                case 9:
                    return AuthenticationResult.EmailLoginUnavailable;
                default:
                    return AuthenticationResult.Failure;
            }
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

    internal class AuthenticationResponse
    {
        [JsonProperty("Success")]
        public bool success { get; set; }

        [JsonProperty("ErrorType")]
        public int errorNum { get; set; }
    }

    public enum AuthenticationResult
    {
        Success,
        Failure,
        InvalidUsernameOrPassowrd,
        UnactivatedUsername,
        AccountLocked,
        AccountDisabled,
        NeedToChooseUsername,
        EmailLoginUnavailable
    }
}
