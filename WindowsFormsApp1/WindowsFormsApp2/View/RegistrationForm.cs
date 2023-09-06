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
        public RegistrationForm(RegistrationModel model, bool isChangeExecuteButton)
        {
            InitializeComponent();
            if (isChangeExecuteButton)
            {
                ExecuteButton.Text = ConstString.ChangeString;

            }
            else
            {
                ExecuteButton.Text = ConstString.RegistrationString;
            }
            this.isChangeExecuteButton = isChangeExecuteButton;
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
            string name = NameTextBox.Text;
            string pwd = PwdTextBox.Text;
            if (isChangeExecuteButton)
            {
                rc.UpdateAccount(Convert.ToInt32(model.UserId), name, pwd);
            }
            else
            {
                rc.InsertAccount(name, pwd);
            }
            this.Close();
        }
    }
}
