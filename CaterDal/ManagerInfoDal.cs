using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
    public partial class ManagerInfoDal
    {
        public List<ManagerInfo> GetList()
        {
            string sql = "select * from ManagerInfo";
            DataTable dataTable= SqliteHelper.GetDataTable(sql);
            List<ManagerInfo> list=new List<ManagerInfo>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                list.Add(new ManagerInfo()
                {
                    MId = Convert.ToInt32(dataRow["mid"]),
                    MName = dataRow["mname"].ToString(),
                    MPwd = dataRow["mpwd"].ToString(),
                    MType = Convert.ToInt32(dataRow["mtype"])
                });
            }

            return list;
        }
    }
}
