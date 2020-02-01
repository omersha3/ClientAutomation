using Infra;
using OpenQA.Selenium;

namespace Tests.PageObjects
{
    public class SentItemsPage : AbstractWebPage
    {
        private readonly By c_emailThread = By.XPath("//span[@class='bog'");

        public SentItemsPage(Driver driver) : base(driver)
        {
        }

        public bool IsMessegeDisplayed(string messageTitle)
        {
            var elements = m_driver.FindElements(c_emailThread);
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Text.Contains(messageTitle))
                    return true;
            }

            return false;
        }
    }
}