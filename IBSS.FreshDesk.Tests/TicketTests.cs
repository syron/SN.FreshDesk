using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IBSS.FreshDesk.Models.Responses;
using System.Threading.Tasks;
using IBSS.FreshDesk.Models;

namespace IBSS.FreshDesk.Tests
{
    [TestClass]
    public class TicketTests : BaseTestClass
    {
        [TestMethod]
        public async Task GetTickets()
        {
            List<ticket> t = await fd.GetTickets();
        }

        [TestMethod]
        public async Task GetTicket()
        {
            ticket t = await fd.GetTicket(598);
        }
    }
}
