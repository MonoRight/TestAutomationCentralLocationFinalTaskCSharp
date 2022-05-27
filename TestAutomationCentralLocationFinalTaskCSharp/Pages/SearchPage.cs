using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class SearchPage : BasePage
    {
        public By SearchInputBy => By.XPath("//input[@id='search-input']");
        public IWebElement SearchInput => WebDriver.FindElement(SearchInputBy);
        public By SearchButtonBy => By.XPath("//button[@data-testid='test-search-submit']");
        public IWebElement SearchButton => WebDriver.FindElement(SearchButtonBy);

        public SearchPage(IWebDriver webDriver) : base(webDriver) { }
    }
}
