using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YAConpay.Models;
namespace YAConpay.Controllers
{
    [Login]
    public class BuyController : Controller
    {
        YACompanyEntities db = new YACompanyEntities();
        // GET: Buy
        public ActionResult Index(int? page)
        {
            //第几页  三目运算符
            int pageNumber = page ?? 1;
            //每页显示多少条
            int pageSize = 5;
            //排序            
            List<Buy> kk = db.Buy.OrderBy(p => p.Buy1).ToList();
            ///通过ToPagedList扩展方法进行分页  
            IPagedList<Buy> usePageList = kk.ToPagedList(pageNumber, pageSize);
            ViewBag.course = usePageList;
            return View(usePageList);

        }
        public ActionResult Create()
        {
            ViewBag.wh = db.Warehouse.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Buy buy)
        {
            db.Buy.Add(buy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            var buy = db.Buy.Find(ID);
            db.Buy.Remove(buy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Datails(int ID)
        {
            return View(db.Buy.Find(ID));
        }
        public ActionResult Eidt(int ID)
        {
            ViewBag.wh = db.Warehouse.ToList();
            return View(db.Buy.Find(ID));
        }
        [HttpPost]
        public ActionResult Eidt(Buy buy)
        {
            db.Entry(buy).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}