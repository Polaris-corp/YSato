using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Controller;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2
{
    public partial class UsersTableViewForm : Form
    {
        public UsersTableViewForm()
        {
            InitializeComponent();
        }
        UsersTableViewController uc = new UsersTableViewController();
        DataTable dt = new DataTable();

        private void UsersTableViewForm_Load(object sender, EventArgs e)
        {
            GetDataUsersTable();
        }

        private void registrationbutton_Click(object sender, EventArgs e)
        {
            RegistrationModel model = new RegistrationModel();
            if (model != null)
            {
                RegistrationForm registrationForm = new RegistrationForm();
                registrationForm.model = model;
                registrationForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(Common.ConstString.NullString);
            }

        }

        private void changebutton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            RegistrationModel model = new RegistrationModel();
            model.UserId = selectedRow.Cells["ID"].Value.ToString();
            model.Name = selectedRow.Cells["Name"].Value.ToString();
            model.Pwd = selectedRow.Cells["Pwd"].Value.ToString();
            if (model != null)
            {
                RegistrationForm registrationForm = new RegistrationForm(true);
                registrationForm.model = model;
                registrationForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(Common.ConstString.NullString);
            }
        }

        private void GetDataUsersTable()
        {
            dt = uc.ReadUsersTable();
            dataGridView1.DataSource = dt;
        }
    }
}

