using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Tests
{
    public static class Settings
    {
        /// <summary>
        /// The api key used to call the FreshDesk API. See http://freshdesk.com/api#authentication and take a look at the section "Where can I find my API key?".
        /// </summary>
        public const string ApiKey = "YOUR_API-Key";
        /// <summary>
        /// The domain you are using, e.g. integrationsoftware
        /// </summary>
        public const string Domain = "YOUR-COMPANY-NAME";

        public static string Base64Encode(string text)
        {
            byte[] encodedByte = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            return Convert.ToBase64String(encodedByte);
        }
    }
}
