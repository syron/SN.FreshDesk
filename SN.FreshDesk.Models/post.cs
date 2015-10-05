using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN.FreshDesk.Models
{
    public class post
    {
        public int account_id { get; set; }
        public bool answer { get; set; }
        public string body { get; set; }
        public string body_html { get; set; }
        public DateTime created_at { get; set; }
        public int forum_id { get; set; }
        public int id { get; set; }
        public int? import_id { get; set; }
        public int topic_id { get; set; }
        public DateTime updated_at { get; set; }
        public int user_id { get; set; }
    }
}
