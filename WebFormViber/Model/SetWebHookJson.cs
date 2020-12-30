using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormViber.Model
{
    public class SetWebHookJson
    {
        public string auth_token;
        public string url;
        ICollection<EventType> eventTypes = null;

        public SetWebHookJson(string paAuthenticationToken, string url, ICollection<EventType> eventTypes = null)
        {
            this.auth_token = paAuthenticationToken;
            this.url = url;
            this.eventTypes = eventTypes;
        }
    }
}