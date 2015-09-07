using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Models
{
    public class forum
    {
        public string description { get; set; }
        public string description_html { get; set; }
        public int forum_category_id { get; set; }
        public int forum_type { get; set; }
        public int forum_visibility { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int position { get; set; }
        public int posts_count { get; set; }
        public int topics_count { get; set; }
        public List<topic> topics { get; set; }
    }
}
