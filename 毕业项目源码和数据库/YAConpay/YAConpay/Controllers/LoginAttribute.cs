using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YAConpay.Controllers
{
    public class LoginAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session["Name"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }
        }
    }
}