using Microsoft.Azure.AppService.ApiApps.Service;
using Newtonsoft.Json.Linq;
using SN.FreshDesk.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TRex.Metadata;

namespace SN.FreshDesk.Connector.Controllers
{
    public class FreshDeskController : ApiController
    {
        /// <summary>
        /// Polling trigger.
        /// </summary>
        /// <param name="triggerState"></param>
        /// <param name="domain"></param>
        /// <param name="apiKey"></param>
        /// <param name="forumId"></param>
        /// <returns></returns>
        [Trigger(TriggerType.Poll, typeof(List<topic>))]
        [Metadata("Polls a FreshDesk forum", "Polls a specific forum for its topics.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad configuration")]
        [HttpGet, Route("TopicPoll")]
        public async Task<HttpResponseMessage> TopicPoll(
                                    string triggerState,
                                    [Metadata("FreshDesk Domain", "The FreshDesk Domain")]
                                    string domain,
                                    [Metadata("FreshDesk API Key", "The FreshDesk API Key")]
                                    string apiKey,
                                    [Metadata("Forum Id", "The id of the forum")]
                                    int forumId)
        {
            var fd = new FreshDesk(apiKey, domain);

            forum t = await fd.GetForum(forumId); //1000227207
            var tickets = t.topics.OrderByDescending(to => to.created_at).ToList();


            if (string.IsNullOrEmpty(triggerState) || string.IsNullOrWhiteSpace(triggerState))
            {
                triggerState = "2016-01-01";
            }
            var lastTriggerTimeUtc = DateTime.Parse(triggerState).ToUniversalTime();
            tickets = tickets.Where(to => to.created_at >= lastTriggerTimeUtc).ToList();

            var resultingTopics = new List<topic>();

            foreach(var ticket in tickets)
            {
                resultingTopics.Add(await fd.GetTopic(ticket.id));
            }


            JObject json = new JObject();
            json["topics"] = JToken.FromObject(resultingTopics);

            if (tickets != null && tickets.Count() != 0)
            {
                return this.Request.EventTriggered(json);
            }
            else
            {
                return this.Request.EventWaitPoll(new TimeSpan(0, 1, 0));
            }
        }
    }
}
