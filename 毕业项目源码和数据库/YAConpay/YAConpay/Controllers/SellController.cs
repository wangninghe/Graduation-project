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
    public class SellController : Controller
    {
        YACompanyEntities db = new YACompanyEntities();
        // GET: Sell
        public ActionResult Index(int? page)
        {
            //第几页  三目运算符
            int pageNumber = page ?? 1;
            //每页显示多少条
            int pageSize = 5;
            //排序            
            List<Sell> kk = db.Sell.OrderBy(p => p.SellID).ToList();
            ///通过ToPagedList扩展方法进行分页  
            IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
            ViewBag.course = usePageList;
            return View(usePageList);

        }
        public ActionResult Create()
        {
            ViewBag.wh = db.Warehouse.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Sell sell)
        {
            db.Sell.Add(sell);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            var sell = db.Sell.Find(ID);
            db.Sell.Remove(sell);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Datails(int ID)
        {
            return View(db.Sell.Find(ID));
        }
        public ActionResult Eidt(int ID)
        {
            ViewBag.wh = db.Warehouse.ToList();
            return View(db.Sell.Find(ID));
        }
        [HttpPost]
        public ActionResult Eidt(Sell sell)
        {
            db.Entry(sell).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}