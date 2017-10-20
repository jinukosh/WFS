using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace WFS.WebApi.Security
{
    public class Identity : IIdentity
    {
        private string _name;
        private string _email;
        private int _userID;
        private int _userType;
        private string _ipaddress;

        public Identity(string name, int userID, string email, int userType, string ipaddress)
        {
            _userID = userID;
            _email = email;
            _name = name;
            _userType = userType;
             _ipaddress = ipaddress;
        }

        public int UserID
        {
            get { return _userID; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string AuthenticationType
        {
            get { return "Bearer"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int UserType
        {
            get { return _userType; }
        }

        public string IpAddress
        {
            get { return _ipaddress; }
        }
    }
}