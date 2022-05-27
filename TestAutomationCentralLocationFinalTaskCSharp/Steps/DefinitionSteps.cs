using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TestAutomationCentralLocationFinalTaskCSharp.BLL;

namespace TestAutomationCentralLocationFinalTaskCSharp.Steps
{
    [Binding]
    public sealed class DefinitionSteps
    {
        private const double DEFAULT_TIMEOUT = 60;
        WebDriver driver;
        BussinesLogicLayer businessLogicLayer;
        string buffer = "";

        [Before]
        public void TestsSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            businessLogicLayer = new BussinesLogicLayer(driver);
        }

        [After]
        public void TearDown()
        {
            driver.Quit();
        }


        [Given(@"User opens '(.*)' page")]
        public void GivenUserOpensPage(string url)
        {
            businessLogicLayer.OpenPage(url);
        }

        [Given(@"User clicks News button")]
        [When(@"User clicks News button")]
        public void WhenUserClicksNewsButton()
        {
            businessLogicLayer.ClickNewsButton(DEFAULT_TIMEOUT);
        }

        [Then(@"User checks that main (.*) article contains '(.*)'")]
        public void ThenUserChecksThatMainArticleContains(int index, string text)
        {
            Assert.AreEqual(text, businessLogicLayer.GetTextOfMainArticle(DEFAULT_TIMEOUT, index));
        }

        [Then(@"User checks first (.*) articles in '(.*)'")]
        public void ThenUserChecksFirstArticlesIn(string count, string order)
        {
            List<string> orderArticlesList = TransformToListOfString(order);
            for (int i = 0; i < count.Length; i++)
            {
                Assert.AreEqual(orderArticlesList[i], businessLogicLayer.GetTextOfSecondaryArticleByIndex(DEFAULT_TIMEOUT, i));
            }
        }

        [StepArgumentTransformation]
        public List<string> TransformToListOfString(string semicolonSeparatedList)
        {
            return semicolonSeparatedList.Split(";").ToList();
        }

        [Given(@"User copies Coronavirus selection text")]
        public void GivenUserCopiesCoronavirusSelectionText()
        {
            buffer = businessLogicLayer.GetTextCoronavirusSelection(DEFAULT_TIMEOUT);
        }

        [Given(@"User clicks Search button")]
        public void GivenUserClicksSearchButton()
        {
            businessLogicLayer.ClickSearchButton();
        }

        [Given(@"User insert copied text to Search field")]
        public void GivenUserInsertCopiedTextToSearchField()
        {
            businessLogicLayer.InsertTextToSearchInput(DEFAULT_TIMEOUT, buffer);
        }

        [When(@"User clicks Search request button")]
        public void WhenUserClicksSearchRequestButton()
        {
            businessLogicLayer.ClickSearchRequestButton();
        }

        [Then(@"User checks that (.*) article contains '(.*)'")]
        public void ThenUserChecksThatArticleContains(int index, string text)
        {
            Assert.AreEqual(text, businessLogicLayer.GetTextArticleAfterSearchingByIndex(DEFAULT_TIMEOUT, index));
        }

        [Given(@"User clicks Coronavirus selection")]
        public void GivenUserClicksCoronavirusSelection()
        {
            businessLogicLayer.ClickCoronavirusSelection(DEFAULT_TIMEOUT);
        }

        [Given(@"User clicks (.*) Your Coronavirus Stories selection")]
        public void GivenUserClicksYourCoronavirusStoriesSelection(int index)
        {
            businessLogicLayer.ClickCoronavirusStoriesSelection(DEFAULT_TIMEOUT, index);
        }


        [Given(@"User clicks How to share with BBC News article")]
        public void GivenUserClicksHowToShareWithBBCNewsArticle()
        {
            businessLogicLayer.ClickShareCoronavirusStoryArticle(DEFAULT_TIMEOUT);
        }

        [Given(@"User closes pop up window")]
        public void GivenUserClosesPopUpWindow()
        {
            businessLogicLayer.ClosePopUpWindow(DEFAULT_TIMEOUT);
        }


        [Given(@"User clicks on checkBox I accept the Terms of Service")]
        public void GivenUserClicksOnCheckBoxIAcceptTheTermsOfService()
        {
            businessLogicLayer.ClickAcceptTermsCheckBox();
        }


        [When(@"User clicks Submit button")]
        public void WhenUserClicksSubmitButton()
        {
            businessLogicLayer.ClickSubmitButton();
        }

