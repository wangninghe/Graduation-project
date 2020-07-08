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
    public class SiteController : Controller
    {
        YACompanyEntities db = new YACompanyEntities();
        public ActionResult Index(int? page)
        {
            //第几页  三目运算符
            int pageNumber = page ?? 1;
            //每页显示多少条
            int pageSize = 5;
            //排序
            List<Site> kk = db.Site.OrderBy(p => p.SiteId).ToList();

            ///通过ToPagedList扩展方法进行分页  
            IPagedList<Site> usePageList = kk.ToPagedList(pageNumber, pageSize);
            ViewBag.course = usePageList;
            ViewBag.Staff = db.Staff.ToList();
            return View(usePageList);

        }
        // GET: Site
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Site site)
        {
            db.Site.Add(site);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            var site = db.Site.Find(ID);
            db.Site.Remove(site);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Datails(int ID)
        {
            return View(db.Site.Find(ID));
        }
        public ActionResult Eidt(int ID)
        {
            return View(db.Site.Find(ID));
        }
        [HttpPost]
        public ActionResult Edit(Site site)
        {
            db.Entry(site).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult SelectAjax(string Rid) {
            int id = Convert.ToInt32(Rid);
            List<string> str = new List<string>();
            List<Sendpeople> s= db.Sendpeople.Where(p => p.SiteID ==id ).ToList();
            s.ForEach(p => str.Add(p.StaffID.ToString()));
            return Json(str, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Ajsx(string[] StaffID,int SiteId)
        {
            var Send = db.Sendpeople.Where(p => p.SiteID == SiteId).ToList();
            foreach (var item in Send)
            {
                db.Sendpeople.Remove(item);
                db.SaveChanges();
            }           
            foreach (var item in StaffID)
            {
                Sendpeople sendpeople = new Sendpeople();
                sendpeople.StaffID = int.Parse(item.ToString());
                sendpeople.SiteID = SiteId;
                db.Sendpeople.Add(sendpeople);
                db.SaveChanges();
            }          
            return RedirectToAction("Index");
        }
    }
}