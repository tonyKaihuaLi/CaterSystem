using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class MemberInfoBll
    {
        private MemberInfoDal memberInfoDal= new MemberInfoDal();

        public List<MemberInfo> GetList(Dictionary<string,string> dic)
        {
            return memberInfoDal.GetList(dic);
        }

        public bool Add(MemberInfo managerInfo)
        {
            return MemberInfoDal.Insert(managerInfo)>0;

        }

        public bool Edit(MemberInfo memberInfo)
        {
            return memberInfoDal.Update(memberInfo) > 0;
        }

        public bool Remove(int id)
        {
            return memberInfoDal.Delete(id) > 0;
        }
    }
}
