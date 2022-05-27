using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class ResultSearchingPage : BasePage
    {
        public By SearchTitlesListBy => By.XPath("//span[@role='text']//span");
        public IList<IWebElement> SearchTitlesList => WebDriver.FindElements(SearchTitlesListBy);

        public ResultSearchingPage(IWebDriver webDriver) : base(webDriver) { }

        public IWebElement GetSearchTitleByIndex(int index)
        {
            return SearchTitlesList[index];
        }
        public string GetTextSearchTitleByIndex(int index)
        {
            return SearchTitlesList[index].Text;
        }
    }
}
