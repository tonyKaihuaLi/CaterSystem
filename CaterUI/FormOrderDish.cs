using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class FormOrderDish : Form
    {
        public FormOrderDish()
        {
            InitializeComponent();
        }

        OrderInfoBll orderInfoBll = new OrderInfoBll();

        private void FormOrderDish_Load(object sender, EventArgs e)
        {
            LoadDishType();
            LoadDishInfo();
            LoadDetailList();
        }

        private void LoadDishInfo()
        {


            Dictionary<string,string> dictionary=new Dictionary<string, string>();

            if (txtTitle.Text != "")
            {
                dictionary.Add("dchar", txtTitle.Text);
            }

            if (ddlType.SelectedValue.ToString() != "0")
            {
                dictionary.Add("dtypeid", ddlType.SelectedValue.ToString());
            }

            DishInfoBll dishInfoBll=new DishInfoBll();
            dgvAllDish.AutoGenerateColumns = false;
            dgvAllDish.DataSource = dishInfoBll.GetList(dictionary);
        }

        private void LoadDishType()
        {
            DishTypeInfoBll dishTypeInfoBll=new DishTypeInfoBll();
            var list = dishTypeInfoBll.GetList();

            list.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "All",
            });
            ddlType.ValueMember = "did";
            ddlType.DisplayMember = "dtitle"; 
            ddlType.DataSource=list;
        }

        private void LoadDetailList()
        {
            int orderID = Convert.ToInt32(this.Tag);
            dgvOrderDetail.AutoGenerateColumns = false;
            dgvOrderDetail.DataSource = orderInfoBll.GetDetailList(orderID);
            GetTotalMoneyByOrderID();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void dgvAllDish_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //order number
            int orderID = Convert.ToInt32(this.Tag);

            int dishID = Convert.ToInt32(dgvAllDish.Rows[e.RowIndex].Cells[0].Value);

            OrderInfoBll orderInfoBll=new OrderInfoBll();
            if(orderInfoBll.OrderBusy(orderID, dishID))
            {

                LoadDetailList();
            }
        
        }

        private void dgvOrderDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var row = dgvOrderDetail.Rows[e.RowIndex];
                int oid = Convert.ToInt32(row.Cells[0].Value);

                int count = Convert.ToInt32(row.Cells[2].Value);

                orderInfoBll.UpdateCountByOId(oid, count);

                GetTotalMoneyByOrderID();
            }
        }

        private void GetTotalMoneyByOrderID()
        {
            int orderId = Convert.ToInt32(this.Tag);
            lblMoney.Text=orderInfoBll.GetTotalMoneyByOrderId(orderId).ToString();

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(this.Tag);
            decimal price = Convert.ToDecimal(lblMoney.Text);
            if (orderInfoBll.SetOrderPrice(orderId, price))
            {
                MessageBox.Show("succeed");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("sure?", "waring", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            int oid = Convert.ToInt32(dgvOrderDetail.SelectedRows[0].Cells[0].Value);

            if (orderInfoBll.DeleteDetailByOid(oid))
            {
                LoadDetailList();
            }
        }


    }
}
