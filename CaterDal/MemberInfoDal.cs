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
    public partial class MemberInfoDal
    {
        public List<MemberInfo> GetList(Dictionary<string, string> dic)
        {
            string sql = "select mi.*,mti.mTitle as MTypeTitle " +
                         "from MemberInfo as mi " +
                         "inner join MemberTypeInfo as mti " +
                         "on mi.mTypeId=mti.mid " +
                         "where mi.mIsDelete=0 ";
            //List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    sql += " and " + pair.Key + "  like '%"+pair.Value+"%'";

                }
            }

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

        public static int Insert(MemberInfo memberInfo)
        {
            string sql =
                "insert into memberinfo(mtypeid, mname, mphone, mmoney, misDelete) values (@tid, @name, @phone, @money, 0)";

            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("tid", memberInfo.MTypeId),
                new SQLiteParameter("@name", memberInfo.MName),
                new SQLiteParameter("@phone", memberInfo.MPhone),
                new SQLiteParameter("@money", memberInfo.MMoney)
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Update(MemberInfo memberInfo)
        {
            string sql =
                "update memberinfo set mname=@name, mphone = @phone, mmoney =@money, mtypeid=@tid where mid=@id";

            SQLiteParameter[] parameter =
            {
                new SQLiteParameter("@name", memberInfo.MName),
                new SQLiteParameter("@money", memberInfo.MMoney),
                new SQLiteParameter("@tid", memberInfo.MTypeId),
                new SQLiteParameter("@id", memberInfo.MId),
                new SQLiteParameter("@phone", memberInfo.MPhone)

            };

            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }

        public int Delete(int id)
        {
            string sql = "update memberInfo set misdelete = 1 where mid=@id";
            SQLiteParameter parameter = new SQLiteParameter("@id",id);
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }


    }

    
}
