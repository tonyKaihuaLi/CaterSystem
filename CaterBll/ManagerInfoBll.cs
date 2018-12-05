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
        ManagerInfoDal managerInfoD = new ManagerInfoDal();
        public List<ManagerInfo> GetList()
        {
            
            return managerInfoD.GetList();
        }

        public bool Add(ManagerInfo managerInfo)
        {
            return managerInfoD.Insert(managerInfo) > 0;
        }

        public bool Edit(ManagerInfo managerInfo)
        {
            return managerInfoD.Update(managerInfo) > 0;
        }
    }
}
