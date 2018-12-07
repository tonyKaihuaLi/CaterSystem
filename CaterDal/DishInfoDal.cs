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
    public partial class DishInfoDal
    {
        public List<DishInfo> GetList(Dictionary<string,string> dictionary)
        {
            string sql =
                "select di.*, dti.dtitle as dTypeTitle from dishinfo as di inner join dishtypeinfo as dti on di.dtypeid = dti.did where di.disdelete=0 and dti.disdelete=0";

            List<SQLiteParameter> listParameters = new List<SQLiteParameter>();

            if (dictionary.Count > 0)
            {
                //sql+=" and "++" like"

                foreach (var VARIABLE in dictionary)
                {
                    sql += " and di." + VARIABLE.Key + " like '%" + VARIABLE.Value + "%'";
                    listParameters.Add(new SQLiteParameter("@"+VARIABLE.Key, "%"+VARIABLE.Value+"%"));
                }
            }

            DataTable dataTable = SqliteHelper.GetDataTable(sql,listParameters.ToArray());
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

        public int Insert(DishInfo dishInfo)
        {
            string sql = "insert into dishinfo(dtitle, dtypeid, dprice, dchar, dISDelete) values(@title, @tid, @price, @dchar, 0)";
            SQLiteParameter[] parameter =
            {
                new SQLiteParameter("@title", dishInfo.DTitle),
                new SQLiteParameter("@tid", dishInfo.DTypeId),
                new SQLiteParameter("@price", dishInfo.DPrice),
                new SQLiteParameter("@dchar", dishInfo.DChar),
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }

        public int Update(DishInfo dishInfo)
        {
            string sql = "update dishinfo set dtitle=@title, dtypeid=@tid, dprice=@price,dchar=@dchar where did=@id";

            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@title", dishInfo.DTitle),
                new SQLiteParameter("@tid", dishInfo.DTypeId),
                new SQLiteParameter("@price", dishInfo.DPrice),
                new SQLiteParameter("@dchar", dishInfo.DChar),
                new SQLiteParameter("@id", dishInfo.DId),
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Delete(int id)
        {
            string sql = "update dishinfo set disdelete = 1 where did = @id";
            SQLiteParameter parameter = new SQLiteParameter("@id", id);

            return SqliteHelper.ExecuteNonQuery(sql, parameter);

        }
    }
}
