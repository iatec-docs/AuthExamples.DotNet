using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(AuthExamples.ProtectedWebApi.Startup))]

namespace AuthExamples.ProtectedWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll); // Enable CORS support
            var idsrvAuthOptions = new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://login-dev.sdasystems.org/", // points to development environment

                // development credentials 
                ClientId = "demoapi",
                ClientSecret = "secret123",

                // validates the token in the server in order to provide single-sign-off
                ValidationMode = ValidationMode.ValidationEndpoint,
                RequiredScopes = new[] { "demoapi" },

            };
            app.UseIdentityServerBearerTokenAuthentication(idsrvAuthOptions);
            var httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();
            app.UseWebApi(httpConfig);
        }
    }
}
