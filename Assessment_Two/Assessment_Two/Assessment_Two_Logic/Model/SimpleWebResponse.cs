using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment_Two_Logic.Model
{
    public class SimpleWebResponse
    {
        public String Url { get; set; }
        public String Html { get; set; }

        public SimpleWebResponse(string p, string htmlCode)
        {
            this.Url = p;
            this.Html = htmlCode;
        }
    }
}
