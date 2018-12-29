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
    public partial class HallInfoDal
    {
        public List<HallInfo> GetList()
        {
            string sql = "select * from hallInfo where hIsDelete = 0";
            DataTable dataTable = SqliteHelper.GetDataTable(sql);

            List<HallInfo> list= new List<HallInfo>();

            foreach (DataRow VARIABLE in dataTable.Rows)
            {
                list.Add(new HallInfo()
                {
                    HId = Convert.ToInt32(VARIABLE["hid"]),
                    HTitle = VARIABLE["htitle"].ToString()
                });
            }

            return list;
        }

        public int Insert(HallInfo hallInfo)
        {
            string sql = "insert into hallinfo(htitle, hisDelete) values (@title,0)";
            SQLiteParameter parameter=new SQLiteParameter("@title", hallInfo.HTitle);

            return SqliteHelper.ExecuteNonQuery(sql, parameter);

        }

        public int Update(HallInfo hallInfo)
        {
            string sql = "update hallinfo set htitle=@title where hid=@id";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@title", hallInfo.HTitle),
                new SQLiteParameter("@id", hallInfo.HId),
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);

        }

        public int Delete(int id)
        {
            string sql = "update hallinfo set hIsDelete=1 where hid=@id";
            SQLiteParameter parameter= new SQLiteParameter("@id",id);
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }
    }
}
