using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApp2.Common;

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
        public void DeleteAccount(int userId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                connection.Open();
                CommandCreationDeleteAccount(userId, connection).ExecuteNonQuery();
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
                    users
                WHERE
                    Deleted = 0;
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
        public MySqlCommand CommandCreationDeleteAccount(int userId, MySqlConnection connection)
        {
            string query = $@"
                UPDATE
                    users 
                SET
                    Deleted = 1 
                WHERE
                    ID = @userId;
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", userId);
            return command;
        }
    }
}
