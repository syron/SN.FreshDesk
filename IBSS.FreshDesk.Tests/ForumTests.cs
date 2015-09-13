using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using IBSS.FreshDesk.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace IBSS.FreshDesk.Tests
{
    [TestClass]
    public class ForumTests : BaseTestClass
    {

        [TestMethod]
        public async Task GetListOfForums()
        {
            forum t = await fd.GetForum(1000227207);
        }

        [TestMethod]
        public async Task GetTopic()
        {
            topic t = await fd.GetTopic(1000065429);
        }

        [TestMethod]
        public async Task CreateForum()
        {
            Models.Requests.forum forum = new Models.Requests.forum();
            forum.description = "Ticket related functions";
            forum.forum_type = Models.forum_type.HowTo;
            forum.forum_category_id = 1;
            forum.forum_visibility = Models.forum_visibility.Anyone;
            forum.name = "Ticket Operations";
            //await fd.CreateForum(forum);
        }

        [TestMethod]
        public async Task GetForumCategories()
        {
            var categories = await fd.GetForumCategories();
        }
    }
}
