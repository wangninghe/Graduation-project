using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YAConpay.Models;
namespace YAConpay.Controllers
{
    public class LoginController : Controller
    {
        YACompanyEntities db = new YACompanyEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (db.Login.SingleOrDefault(p=>p.Name==login.Name&&p.PWd==login.PWd) !=null)
            {
                Session["Name"] = login.Name;
                return RedirectToAction("Index1","Home");
            }
            return View();
        }
    }
}