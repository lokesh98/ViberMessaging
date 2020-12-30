using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormViber.Model
{
    public class SenderJson
    {
        public string id;
        public string name;
        public string avatar;
        public string country;
        public string language;
        public string api_version;
    }

    public class SenderJsonNoId
    {
        public string name;
        public string avatar;
    };
}