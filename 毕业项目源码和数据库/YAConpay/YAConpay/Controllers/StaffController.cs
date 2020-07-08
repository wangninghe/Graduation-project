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
    public class StaffController : Controller
    {
        YACompanyEntities db = new YACompanyEntities();
        // GET: Staff/ 
        public ActionResult Index(int ? page)
        {
            //第几页  三目运算符
            int pageNumber = page ?? 1;
            //每页显示多少条
            int pageSize = 5;
            //排序
            List<Staff> kk = db.Staff.OrderBy(p => p.StaffID).ToList();

            ///通过ToPagedList扩展方法进行分页  
            IPagedList<Staff> usePageList = kk.ToPagedList(pageNumber, pageSize);
            ViewBag.course = usePageList;
            return View(usePageList);
           
        }
        public ActionResult Insert()
        {
            ViewBag.post = db.Post.ToList();
            ViewBag.dorm = db.Dorm.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Staff staff)
        {
            db.Staff.Add(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Datails(int ID)
        {
            return View(db.Staff.Find(ID));
        }
        public ActionResult Edit(int ID)
        {
            ViewBag.post = db.Post.ToList();
            ViewBag.dorm = db.Dorm.ToList();
            return View(db.Staff.Find(ID));
        }
        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            db.Entry(staff).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            var staff = db.Staff.Find(ID);
            db.Staff.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}