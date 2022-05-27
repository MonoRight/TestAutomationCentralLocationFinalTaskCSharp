using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationCentralLocationFinalTaskCSharp.Manager;
using TestAutomationCentralLocationFinalTaskCSharp.Pages;

namespace TestAutomationCentralLocationFinalTaskCSharp.BLL
{
    public class BussinesLogicLayer
    {
        private readonly IWebDriver _webDriver;
        private HomePage _homePage;
        private NewsPage _newsPage;
        private SearchPage _searchPage;
        private ResultSearchingPage _resultSearchingPage;
        private CoronavirusNewsPage _coronavirusNewsPage;
        private CoronavirusStoriesPage _coronavirusStoriesPage;
        private AddingStoryPage _addingStoryPage;
        private SportPage _sportPage;
        private FootballNewsPage _footballNewsPage;
        private FootballScoresAndFixturesPage _footballScoresAndFixturesPage;
        private MatchResultPage _matchResultPage;
        private readonly PageFactoryManager _pageFactoryManager;
        private Score score = null;


        public BussinesLogicLayer(WebDriver webDriver)
        {
            this._webDriver = webDriver;
            _pageFactoryManager = new PageFactoryManager(_webDriver);
        }

        public void OpenPage(string url)
        {
            _homePage = _pageFactoryManager.GetHomePage();
            _homePage.OpenHomePage(url);
        }
        public void ClickNewsButton(double waitTime)
        {
            _homePage.WaitVisibilityOfElement(waitTime, _homePage.NewsCategoryBy);
            _homePage.ClickTheWebElement(_homePage.NewsCategory);
        }
        public string GetTextOfMainArticle(double waitTime, int index)
        {
            _newsPage = _pageFactoryManager.GetNewsPage();
            _newsPage.WaitForPageLoadComplete(waitTime);
            return _newsPage.GetTextTitleByIndex(index);
        }

        public string GetTextOfSecondaryArticleByIndex(double waitTime, int index)
        {
            _newsPage = _pageFactoryManager.GetNewsPage();
            _newsPage.WaitForPageLoadComplete(waitTime);
            return _newsPage.GetTextSecondaryTitleByIndex(index);
        }

        public string GetTextCoronavirusSelection(double waitTime)
        {
            _newsPage = _pageFactoryManager.GetNewsPage();
            _newsPage.WaitForPageLoadComplete(waitTime);
            _newsPage.WaitVisibilityOfElement(waitTime, _newsPage.SearchButtonBy);
            return _newsPage.GetTextCoronavirusSelection();
        }

        public void ClickSearchButton()
        {
            _newsPage.ClickTheWebElement(_newsPage.SearchButton);
        }

        public void InsertTextToSearchInput(double waitTime, string searchText)
        {
            _searchPage = _pageFactoryManager.GetSearchPage();
            _searchPage.WaitVisibilityOfElement(waitTime, _searchPage.SearchInputBy);
            _searchPage.EnterInput(_searchPage.SearchInput, searchText);
        }

        public void ClickSearchRequestButton()
        {
            _searchPage.ClickTheWebElement(_searchPage.SearchButton);
        }

        public string GetTextArticleAfterSearchingByIndex(double waitTime, int index)
        {
            _resultSearchingPage = _pageFactoryManager.GetResultSearchingPage();
            _resultSearchingPage.WaitForPageLoadComplete(waitTime);
            _resultSearchingPage.ScrollToElement(_resultSearchingPage.GetSearchTitleByIndex(index));

            return _resultSearchingPage.GetTextSearchTitleByIndex(index);
        }

        public void ClickCoronavirusSelection(double waitTime)
        {
            _newsPage = _pageFactoryManager.GetNewsPage();
            _newsPage.WaitForPageLoadComplete(waitTime);
            _newsPage.ClickTheWebElement(_newsPage.CoronavirusSelection);
        }

