using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Interfaces;
using Assessment_Two_Logic.Model;
using System.Net;

namespace Assessment_Two_Logic.Presenter
{
    /// <summary>
    /// Used to request webpages in an asynchronous fashion.
    /// </summary>
    public class PagePresenter
    {
        /// <summary>
        /// References the associated view.
        /// </summary>
        private IWebpageView _WebPageView;
        /// <summary>
        /// References the history handler.
        /// </summary>
        private HistoryHandler _HistoryHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PagePresenter(IWebpageView view)
        {
            this._WebPageView = view;
            this._HistoryHandler = HistoryHandler.Instance;
        }

        /// <summary>
        /// Requests the webpage.
        /// To keep the UI-Thread responsive the request will be started in a thread.
        /// </summary>
        public void RequestWebpage()
        {
            String requestUrl = this._WebPageView.Url;
            bool validUrl = PageHandler.IsValidUrl(requestUrl);
            if (validUrl)
            {
                PageHandler pageHandler = new PageHandler(requestUrl);
                this._HistoryHandler.AddEntry(requestUrl);
                Func<SimpleWebResponse> method = pageHandler.FetchUrl;
                method.BeginInvoke(Done, method);
            }
            else
            {
                this.DisplayError("The provided url is not valid.");
            }
        }

        /// <summary>
        /// Callback when a thread is finished with processing.
        /// </summary>
        /// <param name="result">The result of the threaded call.</param>
        public void Done(IAsyncResult result)
        {
            lock (this)
            {
                var target = (Func<SimpleWebResponse>)result.AsyncState;
                SimpleWebResponse response = target.EndInvoke(result);
                this._WebPageView.DisplayWebPage(response);
            }
        }

        /// <summary>
        /// Displays the error.
        /// </summary>
        /// <param name="p">The String to create an error from.</param>
        private void DisplayError(string p)
        {
            ErrorMessage em = new ErrorMessage(p);
            ErrorMessageCollection emc = new ErrorMessageCollection();
            emc.Add(em);
            this._WebPageView.DisplayErrors(emc);
        }
    }
}
