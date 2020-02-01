using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace Infra
{
    public class Driver : EventFiringWebDriver
    {

        private WebDriverWait m_explicitWait;

        public Driver(IWebDriver parentDriver) : base(parentDriver)
        {
            m_explicitWait = new WebDriverWait(parentDriver, TimeSpan.FromMilliseconds(5000));
            m_explicitWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            m_explicitWait.PollingInterval = TimeSpan.FromMilliseconds(250);
        }

        public Driver ClickOnElement(By searchMechanisam, string description)
        {
            IWebElement element = FindElement(searchMechanisam);
            element.Click();
            WaitCondition(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element), 1000);
            Report($"Clicked on {description}");
            return this;
        }

        private void Report(string v)
        {
            
        }

        public Driver TypeToElement(By searchMechanisam, string description, string textToType)
        {
            IWebElement element = FindElement(searchMechanisam);
            element.SendKeys(textToType);
            Report($"Typed to {description} {textToType}");
            return this;
        }

        public Driver WaitCondition(Func<IWebDriver, IWebElement> conditionFunc, int timeoutInMilliseconds)
        {

            WebDriverWait explicitWait = new WebDriverWait(this, TimeSpan.FromMilliseconds(timeoutInMilliseconds));
            explicitWait.Until(conditionFunc);
            return this;

        }

        public string GetTextFromElement(By searchMechanisam)
        {
            IWebElement element = FindElement(searchMechanisam);
            return element.Text;
        }
       
    }
}
