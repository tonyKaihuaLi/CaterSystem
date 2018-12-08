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
    public partial class OrderInfoDal
    {
        public int MakeOrder(int tableId)
        {
            //order update and get the latest order id
            string sql = "insert into orderinfo(odate,ispay,tableId) values(datetime('now', 'localtime'),0,@tid);" +
                         //更新餐桌状态
                         "update tableinfo set tIsFree=0 where tid=@tid;" +
                         //获取最新的订单编号
                         "select oid from orderinfo order by oid desc limit 0,1";

            SQLiteParameter parameter=new SQLiteParameter("@tid", tableId);
            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sql, parameter));
        }

        public int GetOrderIdByTableId(int tableId)
        {
            string sql = "select oid from orderinfo where tableId=@tableid and ispay=0";

            SQLiteParameter parameter= new SQLiteParameter("@tableid", tableId);
            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sql, parameter));
        }

        public int OrderBusy(int orderId, int dishId)
        {
            string sql = "select count(*) from orderDetailInfo where orderId=@oid and dishId=@did";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@oid", orderId),
                new SQLiteParameter("@did", dishId)
            };
            int count = Convert.ToInt32(SqliteHelper.ExecuteScalar(sql, ps));
            if (count > 0)
            {
                sql = "update orderDetailInfo set count=count+1 where orderId=@oid and dishId=@did";
            }
            else
            {
                sql = "insert into orderDetailInfo(orderid,dishId,count) values(@oid,@did,1)";
            }
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public List<OrderDetailInfo> GetDetailList(int orderId)
        {
            string sql = @"select odi.oid,di.dTitle,di.dPrice,odi.count from dishinfo as di
            inner join orderDetailInfo as odi
            on di.did=odi.dishid
            where odi.orderId=@orderid";

            SQLiteParameter parameter=new SQLiteParameter("@orderid", orderId);

            DataTable dataTable = SqliteHelper.GetDataTable(sql, parameter);

            List<OrderDetailInfo> list= new List<OrderDetailInfo>();
            
            foreach (DataRow VARIABLE in dataTable.Rows)
            {
                    list.Add(new OrderDetailInfo()
                    {
                        OId = Convert.ToInt32(VARIABLE["oid"]),
                        DTitle = VARIABLE["dtitle"].ToString(),
                        DPrice = Convert.ToDecimal(VARIABLE["dprice"]),
                        Count = Convert.ToInt32(VARIABLE["count"])
                    });
            }

            return list;
            
        }

        public int UpdateCountByOId(int oid, int count)
        {
            string sql = "update orderDetailInfo set count=@count where oid=@oid";

            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@count", count),
                new SQLiteParameter("oid", oid),
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        public decimal GetTotalMoneyByOrderId(int orderid)
        {
            string sql =
                "select sum(oti.count*di.dprice) from orderdetailinfo as oti inner join dishinfo as di on oti.dishid=di.did where oti.orderid=@orderid";
            SQLiteParameter parameter = new SQLiteParameter("@orderid", orderid);

            object obj = SqliteHelper.ExecuteScalar(sql, parameter);
            if (obj == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(obj);
        }

        public int SetOrderPrice(int orderid, decimal price)
        {
            string sql = "update orderinfo set omoney=@money where oid=@oid";

            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@money", price),
                new SQLiteParameter("@oid", orderid),
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);

        }

        public int DeleteDetailById(int oid)
        {
            string sql = "delete from orderDetailInfo where oid=@oid";

            SQLiteParameter parameter = new SQLiteParameter("@oid", oid);

            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }

        public int Check(bool usingBalance, int memberId, decimal payCash, int orderid, decimal discount)
        {
            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["itcastCater"].ConnectionString))
            {
                int result = 0;
                conn.Open();
                SQLiteTransaction tran = conn.BeginTransaction();

                SQLiteCommand cmd = new SQLiteCommand();
                string sql = "";
                cmd.Transaction = tran;
                SQLiteParameter[] parameters;
                try
                {
                    if (usingBalance)
                    {
                        sql = "update MemberInfo set mmoney=mmoney-@paycash where mid=@mid";

                        parameters = new SQLiteParameter[]
                        {
                            new SQLiteParameter("@paycash", payCash),
                            new SQLiteParameter("@mid", memberId),
                        };
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(parameters);
                        result += cmd.ExecuteNonQuery();


                    }

                    sql = "update orderinfo set ispay = 1, memberid =@mid, discount=@discount where oid=@oid";

                    parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@mid", memberId),
                        new SQLiteParameter("@discount", discount),
                        new SQLiteParameter("@oid", orderid),
                    };

                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                    result += cmd.ExecuteNonQuery();

                    sql = "update tableInfo set tisfree=1 where tid==(select tableid from orderinfo where oid=@oid)";
                    SQLiteParameter parameter = new SQLiteParameter("@oid",orderid);
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                    result += cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch
                {
                    result = 0;
                    tran.Rollback();
                }

                

                return result;
            }

            
        }


    }
}
