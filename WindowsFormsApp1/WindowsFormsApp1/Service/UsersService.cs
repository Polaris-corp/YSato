using System;
using MySqlConnector;
using WindowsFormsApp1.Common;

namespace WindowsFormsApp1.Service
{
    public class UsersService
    {
        /// <summary>
        /// DBにログインIDと合致するUserIDが存在するか確認するメソッド
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <returns>合致するUserIDが存在するかの真偽</returns>
        public bool DBAccessUserExistence(string userId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                connection.Open();

                MySqlDataReader reader = CommandCreationID(userId, connection).ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// IDとPwdの紐づき確認メソッド
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <returns>ユーザーIDとログインパスワードが紐づいているかの真偽</returns>
        public bool DBAccessCheckPwd(string userId, string loginPassword)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                // 接続の確立
                connection.Open();
                MySqlDataReader reader = CommandCreationPwd(userId, loginPassword, connection).ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// UserID取得用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        public MySqlCommand CommandCreationID(string userId, MySqlConnection connection)
        {
            string query = $@"
                SELECT 
                    u.ID AS ID 
                FROM 
                    users AS u 
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
        public MySqlCommand CommandCreationPwd(string userId, string loginPassword, MySqlConnection connection)
        {
            string query = $@"
                SELECT
                    u.ID
                FROM
                    users AS u
                WHERE
                    u.ID = @userId
                    AND u.Pwd = @loginPassword; 
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@loginPassword", loginPassword);
            return command;
        }

    }
}
