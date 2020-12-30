using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebFormViber.ViberDummyBot;

namespace WebFormViber.Model
{
    public class SentMessageJson
    {
        public string auth_token;
        public string receiver;
        public string tracking_data;
        public KeyboardJson keyboard;
        public string text;
        public string type;
        public string media;
        public SenderJsonNoId sender;
        public string path = "";

        public SentMessageJson(string paAuthenticationToken, string receiver, string tracking_data, string senderName, string textToSend, string _path)
        {
            this.auth_token = paAuthenticationToken;
            this.receiver = receiver;
            this.tracking_data = (null == tracking_data) ? "" : tracking_data;

            this.sender = new SenderJsonNoId();
            if (senderName.ToLower().Contains("Tank"))
            {
                this.sender.name = "Asokh Darji";
            }
            else
            {
                this.sender.name = "Nepali Tutorial";
            }

            //this.sender.name = senderName;
            this.sender.avatar = "https://avatars0.githubusercontent.com/u/9072931?v=3&s=40";//_path;//;
             //this.sender.avatar = "https://avatars0.githubusercontent.com/u/9072931?v=3&s=40";

            this.media = "";
            this.type = "text";
            this.text = textToSend;
        }
    }
}