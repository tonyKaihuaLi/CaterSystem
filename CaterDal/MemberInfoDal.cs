using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
    public partial class MemberInfoDal
    {
        public List<MemberInfo> GetList()
        {
            string sql = "select mi.*, mti.mTitle as MTypeTitle from MemberInfo as mi inner join MemberTypeInfo as mti on mi.mTypeID=mti.mid where mi.Misdelete = 0";
            DataTable dataTable = SqliteHelper.GetDataTable(sql);
             List<MemberInfo> list = new List<MemberInfo>();

            foreach (DataRow VARIABLE in dataTable.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(VARIABLE["mid"]),
                    MName = VARIABLE["mname"].ToString(),
                    MPhone = VARIABLE["mphone"].ToString(),
                    MMoney = Convert.ToDecimal(VARIABLE["mmoney"]),
                    MTypeId = Convert.ToInt32(VARIABLE["MTypeID"]),
                    MTypeTitle = VARIABLE["MTypeTitle"].ToString()
                });
                
            }

            return list;
        }
    }
}
