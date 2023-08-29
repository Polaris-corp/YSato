﻿using System;
using System.Collections.Generic;
using MySqlConnector;

namespace WindowsFormsApp1.Service
{
    public class UsersService
    {
        /// <summary>
        /// DBにログインIDと合致するUserIDが存在するか確認するメソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <returns>合致するUserIDが存在するかの真偽</returns>
        public bool DBAccessUserExistence(string loginId)
        {
            bool existence = false;
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                connection.Open();

                MySqlDataReader reader = CommandCreationID(loginId, connection).ExecuteReader();
                if (reader.Read())
                {
                    existence = reader.GetBoolean("ID");
                }
            }
            return existence;
        }
        /// <summary>
        /// IDとPwdの紐づき確認メソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <returns>UserID</returns>
        public int DBAccessCheckPwd(string loginId, string loginPassword)
        {
            int res = 0;
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                // 接続の確立
                connection.Open();
                MySqlDataReader reader = CommandCreationPwd(loginId, loginPassword, connection).ExecuteReader();
                while (reader.Read())
                {
                    res += Convert.ToInt32(reader["ID"]);
                }
                return res;
            }
        }
        /// <summary>
        /// UserID取得用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        public MySqlCommand CommandCreationID(string loginId, MySqlConnection connection)
        {
            string query = $@"
                SELECT 
                    u.ID AS ID 
                FROM 
                    users AS u 
                WHERE 
                    ID = @loginId;
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@loginId", loginId);
            return command;
        }
        /// <summary>
        /// UserIDとPwdの紐づき確認用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        public MySqlCommand CommandCreationPwd(string loginId, string loginPassword, MySqlConnection connection)
        {
            string query = $@"
                SELECT
                    u.ID
                FROM
                    users AS u
                WHERE
                    u.ID = @loginId
                    AND u.Pwd = @loginPassword; 
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@loginId", loginId);
            command.Parameters.AddWithValue("@loginPassword", loginPassword);
            return command;
        }

    }
}
