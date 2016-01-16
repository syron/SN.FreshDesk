using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SN.FreshDesk.Models.Responses;
using System.Threading.Tasks;
using SN.FreshDesk.Models;
using SN.FreshDesk.Models.Requests;

namespace SN.FreshDesk.Tests
{
    [TestClass]
    public class CustomerTests : BaseTestClass
    {
        [TestMethod]
        public async Task GetCustomers()
        {
            List<customer> t = await fd.GetCustomers();
        
            Assert.IsNotNull(t);
        }
    }
}
