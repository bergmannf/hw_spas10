using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment_Two_Logic.Model
{
    /// <summary>
    /// A simplified webresponse reduced to the attributes needed to display a webpage.
    /// </summary>
    public class SimpleWebResponse
    {
        public String Url { get; set; }
        public String Title { get; set; }
        public String Html { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleWebResponse"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="title">The title.</param>
        /// <param name="htmlCode">The HTML code.</param>
        public SimpleWebResponse(string url, string title, string htmlCode)
        {
            this.Url = url;
            this.Title = title;
            this.Html = htmlCode;
        }
    }
}
