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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pwd = txtPwd.Text;
            int type;

            ManagerInfoBll managerInfoBll=new ManagerInfoBll();
           LoginState loginState = managerInfoBll.Login(name, pwd, out type);
            switch (loginState)
            {
                case LoginState.Ok:
                    FormMain formMain= new FormMain();
                    formMain.Tag = type;
                    formMain.Show();
                    this.Hide();
                    break;

                case LoginState.NameError:
                    MessageBox.Show("Username or password is wrong");
                    break;

                case LoginState.PwdError:
                    MessageBox.Show("Username or password is wrong");
                    break;
            }
        }
    }
}
