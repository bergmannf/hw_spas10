using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Interfaces;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Presenter
{
    class PagePresenter : INotifiable
    {
        private IWebpageView _WebPageView;

        public PagePresenter(IWebpageView view)
        {
            this._WebPageView = view;
        }

        public void RequestWebpage()
        {
            String requestUrl = this._WebPageView.Url;
            PageHandler pageHandler = new PageHandler(this, requestUrl);
            pageHandler.RequestPage();
        }

        public void Notify()
        {
            lock (this)
            {
                throw new NotImplementedException();
            }
        }
    }
}
