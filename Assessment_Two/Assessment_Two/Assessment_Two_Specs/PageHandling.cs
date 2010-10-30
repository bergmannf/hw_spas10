using System;
using Assessment_Two_Logic.Model;

using TechTalk.SpecFlow;

namespace Assessment_Two_Specs
{
	[Binding]
	public class PageHandling
	{
		[Given(@"I have entered http://www.google.co.uk/")]
        public void GivenIHaveEnteredHttpWww_Google_Co_Uk()
        {
            var pageHandler = new PageHandler();
            pageHandler.RequestURL = "http://www.google.co.uk/";
        }

        [When(@"I request the page")]
        public void WhenIRequestThePage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a 200-header-message should be returned")]
        public void ThenA200_Header_MessageShouldBeReturned()
        {
            ScenarioContext.Current.Pending();
        }
	}
}