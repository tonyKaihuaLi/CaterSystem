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
    public partial class FormTableInfo : Form
    {
        public FormTableInfo()
        {
            InitializeComponent();
        }
        private TableInfoBll tableInfoBll=new TableInfoBll();

        private void FormTableInfo_Load(object sender, EventArgs e)
        {
            LoadListSearch();
            LoadList();
        }

        private void LoadList()
        {
            Dictionary<string,string> dictionary=new Dictionary<string, string>();

            if (ddlHallSearch.SelectedIndex > 0)
            {
                dictionary.Add("thallid", ddlHallSearch.SelectedValue.ToString());
            }

            if (ddlFreeSearch.SelectedIndex > 0)
            {
                dictionary.Add("tisfree", ddlFreeSearch.SelectedValue.ToString());
            }

            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = tableInfoBll.GetList(dictionary);
        }

        private void LoadListSearch()
        {
            HallInfoBll hallInfoBll=new HallInfoBll();
            var list = hallInfoBll.GetList();

            list.Insert(0, new HallInfo()
            {
                HId = 0,
                HTitle = "All"
            });

            ddlHallAdd.DataSource = hallInfoBll.GetList();
            ddlHallAdd.ValueMember = "hid";
            ddlHallAdd.DisplayMember = "htitle";

            ddlHallSearch.DataSource = list;
            ddlHallSearch.ValueMember = "hid";
            ddlHallSearch.DisplayMember = "htitle";

            List<DdlModel> listDdl= new List<DdlModel>()
            {
                new DdlModel("-1","All"),
                new DdlModel("1", "Free"),
                new DdlModel("0","Busy")
            };
            ddlFreeSearch.DataSource = listDdl;
            ddlFreeSearch.ValueMember = "id";
            ddlFreeSearch.DisplayMember = "title";
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                e.Value = Convert.ToBoolean(e.Value )? "Free" : "Busy";
            }
        }

        private void ddlHallSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void ddlFreeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        } 

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            ddlHallSearch.SelectedIndex = 0;
            ddlFreeSearch.SelectedIndex = 0;
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TableInfo tableInfo=new TableInfo()
            {
                TTitle = txtTitle.Text,
                THallId = Convert.ToInt32(ddlHallAdd.SelectedValue),
                TIsFree = rbFree.Checked
            };

            if (txtId.Text == "Empty")
            {
                if (tableInfoBll.Add(tableInfo))
                {
                    LoadList();
                }
            }
            else
            {
                tableInfo.TId = int.Parse(txtId.Text);
                if (tableInfoBll.Edit(tableInfo))
                {
                    LoadList();
                }

            }

            txtId.Text = "Empty";
            txtTitle.Text = "";
            ddlHallAdd.SelectedIndex = 0;
            rbFree.Checked = true;
            btnSave.Text = "Add";

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "Empty";
            txtTitle.Text = "";
            ddlHallAdd.SelectedIndex = 0;
            rbFree.Checked = true;
            btnSave.Text = "Add";

        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            ddlHallAdd.Text = row.Cells[2].Value.ToString();
            if (Convert.ToBoolean(row.Cells[3].Value))
            {
                rbFree.Checked = true;
            }
            else
            {
                rbUnFree.Checked = true;
            }

            btnSave.Text = "Update";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);

            DialogResult result = MessageBox.Show("Sure?", "warning", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (tableInfoBll.Delete(id))
                {
                    LoadList();
                }
            }
        }

        private void btnAddHall_Click(object sender, EventArgs e)
        {
            FormHallInfo formHallInfo=new FormHallInfo();
            formHallInfo.MyUpdateForm += LoadListSearch;
            formHallInfo.MyUpdateForm += LoadList;
            formHallInfo.Show();
        }
    }
}
