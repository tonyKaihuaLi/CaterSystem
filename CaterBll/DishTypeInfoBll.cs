using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class DishTypeInfoBll
    {
        private DishTypeInfoDal dishTypeInfoDal = new DishTypeInfoDal();

        public List<DishTypeInfo> GetList()
        {
            return dishTypeInfoDal.GetList();
        }
    }
}
