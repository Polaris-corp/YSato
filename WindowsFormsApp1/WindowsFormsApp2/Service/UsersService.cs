using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using WindowsFormsApp2.Common;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2.Service
{
    public class UsersService
    {
        /// <summary>
        /// ユーザー一覧をDataTableで取得するメソッド
        /// </summary>
        /// <returns>ユーザー一覧のDataTable</returns>
        public DataTable ReadUsersTable()
        {
            return DBAccessReadTable(CommandCreationUsersTable());
        }
        /// <summary>
        /// ユーザー一覧をDataTableで取得するメソッド
        /// </summary>
        /// <param name="deletedUsers">削除済みユーザーかどうかの真偽</param>
        /// <returns>ユーザー一覧のDataTable</returns>
        public DataTable ReadUsersTable(bool deletedUsers)
        {
            return DBAccessReadTable(CommandCreationUsersTable(deletedUsers));
        }
        /// <summary>
        /// ユーザー情報登録メソッド
        /// </summary>
        /// <param name="model">ユーザー情報</param>
        public void InsertAccount(RegistrationModel model)
        {
            DBAccessExecuteNonQuery(CommandCreationInsertAccount(model));
        }
        /// <summary>
        /// ユーザー情報変更メソッド
        /// </summary>
        /// <param name="model">ユーザー情報</param>
        public void UpdateAccount(RegistrationModel model)
        {
            DBAccessExecuteNonQuery(CommandCreationUpdateAccount(model));
        }
        /// <summary>
        /// DBへ接続し、値をDataTableに格納するメソッド
        /// </summary>
        /// <param name="command">SQLコマンド</param>
        /// <returns>ユーザー一覧のDataTable</returns>
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
        /// <summary>
        /// DBへ接続し、値の追加か変更を行うメソッド
        /// </summary>
        /// <param name="command">SQLコマンド</param>
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
        /// <summary>
        /// ユーザー一覧取得用コマンド生成メソッド
        /// </summary>
        /// <returns>ユーザー一覧取得用コマンド</returns>
        private MySqlCommand CommandCreationUsersTable()
        {
            string query = $@"
                SELECT
                    ID
                    ,Name
                    ,Pwd
                    ,Deleted
                FROM
                    users;
                ";
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }
        /// <summary>
        /// ユーザー一覧取得用コマンド生成メソッド
        /// </summary>
        /// <param name="deletedUsers">削除済みユーザーかどうかの真偽</param>
        /// <returns>ユーザー一覧取得用コマンド</returns>
        private MySqlCommand CommandCreationUsersTable(bool deletedUsers)
        {
            string query = $@"
                SELECT
                    ID
                    ,Name
                    ,Pwd
                    ,Deleted
                FROM
                    users
                WHERE
                    Deleted = @deleted;
                ";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@deleted", deletedUsers);
            return command;
        }
        /// <summary>
        /// ユーザー情報登録用コマンド生成メソッド
        /// </summary>
        /// <param name="model">ユーザー情報</param>
        /// <returns>SQLコマンド</returns>
        private MySqlCommand CommandCreationInsertAccount(RegistrationModel model)
        {
            string query = $@"
                INSERT INTO
                    users
                        (
                        Name
                        ,Pwd
                        ,Deleted
                        )
                    VALUE
                        (
                        @name
                        ,@pwd
                        ,@deleted
                        );
                ";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", model.Name);
            command.Parameters.AddWithValue("@pwd", model.Pwd);
            command.Parameters.AddWithValue("@deleted", model.Deleted);
            return command;
        }
        /// <summary>
        /// ユーザー情報変更用コマンド生成メソッド
        /// </summary>
        /// <param name="model">ユーザー情報</param>
        /// <returns>SQLコマンド</returns>
        private MySqlCommand CommandCreationUpdateAccount(RegistrationModel model)
        {
            string query = $@"
                UPDATE
                    users
                SET
                    Name = @name
                    ,Pwd = @pwd
                    ,Deleted = @deleted
                WHERE
                    ID = @userId;
                ";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@userId", int.Parse(model.UserId));
            command.Parameters.AddWithValue("@name", model.Name);
            command.Parameters.AddWithValue("@pwd", model.Pwd);
            command.Parameters.AddWithValue("@deleted", model.Deleted);
            return command;
        }
        /// <summary>
        /// UserIDとPwdの紐づき確認用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="pwd">ユーザーパスワード</param>
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

