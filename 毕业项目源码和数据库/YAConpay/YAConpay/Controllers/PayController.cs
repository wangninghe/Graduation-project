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
    public class PayController : Controller
    {
        YACompanyEntities db = new YACompanyEntities();
        // GET: Pay
        public ActionResult Index(int? page)
        {
            //第几页  三目运算符
            int pageNumber = page ?? 1;
            //每页显示多少条
            int pageSize = 5;
            //排序            
            List<Pay> kk = db.Pay.OrderBy(p => p.PayID).ToList();
            ///通过ToPagedList扩展方法进行分页  
            IPagedList<Pay> usePageList = kk.ToPagedList(pageNumber, pageSize);
            ViewBag.course = usePageList;
            return View(usePageList);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Pay pay)
        {
            db.Pay.Add(pay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            var pay = db.Pay.Find(ID);
            db.Pay.Remove(pay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Datails(int ID)
        {
            return View(db.Pay.Find(ID));
        }
        public ActionResult Eidt(int ID)
        {
            return View(db.Pay.Find(ID));
        }
        [HttpPost]
        public ActionResult Edit(Pay pay)
        {
            db.Entry(pay).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}