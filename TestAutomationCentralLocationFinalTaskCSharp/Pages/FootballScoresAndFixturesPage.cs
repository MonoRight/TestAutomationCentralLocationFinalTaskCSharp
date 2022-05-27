using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class FootballScoresAndFixturesPage : BasePage
    {
        public By SearchInputCompetitionsBy => By.XPath("//input[@name='search']");
        public IWebElement SearchInputCompetitions => WebDriver.FindElement(SearchInputCompetitionsBy);
        public By SearchResultListBy => By.XPath("//ul[@id='search-results-list']/li");
        public IList<IWebElement> SearchResultList => WebDriver.FindElements(SearchResultListBy);
        public By MonthListBy => By.XPath("//li[contains(@class, 'date-picker')]/a/span[1]");
        public IList<IWebElement> MonthList => WebDriver.FindElements(MonthListBy);
        public By YearListBy => By.XPath("//li[contains(@class, 'date-picker')]/a/span[2]");
        public IList<IWebElement> YearList => WebDriver.FindElements(YearListBy);
        public By YearAndMonthSelectListBy => By.XPath("//li[contains(@class, 'date-picker')]");
        public IList<IWebElement> YearAndMonthSelectList => WebDriver.FindElements(YearAndMonthSelectListBy);
        public By TeamsListBy => By.XPath("//span[@class='sp-c-fixture__team-name-wrap']");
        public IList<IWebElement> TeamsList => WebDriver.FindElements(TeamsListBy);
        public By ScoresListBy => By.XPath("//span[contains(@class, 'sp-c-fixture__number')]");
        public IList<IWebElement> ScoresList => WebDriver.FindElements(ScoresListBy);

        
        public FootballScoresAndFixturesPage(IWebDriver webDriver) : base(webDriver) { }

        public IWebElement GetSearchResultListByIndex(int index)
        {
            return SearchResultList[index];
        }

        public IWebElement GetMonthByIndex(int index)
        {
            return MonthList[index];
        }

        public string GetTextMonthByIndex(int index)
        {
            return GetMonthByIndex(index).Text;
        }

        public IWebElement GetYearByIndex(int index)
        {
            return YearList[index];
        }

        public string GetTextYearByIndex(int index)
        {
            return GetYearByIndex(index).Text;
        }

        public IWebElement GetYearAndMonthSelectByIndex(int index)
        {
            return YearAndMonthSelectList[index];
        }

        public IWebElement GetTeamByIndex(int index)
        {
            return TeamsList[index];
        }

        public string GetTextTeamByIndex(int index)
        {
            return GetTeamByIndex(index).Text;
        }

        public IWebElement GetScoreByIndex(int index)
        {
            return ScoresList[index];
        }

        public string GetTextScoreByIndex(int index)
        {
            return GetScoreByIndex(index).Text;
        }

        public int GetIntScoreByIndex(int index)
        {
            return Convert.ToInt32(GetTextScoreByIndex(index));
        }
    }
}
