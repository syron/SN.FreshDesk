using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using IBSS.FreshDesk.Models.Responses;

namespace IBSS.FreshDesk.Tests
{
    [TestFixture]
    public class ForumTests
    {

        [Test]
        public async void GetListOfForums()
        {
            FreshDesk fd = new FreshDesk(Settings.ApiKey, Settings.Domain);
            
            forum t = await fd.GetForum(1000227207);
        }

        //[Test]
        //public async void CreateForum()
        //{
        //    FreshDesk fd = new FreshDesk(Settings.ApiKey, Settings.Domain);

        //    forum t = await fd.CreateForum(new Models.Requests.forum()
        //    {
        //        name = "Unit test",
        //        description = "Forum created by unit test",
        //        forum_visibility = 1,
        //        forum_category_id = 1,
        //        forum_type = 2
        //    });
        //}

        [Test]
        public async void GetTopic()
        {
            FreshDesk fd = new FreshDesk(Settings.ApiKey, Settings.Domain);

            topic t = await fd.GetTopic(1000065429);
        }
    }
}
