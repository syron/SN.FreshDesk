using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Linq;
using SN.FreshDesk.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using SN.FreshDesk.Models;

namespace SN.FreshDesk.Tests
{
    [TestClass]
    public class ForumTests : BaseTestClass
    {

        [TestMethod]
        public async Task GetForum()
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
            // get categories
            var categories = await fd.GetForumCategories();

            forum forum = new forum();
            forum.description = "Ticket related functions";
            forum.forum_type = Models.forum_type.HowTo;
            forum.forum_category_id = categories.First().forum_category.id;
            forum.forum_visibility = Models.forum_visibility.Anyone;
            forum.name = "Ticket Operations";

            //await fd.CreateForum(forum);
        }

        [TestMethod]
        public async Task DeleteForum()
        {
            //await fd.DeleteForum(1000228599);
        }

        [TestMethod]
        public async Task GetForumCategories()
        {
            var categories = await fd.GetForumCategories();
        }

        [TestMethod]
        public async Task GetForumCategory()
        {
            var categories = await fd.GetForumCategories();

            var category = await fd.GetForumCategory(categories.First().forum_category.id);
        }
    }
}
