using IBSS.FreshDesk.Models;
using IBSS.FreshDesk.Models.Responses;
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="domain">Your freshdesk domain</param>
        public FreskDesk(string apiKey, string domain)
        {
            AuthorizationHeaderValue = Helpers.Base64Encode(string.Format("{0}:x", apiKey));
            BaseUri = new Uri(string.Format("http://{0}.freshdesk.com/", domain));
        }

        private async Task<T> SendGetRequest<T>(string relativeUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = this.BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.AuthorizationHeaderValue);

                HttpResponseMessage response = await client.GetAsync(relativeUrl);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {                        
                        return await response.Content.ReadAsAsync<T>();
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
        /// <summary>
        /// Gets forum details.
        /// </summary>
        /// <param name="forumId">The id of the forum.</param>
        /// <returns>Forum details.</returns>
        public async Task<forum> GetForum(int forumId)
        {
            var relativeUrl = string.Format("discussions/forums/{0}.json", forumId);

            var result = await SendGetRequest<response_forum>(relativeUrl);

            return null;
        }
        #endregion
    }
}
