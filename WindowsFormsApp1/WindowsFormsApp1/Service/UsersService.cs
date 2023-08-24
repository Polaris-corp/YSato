﻿using System;
using System.Collections.Generic;
using MySqlConnector;

namespace WindowsFormsApp1.Service
{
    public class UsersService
    {
        public string DBAccessUsersList(string query)
        {
            string result = "";
            MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING
);
            try
            {
                // 接続の確立
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader["ID"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int DBAccessCheckPwd(string query)
        {
            int res = 0;
            MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING
);
            try
            {
                // 接続の確立
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res += Convert.ToInt32(reader["res"]);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return res;
        }
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
        public string QueryCreationPwd(string loginId, string loginPassword)
        {
            string sql = $@"
            SELECT 
                u.ID, CASE 
                    WHEN ( 
                        u.ID = {loginId} 
                        AND u.Pwd = {loginPassword} 
                    ) 
                        THEN true 
                    ELSE false 
                    END AS res 
            FROM 
                users AS u;
            ";
            return sql;
        }

    }
}
