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
    public partial class FormHallInfo : Form
    {
        public FormHallInfo()
        {
            InitializeComponent();

            hallInfoBll = new HallInfoBll();
        }

        private HallInfoBll hallInfoBll;

        public event Action MyUpdateForm;

        private void FormHallInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = hallInfoBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HallInfo hallInfo=new HallInfo()
            {
                HTitle = txtTitle.Text
            };

            if (txtId.Text == "Empty")
            {
                if (hallInfoBll.Add(hallInfo))
                {
                    LoadList();

                }
            }
            else
            {
                hallInfo.HId = int.Parse(txtId.Text);
                if (hallInfoBll.Edit(hallInfo))
                {
                    LoadList();
                }

            }

            txtId.Text = "Empty";
            txtTitle.Text = "";
            btnSave.Text = "Add";

            MyUpdateForm();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "Empty";
            txtTitle.Text = "";
            btnSave.Text = "Add";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "Update";

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);

            DialogResult result = MessageBox.Show("Sure?", "warning", MessageBoxButtons.OKCancel);

            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (hallInfoBll.Remove(id))
            {
                LoadList();
            }

            MyUpdateForm();
        }
    }
}
