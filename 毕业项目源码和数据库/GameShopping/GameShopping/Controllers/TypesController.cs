using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
namespace GameShopping.Controllers
{
    
    public class TypesController : Controller
    {
        GameShoppingEntities db = new GameShoppingEntities();

        // GET: Types
        public ActionResult Index()
        {
            return View(db.Type.ToList());
        }

        [HttpPost]
        public ActionResult FindChildren(int Pid)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var typeList =  db.Type.Where(p => p.PID == Pid);
            return Json(typeList);
        }
    }
}