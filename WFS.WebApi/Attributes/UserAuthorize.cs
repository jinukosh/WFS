﻿using WFS.WebApi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WFS.Entities.Enumerations;

namespace WFS.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class UserAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated 
                && HttpContext.Current.User.GetType() != typeof(Principal))
            {
                System.Security.Claims.ClaimsIdentity claimsIdentity = ((System.Security.Claims.ClaimsIdentity)System.Threading.Thread.CurrentPrincipal.Identity);

                string name = claimsIdentity.FindFirst("name").Value;
                string email = claimsIdentity.FindFirst("email").Value;
                int userID = Convert.ToInt32(claimsIdentity.FindFirst("userid").Value);
                int userType = Convert.ToInt32(claimsIdentity.FindFirst("usertype").Value);
                string ipaddress = claimsIdentity.FindFirst("ipaddress").Value;

                if (userType == (int)UserType.Admin || userType == (int)UserType.User)
                {
                    HttpContext.Current.User =
                    System.Threading.Thread.CurrentPrincipal = new Principal(new Identity(name, userID, email, userType, ipaddress));
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
        }
    }
}