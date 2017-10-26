using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            var claims = (User as ClaimsPrincipal).Claims;
            var result = claims.Select(x => new { x.Type, x.Value });
            return Ok(result);
        }
    }
}