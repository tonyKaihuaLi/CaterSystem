using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class FormMain : Form
    {

        OrderInfoBll orderInfoBll = new OrderInfoBll();

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

            LoadHallInfo();

        }

        private void LoadHallInfo()
        {
            HallInfoBll hallInfoBll=new HallInfoBll();
            var list = hallInfoBll.GetList();

            tcHallInfo.TabPages.Clear();

            TableInfoBll tableInfoBll = new TableInfoBll();

            foreach (var items in list)
            {
                TabPage tabPage = new TabPage(items.HTitle);

                Dictionary<string,string> dictionary=new Dictionary<string, string>();

                dictionary.Add("thallid",items.HId.ToString());

                tableInfoBll.GetList(dictionary);
                var listTableInfo = tableInfoBll.GetList(dictionary);

                ListView listViewTableInfo= new ListView();

                //make oreder
                listViewTableInfo.DoubleClick+=listViewTableInfo_DoubleClick;

                listViewTableInfo.LargeImageList = imageList1;

                listViewTableInfo.Dock = DockStyle.Fill;

                tabPage.Controls.Add(listViewTableInfo);

                foreach (var VARIABLE in listTableInfo)
                {
                    var lvi = new ListViewItem(VARIABLE.TTitle, VARIABLE.TIsFree ? 0 : 1);

                    lvi.Tag = VARIABLE.TId;

                    listViewTableInfo.Items.Add(lvi);

                }

                tcHallInfo.TabPages.Add(tabPage);

            }
        }


        private void listViewTableInfo_DoubleClick(object sender, EventArgs e)
        {
            var lv1 = sender as ListView;
            var lvi = lv1.SelectedItems[0];

            int tableID = Convert.ToInt32(lvi.Tag);

            if (lvi.ImageIndex == 0)//state judgement
            {
                
                int orderId = orderInfoBll.MakeOrder(tableID);
                lvi.Tag = orderId;

                lv1.SelectedItems[0].ImageIndex = 1;
            }
            else
            {
                //table is busy
                lvi.Tag = orderInfoBll.GetOrderIdByTableId(tableID); 

            }

            FormOrderDish formOrderDish=new FormOrderDish();
            formOrderDish.Tag = lvi.Tag;
            formOrderDish.Show();
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

        private void menuMemberInfo_Click(object sender, EventArgs e)
        {
            FormMemberInfo formMemberInfo = new FormMemberInfo();
            formMemberInfo.Show();
        }

        private void menuTableInfo_Click(object sender, EventArgs e)
        {
            FormTableInfo formTableInfo=new FormTableInfo();
            formTableInfo.Refresh += LoadHallInfo;
            formTableInfo.Show();
        }

        private void menuDishInfo_Click(object sender, EventArgs e)
        {
            FormDishInfo formDishInfo=new FormDishInfo();
            formDishInfo.Show();
        }

        private void menuOrderInfo_Click(object sender, EventArgs e)
        {
            var listView = tcHallInfo.SelectedTab.Controls[0] as ListView;
            var lvTable = listView.SelectedItems[0];
            if (lvTable.ImageIndex == 0)
            {
                return;
            }

            int tableID = Convert.ToInt32(listView.SelectedItems[0].Tag);

            int orderID
                = orderInfoBll.GetOrderIdByTableId(tableID);


            FormOrderCheck formOrderCheck= new FormOrderCheck();
            formOrderCheck.Tag = orderID;
            formOrderCheck.Show();
        }

        private void tcHallInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}