using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using OpenQA.Selenium;

namespace Tests.PageObjects
{
    public class MainGmailPage : AbstractWebPage
    {
        private readonly By c_composeButton = By.XPath("//*[@role='button' and (.)='Compose']");
        private readonly By c_toBox = By.XPath(".//textarea[contains(@aria-label, 'To')]");
        private readonly By c_subjectBox = By.Name("subjectbox");
        private readonly By c_bodyBox = By.XPath(" .//*[@role='textbox' and @aria-label='Message Body']");
        private readonly By c_sendButton = By.XPath("//*[@role='button' and (.)='Send']");
        private readonly By c_sentButton = By.XPath("//*[@title='Sent']");

        public MainGmailPage(Driver driver) : base(driver)
        {

        }

        internal void SendNewMail(string recipient, string subject, string body)
        {
            ClickOnCompose().TypeToRecipients(recipient).TypeToSubject(subject).FillBody(body).ClickOnSend();
        }

        internal MainGmailPage ClickOnSent()
        {
            m_driver.ClickOnElement(c_sentButton, "Sent button");
            return this;
        }

        private MainGmailPage ClickOnSend()
        {
            m_driver.ClickOnElement(c_sendButton, "Send button");
            return this;
        }

        private MainGmailPage TypeToRecipients(string recipient)
        {
            m_driver.TypeToElement(c_toBox, "Recipients box", recipient);
            return this;
        }

        private MainGmailPage TypeToSubject(string subject)
        {
            m_driver.TypeToElement(c_subjectBox, "Subject box", subject);
            return this;
        }

        private MainGmailPage FillBody(string body)
        {
            m_driver.TypeToElement(c_bodyBox, "Body Textbox", body);
            return this;
        }

        private MainGmailPage ClickOnCompose()
        {
            m_driver.ClickOnElement(c_composeButton, "Compose button");
            return this;
        }
    }
}
