using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Models.Responses
{
    public class cc_email
    {
        public List<string> cc_emails { get; set; }
        public List<string> fwd_emails { get; set; }
    }
}
