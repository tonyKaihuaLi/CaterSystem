using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class HallInfoBll
    {
        private HallInfoDal hallInfoDal;

        public HallInfoBll()
        {
            hallInfoDal=new HallInfoDal();
        }

        public List<HallInfo> GetList()
        {
            return hallInfoDal.GetList();
        }

        public bool Add(HallInfo hallInfo)
        {
            return hallInfoDal.Insert(hallInfo) > 0;
        }

        public bool Edit(HallInfo hallInfo)
        {
            return hallInfoDal.Update(hallInfo) > 0;
        }

        public bool Remove(int id)
        {
            return hallInfoDal.Delete(id) > 0;
        }
    }
}
