using SN.FreshDesk.Models;
using SN.FreshDesk.Models.Responses;
using SN.FreshDesk.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SN.FreshDesk
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

        private async Task<T> SendPutRequest<T>(string relativeUrl, object data)
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
        public async Task<ticket> CreateTicket(request_create_ticket ticket)
        {
            var relativeUrl = string.Format("/helpdesk/tickets.json");

            var response = await SendPostRequest<response_ticket>(relativeUrl, ticket);

            return response.helpdesk_ticket;
        }

        /// <summary>
        /// Creates a new ticket on FreshDesk.
        /// </summary>
        /// <param name="subject">The subject of the ticket.</param>
        /// <param name="description">The description.</param>
        /// <param name="email">The email of the issuer.</param>
        /// <param name="priority">Ticket priority.</param>
        /// <param name="status">Ticket status.</param>
        /// <param name="cc_emails">List of emails to receive ticket as well.</param>
        /// <returns></returns>
        public async Task<ticket> CreateTicket(string subject, string description, string email, ticket_priority priority, ticket_status status, List<string> cc_emails)
        {
            var createdTicket = new request_create_ticket();

            createdTicket.helpdesk_ticket.subject = subject;
            createdTicket.helpdesk_ticket.description = description;
            createdTicket.helpdesk_ticket.email = email;
            createdTicket.helpdesk_ticket.priority = priority;
            createdTicket.helpdesk_ticket.status = status;
            createdTicket.cc_emailList = cc_emails;

            return await CreateTicket(createdTicket);
        }

        /// <summary>
        /// Gets all tickets without any filter applied.
        /// </summary>
        /// <returns>List of tickets (max 30).</returns>
        public async Task<List<ticket>> GetAllTickets(int page = 1, string sortBy = "created_at", string sortByType = "desc")
        {
            if (page < 1)
                throw new ArgumentException("Page must not be lower than 1.");

            var relativeUrl = string.Format("helpdesk/tickets/filter/all_tickets?format=json&page={0}&wf_order={1}&wf_order_type={2}", page, sortBy, sortByType);

            return await SendGetRequest<List<ticket>>(relativeUrl);
        }

        /// <summary>
        /// Uses the new_and_my_open filter.
        /// </summary>
        /// <returns>List of found tickets (max 30) matching the new_and_my_open filter.</returns>
        public async Task<List<ticket>> GetNewAndOpenTickets(int page = 1, string sortBy = "created_at", string sortByType = "desc")
        {
            if (page < 1)
                throw new ArgumentException("Page must not be lower than 1.");

            var relativeUrl = string.Format("helpdesk/tickets.json?page={0}&wf_order={1}&wf_order_type={2}", page, sortBy, sortByType);

            return await SendGetRequest<List<ticket>>(relativeUrl);
        }

        /// <summary>
        /// Gets tickets by using one of the predefined filters.
        /// </summary>
        /// <param name="filter_name">The various filters available are all_tickets, new_and_my_open, monitored_by, spam, deleted.</param>
        /// <returns>List of found tickets.</returns>
        public async Task<List<ticket>> GetTicketsByPredefinedFilter(string filter_name, int page = 1, string sortBy = "created_at", string sortByType = "desc")
        {
            if (page < 1)
                throw new ArgumentException("Page must not be lower than 1.");

            var relativeUrl = string.Format("helpdesk/tickets/filter/{0}?format=json&page={1}&wf_order={2}&wf_order_type={3}", filter_name, page, sortBy, sortByType);

            return await SendGetRequest<List<ticket>>(relativeUrl);
        }

        /// <summary>
        /// Gets tickets by requester.
        /// </summary>
        /// <param name="requester_id">The id of the requester.</param>
        /// <returns>List of found tickets.</returns>
        public async Task<List<ticket>> GetTicketsByRequester(string requester_id, int page = 1, string sortBy = "created_at", string sortByType = "desc")
        {
            if (page < 1)
                throw new ArgumentException("Page must not be lower than 1.");

            var relativeUrl = string.Format("helpdesk/tickets/filter/requester/{0}?format=json&page={1}&wf_order={2}&wf_order_type={3}", requester_id, page, sortBy, sortByType);

            return await SendGetRequest<List<ticket>>(relativeUrl);
        }

        /// <summary>
        /// Gets tickets by custom ticket views.
        /// </summary>
        /// <param name="view_id">The id of the custom view id.</param>
        /// <returns>List of found tickets.</returns>
        public async Task<List<ticket>> GetTicketsByCustomTicketViews(string view_id, int page = 1, string sortBy = "created_at", string sortByType = "desc")
        {
            if (page < 1)
                throw new ArgumentException("Page must not be lower than 1.");

            var relativeUrl = string.Format("helpdesk/tickets/view/{0}?format=json&page={1}&wf_order={2}&wf_order_type={3}", view_id, page, sortBy, sortByType);

            return await SendGetRequest<List<ticket>>(relativeUrl);
        }

        /// <summary>
        /// Gets tickets by company name.
        /// </summary>
        /// <param name="company_name">The name of the company.</param>
        /// <returns>List of found tickets.</returns>
        public async Task<List<ticket>> GetTicketsByCompanyName(string company_name, int page = 1, string sortBy = "created_at", string sortByType = "desc")
        {
            if (page < 1)
                throw new ArgumentException("Page must not be lower than 1.");

            var relativeUrl = string.Format("helpdesk/tickets.json?company_name={0}&page={1}&wf_order={2}&wf_order_type={3}", company_name, page, sortBy, sortByType);

            return await SendGetRequest<List<ticket>>(relativeUrl);
        }

        /// <summary>
        /// Gets tickets by company id.
        /// </summary>
        /// <param name="company_id">The id of the company.</param>
        /// <returns>List of found tickets.</returns>
        public async Task<List<ticket>> GetTicketsByCompanyId(string company_id, int page = 1, string sortBy = "created_at", string sortByType = "desc")
        {
            if (page < 1)
                throw new ArgumentException("Page must not be lower than 1.");

            var relativeUrl = string.Format("helpdesk/tickets.json?company_id={0}&page={1}&wf_order={2}&wf_order_type={3}", company_id, page, sortBy, sortByType);

            return await SendGetRequest<List<ticket>>(relativeUrl);
        }

        /// <summary>
        /// Gets tickets by requester email.
        /// </summary>
        /// <param name="email">The email of the requester.</param>
        /// <returns>List of found tickets.</returns>
        public async Task<List<ticket>> GetTicketsByRequesterEmail(string email, int page = 1, string sortBy = "created_at", string sortByType = "desc")
        {
            if (page < 1)
                throw new ArgumentException("Page must not be lower than 1.");

            var relativeUrl = string.Format("helpdesk/tickets.json?email={0}&page={1}&wf_order={2}&wf_order_type={3}", email, page, sortBy, sortByType);

            return await SendGetRequest<List<ticket>>(relativeUrl);
        }

        public async Task<ticket> GetTicket(int id)
        {
            var relativeUrl = string.Format("helpdesk/tickets/{0}.json", id);

            var response = await SendGetRequest<response_ticket>(relativeUrl);

            return response.helpdesk_ticket;
        }

        public async Task<ticket> UpdateTicket(int id, request_update_ticket ticket)
        {
            var relativeUrl = string.Format("helpdesk/tickets/{0}.json", id);

            var response = await SendPutRequest<response_ticket>(relativeUrl, ticket);

            return response.helpdesk_ticket;
        }

        public async Task<ticket> PickTicket(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTicket(int id)
        {
            var relativeUrl = string.Format("/helpdesk/tickets/{0}.json", id);

            var response = await SendDeleteRequest(relativeUrl);

            return response;
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
