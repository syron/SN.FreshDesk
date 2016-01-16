using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN.FreshDesk.Models
{
    public class customer
    {
        public DateTime created_at { get; set; }
        public string cust_identifier { get; set; }
        public string description { get; set; }
        public string domains { get; set; }
        public int id { get; set; }
        public string name {get; set; }
        public string note { get; set; }
        public int sla_policy_id { get; set; }
        public DateTime updated_at { get; set; }
        public Dictionary<string, string> custom_field { get; set; }

    }
}
