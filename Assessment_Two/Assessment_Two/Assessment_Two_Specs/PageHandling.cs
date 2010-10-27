using System;

using TechTalk.SpecFlow;

namespace Assessment_Two_Specs
{
	[Binding]
	public class PageHandling
	{
		[Given(@"I have entered http://www.google.co.uk/")]
        public void GivenIHaveEnteredHttpWww_Google_Co_Uk()
        {
            ScenarioContext.Current.Pending();
        }
		
		[When(@"I press go")]
        public void WhenIPressGo()
        {
            ScenarioContext.Current.Pending();
        }

		[Then(@"then valid html should be returned")]
        public void ThenThenValidHtmlShouldBeReturned()
        {
            ScenarioContext.Current.Pending();
        }
	}
}