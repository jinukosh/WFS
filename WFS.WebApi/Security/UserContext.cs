using WFS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WFS.WebApi.Security
{
    public class UserContext : WFS.Entities.Interfaces.IUserContext
    {
        public bool IsLogged
        {
            get
            {
                if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated
                && HttpContext.Current.User.GetType() != typeof(Principal))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public CurrentUser CurrentUserIdentity
        {
            get
            {
                if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    //&& HttpContext.Current.User.GetType() != typeof(Principal))
                    //System.Security.Claims.ClaimsIdentity claimsIdentity = ((System.Security.Claims.ClaimsIdentity)System.Threading.Thread.CurrentPrincipal.Identity);

                    string name = ((WFS.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).Name;
                    string email = ((WFS.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).Email;
                    int userID = ((WFS.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).UserID;
                    int userType = ((WFS.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).UserType;
                   string ipaddress = ((WFS.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).IpAddress;

                    return new CurrentUser { Name = name,  Email = email , UserID = userID , UserType = userType, IpAddress = ipaddress };
                }
                else
                {
                    return null;
                }
            }            
        }
    }
}
