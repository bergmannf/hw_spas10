using System;
using Assessment_Two_Logic.Model;

using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Net;
using System.Diagnostics;

namespace Assessment_Two_Specs
{
	[Binding]
	public class PageHandling
	{
        private PageHandler pageHandler;

		[Given(@"I have entered (.*)")]
        public void GivenIHaveEnteredHttp(String webPage)
        {
            pageHandler = new PageHandler();
            pageHandler.RequestUrl = webPage;
            Assert.AreEqual(pageHandler.RequestUrl, webPage);
        }

        [When(@"I request the page")]
        public void WhenIRequestThePage()
        {
            pageHandler.FetchUrl();
        }

        [Then(@"a 200-OK status code should be returned")]
        public void ThenA200_Header_MessageShouldBeReturned()
        {
            HttpWebResponse rep = pageHandler.Response as HttpWebResponse;
            Assert.AreEqual(HttpStatusCode.OK, rep.StatusCode);
        }

        [Then(@"a 400-header-message should be returned")]
        public void ThenA400_Header_MessageShouldBeReturned()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a 404-header-message should be returned")]
        public void ThenA404_Header_MessageShouldBeReturned()
        {
            ScenarioContext.Current.Pending();
        }
	}
}