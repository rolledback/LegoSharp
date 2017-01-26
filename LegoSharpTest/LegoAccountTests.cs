using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LegoSharp;

namespace LegoSharpTest
{
    [TestClass]
    public class LegoAccountTests
    {
        string username = PrivateConstants.testUsername;
        string password = PrivateConstants.testPassword;

        [TestMethod]
        public void testLoginFlow()
        {
            LegoAccountClient client = new LegoAccountClient();
            LegoAccount currUser = null;

            if (client.authenticate(username, password))
            {
                currUser = client.getCurrentUser();
            }

            Assert.IsNotNull(currUser);
        }

        [TestMethod]
        public void testEncryption()
        {
            AesPair pair = new AesPair();
            pair.key = "CAE809FEE46E29D7EA7BCBC592D005E2";
            pair.initializationVector = "C80CBC672533C9E0A9814C74C7199621";

            string password = "password";
            LegoAccountClient client = new LegoAccountClient();
            string encryptedPassword = client.encrpytPassword(password, pair);

            Assert.IsTrue(encryptedPassword.Equals("fa799fac0431044d13e3fbdabc009595"));

            pair.key = "5AF22677325457F06481AD04816A8A63";
            pair.initializationVector = "2E3E1C4EA673D33667F2052BB8352349";

            password = "password";
            client = new LegoAccountClient();
            encryptedPassword = client.encrpytPassword(password, pair);

            Assert.IsTrue(encryptedPassword.Equals("ff01e40651841e0b4661bb2dbc115924"));
        }

        [TestMethod]
        public void readmeCode()
        {
            // create an account client
            LegoAccountClient client = new LegoAccountClient();

            // attempt to authenticate using your username and password
            bool authenticationSuccessful = client.authenticate(username, password);

            if (authenticationSuccessful)
            {
                // if the authentication worked, then get the current user
                LegoAccount currUser = client.getCurrentUser();
            }
        }
    }
}
