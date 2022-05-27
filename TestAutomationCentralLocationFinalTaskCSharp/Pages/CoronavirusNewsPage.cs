using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class CoronavirusNewsPage : BasePage
    {
        public By CoronavirusStoriesListBy => By.XPath("//header//span[contains(text(), 'Your Coronavirus')]");
        public IList<IWebElement> CoronavirusStoriesList => WebDriver.FindElements(CoronavirusStoriesListBy);

        public CoronavirusNewsPage(IWebDriver webDriver) : base(webDriver) { }

        public IWebElement GetCoronavirusStoryByIndex(int index)
        {
            return CoronavirusStoriesList[index];
        }
    }
}
