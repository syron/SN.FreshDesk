using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Models
{
    public class ticket
    {
        public int display_id { get; set; }
        public string email { get; set; }
        public DateTime created_at { get; set; }
        public int phone { get; set; }
        public string twitter_id { get; set; }
        public string name { get; set; }
        public int requester_id { get; set; }
        public string requester_name { get; set; }
        public string requester_status_name { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public string description_html { get; set; }
        public ticket_status status { get; set; }
        public string status_name { get; set; }
        public ticket_priority priority { get; set; }
        public string priority_name { get; set; }
        public ticket_source_type source { get; set; }
        public string source_name { get; set; }
        public bool urgent { get; set; }
        public bool deleted { get; set; }
        public bool delta { get; set; }
        public bool spam { get; set; }
        public int? responder_id { get; set; }
        public string responder_name { get; set; }
        public int? product_id { get; set; }
        public int? group_id { get; set; }
        public string ticket_type { get; set; }
        public cc_email cc_email { get; set; }
        public List<string> to_emails { get; set; }
        public int? email_config_id { get; set; }
        public string to_email { get; set; }
        public bool trained { get; set; }
        public DateTime updated_at { get; set; }
        public int? owner_id { get; set; }
        public bool isescalated { get; set; }
        public bool fr_escalated { get; set; }
        public DateTime due_by { get; set; }
        public DateTime frDueBy { get; set; }
        public int id { get; set; }
        public List<object> attachments { get; set; }
        public Dictionary<string, string> custom_field { get; set; }

    }
}
