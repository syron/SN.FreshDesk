using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN.FreshDesk.Models
{
    public class forum_category
    {
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int position { get; set; }
        public DateTime updated_at { get; set; }
        public List<forum> forums { get; set; }
    }
}
