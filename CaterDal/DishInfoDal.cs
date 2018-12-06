using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
    public partial class DishInfoDal
    {
        public List<DishInfo> GetList()
        {
            string sql =
                "select di.*, dti.dtitle as dTypeTitle from dishinfo as di inner join dishtypeinfo as dti on di.dtypeid = dti.did where di.disdelete=0 and dti.disdelete=0";

            DataTable dataTable = SqliteHelper.GetDataTable(sql);
            List<DishInfo> list = new List<DishInfo>();

            foreach (DataRow VARIABLE in dataTable.Rows)
            {
                list.Add(new DishInfo()
                {
                    DId = Convert.ToInt32(VARIABLE["did"]),
                    DTitle = VARIABLE["dtitle"].ToString(),
                    DTypeTitle = VARIABLE["dtypetitle"].ToString(),
                    DChar = VARIABLE["dchar"].ToString(),
                    DPrice = Convert.ToDecimal(VARIABLE["dprice"])
                });
                
            }

            return list;
        }
    }
}
