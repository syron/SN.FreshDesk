using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SN.FreshDesk.Connector.Controllers
{
    public class TestController : ApiController
    {
        public TestMessageResponse Get()
        {

            return new TestMessageResponse() { Message = "Hello World" };
        }

        private HttpResponseMessage Unauthorized()
        {
            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }

    public class TestMessageResponse
    {
        public string Message { get; set; }
    }
}
