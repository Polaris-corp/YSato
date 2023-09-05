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

        public RegistrationForm()
        {
            InitializeComponent();
            executebutton.Text = ConstString.RegistrationString;
        }
        public RegistrationForm(bool flg)
        {
            InitializeComponent();
            executebutton.Text = ConstString.ChangeString;
            this.flg = flg;
        }
        RegistrationController rc = new RegistrationController();
        bool flg = false;
        public RegistrationModel model { get; set; }

        public void RegistrationForm_Load(object sender, EventArgs e)
        {
            //if (!flg)
            //{
                textBox1.Text = model.UserId;
                textBox2.Text = model.Name;
                textBox3.Text = model.Pwd;
            //}
        }

        private void executebutton_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string pwd = textBox3.Text;
            if (!flg)
            {
                rc.InsertAccount(name, pwd);
            }
            else
            {
                rc.UpdateAccount(Convert.ToInt32(model.UserId), name, pwd);
            }
            this.Close();
        }
    }
}
