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
    public partial class FormOrderCheck : Form
    {
        
        public FormOrderCheck()
        {
            InitializeComponent();
        }

        public event Action Refresh;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int orderId;

        private OrderInfoBll orderInfoBll= new OrderInfoBll();

        private void FormOrderCheck_Load(object sender, EventArgs e)
        {
            orderId = Convert.ToInt32(this.Tag);

            gbMember.Enabled = false;

            GetPriceByOrderId();

        }

        private void GetPriceByOrderId()
        {
            lblPayMoney.Text=lblPayMoneyDiscount.Text=orderInfoBll.GetTotalMoneyByOrderId(orderId).ToString();

        }

        private void cbkMember_CheckedChanged(object sender, EventArgs e)
        {
            gbMember.Enabled = cbkMember.Checked;
        }

        private void LoadMember()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (txtId.Text != "")
            {
                dic.Add("mid", txtId.Text);
            }

            if (txtPhone.Text != "")
            {
                dic.Add("mPhone",txtPhone.Text);
            }

            MemberInfoBll milBll=new MemberInfoBll();

           var list = milBll.GetList(dic);

            if (list.Count > 0)
            {
                MemberInfo memberInfo = list[0];
                lblMoney.Text = memberInfo.MMoney.ToString();
                lblTypeTitle.Text = memberInfo.MTypeTitle;
                lblDiscount.Text = memberInfo.MDiscount.ToString();

                lblPayMoneyDiscount.Text =
                    (Convert.ToDecimal(lblPayMoney.Text) * Convert.ToDecimal(lblDiscount.Text)).ToString();
            }
            else
            {
                MessageBox.Show("wrong");
            }

        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            LoadMember();
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            LoadMember();
        }

        private void btnOrderPay_Click(object sender, EventArgs e)
        {
            if (orderInfoBll.Check(cbkMoney.Checked, int.Parse(txtId.Text), Convert.ToDecimal(lblPayMoneyDiscount.Text),
                orderId, Convert.ToDecimal(lblDiscount.Text)))
            {
                //MessageBox.Show("succeed");
                Refresh();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
