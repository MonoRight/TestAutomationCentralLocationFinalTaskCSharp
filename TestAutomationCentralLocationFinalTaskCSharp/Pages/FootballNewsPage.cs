using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class FootballNewsPage : BasePage
    {
        public By ScoresAndFixturesSelectionBy => By.XPath("//li[contains(@class, 'sport-navigation')]//a[@data-stat-title='Scores & Fixtures']");
        public IWebElement ScoresAndFixturesSelection => WebDriver.FindElement(ScoresAndFixturesSelectionBy);


        public FootballNewsPage(IWebDriver webDriver) : base(webDriver) { }
    }
}
