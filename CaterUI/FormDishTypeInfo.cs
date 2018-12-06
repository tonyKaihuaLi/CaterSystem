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
    public partial class FormDishTypeInfo : Form
    {
        public FormDishTypeInfo()
        {
            InitializeComponent();
        }

        DishTypeInfoBll dishTypeInfoBll = new DishTypeInfoBll();

        private void FormDishTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {

            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = dishTypeInfoBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishTypeInfo dishTypeInfo=new DishTypeInfo()
            {
                DTitle = txtTitle.Text
            };

            if (txtId.Text == "Empty")
            {
                if (dishTypeInfoBll.Add(dishTypeInfo))
                {
                    LoadList();
                }
                else
                {
                    return;
                }
            }
            else
            {
                dishTypeInfo.DId = int.Parse(txtId.Text);
                if (dishTypeInfoBll.Update(dishTypeInfo))
                {
                    LoadList();
                }
                else
                {
                    return;
                }

            }



            txtId.Text = "Empty";
            txtTitle.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "Empty";
            txtTitle.Text = "";

        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];

            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "UPDATE";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var row = dgvList.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);

            DialogResult sureResult = MessageBox.Show("Sure?", "Warning", MessageBoxButtons.OKCancel);

            if (sureResult == DialogResult.Cancel)
            {
                return;
            }

            if (dishTypeInfoBll.Delete(id))
            {
                LoadList();
            }
            else
            {
                return;
            }
        }
    }
}
