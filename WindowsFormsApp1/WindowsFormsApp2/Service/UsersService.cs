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
        /// <summary>
        /// IDとPwdの存在と紐づきの確認メソッド
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <returns>ユーザーIDとログインパスワードが存在して、紐づいているかの真偽</returns>
        public bool DBAccessCheckIdAndPwd(int userId, string loginPassword)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                // 接続の確立
                connection.Open();
                MySqlDataReader reader = CommandCreationIdAndPwd(userId, loginPassword, connection).ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                return false;
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
        /// <summary>
        /// UserIDとPwdの紐づき確認用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        public MySqlCommand CommandCreationIdAndPwd(int userId, string loginPassword, MySqlConnection connection)
        {
            string query = $@"
                SELECT
                    u.ID
                FROM
                    users AS u
                WHERE
                    u.ID = @userId
                    AND u.Pwd = @loginPassword
                    AND u.Deleted = 0;
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@loginPassword", loginPassword);
            return command;
        }
    }
}
