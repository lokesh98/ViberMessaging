using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormViber.Utility
{
    public static class UtilityHelper
    {
        public static string getJsonString(System.IO.Stream postedData)
        {
            byte[] readBytes = new byte[postedData.Length];
            postedData.Read(readBytes, 0, (int)postedData.Length);
            string readString = System.Text.Encoding.UTF8.GetString(readBytes).TrimEnd('\0');
            return readString;
        }

        
    }
}