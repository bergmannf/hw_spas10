using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;
using System.Net;

namespace Assessment_Two_Logic.Interfaces
{
    /// <summary>
    /// Interface to allow a page-presenter to communicate with the view. 
    /// </summary>
    public interface IWebpageView : IView
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        String Url { get; set; }

        /// <summary>
        /// Gets or sets the site text.
        /// </summary>
        /// <value>The site text.</value>
        String SiteText { get; }

        /// <summary>
        /// Displays the web page.
        /// </summary>
        /// <param name="webpage">The webpage.</param>
        void DisplayWebPage(SimpleWebResponse webpage);
    }
}
