using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Service.Services
{
    public static class TokenServiceSettings
    {
        public static string Secret = "fedaf7d8863b48e197b9287d492b708e";
        public static int Expiration = 2;
        public static string myIssuer = "http://mysite.com";
        public static string myAudience = "http://myaudience.com";

    }
}

