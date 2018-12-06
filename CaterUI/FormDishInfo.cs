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
            LoadList();   
        }

        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = dishInfoBll.GetList();
        }

        private void txtTitleSearch_Leave(object sender, EventArgs e)
        {

        }

        private void ddlTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
