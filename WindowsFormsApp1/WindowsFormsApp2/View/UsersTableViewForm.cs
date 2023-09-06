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
        bool isChangeButton = false;

        private void UsersTableViewForm_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            isChangeButton = false;
            RegistrationModel model = new RegistrationModel();
            RegistrationForm registrationForm = new RegistrationForm(model, isChangeButton);
            registrationForm.ShowDialog();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            isChangeButton = true;
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            RegistrationModel model = new RegistrationModel
            {
                UserId = selectedRow.Cells["ID"].Value.ToString(),
                Name = selectedRow.Cells["Name"].Value.ToString(),
                Pwd = selectedRow.Cells["Pwd"].Value.ToString()
            };
            RegistrationForm registrationForm = new RegistrationForm(model, isChangeButton);
            registrationForm.ShowDialog();
        }

        private void RenewalButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadUserData()
        {
            dt = uc.ReadUsersTable();
            dataGridView1.DataSource = dt;
        }

    }
}

