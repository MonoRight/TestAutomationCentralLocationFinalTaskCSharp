using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationCentralLocationFinalTaskCSharp.Pages;

namespace TestAutomationCentralLocationFinalTaskCSharp.BLL
{
    public static class Form
    {
        public static void FillForm(BasePage page, IList<IWebElement> inputs, IList<string> values)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                page.ClickTheWebElement(inputs[i]);
                page.EnterInput(inputs[i], values[i]);
            }
        }
    }
}
