using System;
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
        /// <param name="query">SQLクエリ</param>
        public void DBAccessTimeStamp(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                return;
            }
        }
        /// <summary>
        /// 直近3件のログイン履歴を取得するメソッド
        /// </summary>
        /// <param name="query">SQLクエリ</param>
        /// <returns>ログイン履歴(直近3件)</returns>
        public List<History> DBAccessLatest3Cases(string query)
        {
            List<History> latest3Cases = new List<History>();
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

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
        /// ログイン履歴記録用SQLクエリ生成メソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="res">ログイン成否</param>
        /// <returns>SQLクエリ</returns>
        public string QueryCreationTime(string loginId, int res)
        {
            string sql = $@"
                INSERT INTO 
                    login_history
                    (
                        User_ID
                        ,Datetime
                        ,Rslt
                    )
                VALUES
                (
                    {loginId}
                    ,CURRENT_TIMESTAMP
                    ,{res}
                );
                ";
            return sql;
        }
        /// <summary>
        /// 直近3件のログイン履歴取得用SQLクエリ生成メソッド
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <returns>SQLクエリ</returns>
        public string QueryCreationLatest3Cases(string loginId)
        {
            string sql = $@"
                SELECT 
                    l.Rslt
                    ,l.Datetime 
                FROM 
                    login_history AS l 
                WHERE 
                    l.User_ID = {loginId} 
                ORDER BY 
                    l.Datetime DESC 
                LIMIT 
                    3;
                ";
            return sql;
        }
    }
}
