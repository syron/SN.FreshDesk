using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN.FreshDesk.Models
{
    public class update_ticket
    {
        public update_ticket()
        {
            custom_field = new Dictionary<string, string>();
        }

        public update_ticket(ticket ticket)
        {
            priority = ticket.priority;
            status = ticket.status;
            custom_field = ticket.custom_field;
        }
        public ticket_priority priority { get; set; }
        public ticket_status status { get; set; }
        public Dictionary<string, string> custom_field { get; set; }
    }
}
