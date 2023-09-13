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
        public RegisterForm(RegistrationModel model, bool isChange)
        {
            InitializeComponent();
            if (isChange)
            {
                btnExecute.Text = ConstString.ChangeString;
            }
            else
            {
                btnExecute.Text = ConstString.RegistrationString;
            }
            lblUserId.Visible = isChange;
            txtUserId.Visible = isChange;
            rbtAvailable.Checked = !model.Deleted;
            rbtNotAvailable.Checked = model.Deleted;

            this.isChangeExecuteButton = isChange;
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
            bool deleted = rbtNotAvailable.Checked;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show(ConstString.EmptyMessage);
                return;
            }
            if (isChangeExecuteButton)
            {
                int userId = Convert.ToInt32(txtUserId.Text);
                rc.UpdateAccount(userId, name, pwd, deleted);
            }
            else
            {
                rc.InsertAccount(name, pwd);
            }
            this.Close();
        }
    }
}
