using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk
{
    /// <summary>
    /// Hellper class containing non-freshdesk functions.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Base64 Encode string.
        /// </summary>
        /// <param name="text">String to encode.</param>
        /// <returns>The encoded string.</returns>
        public static string Base64Encode(string text)
        {
            byte[] encodedByte = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            return Convert.ToBase64String(encodedByte);
        }
    }
}
