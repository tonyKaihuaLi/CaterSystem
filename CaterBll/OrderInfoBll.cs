using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class OrderInfoBll
    {
        private OrderInfoDal orderInfoDal=new OrderInfoDal();

        public int MakeOrder(int tableId)
        {
            return orderInfoDal.MakeOrder(tableId);
        }

        public bool OrderBusy(int orderId, int dishID)
        {
            return orderInfoDal.OrderBusy(orderId, dishID) > 0;
        }

        public List<OrderDetailInfo> GetDetailList(int orderId)
        {
            return orderInfoDal.GetDetailList(orderId);
        }

        public int GetOrderIdByTableId(int tableId)
        {
            return orderInfoDal.GetOrderIdByTableId(tableId);
        }

        public bool UpdateCountByOId(int oid, int count)
        {
            return orderInfoDal.UpdateCountByOId(oid, count) > 0;
        }

        public decimal GetTotalMoneyByOrderId(int orderid)
        {
            return orderInfoDal.GetTotalMoneyByOrderId(orderid);
        }

        public bool SetOrderPrice(int order, decimal price)
        {
            return orderInfoDal.SetOrderPrice(order, price)>0;
        }

        public bool DeleteDetailByOid(int oid)
        {
            return orderInfoDal.DeleteDetailById(oid) > 0;
        }

        public bool Check(bool usingBalance, int memberId, decimal payCash, int orderid, decimal discount)
        {
            return orderInfoDal.Check(usingBalance, memberId, payCash, orderid, discount)>0;
        }
    }
}
