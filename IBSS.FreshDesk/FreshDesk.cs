using IBSS.FreshDesk.Models;
using IBSS.FreshDesk.Models.Responses;
using IBSS.FreshDesk.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace IBSS.FreshDesk
{
    public class FreshDesk
    {
        private string AuthorizationHeaderValue { get; set; }
        private Uri BaseUri { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="domain">Your freshdesk domain</param>
        public FreshDesk(string apiKey, string domain)
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
                    string msg = "";
                    HttpStatusCode statusCode = response.StatusCode;

                    throw new Exception(string.Format("Response status not 200... TODO: Improved error message.", (int)statusCode));
                }
            }
        }

        private async Task<bool> SendDeleteRequest(string relativeUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = this.BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.AuthorizationHeaderValue);

                HttpResponseMessage response = await client.DeleteAsync(relativeUrl);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        return true;
                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        private async Task<bool> SendPutRequest(string relativeUrl, object data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = this.BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.AuthorizationHeaderValue);

                HttpResponseMessage response = await client.PutAsJsonAsync(relativeUrl, data);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        return true;
                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        private async Task<T> SendPostRequest<T>(string relativeUrl, object data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = this.BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.AuthorizationHeaderValue);

                HttpResponseMessage response = await client.PostAsJsonAsync(relativeUrl, data);
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
        #region Tickets
        public async Task<ticket> CreateTicket(request_ticket ticket)
        {
            var relativeUrl = string.Format("/helpdesk/tickets.json");

            var response = await SendPostRequest<response_ticket>(relativeUrl, ticket);

            return response.helpdesk_ticket;
        }

        public async Task<List<ticket>> GetTickets()
        {
            var relativeUrl = string.Format("helpdesk/tickets.json");

            var response = await SendGetRequest<List<ticket>>(relativeUrl);

            return response;

        }

        public async Task<ticket> GetTicket(int id)
        {
            var relativeUrl = string.Format("helpdesk/tickets/{0}.json", id);

            var response = await SendGetRequest<response_ticket>(relativeUrl);

            return response.helpdesk_ticket;
        }

        public async Task<ticket> UpdateTicket(request_ticket ticket)
        {
            throw new NotImplementedException();
        }

        public async Task<ticket> PickTicket(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTicket(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ticket> RestoreTicket(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ticket> AssignTicket(int id, int user_id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ticket_field>> GetTicketFields()
        {
            throw new NotImplementedException();
        }

        public async Task<note> AddNoteToTicket(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<note> AddNoteToTicketWithAttachment(int id)
        {
            throw new NotImplementedException();
        }
        #endregion



        #region FORUM CATEGORIES

        public async Task<response_forum_category> GetForumCategory(int id)
        {
            var relativeUrl = string.Format("/discussions/categories/{0}.json", id);

            var response = await SendGetRequest<response_forum_category>(relativeUrl);

            return response;
        }

        public async Task<List<response_forum_category>> GetForumCategories()
        {
            var relativeUrl = string.Format("/discussions/categories.json");

            var response = await SendGetRequest<List<response_forum_category>>(relativeUrl);

            return response;
        }

        public async Task<response_forum_category> CreateForumCategory(forum_category forum_category)
        {
            var relativeUrl = string.Format("/discussions/categories.json");

            var request_forum_category = new request_forum_category();
            request_forum_category.forum_category = forum_category;

            var response = await SendPostRequest<response_forum_category>(relativeUrl, request_forum_category);

            return response;
        }

        #endregion

        #region Forums

        /// <summary>
        /// Gets forum details.
        /// </summary>
        /// <param name="forumId">The id of the forum.</param>
        /// <returns>Forum details.</returns>
        public async Task<forum> GetForum(int forumId)
        {
            var relativeUrl = string.Format("discussions/forums/{0}.json", forumId);

            var response = await SendGetRequest<response_forum>(relativeUrl);

            return response.forum;
        }

        /// <summary>
        /// Creates a new forum.
        /// </summary>
        /// <param name="forum"></param>
        /// <returns></returns>
        public async Task<forum> CreateForum(forum forum)
        {
            var relativeUrl = "/discussions/forums.json";

            var request_forum = new request_forum();
            request_forum.forum = forum;

            var response = await SendPostRequest<response_forum>(relativeUrl, request_forum);

            return response.forum;
        }


        public async Task<bool> DeleteForum(int id)
        {
            var relativeUrl = string.Format("/discussions/forums/{0}.json", id);

            var response = await SendDeleteRequest(relativeUrl);

            return response;
        }

        /// <summary>
        /// Gets topic details.
        /// </summary>
        /// <param name="topicId">The id of the topic.</param>
        /// <returns>Topic details.</returns>
        public async Task<topic> GetTopic(int topicId)
        {
            var relativeUrl = string.Format("/discussions/topics/{0}.json", topicId);

            var response = await SendGetRequest<response_topic>(relativeUrl);

            return response.topic;
        }
        #endregion
    }
}
