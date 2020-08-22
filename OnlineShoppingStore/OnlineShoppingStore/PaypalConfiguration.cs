using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;


        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "ASxHFAyLzZSYm5qVgL4I9UvdU0bYSk9zkGXRPy6mtRlkhUNv009yAmP7vW9lk4ScYpl9vMT7Mjou6kTb";
            clientSecret = "EKouSso_lRWaZPa_QyzslRYyrdoMFQTrOzfo1kduei_jf8Ln-UYETc5tOLnryo18Tmx572Gq9c20FJTU";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}