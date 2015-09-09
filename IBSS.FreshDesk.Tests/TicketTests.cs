using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IBSS.FreshDesk.Models.Responses;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Tests
{
    [TestClass]
    public class TicketTests
    {
        [TestMethod]
        public async Task GetTickets()
        {
            FreshDesk fd = new FreshDesk(Settings.ApiKey, Settings.Domain);

            List<ticket> t = await fd.GetTickets();
        }
    }
}
