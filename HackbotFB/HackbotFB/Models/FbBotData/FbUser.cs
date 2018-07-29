using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackbotFB.Models.FbBotData
{
    [Serializable]
    public class FbUser
    {
        public string id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string gender { get; set; }

        public string locale { get; set; }

        public int timezone { get; set; }

        public string profile_pic { get; set; }
    }
}