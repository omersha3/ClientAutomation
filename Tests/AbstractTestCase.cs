using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public abstract class AbstractTestCase
    {
        protected Driver m_driver;

        [SetUp]
        public void BeforeTest()
        {
            m_driver = new Driver(DriverCreator.CreateWebDriver());
            m_driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            m_driver.Quit();
        }

    }
}
