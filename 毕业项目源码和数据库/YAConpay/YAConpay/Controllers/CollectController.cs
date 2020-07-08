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
    public class CollectController : Controller
    {
        YACompanyEntities db = new YACompanyEntities();
        // GET: Collect
        public ActionResult Index(int? page)
        {
            //第几页  三目运算符
            int pageNumber = page ?? 1;
            //每页显示多少条
            int pageSize = 5;
            //排序            
            List<Collect> kk = db.Collect.OrderBy(p => p.CollectID).ToList();
            ///通过ToPagedList扩展方法进行分页  
            IPagedList<Collect> usePageList = kk.ToPagedList(pageNumber, pageSize);
            ViewBag.course = usePageList;
            return View(usePageList);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Collect collect)
        {
            db.Collect.Add(collect);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            var collect = db.Collect.Find(ID);
            db.Collect.Remove(collect);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Datails(int ID)
        {
            return View(db.Collect.Find(ID));
        }
        public ActionResult Eidt(int ID)
        {
            return View(db.Collect.Find(ID));
        }
        [HttpPost]
        public ActionResult Edit(Collect collect)
        {
            db.Entry(collect).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}