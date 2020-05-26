using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.IO;
namespace GameShopping.Controllers
{
    public class HeroController : Controller
    {
        HeroesBLL bll = new HeroesBLL();
        // GET: Hero
        public ActionResult Default()
        {
           List<Heroes> list =  bll.SelectAllHero();
            return View(list);
        }

        public ActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(Heroes heroes,HttpPostedFileBase Photo)
        {
            if (Photo!=null)
            {
                string fileName = Path.GetFileName(Photo.FileName);
                Photo.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                heroes.Photo = fileName;
            }
           int result =  bll.AddHero(heroes);
            if (result!=0)
            {
                return RedirectToAction("Default");
            }
            return View();
        }

        public ActionResult Delete(int id) {
           int result =  bll.DeleteHero(id);
            return RedirectToAction("Default");
        }

        public ActionResult EditHero(int id)
        {
            Heroes heroes = bll.EditHero(id);
            return View(heroes);
        }
        [HttpPost]
        public ActionResult EditHero(Heroes heroes, HttpPostedFileBase cPhoto)
        {
            if (cPhoto != null)
            {
                string fileName = Path.GetFileName(cPhoto.FileName);
                cPhoto.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                heroes.Photo = fileName;
            }
            int result = bll.EditSave(heroes);
            if (result != 0)
            {
                return RedirectToAction("Default");
            }
            return View();
        }
    }
}