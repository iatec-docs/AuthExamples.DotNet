using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(AuthExamples.ProtectedWebApi.Startup))]

namespace AuthExamples.ProtectedWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();
            app.UseWebApi(httpConfig);
        }
    }
}
