using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class HeroesDAL
    {
        GameShoppingEntities db = new GameShoppingEntities();
        /// <summary>
        /// 查询 返回查询的集合，注意在使用EF时，要安装EntityFramework
        /// </summary>
        /// <returns></returns>
        public List<Heroes> Select() {
            return db.Heroes.ToList();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public int Add(Heroes hero)
        {
            db.Heroes.Add(hero);
           int result =  db.SaveChanges();
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
           Heroes heroes= db.Heroes.Find(id);
            db.Heroes.Remove(heroes);
           int result =  db.SaveChanges();
            return result;
        }

        public Heroes Edit(int id)
        {
            Heroes heroes = db.Heroes.Find(id);
            return heroes;
        }

        public int EditSave(Heroes heroes)
        {
            db.Entry(heroes).State = System.Data.Entity.EntityState.Modified;
           int result =  db.SaveChanges();
            return result;
        }
    }
}
