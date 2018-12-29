using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class FormMemberInfo : Form
    {
        MemberInfoBll memberInfoBll = new MemberInfoBll();
        public FormMemberInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormMemberInfo_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadTypeList();
        }

        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (txtNameSearch.Text != "")
            {
                dic.Add("mname",txtNameSearch.Text);
            }

            if (txtPhoneSearch.Text != "")
            {
                dic.Add("mphone", txtPhoneSearch.Text);
            }



            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = memberInfoBll.GetList(dic);
        }

        private void LoadTypeList()
        {
            MemberTypeInfoBll memberTypeInfoBll = new MemberTypeInfoBll();
            List<MemberTypeInfo> list = memberTypeInfoBll.GetList();

            ddlType.DataSource = list;

            ddlType.DisplayMember = "mtitle";
            ddlType.ValueMember = "mid";
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void txtPhoneSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtNameSearch.Text = "";
            txtPhoneSearch.Text = "";
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNameAdd.Text == "")
            {
                return;
            }

            MemberInfo memberInfo=new MemberInfo()
            {
                MName = txtNameAdd.Text,
                MPhone = txtPhoneAdd.Text,
                MMoney = Convert.ToDecimal(txtMoney.Text),
                MTypeId = Convert.ToInt32(ddlType.SelectedValue)
            };
            if (txtId.Text.Equals("Empty"))
            {

                if (memberInfoBll.Add(memberInfo))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Someting Wrong");
                }
            }
            else
            {
                memberInfo.MId = int.Parse(txtId.Text);
                if (memberInfoBll.Edit(memberInfo))
                {
                    LoadList();
                }

            }

            txtId.Text = "Empty";
            txtMoney.Text = "";
            txtNameAdd.Text = "";
            txtPhoneAdd.Text = "";
            ddlType.SelectedIndex = 0;
            btnSave.Text = "Add";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "Empty";
            txtMoney.Text = "";
            txtNameAdd.Text = "";
            txtPhoneAdd.Text = "";
            ddlType.SelectedIndex = 0;
            btnSave.Text = "Add";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtNameAdd.Text = row.Cells[1].Value.ToString();
            ddlType.Text = row.Cells[2].Value.ToString();
            txtPhoneAdd.Text = row.Cells[3].Value.ToString();
            txtMoney.Text = row.Cells[4].Value.ToString();
            btnSave.Text = "Update";

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);

            DialogResult result = MessageBox.Show("Sure?", "Warning", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            if (memberInfoBll.Remove(id))
            {
                LoadList();

            }
            else
            {
                return;
            }
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            FormMemberTypeInfo formMemberTypeInfo =new FormMemberTypeInfo();
            DialogResult result = formMemberTypeInfo.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadTypeList();
                LoadList();
            }
        }
    }
}
