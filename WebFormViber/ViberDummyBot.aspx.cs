using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormViber.Model;
using WebFormViber.Utility;

namespace WebFormViber
{
    public partial class ViberDummyBot : System.Web.UI.Page
    {
        const string paAuthenticationToken = ""; //Add your key here
        const string viberUrlForSendingMessagesTo = "https://chatapi.viber.com/pa/send_message";
        const string webhookurl = "https://chatapi.viber.com/pa/set_webhook";


        protected void Page_Load(object sender, EventArgs e)
        {
            string readString = UtilityHelper.getJsonString(Request.GetBufferlessInputStream());

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            Dictionary<string, object> dict = serializer.Deserialize<Dictionary<string, object>>(readString);
            if (null == dict)
            {
                ReplyEmptyResponse();
                return;
            }

            object eventTypeOject;
            if (!dict.TryGetValue("event", out eventTypeOject))
            {
                ReplyEmptyResponse();
                return;//ERROR
            }

            string eventType = eventTypeOject.ToString().ToLower();

            if (eventType.Equals("webhook"))
            {
                object testWEbhook;
                if (dict.TryGetValue("webhook", out testWEbhook))
                {
                    //receivedMessageJson messageObject = serializer.ConvertToType<receivedMessageJson>(testWEbhook);
                    System.IO.File.WriteAllText(Server.MapPath("~/Model/messager.txt"), testWEbhook.ToString());
                }
                
            }


            if (eventType.Equals("message"))
            {
                object senderValue;
                if (!dict.TryGetValue("sender", out senderValue))
                {
                    ReplyEmptyResponse();
                    return;//ERROR
                }
                SenderJson SenderObject = serializer.ConvertToType<SenderJson>(senderValue);
                if (null == SenderObject)
                {
                    ReplyEmptyResponse();
                    return;//TODO: ERROR
                }

                object sentMessage;
                if (dict.TryGetValue("message", out sentMessage))
                {//Send reply message to user:
                    receivedMessageJson messageObject = serializer.ConvertToType<receivedMessageJson>(sentMessage);

                    // Get received message text and send it back to the sender:
                    //String arrivingText = "Hello Amrit Damna " + messageObject.text;
                    string name = "";
                    string msg = " ";
                    if (name.ToLower().Contains("Tank"))
                    {
                        name = "Tanke Sanke";
                        msg = "Hi ";
                    }
                    else
                    {
                        name = SenderObject.name;
                    }

                    String arrivingText = "Hi....."+ name + " Damna, How are you ? "+ msg + messageObject.text;

                    //el.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));

                    string x = Server.MapPath("~/Images/download.jpg");
                    SentMessageJson autoSentReplyToUser = new SentMessageJson(paAuthenticationToken, SenderObject.id, messageObject.tracking_data, SenderObject.name, arrivingText,x);
                   
                    string jsonStr = serializer.Serialize(autoSentReplyToUser);
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(viberUrlForSendingMessagesTo);
                    var data = Encoding.UTF8.GetBytes(jsonStr);
                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.ContentLength = data.Length;
                    using (var stream = httpWebRequest.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);

                    }
                }
            }

            ReplyEmptyResponse();
        }


        public void ReplyEmptyResponse()
        {
            Response.Write("{}");
        }






    }
}