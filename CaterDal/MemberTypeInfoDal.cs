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
    public partial class MemberTypeInfoDal
    {
        public List<MemberTypeInfo> GetList()
        {
            string sql = "select * from memberTypeInfo where mIsDelete =0";
            DataTable dataTable = SqliteHelper.GetDataTable(sql);
            List<MemberTypeInfo> list=new List<MemberTypeInfo>();

            foreach (DataRow VARIABLE in dataTable.Rows)
            {
                list.Add(new MemberTypeInfo()
                {
                    MId = Convert.ToInt32(VARIABLE["mid"]),
                    MTitle = VARIABLE["mtitle"].ToString(),
                    MDiscount = Convert.ToDecimal(VARIABLE["mdiscount"]),


                });
            }

            return list;
        }

        public static int Insert(MemberTypeInfo memberTypeInfo)
        {
            string sql = "insert into MemberTypeInfo(mtitle, mdiscount, misDelete) values(@title, @discount,0)";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@title", memberTypeInfo.MTitle),
                new SQLiteParameter("@discount", memberTypeInfo.MDiscount)
                
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Update(MemberTypeInfo memberTypeInfo)
        {
            string sql = "update memberTypeInfo set MTitle=@title, MDiscount = @discount where MId = @id";

            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@title", memberTypeInfo.MTitle),
                new SQLiteParameter("@discount", memberTypeInfo.MDiscount),
                new SQLiteParameter("@id", memberTypeInfo.MId)
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Delete(int id)
        {
            string sql = "update memberTypeInfo set mIsDelete = 1 where mid = @id";
            SQLiteParameter parameter= new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }


    }
}
