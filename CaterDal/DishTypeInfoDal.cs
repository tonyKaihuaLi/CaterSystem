using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

        public int Insert(DishTypeInfo dishTypeInfo)
        {
            string sql = "insert into dishtypeinfo (dtitle, dIsDelete) values (@title, 0)";
            SQLiteParameter parameter= new SQLiteParameter("@title", dishTypeInfo.DTitle);
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }

        public int Update(DishTypeInfo dishTypeInfo)
        {
            string sql = "update dishtypeinfo set dtitle = @title where did=@id";
            SQLiteParameter[] parameter=
            {
                new SQLiteParameter("@title", dishTypeInfo.DTitle),
                new SQLiteParameter("@id", dishTypeInfo.DId) 
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }

        public int Delete(int Id)
        {
            string sql = "update dishtypeinfo set disdelete = 1 where did =@id";
            SQLiteParameter parameter=new SQLiteParameter("@id", Id);
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }
    }
}
