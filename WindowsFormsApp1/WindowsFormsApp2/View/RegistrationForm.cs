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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm(RegistrationModel model, bool isChangeButton)
        {
            InitializeComponent();
            if (isChangeButton)
            {
                ExecuteButton.Text = ConstString.ChangeString;
                DeleteButton.Visible = isChangeButton;
            }
            else
            {
                ExecuteButton.Text = ConstString.RegistrationString;
                IdLabel.Visible = false;
                UserIdTextBox.Visible = false;
            }
            this.isChangeExecuteButton = isChangeButton;
            this.model = model;
        }
        RegistrationController rc = new RegistrationController();
        RegistrationModel model;
        bool isChangeExecuteButton;


        public void RegistrationForm_Load(object sender, EventArgs e)
        {
            UserIdTextBox.Text = model.UserId;
            NameTextBox.Text = model.Name;
            PwdTextBox.Text = model.Pwd;
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(UserIdTextBox.Text);
            string name = NameTextBox.Text;
            string pwd = PwdTextBox.Text;
            if (isChangeExecuteButton)
            {
                rc.UpdateAccount(userId, name, pwd);
            }
            else
            {
                rc.InsertAccount(name, pwd);
            }
            this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(UserIdTextBox.Text);
            rc.DeleteAccount(userId);
            this.Close();
        }
    }
}
