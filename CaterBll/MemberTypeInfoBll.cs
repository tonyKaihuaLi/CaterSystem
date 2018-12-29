using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class MemberTypeInfoBll
    {
        private MemberTypeInfoDal memberTypeInfoDal;

        public MemberTypeInfoBll()
        {
            memberTypeInfoDal=new MemberTypeInfoDal();
        }

        public List<MemberTypeInfo> GetList()
        {
            return memberTypeInfoDal.GetList();
        }

        public bool Add(MemberTypeInfo memberTypeInfo)
        {
            return MemberTypeInfoDal.Insert(memberTypeInfo) > 0;
        }

        public bool Edit(MemberTypeInfo memberTypeInfo)
        {
            return memberTypeInfoDal.Update(memberTypeInfo)>0;
        }

        public bool Remove(int id)
        {
            return memberTypeInfoDal.Delete(id) > 0;
        }
    }
}
