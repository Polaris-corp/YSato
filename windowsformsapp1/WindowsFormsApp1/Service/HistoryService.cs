﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace WindowsFormsApp1.Service
{
    public class HistoryService
    {
        /// <summary>
        /// DBのHistoryTable内にログイン履歴を残すメソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="flg">ログイン成否</param>
        public void DBAccessTimeStamp(string loginId, int flg)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                connection.Open();
                CommandCreationTime(loginId, flg, connection).ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 直近3件(降順)のログイン履歴を取得するメソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <returns>ログイン履歴(直近3件)</returns>
        public List<History> DBAccessLatest3Cases(string loginId)
        {
            List<History> latest3Cases = new List<History>();
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                connection.Open();

                MySqlDataReader reader = CommandCreationLatest3Cases(loginId, connection).ExecuteReader();

                while (reader.Read())
                {
                    History tmp = new History();
                    tmp.Result = Convert.ToInt32(reader["Rslt"]);
                    tmp.Times = Convert.ToDateTime(reader["Datetime"]);
                    latest3Cases.Add(tmp);
                }
                return latest3Cases;
            }
        }
        /// <summary>
        /// ログイン不可時の残り時間取得メソッド
        /// </summary>
        /// <param name="time">近々のログイン失敗時間</param>
        /// <returns>ログイン可になるまでの残り時間</returns>
        public TimeSpan LoginUnLockTime(DateTime time)
        {
            return time.AddMinutes(5) - DateTime.Now;
        }
        /// <summary>
        /// ログイン履歴記録用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="res">ログイン成否</param>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        public MySqlCommand CommandCreationTime(string loginId, int res, MySqlConnection connection)
        {
            string query = $@"
                INSERT INTO 
                    login_history
                    (
                        User_ID
                        ,Datetime
                        ,Rslt
                    )
                VALUES
                (
                    @loginId
                    ,CURRENT_TIMESTAMP
                    ,@res
                );
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@loginId", loginId);
            command.Parameters.AddWithValue("@res", res);
            return command;
        }
        /// <summary>
        /// 直近3件のログイン履歴取得用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        public MySqlCommand CommandCreationLatest3Cases(string loginId, MySqlConnection connection)
        {
            string query = $@"
                SELECT 
                    l.Rslt
                    ,l.Datetime 
                FROM 
                    login_history AS l 
                WHERE 
                    l.User_ID = @loginId 
                ORDER BY 
                    l.Datetime DESC 
                LIMIT 
                    3;
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@loginId", loginId);
            return command;
        }
    }
}