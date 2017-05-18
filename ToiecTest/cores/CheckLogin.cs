using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToiecTest.cores
{
    public class CheckLogin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Session["check"]==null)
            {
                filterContext.Result = new RedirectResult("/Admin/Account/Login");
            }
        }
    }
}