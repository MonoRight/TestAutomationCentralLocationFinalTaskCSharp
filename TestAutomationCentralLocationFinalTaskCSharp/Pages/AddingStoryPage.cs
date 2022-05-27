using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class AddingStoryPage : BasePage
    {
        public By AddStoryFormContainerBy => By.XPath("//div[@class='embed-content-container']");
        public IWebElement AddStoryFormContainer => WebDriver.FindElement(AddStoryFormContainerBy);
        public By StoryInputBy => By.XPath("//textarea[@class='text-input--long']");
        public IWebElement StoryInput => WebDriver.FindElement(StoryInputBy);
        public By NameInputBy => By.XPath("//input[@placeholder='Name']");
        public IWebElement NameInput => WebDriver.FindElement(NameInputBy);
        public By EmailInputBy => By.XPath("//input[@placeholder='Email address']");
        public IWebElement EmailInput => WebDriver.FindElement(EmailInputBy);
        public By TelephoneInputBy => By.XPath("//input[@placeholder='Contact number ']");
        public IWebElement TelephoneInput => WebDriver.FindElement(TelephoneInputBy);
        public By LocationInputBy => By.XPath("//input[@placeholder='Location ']");
        public IWebElement LocationInput => WebDriver.FindElement(LocationInputBy);
        public By AcceptTermsCheckBoxBy => By.XPath("//p[contains(text(), 'I accept')]");
        public IWebElement AcceptTermsCheckBox => WebDriver.FindElement(AcceptTermsCheckBoxBy);
        public By SendStoryButtonBy => By.XPath("//button[@class='button']");
        public IWebElement SendStoryButton => WebDriver.FindElement(SendStoryButtonBy);
        public By ResultParagraphsAfterAddingStoryBy => By.XPath("//div[@class='section-header-group__section-subheader']//p");
        public IList<IWebElement> ResultParagraphsAfterAddingStory => WebDriver.FindElements(ResultParagraphsAfterAddingStoryBy);
        public By ErrorMessagesBy => By.XPath("//div[@class='input-error-message']");
        public IList<IWebElement> ErrorMessages => WebDriver.FindElements(ErrorMessagesBy);
        public IList<IWebElement> FormFields => new List<IWebElement>() { StoryInput, NameInput, EmailInput, TelephoneInput, LocationInput };


        public AddingStoryPage(IWebDriver webDriver) : base(webDriver) { }

        public string GetTextResultParagraphByIndex(int index)
        {
            return ResultParagraphsAfterAddingStory[index].Text;
        }

        public string GetTextErrorMessageByIndex(int index)
        {
            return ErrorMessages[index].Text;
        }
    }
}
