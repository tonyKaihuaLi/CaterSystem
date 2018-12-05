using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterCommon;
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

        public int Insert(ManagerInfo managerInfo)
        {
            string sql = "insert into ManagerInfo(mname, mpwd, mtype)values(@name, @pwd, @type)";

            SQLiteParameter[] sqLiteParameters =
            {
                new SQLiteParameter("@name", managerInfo.MName),
                new SQLiteParameter("@pwd", MD5Helper.EncryptString(managerInfo.MPwd)),
                new SQLiteParameter("@type", managerInfo.MType),

            };
            return SqliteHelper.ExecuteNonQuery(sql, sqLiteParameters);
        }

        public int Update(ManagerInfo managerInfo)
        {
            List<SQLiteParameter> listParameters= new List<SQLiteParameter>();

            string sql = "update ManagerInfo set mname=@name";

            listParameters.Add(new SQLiteParameter("@name",managerInfo.MName));

            if(!managerInfo.MPwd.Equals("This is the orginal pwd"))
            {
                sql += ",upwd=@pwd";
                listParameters.Add(new SQLiteParameter("@pwd",MD5Helper.EncryptString(managerInfo.MPwd)));
            }

            sql+=", mtype=@type where mid=@id";
            listParameters.Add(new SQLiteParameter("@type",managerInfo.MType));
            listParameters.Add(new SQLiteParameter("@id", managerInfo.MId));


            return SqliteHelper.ExecuteNonQuery(sql, listParameters.ToArray());
        }
    }
}
