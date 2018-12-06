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

        public List<MemberInfo> GetList()
        {
            return memberInfoDal.GetList();
        }
    }
}
