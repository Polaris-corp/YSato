using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Common;
using WindowsFormsApp2.Controller;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2
{
    public partial class RegisterForm : Form
    {
        public RegisterForm(RegistrationModel model, bool isChangeButton)
        {
            InitializeComponent();
            if (isChangeButton)
            {
                btnExecute.Text = ConstString.ChangeString;
                btnDelete.Visible = isChangeButton;
            }
            else
            {
                btnExecute.Text = ConstString.RegistrationString;
                lblUserId.Visible = false;
                txtUserId.Visible = false;
            }
            this.isChangeExecuteButton = isChangeButton;
            this.model = model;
        }
        RegistrationController rc = new RegistrationController();
        RegistrationModel model;
        bool isChangeExecuteButton;


        public void RegisterForm_Load(object sender, EventArgs e)
        {
            txtUserId.Text = model.UserId;
            txtName.Text = model.Name;
            txtPwd.Text = model.Pwd;
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pwd = txtPwd.Text;
            if (isChangeExecuteButton)
            {
                int userId = Convert.ToInt32(txtUserId.Text);
                rc.UpdateAccount(userId, name, pwd);
            }
            else
            {
                rc.InsertAccount(name, pwd);
            }
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(txtUserId.Text);
            rc.DeleteAccount(userId);
            this.Close();
        }
    }
}
