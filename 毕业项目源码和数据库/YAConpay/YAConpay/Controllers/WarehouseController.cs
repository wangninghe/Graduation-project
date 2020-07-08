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
    public class WarehouseController : Controller
    {
        YACompanyEntities db = new YACompanyEntities();
        // GET: Warehouse
        public ActionResult Index(int? page)
        {
            //第几页  三目运算符
            int pageNumber = page ?? 1;
            //每页显示多少条
            int pageSize = 5;
            //排序            
            List<Warehouse> kk = db.Warehouse.OrderBy(p => p.WarehouseID).ToList();
            ///通过ToPagedList扩展方法进行分页  
            IPagedList<Warehouse> usePageList = kk.ToPagedList(pageNumber, pageSize);
            ViewBag.course = usePageList;
            return View(usePageList);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Warehouse warehouse)
        {
            db.Warehouse.Add(warehouse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            var warehouse = db.Warehouse.Find(ID);
            db.Warehouse.Remove(warehouse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Datails(int ID)
        {
            return View(db.Warehouse.Find(ID));
        }
        public ActionResult Eidt(int ID)
        {
            return View(db.Warehouse.Find(ID));
        }
        [HttpPost]
        public ActionResult Eidt(Warehouse warehouse)
        {
            db.Entry(warehouse).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}