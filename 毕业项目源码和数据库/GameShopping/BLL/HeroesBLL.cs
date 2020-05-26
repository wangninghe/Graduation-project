using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class HeroesBLL
    {
        //DAL层定义的方法，非静态方法，需要实例化才可调用
        HeroesDAL dal = new HeroesDAL();
        /// <summary>
        /// 业务逻辑层的查询所有英雄的方法
        /// </summary>
        /// <returns></returns>
        public List<Heroes> SelectAllHero() {
          return  dal.Select();
        }

        public int AddHero(Heroes hero)
        {
            return dal.Add(hero);
        }

        public int DeleteHero(int id)
        {
            return dal.Delete(id);
        }

        public Heroes EditHero(int id) {
            return dal.Edit(id);
        }

        public int EditSave(Heroes heroes)
        {
            return dal.EditSave(heroes);
        }
    }
}
