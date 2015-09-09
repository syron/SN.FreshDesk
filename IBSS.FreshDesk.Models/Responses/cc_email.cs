using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Models.Responses
{
    public class cc_email
    {
        /// <summary>
        /// List of emails being cc'd to.
        /// </summary>
        public List<string> cc_emails { get; set; }
        /// <summary>
        /// List of emails being forwared to.
        /// </summary>
        public List<string> fwd_emails { get; set; }
    }
}
