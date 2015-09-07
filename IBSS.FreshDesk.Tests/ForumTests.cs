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
            FreskDesk fd = new FreskDesk(Settings.ApiKey, Settings.Domain);
            
            forum t = await fd.GetForum(1000227207);
        }
    }
}
