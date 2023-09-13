using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using WindowsFormsApp2.Common;

namespace WindowsFormsApp2.Service
{
    public class UsersService
    {
        public DataTable ReadUsersTable()
        {
            return DBAccessReadTable(CommandCreationUsersTable());
        }
        public DataTable ReadUsersTable(bool deletedUsers)
        {
            return DBAccessReadTable(CommandCreationUsersTable(deletedUsers));
        }
        public void InsertAccount(string name, string pwd)
        {
            DBAccessExecuteNonQuery(CommandCreationInsertAccount(name, pwd));
        }
        public void UpdateAccount(int userId, string name, string pwd)
        {
            DBAccessExecuteNonQuery(CommandCreationUpdateAccount(userId, name, pwd));
        }
        public void DeleteAccount(int userId)
        {
            DBAccessExecuteNonQuery(CommandCreationDeleteAccount(userId));
        }
        private DataTable DBAccessReadTable(MySqlCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                command.Connection = connection;
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt);
                return dt;
            }
        }
        private void DBAccessExecuteNonQuery(MySqlCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// IDとPwdの存在と紐づきの確認メソッド
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <returns>ユーザーIDとログインパスワードが存在して、紐づいているかの真偽</returns>
        public bool DBAccessCheckIdAndPwd(int userId, string pwd)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                connection.Open();
                MySqlDataReader reader = CommandCreationIdAndPwd(userId, pwd, connection).ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
        }
        private MySqlCommand CommandCreationUsersTable()
        {
            string query = $@"
                SELECT
                    ID
                    ,Name
                    ,Pwd
                FROM
                    users;
                ";
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }
        private MySqlCommand CommandCreationUsersTable(bool deletedUsers)
        {
            string query = $@"
                SELECT
                    ID
                    ,Name
                    ,Pwd
                FROM
                    users
                WHERE
                    Deleted = @deleted;
                ";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@deleted", deletedUsers);
            return command;
        }
        private MySqlCommand CommandCreationInsertAccount(string name, string pwd)
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
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@pwd", pwd);
            return command;
        }
        private MySqlCommand CommandCreationUpdateAccount(int userId, string name, string pwd)
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
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@pwd", pwd);
            return command;
        }
        private MySqlCommand CommandCreationDeleteAccount(int userId)
        {
            string query = $@"
                UPDATE
                    users 
                SET
                    Deleted = 1 
                WHERE
                    ID = @userId;
                ";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@userId", userId);
            return command;
        }
        /// <summary>
        /// UserIDとPwdの紐づき確認用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        private MySqlCommand CommandCreationIdAndPwd(int userId, string pwd, MySqlConnection connection)
        {
            string query = $@"
                SELECT
                    u.ID
                FROM
                    users AS u
                WHERE
                    u.ID = @userId
                    AND u.Pwd = @pwd
                    AND u.Deleted = 0;
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@pwd", pwd);
            return command;
        }
    }
}

