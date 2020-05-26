using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
namespace GameShopping.Controllers
{
    public class GoodsController : Controller
    {
        GameShoppingEntities db = new GameShoppingEntities();
        
        // GET: Goods
        public ActionResult Index(int? typeId)
        {
            List<Good> gList = db.Good.Where(p => typeId == null || p.TypeID == typeId).ToList();
            ViewBag.TypeList = db.Type.ToList();
            ViewBag.shopCarCount = db.ShopCar.Count();
            return View(gList);
        }

        public ActionResult ShoppingCar()
        {
            return View(db.ShopCar.ToList());
        }

        public void AddCart(int GoodId)
        {
            ShopCar shop = new ShopCar()
            {
                GoodID = GoodId
            };
            db.ShopCar.Add(shop);
            db.SaveChanges();
        }
    }
}