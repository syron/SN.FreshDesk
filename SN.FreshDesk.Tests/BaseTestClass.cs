using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN.FreshDesk.Tests
{
    [TestClass]
    public class BaseTestClass
    {
        protected FreshDesk fd = null;

        public BaseTestClass()
        {
             fd = new FreshDesk(Settings.ApiKey, Settings.Domain);
        }
    }
}
