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


            await fd.AssignTicket(createdTicket.display_id, 1000734716);


            update_ticket up_ticket = new update_ticket(createdTicket);

            up_ticket.status = ticket_status.Closed;

            request_update_ticket req_up_ticket = new request_update_ticket();
            req_up_ticket.helpdesk_ticket = up_ticket;


            await fd.UpdateTicket(createdTicket.display_id, req_up_ticket);
            

            await fd.DeleteTicket(createdTicket.display_id);

            await fd.RestoreTicket(createdTicket.display_id);

            await fd.DeleteTicket(createdTicket.display_id);
        }


    }
}
