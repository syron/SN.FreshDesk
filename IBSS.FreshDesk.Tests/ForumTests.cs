using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using IBSS.FreshDesk.Models;

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

        [Test]
        public async void GetTopic()
        {
            FreshDesk fd = new FreshDesk(Settings.ApiKey, Settings.Domain);

            topic t = await fd.GetTopic(1000065429);
        }
    }
}
