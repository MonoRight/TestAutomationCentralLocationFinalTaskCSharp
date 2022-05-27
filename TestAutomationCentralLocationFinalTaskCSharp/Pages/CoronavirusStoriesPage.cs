using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class CoronavirusStoriesPage : BasePage
    {
        public By ShareCoronavirusStoryBy => By.XPath("//h3[contains(text(), 'share')]");
        public IWebElement ShareCoronavirusStory => WebDriver.FindElement(ShareCoronavirusStoryBy);

        public CoronavirusStoriesPage(IWebDriver webDriver) : base(webDriver) { }
    }
}
