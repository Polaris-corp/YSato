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
            rbtAvailable.Checked = !model.Deleted;
            rbtNotAvailable.Checked = model.Deleted;
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            model.Name = txtName.Text;
            model.Pwd = txtPwd.Text;
            model.Deleted = rbtNotAvailable.Checked;
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Pwd))
            {
                MessageBox.Show(ConstString.EmptyMessage);
                return;
            }
            if (isChangeExecuteButton)
            {
                model.UserId = txtUserId.Text;
                rc.UpdateAccount(model);
            }
            else
            {
                rc.InsertAccount(model);
            }
            this.Close();
        }
    }
}
