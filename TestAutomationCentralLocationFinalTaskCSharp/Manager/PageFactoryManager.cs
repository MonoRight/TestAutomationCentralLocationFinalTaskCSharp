using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationCentralLocationFinalTaskCSharp.Pages;

namespace TestAutomationCentralLocationFinalTaskCSharp.Manager
{
    public class PageFactoryManager
    {
        readonly IWebDriver webDriver;

        public PageFactoryManager(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public HomePage GetHomePage() => new HomePage(webDriver);
        public NewsPage GetNewsPage() => new NewsPage(webDriver);
        public SearchPage GetSearchPage() => new SearchPage(webDriver);
        public ResultSearchingPage GetResultSearchingPage() => new ResultSearchingPage(webDriver);
        public CoronavirusNewsPage GetCoronavirusNewsPage() => new CoronavirusNewsPage(webDriver);
        public CoronavirusStoriesPage GetCoronavirusStoriesPage() => new CoronavirusStoriesPage(webDriver);
        public AddingStoryPage GetAddingStoryPage() => new AddingStoryPage(webDriver);
        public SportPage GetSportPage() => new SportPage(webDriver);
        public FootballNewsPage GetFootballNewsPage() => new FootballNewsPage(webDriver);
        public FootballScoresAndFixturesPage GetFootballScoresAndFixtures() => new FootballScoresAndFixturesPage(webDriver);
        public MatchResultPage GetMatchResultPage() => new MatchResultPage(webDriver);
      
    }
}
