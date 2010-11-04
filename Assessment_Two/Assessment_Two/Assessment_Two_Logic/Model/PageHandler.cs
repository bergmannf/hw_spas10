using System;
using System.Net;
using System.Threading;
using Assessment_Two_Logic.Interfaces;
using System.IO;
using NLog;

namespace Assessment_Two_Logic.Model
{
    /// <summary>
    /// Allows the fetching of urls in a thread.
    /// Will notify the caller via "ThreadFinished" callback method.
    /// </summary>
	public class PageHandler
	{
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

        private INotifiable _NotifyMember;
        public INotifiable NotifyMember
        {
            get
            {
                return _NotifyMember;
            }
            set
            {
                _NotifyMember = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageHandler"/> class.
        /// </summary>
		public PageHandler ()
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
            this.Request = WebRequest.Create(this.RequestUrl);
            try
            {
                this.Response = this.Request.GetResponse();
            }
            catch (Exception)
            {
                logger.Error("Exception when creating request for url: {0}", this.RequestUrl);
                
                throw;
            }
            String htmlCode = "";
            StreamReader sr = new StreamReader(this.Response.GetResponseStream());
            
            htmlCode = sr.ReadToEnd();

            SimpleWebResponse swr = new SimpleWebResponse(this.RequestUrl, this.RequestUrl, htmlCode);

            return swr;
        }
    }
}

