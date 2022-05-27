using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class SportPage : BasePage
    {
        public By FootballSectionListBy => By.XPath("//ul[@role='list']//span[text()='Football']");
        public IList<IWebElement> FootballSectionList => WebDriver.FindElements(FootballSectionListBy);

        public SportPage(IWebDriver webDriver) : base(webDriver) { }

        public IWebElement GetFootballSectionByIndex(int index)
        {
            return FootballSectionList[index];
        }
    }
}
