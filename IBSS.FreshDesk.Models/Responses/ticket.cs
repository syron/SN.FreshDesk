using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Models.Responses
{
    public class ticket
    {
        public int display_id { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public string twitter_id { get; set; }
        public string name { get; set; }
        public int requester_id { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public string description_html { get; set; }
        public int status { get; set; }
        public int priority { get; set; }
        public int source { get; set; }
        public bool deleted { get; set; }
        public bool spam { get; set; }
        public int responder_id { get; set; }
        public int group_id { get; set; }
        public string ticket_type { get; set; }
        public List<string> cc_emails { get; set; }
        public int email_config_id { get; set; }
        public bool isescalated { get; set; }
        public DateTime due_by { get; set; }
        public int id { get; set; }
        public List<object> attachments { get; set; }
        public Dictionary<string, string> custom_fields { get; set; }

    }
}
