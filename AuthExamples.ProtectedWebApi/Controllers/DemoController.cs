using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AuthExamples.ProtectedWebApi.Controllers
{
    [Authorize]
    [RoutePrefix("demo")]
    public class DemoController : ApiController
    {
        [HttpGet, Route("test")]
        public IHttpActionResult Test()
        {
            return Ok("Hello World!");
        }
    }
}