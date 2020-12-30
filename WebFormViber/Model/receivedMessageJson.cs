using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormViber.Model
{
    public class receivedMessageJson
    {
        public string type;
        public string text;
        public string media;
        public locationJson location;
        public string tracking_data;
        public contactJson contact;
    }
}