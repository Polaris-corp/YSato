﻿using MySqlConnector;
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
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
        }
        UsersTableViewController uc = new UsersTableViewController();
        DataTable dt = new DataTable();
        bool isChangeButton = false;

        private void UserListForm_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            isChangeButton = false;
            RegistrationModel model = new RegistrationModel();
            RegisterForm registrationForm = new RegisterForm(model, isChangeButton);
            registrationForm.ShowDialog();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            isChangeButton = true;
            DataGridViewRow selectedRow = userListGridView.SelectedRows[0];
            RegistrationModel model = new RegistrationModel
            {
                UserId = selectedRow.Cells["ID"].Value.ToString(),
                Name = selectedRow.Cells["Name"].Value.ToString(),
                Pwd = selectedRow.Cells["Pwd"].Value.ToString()
            };
            RegisterForm registrationForm = new RegisterForm(model, isChangeButton);
            registrationForm.ShowDialog();
        }

        private void BtnRenewal_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {
            dt = uc.ReadUsersTable();
            userListGridView.DataSource = dt;
        }

    }
}
