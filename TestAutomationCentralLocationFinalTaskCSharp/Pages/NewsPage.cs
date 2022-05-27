using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.Pages
{
    public class NewsPage : BasePage
    {
        public By TitleListBy => By.XPath("//div[contains(@class, 'top-stories-primary')]//h3[contains(@class, 'promo-heading__title')]");
        public IList<IWebElement> TitleList => WebDriver.FindElements(TitleListBy);
        public By SecondaryTitlesListBy => By.XPath("//a[@class='gs-c-promo-heading gs-o-faux-block-link__overlay-link gel-pica-bold nw-o-link-split__anchor']");
        public IList<IWebElement> SecondaryTitlesList => WebDriver.FindElements(SecondaryTitlesListBy);
        public By CoronavirusSelectionBy => By.XPath("//nav[@class='nw-c-nav__wide']//span[contains(text(), 'Coronavirus')]");
        public IWebElement CoronavirusSelection => WebDriver.FindElement(CoronavirusSelectionBy);
        public By SearchButtonBy => By.XPath("//a[@id='orbit-search-button']");
        public IWebElement SearchButton => WebDriver.FindElement(SearchButtonBy);

        public NewsPage(IWebDriver webDriver) : base(webDriver) { }

        public string GetTextTitleByIndex(int index)
        {
            return TitleList[index].Text;
        }
        public string GetTextSecondaryTitleByIndex(int index)
        {
            return SecondaryTitlesList[index].Text;
        }
        public string GetTextCoronavirusSelection()
        {
            return CoronavirusSelection.Text;
        }
    }
}
