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
    public class ForumTests
    {

        [TestMethod]
        public async Task GetListOfForums()
        {
            FreshDesk fd = new FreshDesk(Settings.ApiKey, Settings.Domain);
            
            forum t = await fd.GetForum(1000227207);
        }

        [TestMethod]
        public async Task GetTopic()
        {
            FreshDesk fd = new FreshDesk(Settings.ApiKey, Settings.Domain);

            topic t = await fd.GetTopic(1000065429);
        }
    }
}
