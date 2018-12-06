using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class FormMemberTypeInfo : Form
    {
        MemberTypeInfoBll memberTypeInfoBll = new MemberTypeInfoBll();

        public FormMemberTypeInfo()
        {
            InitializeComponent();
        }

        private DialogResult resultDia = DialogResult.Cancel;

        private void FormMemberTypeInfo_Load(object sender, EventArgs e)
        {
            ListLoad();
        }

        private void ListLoad()
        {
         
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = memberTypeInfoBll.GetList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberTypeInfo memberTypeInfo = new MemberTypeInfo()
            {
                MTitle = txtTitle.Text,
                MDiscount = Convert.ToDecimal(txtDiscount.Text)
            };

            if (txtId.Text.Equals("Empty"))
            {


                if (memberTypeInfoBll.Add(memberTypeInfo))
                {
                    ListLoad();
                }
                else
                {
                    MessageBox.Show("Please try later");
                }
                
            }
            else
            {
                memberTypeInfo.MId = int.Parse(txtId.Text);
                if (memberTypeInfoBll.Edit(memberTypeInfo))
                {
                    ListLoad();
                }
                else
                {
                    MessageBox.Show("someting wrong");
                }
            }

            txtId.Text = "Empty";
            txtDiscount.Text = "";
            txtTitle.Text = "";
            btnSave.Text = "ADD";

            resultDia = DialogResult.OK;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];

            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "Change";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var row = dgvList.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);
            DialogResult result =
            MessageBox.Show("Sure?", "", MessageBoxButtons.OKCancel);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            if (memberTypeInfoBll.Remove(id))
            {
                ListLoad();
            }
            else
            {
                MessageBox.Show("Something wrong");
            }

            resultDia = DialogResult.OK;
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormMemberTypeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = resultDia;
        }
    }
}
