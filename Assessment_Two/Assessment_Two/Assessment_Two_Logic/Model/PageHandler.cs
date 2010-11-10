using System;
using System.Net;
using System.Threading;
using Assessment_Two_Logic.Interfaces;
using System.IO;
using NLog;
using System.Text.RegularExpressions;

namespace Assessment_Two_Logic.Model
{
    /// <summary>
    /// Allows the fetching of urls in a thread.
    /// Will notify the caller via "ThreadFinished" callback method.
    /// </summary>
    public class PageHandler
    {
        private const string HTTP_REGEXP = @"^http\:\/\/[\w\-\.]+\.[a-zA-Z]{2,3}(\/\S*)?$";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Stores the url to be aquired by this handler.
        /// </summary>
        private String requestUrl;

        /// <summary>
        /// Gets or sets the request URL.
        /// </summary>
        /// <value>The request URL.</value>
        public String RequestUrl
        {
            get { return requestUrl; }
            set { requestUrl = value; }
        }

        /// <summary>
        /// Stores the WebRequest.
        /// </summary>
        private WebRequest request;

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>The request.</value>
        public WebRequest Request
        {
            get { return request; }
            set { request = value; }
        }

        private WebResponse response;

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public WebResponse Response
        {
            get { return response; }
            set { response = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageHandler"/> class.
        /// </summary>
        public PageHandler()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageHandler"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public PageHandler(String url)
        {
            this.RequestUrl = url;
        }

        /// <summary>
        /// Fetches the URL.
        /// </summary>
        /// <returns>The webresponse object.</returns>
        public SimpleWebResponse FetchUrl()
        {
            if (IsValidUrl(this.RequestUrl))
            {
                try
                {
                    String htmlCode = "";
                    try
                    {
                        this.Request = WebRequest.Create(this.RequestUrl);
                        this.Response = this.Request.GetResponse();
                    }
                    catch (WebException e)
                    {
                        logger.Error("WebException ({0}) occured when fetching the url: {1}", e.Message, this.RequestUrl);
                        this.Response = e.Response;
                    }
                    StreamReader sr = new StreamReader(this.Response.GetResponseStream());
                    htmlCode = sr.ReadToEnd();
                    SimpleWebResponse swr = new SimpleWebResponse(this.RequestUrl, this.RequestUrl, htmlCode);

                    return swr;
                }
                catch (Exception e)
                {
                    logger.Error("Exception ({1}) occured, when creating request for url: {0}", this.RequestUrl, e.Message);
                    throw new ArgumentException(String.Format("The Url: {0} could not be fetched.", this.RequestUrl));
                }
            }
            else
            {
                throw new ArgumentException(String.Format("The provided url did not match the specified format for html-urls: {0}", this.RequestUrl));
            }
        }

        /// <summary>
        /// Determines whether [the specified URL] is in a valid format.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// 	<c>true</c> if [is valid URL] [the specified URL]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidUrl(String url)
        {
            bool isValidUrl = false;
            Regex regexp = new Regex(HTTP_REGEXP);
            isValidUrl = regexp.IsMatch(url);
            return isValidUrl;
        }
    }
}

