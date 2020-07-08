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
    public class GoodsController : Controller
    {
        YACompanyEntities db = new YACompanyEntities();
        // GET: Goods
        public ActionResult Index(int? page)
        {
            //第几页  三目运算符
            int pageNumber = page ?? 1;
            //每页显示多少条
            int pageSize = 5;
            //排序            
            List<Goods> kk = db.Goods.OrderBy(p => p.GoodsId).ToList();
            ///通过ToPagedList扩展方法进行分页  
            IPagedList<Goods> usePageList = kk.ToPagedList(pageNumber, pageSize);
            ViewBag.course = usePageList;
            return View(usePageList);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Goods goods)
        {
            db.Goods.Add(goods);
            Pay pay = new Pay();
            pay.PayName = goods.GoodsName;
            pay.PaytMoney = goods.GoodsMoney;
            pay.PayTime = goods.GoodsTime;
            pay.PayDetai = goods.GoodsDetai;
            pay.PayReason = goods.GoodsReason;
            db.Pay.Add(pay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            var goods = db.Goods.Find(ID);
            db.Goods.Remove(goods);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Datails(int ID)
        {
            return View(db.Goods.Find(ID));
        }
        public ActionResult Eidt(int ID)
        {
            return View(db.Goods.Find(ID));
        }
        [HttpPost]
        public ActionResult Edit(Goods goods)
        {
            db.Entry(goods).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}