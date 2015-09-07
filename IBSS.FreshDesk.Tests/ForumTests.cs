using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace IBSS.FreshDesk.Tests
{
    [TestFixture]
    public class ForumTests
    {
        [Test]
        public async void GetListOfForums()
        {
            int forumId = 1000227207;

            var relativeUrl = string.Format("discussions/forums/{0}.json", forumId);

            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = new Uri(string.Format("http://{0}.freshdesk.com/", Settings.ApiKey));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Settings.Base64Encode(string.Format("{0}:x", Settings.ApiKey)));

                HttpResponseMessage response = await client.GetAsync(relativeUrl);
                if (response.IsSuccessStatusCode)
                {
                    string stringResult = await response.Content.ReadAsStringAsync();
                    try {
                        JObject.Parse(stringResult);
                    }
                    catch
                    {
                        Assert.Fail();
                        throw;
                    }
                }
            }
        }
    }
}
