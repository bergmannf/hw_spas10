using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment_Two_Logic.Model
{
    public class SimpleWebResponse
    {
        public String Url { get; set; }
        public String Title { get; set; }
        public String Html { get; set; }

        public SimpleWebResponse(string url, string title, string htmlCode)
        {
            this.Url = url;
            this.Title = title;
            this.Html = htmlCode;
        }
    }
}
