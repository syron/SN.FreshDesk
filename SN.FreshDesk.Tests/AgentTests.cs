using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN.FreshDesk.Tests
{
    [TestClass]
    public class AgentTests : BaseTestClass
    {
        [TestMethod]
        public async Task GetCurrentAgent()
        {
            var a =  await fd.GetCurrentlyAuthenticatedAgent();
            Assert.IsTrue(a.available);
        }

    }
}
