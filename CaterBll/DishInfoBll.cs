using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class DishInfoBll
    {
        private DishInfoDal dishInfoDal= new DishInfoDal();

        public List<DishInfo> GetList(Dictionary<string,string> dictionary)
        {
            return dishInfoDal.GetList(dictionary);
        }

        public bool Add(DishInfo dishInfo)
        {
            return dishInfoDal.Insert(dishInfo) > 0;
        }

        public bool Update(DishInfo dishInfo)
        {
            return dishInfoDal.Update(dishInfo) > 0;
;       }

        public bool Delete(int id)
        {
            return dishInfoDal.Delete(id) > 0;
        }
    }

    
}
