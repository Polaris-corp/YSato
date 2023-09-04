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
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2
{
    public partial class RegistrationForm : Form
    {

        public RegistrationForm()
        {
            InitializeComponent();
            button1.Text = ConstString.RegistrationString;
        }
        public RegistrationForm(bool flg)
        {
            InitializeComponent();
            button1.Text = ConstString.ChangeString;
            this.flg = flg;
        }

        public RegistrationModel model { get; set; }
        bool flg = false;

        public void RegistrationForm_Load(object sender, EventArgs e)
        {
            //if (!flg)
            //{
                textBox1.Text = model.UserId;
                textBox2.Text = model.Name;
                textBox3.Text = model.Pwd;
            //}
        }
    }
}
