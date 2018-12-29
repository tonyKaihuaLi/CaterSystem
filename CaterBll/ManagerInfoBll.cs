using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterCommon;
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

        public bool Remove(int id)
        {
            return managerInfoD.Delete(id) > 0;
        }

        public LoginState Login(string name, string pwd, out int type)
        {
            ManagerInfo managerInfo = managerInfoD.GetByName(name);
            if (managerInfo == null)
            {
                type = 0;
                return LoginState.NameError;
            }
            else
            {
                if (managerInfo.MPwd.Equals(MD5Helper.EncryptString(pwd)))
                {
                    type = managerInfo.MType;
                    return LoginState.Ok;
                }
                else
                {
                    type = 0;
                    return LoginState.PwdError;
                }
            }

        }
    }
}
