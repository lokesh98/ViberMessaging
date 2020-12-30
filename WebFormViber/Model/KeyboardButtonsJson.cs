using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormViber.Model
{
    public class KeyboardButtonsJson
    {
        public string ActionType;
        public string ActionBody;
        public string BgColor;
        public int Columns;
        public int Rows;
        public string Text;
        public string TextHAlign;
        public string Image;
        public string TextSize;
        public int TextOpacity;

        public KeyboardButtonsJson(string actionType, string actionBody, string backgroundColor, string text, string textAlign,
            int buttonColumns = 6, int buttonsRows = 1, string ImageUrl = null, bool isLargeTextSize = false, int textOpacity = 100)
        {
            const int maxNumColums = 6;
            const int maxNumRows = 2;
            buttonColumns = ((buttonColumns > 0) && (buttonColumns < maxNumColums)) ? buttonColumns : maxNumColums;
            buttonsRows = ((buttonsRows > 0) && (buttonsRows < maxNumColums)) ? buttonsRows : maxNumRows;

            this.Image = ImageUrl;
            this.ActionType = actionType;
            this.ActionBody = actionBody;
            this.BgColor = backgroundColor;
            this.Text = text;
            this.TextHAlign = textAlign;//possible values: "left", "center", "right"
            this.Columns = buttonColumns;
            this.Rows = buttonsRows;
            this.TextSize = isLargeTextSize ? "large" : "regular";// (can also be "small")
            this.TextOpacity = ((textOpacity >= 0) && (textOpacity <= 100)) ? textOpacity : 100;
        }
    }


    public class KeyboardJson
    {
        public string Type;
        public List<KeyboardButtonsJson> Buttons;

        public KeyboardJson(List<KeyboardButtonsJson> buttons, string queryForMedicalSearch)
        {
            this.Type = "keyboard";
            this.Buttons = buttons;
        }
    }
}