        [Given(@"User fills form with data: story - (.*), name - (.*), email - (.*), contact number - (.*), location - (.*)")]
        public void GivenUserFillsFormWithDataStory_Name_Email_ContactNumber_Location_(string story, string name, string email, string number, string location)
        {
            IList<string> formData = new List<string>() { story, name, email, number, location};
            businessLogicLayer.FillStoryForm(formData);
        }

        [Then(@"User checks result of sending story, it must contain '(.*)' and '(.*)'")]
        public void ThenUserChecksResultOfSendingStoryItMustContainAnd(string firstParagraph, string secondParagraph)
        {
            Assert.AreEqual(firstParagraph.Replace(';', '\"'), businessLogicLayer.GetResultParagraphAfterAddingStory(DEFAULT_TIMEOUT, 0));
            Assert.AreEqual(secondParagraph, businessLogicLayer.GetResultParagraphAfterAddingStory(DEFAULT_TIMEOUT, 1));
        }

        [Then(@"User checks that error messages displayed: error story empty field - (.*), error name empty field - (.*), error acceptance terms - (.*)")]
        public void ThenUserChecksThatErrorMessagesDisplayedErrorStoryEmptyField_ErrorNameEmptyField_ErrorAcceptanceTerms_(string errorStory, string errorName, string errorTerms)
        {
            Assert.AreEqual(errorStory, businessLogicLayer.GetErrorsAfterAddingStoryWIthEmptyFields(DEFAULT_TIMEOUT, 0));
            Assert.AreEqual(errorName, businessLogicLayer.GetErrorsAfterAddingStoryWIthEmptyFields(DEFAULT_TIMEOUT, 1));
            Assert.AreEqual(errorTerms, businessLogicLayer.GetErrorsAfterAddingStoryWIthEmptyFields(DEFAULT_TIMEOUT, 2));
        }

        [Then(@"User checks error '(.*)' because of invalid email")]
        public void ThenUserChecksErrorBecauseOfInvalidEmail(string errorEmail)
        {
            Assert.AreEqual(errorEmail, businessLogicLayer.GetErrorAfterAddingStoryWithInvalidEmail(DEFAULT_TIMEOUT));
        }

        [Given(@"User clicks Sport button")]
        public void GivenUserClicksSportButton()
        {
            businessLogicLayer.ClickSportButton(DEFAULT_TIMEOUT);
        }

        [Given(@"User clicks on (.*) Football section")]
        public void GivenUserClicksOnFootballSection(int index)
        {
            businessLogicLayer.ClickFootballSection(DEFAULT_TIMEOUT, index);
        }

        [Given(@"User clicks on Scores & Fixtures section")]
        public void GivenUserClicksOnScoresFixturesSection()
        {
            businessLogicLayer.ClickScoresFixturesSection(DEFAULT_TIMEOUT);
        }

        [Given(@"User enters (.*) in Enter a team or competition input")]
        public void GivenUserEntersInEnterATeamOrCompetitionInput(string competition)
        {
            businessLogicLayer.EnterTeamOrCompetitionInput(DEFAULT_TIMEOUT, competition);
        }

        [Given(@"User chooses (.*) from the drop down list")]
        public void GivenUserChoosesFromTheDropDownList(int index)
        {
            businessLogicLayer.ChooseFromTheDropDownList(DEFAULT_TIMEOUT, index);
        }

        [Given(@"User select (.*) and (.*) of competition")]
        public void GivenUserSelectAndOfCompetition(string month, string year)
        {
            businessLogicLayer.SelectMonthAndYearOfCompetition(DEFAULT_TIMEOUT, month, year);
        }

        [When(@"User finds match between (.*) and (.*) with score for first team - (.*), and score for second team - (.*)")]
        public void WhenUserFindsMatchBetweenAndWithScoreForFirstTeam_AndScoreForSecondTeam_(string team1, string team2, int score1, int score2)
        {
            businessLogicLayer.ClickMatchWithSpecifiedTeamsAndScore(DEFAULT_TIMEOUT, team1, team2, score1, score2);
        }

        [Then(@"User compares displayed scores with scores from previous page and specified scores: (.*), (.*)")]
        public void ThenUserComparesDisplayedScoresWithScoresFromPreviousPageAndSpecifiedScores(int score1, int score2)
        {
            Assert.IsTrue(businessLogicLayer.CompareDisplayedScoresWithPreviousPageAndSpecifiedScores(DEFAULT_TIMEOUT, score1, score2));
        }
    }
}
