using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN.FreshDesk.Models
{
    /// <summary>
    /// List of emails to cc and forward to.
    /// </summary>
    public class cc_email
    {
        public cc_email()
        {
            cc_emails = new List<string>();
            fwd_emails = new List<string>();
        }
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