        public void ClickCoronavirusStoriesSelection(double waitTime, int index)
        {
            _coronavirusNewsPage = _pageFactoryManager.GetCoronavirusNewsPage();
            _coronavirusNewsPage.WaitVisibilityOfElement(waitTime, _coronavirusNewsPage.CoronavirusStoriesListBy);
            _coronavirusNewsPage.ClickTheWebElement(_coronavirusNewsPage.GetCoronavirusStoryByIndex(index));
        }

        public void ClickShareCoronavirusStoryArticle(double waitTime)
        {
            _coronavirusStoriesPage = _pageFactoryManager.GetCoronavirusStoriesPage();
            _coronavirusStoriesPage.WaitForPageLoadComplete(waitTime);
            _coronavirusStoriesPage.ScrollToElement(_coronavirusStoriesPage.ShareCoronavirusStory);
            _coronavirusStoriesPage.ClickTheWebElementByJS(_coronavirusStoriesPage.ShareCoronavirusStory);
        }

        public void ClosePopUpWindow(double waitTime)
        {
            _addingStoryPage = _pageFactoryManager.GetAddingStoryPage();
            _addingStoryPage.WaitForPageLoadComplete(waitTime);
            try
            {
                _addingStoryPage.WaitVisibilityOfAllElementsLocatedBy(waitTime, _addingStoryPage.ClosePopUpWindowButtonBy);
                _addingStoryPage.ClickTheWebElement(_addingStoryPage.ClosePopUpWindowButton);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void FillStoryForm(IList<string> values)
        {
            _addingStoryPage.ScrollToElement(_addingStoryPage.AddStoryFormContainer);
            Form.FillForm(_addingStoryPage, _addingStoryPage.FormFields, values);
        }

        public void ClickAcceptTermsCheckBox()
        {
            _addingStoryPage.ClickTheWebElement(_addingStoryPage.AcceptTermsCheckBox);
        }

        public void ClickSubmitButton()
        {
            _addingStoryPage.ClickTheWebElement(_addingStoryPage.SendStoryButton);
        }

        public string GetResultParagraphAfterAddingStory(double waitTime, int index)
        {
            _addingStoryPage.WaitVisibilityOfAllElementsLocatedBy(waitTime, _addingStoryPage.ResultParagraphsAfterAddingStoryBy);
            return _addingStoryPage.GetTextResultParagraphByIndex(index);
        }

        public string GetErrorsAfterAddingStoryWIthEmptyFields(double waitTime, int index)
        {
            _addingStoryPage.WaitVisibilityOfAllElementsLocatedBy(waitTime, _addingStoryPage.ErrorMessagesBy);
            return _addingStoryPage.GetTextErrorMessageByIndex(index);
        }

        public string GetErrorAfterAddingStoryWithInvalidEmail(double waitTime)
        {
            _addingStoryPage.WaitVisibilityOfAllElementsLocatedBy(waitTime, _addingStoryPage.ErrorMessagesBy);
            return _addingStoryPage.GetTextErrorMessageByIndex(0);
        }

        public void ClickSportButton(double waitTime)
        {
            _homePage.WaitVisibilityOfElement(waitTime, _homePage.SportCategoryBy);
            _homePage.ClickTheWebElement(_homePage.SportCategory);
        }

        public void ClickFootballSection(double waitTime, int index)
        {
            _sportPage = _pageFactoryManager.GetSportPage();
            _sportPage.WaitVisibilityOfElement(waitTime, _sportPage.FootballSectionListBy);
            _sportPage.ClickTheWebElement(_sportPage.GetFootballSectionByIndex(index));
        }

        public void ClickScoresFixturesSection(double waitTime)
        {
            _footballNewsPage = _pageFactoryManager.GetFootballNewsPage();
            _footballNewsPage.WaitVisibilityOfElement(waitTime, _footballNewsPage.ScoresAndFixturesSelectionBy);
            _footballNewsPage.ClickTheWebElement(_footballNewsPage.ScoresAndFixturesSelection);
        }

        public void EnterTeamOrCompetitionInput(double waitTime, string competition)
        {
            _footballScoresAndFixturesPage = _pageFactoryManager.GetFootballScoresAndFixtures();
            _footballScoresAndFixturesPage.WaitVisibilityOfElement(waitTime, _footballScoresAndFixturesPage.SearchInputCompetitionsBy);
            _footballScoresAndFixturesPage.EnterInput(_footballScoresAndFixturesPage.SearchInputCompetitions, competition);
        }

        public void ChooseFromTheDropDownList(double waitTime, int index)
        {
            _footballScoresAndFixturesPage.WaitVisibilityOfElement(waitTime, _footballScoresAndFixturesPage.SearchResultListBy);
            _footballScoresAndFixturesPage.ScrollToElement(_footballScoresAndFixturesPage.GetSearchResultListByIndex(index));
            _footballScoresAndFixturesPage.ClickTheWebElement(_footballScoresAndFixturesPage.GetSearchResultListByIndex(index));
        }

        public void SelectMonthAndYearOfCompetition(double waitTime, string month, string year)
        {
            _footballScoresAndFixturesPage.WaitForPageLoadComplete(waitTime);

            WebElement monthAndYearWebElement = null;
            for (int i = 0; i < _footballScoresAndFixturesPage.YearAndMonthSelectList.Count; i++)
            {
                if (_footballScoresAndFixturesPage.GetTextYearByIndex(i) == year && _footballScoresAndFixturesPage.GetTextMonthByIndex(i) == month)
                {
                    monthAndYearWebElement = (WebElement)_footballScoresAndFixturesPage.GetYearAndMonthSelectByIndex(i);
                    break;
                }
            }

            if (monthAndYearWebElement != null)
            {
                _footballScoresAndFixturesPage.ClickTheWebElement(monthAndYearWebElement);
            }
            else throw new WebDriverException("Element was not found with such year and month");
        }

        public void ClickMatchWithSpecifiedTeamsAndScore(double waitTime, string team1, string team2, int score1, int score2)
        {
            _footballScoresAndFixturesPage.WaitForPageLoadComplete(waitTime);
            _footballScoresAndFixturesPage.WaitVisibilityOfAllElementsLocatedBy(waitTime, _footballScoresAndFixturesPage.TeamsListBy);

            ScoreBoard scoreBoard = new ScoreBoard();
            score = scoreBoard.GetScore(_footballScoresAndFixturesPage, team1, team2);

            if (score1 == score.ScoreTeam1 && score2 == score.ScoreTeam2)
            {
                for (int i = 0; i < _footballScoresAndFixturesPage.TeamsList.Count - 1; i++)
                {
                    if (_footballScoresAndFixturesPage.GetTextTeamByIndex(i) == team1 && _footballScoresAndFixturesPage.GetTextTeamByIndex(i + 1) == team2)
                    {
                        _footballScoresAndFixturesPage.ScrollToElement(_footballScoresAndFixturesPage.GetTeamByIndex(i));
                        _footballScoresAndFixturesPage.ClickTheWebElement(_footballScoresAndFixturesPage.GetTeamByIndex(i));
                    }
                }
            }
            else throw new WebDriverException("Found scores are not similar as in tests");
        }

        public bool CompareDisplayedScoresWithPreviousPageAndSpecifiedScores(double waitTime, int score1, int score2)
        {
            _matchResultPage = _pageFactoryManager.GetMatchResultPage();
            _matchResultPage.WaitForPageLoadComplete(waitTime);

            _matchResultPage.WaitVisibilityOfAllElementsLocatedBy(waitTime, _matchResultPage.ResultScoresListBy);
            return _matchResultPage.GetIntResultScoreByIndex(0) == score1 && _matchResultPage.GetIntResultScoreByIndex(0) == score.ScoreTeam1 &&
                    _matchResultPage.GetIntResultScoreByIndex(1) == score2 && _matchResultPage.GetIntResultScoreByIndex(1) == score.ScoreTeam2;
        }
    }
}
