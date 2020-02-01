using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;

namespace Tests
{
    public abstract class AbstractWebPage
    {
        protected readonly Driver m_driver;

        public AbstractWebPage(Driver driver)
        {
            this.m_driver = driver;
        }
    }
}
