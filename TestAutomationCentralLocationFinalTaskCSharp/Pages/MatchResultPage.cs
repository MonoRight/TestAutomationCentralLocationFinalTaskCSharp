using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class MatchResultPage : BasePage
    {
        public By ResultScoresListBy => By.XPath("//div[contains(@class, 'match-overview-header')]//span[contains(@class, 'fixture__number')]");
        public IList<IWebElement> ResultScoresList => WebDriver.FindElements(ResultScoresListBy);

        public MatchResultPage(IWebDriver webDriver) : base(webDriver) { }

        public IWebElement GetResultScoreByIndex(int index)
        {
            return ResultScoresList[index];
        }

        public int GetIntResultScoreByIndex(int index)
        {
            return Convert.ToInt32(GetResultScoreByIndex(index).Text);
        }
    }
}
