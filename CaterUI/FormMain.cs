using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(this.Tag);
            if (type == 1)
            {

            }
            else
            {
                menuManagerInfo.Visible = false;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuManagerInfo_Click(object sender, EventArgs e)
        {
            FormManagerInfo formManagerInfo=FormManagerInfo.Create();
            formManagerInfo.Show();
            formManagerInfo.Focus();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
