using WFS.Service;
using WFS.Service.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WFS.Service.Authenticate;
using System.Security.Claims;
using Microsoft.Owin.Security;
using WFS.WebApi.Security;
using System.Web;
using WFS.WebApi.Attributes;
using WFS.Entities.Models;

namespace WFS.WebApi.Controllers
{
    public class AuthenticateController : ApiController
    {
        private readonly Container _container;

        public AuthenticateController(Container container)
            : base()
        {
            _container = container;
        }


        [HttpPost]
        public string Authenticate(string Email, string Password)
        {
            AuthenticateService service = new AuthenticateService(_container);

            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                var user = service.Authenticate(Email, Password);
                if (user != null)
                {
                    var authentication = Request.GetOwinContext().Authentication;
                    var identity = new ClaimsIdentity("Bearer");
                    identity.AddClaim(new Claim("name", user.Name));
                    identity.AddClaim(new Claim("email", user.Email));
                    identity.AddClaim(new Claim("userid", user.Id.ToString()));
                    identity.AddClaim(new Claim("usertype", user.UserType.ToString()));
                   
                    AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
                    var currentUtc = new Microsoft.Owin.Infrastructure.SystemClock().UtcNow;
                    ticket.Properties.IssuedUtc = currentUtc;
                    ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));
                    var token = Startup.OAuthServerOptions.AccessTokenFormat.Protect(ticket);

                    authentication.SignIn(identity);

                    return token;
                }
            }

            return "false";
        }

        [ClientAuthorize]
        [HttpGet]
        public CurrentUser Get()
        {
            var user = ((Identity)HttpContext.Current.User.Identity);
            return new CurrentUser
            {
                UserID = user.UserID,
                UserType  = user.UserType,
                Name = user.Name,
                Email = user.Email,
            };
        }

    }
}

