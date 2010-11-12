using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;
using NUnit.Framework;
using System.Net;

namespace Assessment_Two_Specs
{
    [TestFixture]
    class PageHandlerTest
    {
        private PageHandler handler;

        [SetUp]
        public void SetUp()
        {
            this.handler = new PageHandler();
        }

        [Test]
        public void Test404ErrorPage()
        {
            this.handler.RequestUrl = "http://www.google.de/err";
            this.handler.FetchUrl();
            HttpWebResponse resp = this.handler.Response as HttpWebResponse;
            Assert.AreEqual(resp.StatusCode, HttpStatusCode.NotFound);
        }

        [Test]
        public void Test200Page()
        {
            this.handler.RequestUrl = "http://www.google.de/";
            this.handler.FetchUrl();
            HttpWebResponse resp = this.handler.Response as HttpWebResponse;
            Assert.AreEqual(resp.StatusCode, HttpStatusCode.OK);
        }
    }
}
