using MySqlConnector;
using WindowsFormsApp1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApp2.Service
{
    public class UsersService
    {
        public DataTable ReadUsersTable()
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                MySqlCommand command = CommandCreationUsersTable(connection);
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt);
                return dt;
                //using (MySqlDataReader reader = command.ExecuteReader())
                //{
                //    return reader;
                    //int count = reader.FieldCount;
                    //dataGridView1.ColumnCount = count;
                    //for (int i = 0; i < count; i++)
                    //{
                    //    string name = reader.GetName(i);
                    //    dataGridView1.Columns[i].HeaderText = name;
                    //    dataGridView1.Columns[i].Name = name;
                    //}
                    //while (reader.Read())
                    //{
                    //    object[] row = new object[count];
                    //    reader.GetValues(row);
                    //    dataGridView1.Rows.Add(row);
                    //}
                //}
            }

        }
        public void InsertAccount(string name, string pwd)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                connection.Open();
                CommandCreationInsertAccount(name, pwd, connection).ExecuteNonQuery();
            }
        }
        public void UpdateAccount(int userId, string name, string pwd)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                connection.Open();
                CommandCreationUpdateAccount(userId, name, pwd, connection).ExecuteNonQuery();
            }
        }
        public MySqlCommand CommandCreationUsersTable(MySqlConnection connection)
        {
            string query = $@"
                SELECT
                    ID
                    ,Name
                    ,Pwd
                FROM
                    users;
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            return command;
        }
        public MySqlCommand CommandCreationInsertAccount(string name, string pwd, MySqlConnection connection)
        {
            string query = $@"
                INSERT INTO
                    users
                        (
                        Name
                        ,Pwd
                        )
                    VALUE
                        (
                        @name
                        ,@pwd
                        );
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@pwd", pwd);
            return command;
        }
        public MySqlCommand CommandCreationUpdateAccount(int userId, string name, string pwd, MySqlConnection connection)
        {
            string query = $@"
                UPDATE
                    users
                SET
                    Name = @name
                    ,Pwd = @pwd
                WHERE
                    ID = @userId;
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@pwd", pwd);
            return command;
        }
    }
}
