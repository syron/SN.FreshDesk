using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN.FreshDesk.Models.Requests
{
    public class request_update_ticket
    {
        public update_ticket helpdesk_ticket { get; set; }
        public helpdesk helpdesk { get; set; }
    }
}
