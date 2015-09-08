using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Models
{
    public class topic
    {
        public int account_id { get; set; }
        public bool boolean_tc01 { get; set; }
        public bool boolean_tc02 { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? datetime_tc01 { get; set; }
        public DateTime? datetime_tc02 { get; set; }
        public bool delta { get; set; }
        public int forum_id { get; set; }
        public int hits { get; set; }
        public int id { get; set; }
        public int? import_id { get; set; }
        public int? int_tc01 { get; set; }
        public int? int_tc02 { get; set; }
        public int? int_tc04 { get; set; }
        public int? int_tc03 { get; set; }
        public int? int_tc05 { get; set; }
        public int last_post_id { get; set; }
        public bool locked  { get; set; }
        public int? long_tc01 { get; set; }
        public int? long_tc02 { get; set; }
        public int? merged_topic_id { get; set; }
        public int posts_count { get; set; }
        public bool published { get; set; }
        public DateTime replied_at { get; set; }
        public int replied_by { get; set; }
        public int? stamp_type { get; set; }
        public int sticky { get; set; }
        public string string_tc01 { get; set; }
        public string string_tc02 { get; set; }
        public string text_tc01 { get; set; }
        public string text_tc02 { get; set; }
        public string title { get; set; }
        public DateTime updated_at { get; set; }
        public int user_id { get; set; }
        public int user_votes { get; set; }

        public List<post> posts { get; set; }
    }
}
