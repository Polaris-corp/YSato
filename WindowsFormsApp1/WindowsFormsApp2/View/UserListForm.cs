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
using WindowsFormsApp2.Common;
using WindowsFormsApp2.Controller;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2
{
    public partial class UsersListForm : Form
    {
        public UsersListForm()
        {
            InitializeComponent();
        }
        UsersListController usersListController = new UsersListController();
        DataTable dt = new DataTable();
        bool isChangeButton = false;

        private void UserListForm_Load(object sender, EventArgs e)
        {
            cmbViewType.SelectedIndex = ConstNumber.ShowUndeletedUser;
            LoadUserData();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            isChangeButton = false;
            RegistrationModel model = new RegistrationModel();
            RegisterForm registrationForm = new RegisterForm(model, isChangeButton);
            registrationForm.ShowDialog();
            LoadUserData();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            isChangeButton = true;
            if (userListGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(ConstString.NotSelectedRowMessage);
                return;
            }
            DataGridViewRow selectedRow = userListGridView.SelectedRows[0];
            RegistrationModel model = new RegistrationModel
            {
                UserId = selectedRow.Cells["ID"].Value.ToString(),
                Name = selectedRow.Cells["Name"].Value.ToString(),
                Pwd = selectedRow.Cells["Pwd"].Value.ToString(),
                Deleted = Convert.ToBoolean(selectedRow.Cells["Deleted"].Value)
            };
            RegisterForm registrationForm = new RegisterForm(model, isChangeButton);
            registrationForm.ShowDialog();
            LoadUserData();
        }

        private void LoadUserData()
        {
            if (cmbViewType.SelectedIndex == ConstNumber.ShowUndeletedUser)
            {
                dt = usersListController.ReadUsersTable(!ConstOthers.IsDeletedUser);
            }
            else if (cmbViewType.SelectedIndex == ConstNumber.ShowDeletedUser)
            {
                dt = usersListController.ReadUsersTable(ConstOthers.IsDeletedUser);
            }
            else
            {
                dt = usersListController.ReadUsersTable();
            }
            userListGridView.DataSource = dt;
        }

        private void CmbViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}

