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
using WindowsFormsApp1.Common;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2
{
    public partial class UsersTableViewForm : Form
    {
        public UsersTableViewForm()
        {
            InitializeComponent();
        }

        private void UsersTableViewForm_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM users";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    int count = reader.FieldCount;
                    dataGridView1.ColumnCount = count;
                    for (int i = 0; i < count; i++)
                    {
                        string name = reader.GetName(i);
                        dataGridView1.Columns[i].HeaderText = name;
                        dataGridView1.Columns[i].Name = name;
                    }
                    while (reader.Read())
                    {
                        object[] row = new object[count];
                        reader.GetValues(row);
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
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
                RegistrationForm registrationForm = new RegistrationForm();
                registrationForm.model = model;
                registrationForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(Common.ConstString.NullString);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

