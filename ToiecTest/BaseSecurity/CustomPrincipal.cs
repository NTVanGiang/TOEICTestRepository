using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc.Html;

namespace ToiecTest.BaseSecurity
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public CustomPrincipal(string UserName)
        {
            this.Identity = new GenericIdentity(UserName);
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}