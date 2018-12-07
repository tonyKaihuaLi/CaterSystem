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
    public partial class TableInfoDal
    {
        public List<TableInfo> GetList(Dictionary<string,string> dictionary)
        {
            string sql =
                "select ti.*, hi.htitle from tableinfo as ti inner join hallinfo as hi on ti.tHallId=hi.hid where ti.tisdelete=0 and hi.hisdelete=0";

            
            List<SQLiteParameter> listP = new List<SQLiteParameter>();

            if (dictionary.Count > 0)
            {
                foreach (var VARIABLE in dictionary)
                {
                    sql += " and " + VARIABLE.Key + "=@" + VARIABLE.Key;
                    listP.Add(new SQLiteParameter("@"+VARIABLE.Key, VARIABLE.Value));
                    
                }
            }

            DataTable dataTable = SqliteHelper.GetDataTable(sql,listP.ToArray());


            List<TableInfo> list=new List<TableInfo>();

            foreach (DataRow VARIABLE in dataTable.Rows)
            {
                list.Add(new TableInfo()
                {
                    TId = Convert.ToInt32(VARIABLE["tid"]),
                    TTitle = VARIABLE["ttitle"].ToString(),
                    HallTitle = VARIABLE["htitle"].ToString(),
                    THallId = Convert.ToInt32(VARIABLE["thallid"]),
                    TIsFree = Convert.ToBoolean(VARIABLE["tisfree"])
                });
            }

            return list;


        }

        public int Insert(TableInfo tableInfo)
        {
            string sql = "insert into tableinfo(ttitle, thallid, tisfree, tisdelete) values(@title, @hid, @isfree, 0)";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@title", tableInfo.TTitle),
                new SQLiteParameter("@hid", tableInfo.THallId),
                new SQLiteParameter("@isfree", tableInfo.TIsFree),
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Update(TableInfo tableInfo)
        {
            string sql = "update tableinfo set ttitle=@title, thallid=@hid, tisfree=@isfree where tid=@id";

            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@title", tableInfo.TTitle),
                new SQLiteParameter("@hid", tableInfo.THallId),
                new SQLiteParameter("@isfree", tableInfo.TIsFree),
                new SQLiteParameter("@id", tableInfo.TId),
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Delete(int id)
        {
            string sql = "update tableinfo set tisdelete = 1 where tid=@id";
            SQLiteParameter parameter=new SQLiteParameter("@id",id);
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }
    }
}
