using System;
using MySqlConnector;
using WindowsFormsApp1.Common;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Service
{
    public class HistoryService
    {
        /// <summary>
        /// DBのHistoryTable内にログイン履歴を残すメソッド
        /// </summary>
        /// <param name="userId">ログインID</param>
        /// <param name="flg">ログイン成否</param>
        public void DBAccessTimeStamp(string userId, int flg, DateTime dateTimeNow)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                connection.Open();
                CommandCreationTime(userId, flg, connection, dateTimeNow).ExecuteNonQuery();
            }
        }
        /// <summary>
        /// ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間を取得するメソッド
        /// </summary>
        /// <param name="userId">ログインID</param>
        /// <returns>ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間</returns>
        public HistoryModel DBAccessGetResultAndLoginTime(string userId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                HistoryModel resultAndLoginTime = new HistoryModel();
                connection.Open();

                MySqlDataReader reader = CommandCreationGetResultAndLoginTime(userId, connection).ExecuteReader();

                if (reader.Read())
                {
                    resultAndLoginTime.LoginFailureCount = Convert.ToInt32(reader["cnt"]);
                    resultAndLoginTime.NewestTimes = (DateTime)reader["new"];
                    resultAndLoginTime.OldestTimes = (DateTime)reader["old"];
                }
                return resultAndLoginTime;
            }
        }
        /// <summary>
        /// ログイン不可時の残り時間取得メソッド
        /// </summary>
        /// <param name="time">近々のログイン失敗時間</param>
        /// <returns>ログイン可になるまでの残り時間</returns>
        public TimeSpan LoginUnLockTime(DateTime time, DateTime dateTimeNow)
        {
            return time.AddMinutes(5) - dateTimeNow;
        }
        /// <summary>
        /// ログイン履歴記録用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="userId">ログインID</param>
        /// <param name="res">ログイン成否</param>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        public MySqlCommand CommandCreationTime(string userId, int res, MySqlConnection connection, DateTime dateTimeNow)
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
                    ,@dateTimeNow
                    ,@res
                );
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@loginId", userId);
            command.Parameters.AddWithValue("@dateTimeNow", dateTimeNow);
            command.Parameters.AddWithValue("@res", res);
            return command;
        }
        /// <summary>
        /// 直近3件のログイン履歴取得用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="userId">ログインID</param>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        public MySqlCommand CommandCreationGetResultAndLoginTime(string userId, MySqlConnection connection)
        {
            string query = $@"
                SELECT
                    count(*) as cnt
                    ,MAX(T.Datetime) as new
                    ,MIN(T.Datetime) as old
                FROM
                    (
                    SELECT
                        l.Rslt
                        , l.Datetime
                    FROM
                        login_history AS l
                    WHERE
                        l.User_ID = @loginId
                    ORDER BY
                        l.Datetime DESC
                    LIMIT
                        3
                    ) as t
                WHERE
                    t.Rslt = 0;
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@loginId", userId);
            return command;
        }
    }
}