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
    public partial class FormDishInfo : Form
    {
        public FormDishInfo()
        {
            InitializeComponent();
        }

        private DishInfoBll dishInfoBll= new DishInfoBll();

        private void FormDishInfo_Load(object sender, EventArgs e)
        {
            LoadTypeList();
            LoadList();
            
        }

        private void LoadList()
        {
            Dictionary<string, string> dictionary=new Dictionary<string, string>();

            if (txtTitleSearch.Text != "")
            {
                dictionary.Add("dtitle",txtTitleSearch.Text);
            }

            if (ddlTypeSearch.SelectedValue.ToString() != "0")
            {
                dictionary.Add("DTypeID", ddlTypeSearch.SelectedValue.ToString());
            }

            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = dishInfoBll.GetList(dictionary);
        }

        private void LoadTypeList()
        {
            DishTypeInfoBll dishTypeInfoBll =new DishTypeInfoBll();

            List<DishTypeInfo> list = dishTypeInfoBll.GetList();

            list.Insert(0,new DishTypeInfo()
            {
                DId = 0,
                DTitle = "All"
            });

            ddlTypeSearch.DataSource = list;

            ddlTypeSearch.ValueMember = "did";
            ddlTypeSearch.DisplayMember = "dtitle";

            ddlTypeAdd.DataSource = dishTypeInfoBll.GetList();
            ddlTypeAdd.DisplayMember = "dtitle";
            ddlTypeAdd.ValueMember = "did";
        }

        private void txtTitleSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void ddlTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
            
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";
            ddlTypeSearch.SelectedIndex = 0;
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishInfo dishInfo=new DishInfo()
            {
                DTitle = txtTitleSave.Text,
                DChar = txtChar.Text,
                DPrice = Convert.ToDecimal(txtPrice.Text),
                DTypeId = Convert.ToInt32(ddlTypeAdd.SelectedValue)
            };

            if (txtId.Text == "Empty")
            {
                if (dishInfoBll.Add(dishInfo))
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
                //return;
                dishInfo.DId = int.Parse(txtId.Text);
                if (dishInfoBll.Update(dishInfo))
                {
                    LoadList();
                }
                else
                {
                    return;
                }
            }

            txtId.Text = "Empty";
            txtTitleSave.Text = "";
            txtPrice.Text = "";
            txtChar.Text = "";
            btnSave.Text = "Add";
            ddlTypeAdd.SelectedIndex = 0;
        }

        private void txtTitleSave_Leave(object sender, EventArgs e)
        {
            txtChar.Text = txtTitleSave.Text.ToUpper();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "Empty";
            txtTitleSave.Text = "";
            txtPrice.Text = "";
            txtChar.Text = "";
            ddlTypeAdd.SelectedIndex = 0;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitleSave.Text = row.Cells[1].Value.ToString();
            ddlTypeAdd.Text = row.Cells[2].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
            txtChar.Text = row.Cells[4].Value.ToString();
            btnSave.Text = "Update";
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            FormDishTypeInfo formDishTypeInfo=new FormDishTypeInfo();
            DialogResult result = formDishTypeInfo.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadTypeList();
                LoadList();
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);
            DialogResult result = MessageBox.Show("Sure", "warning", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (dishInfoBll.Delete(id))
                {
                    //LoadTypeList();
                    LoadList();
                }
            }
        }
    }
}
