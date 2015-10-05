using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN.FreshDesk.Models
{
    public class create_ticket
    {
        public create_ticket()
        {
            priority = ticket_priority.Low;
            status = ticket_status.Open;
        }

        public string description { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public ticket_priority priority { get; set; }
        public ticket_status status { get; set; }
    }
}