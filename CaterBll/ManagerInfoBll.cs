using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class ManagerInfoBll
    {
        public List<ManagerInfo> GetList()
        {
            ManagerInfoDal managerInfoDal = new ManagerInfoDal();
            return managerInfoDal.GetList();
        }

    }
}
