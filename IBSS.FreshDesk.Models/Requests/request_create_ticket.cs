using IBSS.FreshDesk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Models.Requests
{
    public class request_create_ticket
    {
        public request_create_ticket()
        {
            cc_emailList = new List<string>();
            helpdesk_ticket = new create_ticket();
        }

        public create_ticket helpdesk_ticket { get; set; }
        
        public string cc_emails { get
            {
                return string.Join(",", cc_emailList);
            }
        }

        public List<string> cc_emailList { get; set; }
    }
}
