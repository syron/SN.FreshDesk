using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk
{
    public class FreskDesk
    {
        private string AuthorizationHeaderValue { get; set; }
        private Uri BaseUri { get; set; }

        public FreskDesk(string apiKey, string domain)
        {
            AuthorizationHeaderValue = Helpers.Base64Encode(string.Format("{0}:x", apiKey));
            BaseUri = new Uri(string.Format("http://{0}.freshdesk.com/", domain));
        }

        private async Task<string> SendGetRequest(string relativeUrl)
        {
            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = this.BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.AuthorizationHeaderValue);

                HttpResponseMessage response = await client.GetAsync(relativeUrl);
                if (response.IsSuccessStatusCode)
                {
                    string stringResult = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return stringResult;
                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {
                    throw new Exception("Response status not 200... TODO: Improved error message.");
                }
            }
        }


        #region Forums
        public async Task<string> GetForum(int forumId)
        {
            var relativeUrl = string.Format("discussions/forums/{0}.json", forumId);

            return await SendGetRequest(relativeUrl);
        }
        #endregion
    }
}
