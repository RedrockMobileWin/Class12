using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class12.Models
{

    public class Lastest
    {
        public string status { get; set; }
        public string msg { get; set; }
        public List<Datum> data { get; set; }

        public class Datum
        {
            public string postid { get; set; }
            public string title { get; set; }
            public string wx_small_app_title { get; set; }
            public string pid { get; set; }
            public string app_fu_title { get; set; }
            public string is_xpc { get; set; }
            public string is_promote { get; set; }
            public string is_xpc_zp { get; set; }
            public string is_xpc_cp { get; set; }
            public string is_xpc_fx { get; set; }
            public string is_album { get; set; }
            public string tags { get; set; }
            public string recent_hot { get; set; }
            public string discussion { get; set; }
            public string image { get; set; }
            public string rating { get; set; }
            public string duration { get; set; }
            public string publish_time { get; set; }
            public string like_num { get; set; }
            public string share_num { get; set; }
            public Cate[] cates { get; set; }
            public string request_url { get; set; }
        }

        public class Cate
        {
            public string cateid { get; set; }
            public string catename { get; set; }
        }
    }
}
