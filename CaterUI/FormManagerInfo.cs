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
using static System.Windows.Forms.MessageBoxButtons;

namespace CaterUI
{
    public partial class FormManagerInfo : Form
    {
        ManagerInfoBll managerInfoBll = new ManagerInfoBll();

        public FormManagerInfo()
        {
            InitializeComponent();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormManagerInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = managerInfoBll.GetList();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ManagerInfo managerInfo = new ManagerInfo()
            {
                MName = txtName.Text,
                MPwd = txtPwd.Text,
                MType = rb1.Checked ? 1 : 0

            };

            if (txtId.Text.Equals("Empty"))
            {
                if (managerInfoBll.Add(managerInfo))
                {
                    LoadList();


                }
                else
                {
                    MessageBox.Show("Something Wrong");
                }

            }
            else
            {
                managerInfo.MId = int.Parse(txtId.Text);
                if (managerInfoBll.Edit(managerInfo))
                {
                    LoadList();
                }
            }

            txtName.Text = " ";
            txtPwd.Text = " ";
            rb2.Checked = true;
            btnSave.Text = "Add";
            txtId.Text = "Empty";

        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "Manager" : "Stuff";
            }
        }



        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString().Equals("1"))
            {
                rb1.Checked = true;
            }
            else
            {
                rb2.Checked = true;
            }

            txtPwd.Text = "This is the orginal pwd";

            btnSave.Text = "edit";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "This is the orginal pwd";
            txtName.Text = "";
            txtPwd.Text = "";
            rb2.Checked = true;
            btnSave.Text = "Add";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var rows = dgvList.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure about that?", " ",MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                int id = int.Parse(rows[0].Cells[0].Value.ToString());
                if (managerInfoBll.Remove(id))
                {
                    LoadList();
                }
            }
            else
            {
                MessageBox.Show("Make a selection");
            }
        }
    }
}
