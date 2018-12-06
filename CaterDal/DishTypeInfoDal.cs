using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
    public partial class DishTypeInfoDal
    {
        public List<DishTypeInfo> GetList()
        {
            string sql = "select * from DishTypeInfo where DIsDelete = 0";

            DataTable dataTable = SqliteHelper.GetDataTable(sql);
            List<DishTypeInfo> list = new List<DishTypeInfo>();

            foreach (DataRow VARIABLE in dataTable.Rows)
            {
                list.Add(new DishTypeInfo()
                {
                    DId = Convert.ToInt32(VARIABLE["did"]),
                    DTitle = VARIABLE["dtitle"].ToString()
                });
            }

            return list;
        }
    }
}
