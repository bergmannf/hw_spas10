using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Interfaces;
using Assessment_Two_Logic.Model;
using System.Net;

namespace Assessment_Two_Logic.Presenter
{
    public class PagePresenter
    {
        private IWebpageView _WebPageView;

        public PagePresenter(IWebpageView view)
        {
            this._WebPageView = view;
        }

        /// <summary>
        /// Requests the webpage.
        /// To keep the UI-Thread responsive the request will be started in a thread.
        /// </summary>
        public void RequestWebpage()
        {
            String requestUrl = this._WebPageView.Url;
            // ToDo: Check for valid url via regexp
            PageHandler pageHandler = new PageHandler(requestUrl);
            // ToDo: Add Page to History
            Func<SimpleWebResponse> method = pageHandler.FetchUrl;
            method.BeginInvoke(Done, method);
        }

        public void Done(IAsyncResult result)
        {
            var target = (Func<SimpleWebResponse>)result.AsyncState;
            SimpleWebResponse response = target.EndInvoke(result);
            // ToDo: Update GUI on UI Thread!
            this._WebPageView.DisplayWebPage(response);
        }
    }
}
