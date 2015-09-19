using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Models
{
    public class create_ticket
    {
        public string description { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public ticket_priority priority { get; set; }
        public ticket_status status { get; set; }
    }
}