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
    public class TicketTests : BaseTestClass
    {
        [TestMethod]
        public async Task GetTickets()
        {
            List<ticket> t = await fd.GetNewAndOpenTickets();
        }

        [TestMethod]
        public async Task GetTicket()
        {
            ticket t = await fd.GetTicket(640);
        }

        [TestMethod]
        public async Task AdministrateTicketTests()
        {
            var t = new request_create_ticket();

            create_ticket ticket = new create_ticket();
            ticket.description = "API Created ticket";
            ticket.subject = "New ticket - support needed";
            ticket.email = "rwlmayer@gmail.com";
            ticket.priority = ticket_priority.High;
            ticket.status = ticket_status.Pending;

            t.helpdesk_ticket = ticket;

            var createdTicket = await fd.CreateTicket(t);

            createdTicket = await fd.GetTicket(createdTicket.display_id);


            update_ticket up_ticket = new update_ticket(createdTicket);

            up_ticket.status = ticket_status.Closed;

            request_update_ticket req_up_ticket = new request_update_ticket();
            req_up_ticket.helpdesk_ticket = up_ticket;


            await fd.UpdateTicket(createdTicket.display_id, req_up_ticket);
            
            await fd.DeleteTicket(createdTicket.display_id);
        }
    }
}
