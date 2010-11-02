using System;
using System.Net;
using System.Threading;
namespace Assessment_Two_Logic.Model
{
    /// <summary>
    /// Allows the fetching of urls in a thread.
    /// Will notify the caller via "ThreadFinished" callback method.
    /// </summary>
	public class PageHandler
	{
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
        /// <summary>
        /// 
        /// </summary>
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

		public PageHandler ()
		{
		}

        public void RequestPage()
        { 
            Func<WebResponse> method = FetchUrl;
            method.BeginInvoke(Done, method);
        }

        private WebResponse FetchUrl()
        {
            this.Request = WebRequest.Create(this.RequestUrl);
            this.Request.Proxy = null;
            this.Response = this.Request.GetResponse();
            return this.Response;
        }



        public void Done(IAsyncResult cookie) {
            var target = (Func < WebResponse >) cookie.AsyncState;
            WebResponse test = target.EndInvoke(cookie);
            // Todo Notify caller that fetch is finished ?
            Console.WriteLine("Writing from callback: {0}", test.ToString());
        }
    }
}

