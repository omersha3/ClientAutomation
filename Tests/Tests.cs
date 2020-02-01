using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Tests.PageObjects;

namespace Tests
{
    [TestFixture]
    class Tests : AbstractTestCase
    {
        [Test]
        public void Test1()
        {
            m_driver.Navigate().GoToUrl("https://www.gmail.com");
            
            //SignIn
            SignInPage signInPage = new SignInPage(m_driver);
            signInPage.SignIn("omersha3@gmail.com", "Shani5863");

            //ComposeNewMail
            MainGmailPage mainGmailPage = new MainGmailPage(m_driver);
            mainGmailPage.SendNewMail("omersha3@gmail.com", "Automation Test", "This is Test #1, and it should pass");

            //Verify mail located in sent items
            mainGmailPage.ClickOnSent();

            SentItemsPage sentItemsPage = new SentItemsPage(m_driver);
            bool isDiplayed = sentItemsPage.IsMessegeDisplayed("Automation Test");
            Assert.True(isDiplayed);
        }

       
    }
}
