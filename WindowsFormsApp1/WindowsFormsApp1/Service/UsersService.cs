using System;
using System.Collections.Generic;
using MySqlConnector;

namespace WindowsFormsApp1.Service
{
    public class UsersService
    {
        /// <summary>
        /// DBにログインIDと合致するUserIDが存在するか確認するメソッド
        /// </summary>
        /// <param name="query">SQLクエリ</param>
        /// <returns>合致するUserIDが存在するかの真偽</returns>
        public bool DBAccessUserExistence(string query)
        {
            bool existence = false;
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    existence = reader.GetBoolean("");
                }
            }
            return existence;
        }
        /// <summary>
        /// IDとPwdの紐づき確認メソッド
        /// </summary>
        /// <param name="query">SQLクエリ</param>
        /// <returns>UserID</returns>
        public int DBAccessCheckPwd(string query)
        {
            int res = 0;
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                // 接続の確立
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res += Convert.ToInt32(reader["ID"]);
                }
                return res;
            }
        }
        /// <summary>
        /// UserID取得用SQLクエリ生成メソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <returns>SQLクエリ</returns>
        public string QueryCreationID(string loginId)
        {
            string sql = $@"
                SELECT 
                    u.ID AS ID 
                FROM 
                    users AS u 
                WHERE 
                    ID = {loginId};
                ";
            return sql;
        }
        /// <summary>
        /// UserIDとPwdの紐づき確認用SQLクエリ生成メソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <returns>SQLクエリ</returns>
        public string QueryCreationPwd(string loginId, string loginPassword)
        {
            string sql = $@"
                SELECT
                    u.ID
                FROM
                    users AS u
                WHERE
                    u.ID = {loginId}
                    AND u.Pwd = {loginPassword}; 
                ";
            return sql;
        }

    }
}
