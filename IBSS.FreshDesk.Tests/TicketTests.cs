using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IBSS.FreshDesk.Models.Responses;
using System.Threading.Tasks;
using IBSS.FreshDesk.Models;
using IBSS.FreshDesk.Models.Requests;

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

        [TestMethod]
        public async Task CreateTicket()
        {
            var t = new request_ticket();

            create_ticket ticket = new create_ticket();
            ticket.description = "API Created ticket";
            ticket.subject = "New ticket - support needed";
            ticket.email = "rwlmayer@gmail.com";
            ticket.priority = ticket_priority.Low;
            ticket.status = ticket_status.Open;

            t.helpdesk_ticket = ticket;

            await fd.CreateTicket(t);
        }
    }
}
