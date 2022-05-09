using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN.FreshDesk.Models
{
    public class agent
    {
        public bool available { get; set; }
        public bool occasional { get; set; }
        public long[] group_ids { get; set; }
        public long[] role_ids { get; set; }
        public agent_contact contact { get; set; }
    }

    public class agent_contact
    {
        public bool active { get; set; }
        public string email { get; set; }
        public string job_title { get; set; }
        public string language { get; set; }
        public string mobile { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string time_zone { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime last_login_at { get; set; }
    }
}
