using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using OpenQA.Selenium;

namespace Tests.PageObjects
{
    public class SignInPage: AbstractWebPage
    {
        private readonly By c_emailBox = By.Id("identifierId");
        private readonly By c_passwordBox = By.XPath("//div[@id='password']//input");
        private readonly By c_nextButton = By.XPath("//div[contains(@id,'Next')]");

        public SignInPage(Driver driver) : base(driver)
        {
        }

        public SignInPage TypeToEmailAddressBox(string email)
        {
            m_driver.TypeToElement(c_emailBox, "Email box", email);
            return this;
        }

        public SignInPage ClickOnNextButton()
        {
            m_driver.ClickOnElement(c_nextButton, "Next button");
            return this;
        }

        public SignInPage TypeToPasswordBox(string password)
        {
            m_driver.ClickOnElement(c_passwordBox, "Password box");
            m_driver.TypeToElement(c_passwordBox, "Password box", password);
            return this;
        }

        public SignInPage SignIn(string email, string password)
        {
            TypeToEmailAddressBox(email).ClickOnNextButton().TypeToPasswordBox(password).ClickOnNextButton();
            return this;
        }

        
    }
}
