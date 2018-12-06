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

        public List<DishInfo> GetList()
        {
            return dishInfoDal.GetList();
        }
    }
}
