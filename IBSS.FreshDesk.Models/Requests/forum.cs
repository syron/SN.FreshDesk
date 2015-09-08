using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Models.Requests
{
    public class forum
    {
        public string description { get; set; }
        public int forum_type { get; set; }
        public int forum_category_id { get; set; }
        public int forum_visibility { get; set; }
        public string name { get; set; }
    }
}
