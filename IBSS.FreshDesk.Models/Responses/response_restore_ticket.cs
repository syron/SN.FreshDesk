using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Models.Responses
{
    public class response_restore_ticket
    {
        public bool deleted { get; set; }
        public int display_id { get; set; }
        public string subject { get; set; }
        public string status_name { get; set; }
        public string requester_status_name { get; set; }
        public string priority_name { get; set; }
        public string source_name { get; set; }
        public string requester_name { get; set; }
        public string responder_name { get; set; }
        public List<string> to_emails { get; set; }
    }
}
