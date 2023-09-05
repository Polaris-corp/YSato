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

        public RegistrationForm(RegistrationModel model)
        {
            InitializeComponent();
            executebutton.Text = ConstString.RegistrationString;
            this.model = model;
        }
        public RegistrationForm(RegistrationModel model, bool flg)
        {
            InitializeComponent();
            executebutton.Text = ConstString.ChangeString;
            this.flg = flg;
            this.model = model;
        }
        RegistrationController rc = new RegistrationController();
        RegistrationModel model;
        bool flg = false;


        public void RegistrationForm_Load(object sender, EventArgs e)
        {
                textBox1.Text = model.UserId;
                textBox2.Text = model.Name;
                textBox3.Text = model.Pwd;
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string pwd = textBox3.Text;
            if (flg)
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
