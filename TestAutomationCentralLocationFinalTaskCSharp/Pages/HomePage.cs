using OpenQA.Selenium;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class HomePage : BasePage
    {
        public By NewsCategoryBy => By.XPath("//nav[@class='orbit-header-links international']//span[text()='News']");
        public IWebElement NewsCategory => WebDriver.FindElement(NewsCategoryBy);
        public By SportCategoryBy => By.XPath("//nav[@class='orbit-header-links international']//span[text()='Sport']");
        public IWebElement SportCategory => WebDriver.FindElement(SportCategoryBy);

        public HomePage(IWebDriver webDriver) : base(webDriver)
        {

        }
        public void OpenHomePage(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }
    }
}
