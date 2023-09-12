using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Common;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2.Service
{
    public class HistoryService
    {
        /// <summary>
        /// DBのHistoryTable内にログイン履歴を残すメソッド
        /// </summary>
        /// <param name="result">ログイン成否</param>
        public void DBAccessTimeStamp(int result, DateTime dateTimeNow)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                connection.Open();
                CommandCreationTime(result, connection, dateTimeNow).ExecuteNonQuery();
            }
        }
        /// <summary>
        /// ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間を取得するメソッド
        /// </summary>
        /// <returns>ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間</returns>
        public HistoryModel DBAccessLoginNotPossibleTime()
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.ConnectionString))
            {
                HistoryModel resultAndLoginTime = new HistoryModel();
                connection.Open();

                MySqlDataReader reader = CommandCreationLoginNotPossibleTime(connection).ExecuteReader();

                if (reader.Read())
                {
                    resultAndLoginTime.LoginFailureCount = reader.GetInt32("cnt");
                    resultAndLoginTime.NewestTimes = reader.GetDateTime("new");
                    resultAndLoginTime.OldestTimes = reader.GetDateTime("old");
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
        /// <param name="result">ログイン成否</param>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        public MySqlCommand CommandCreationTime(int result, MySqlConnection connection, DateTime dateTimeNow)
        {
            string query = $@"
                INSERT INTO
                    login_history
                        (
                        Datetime
                        ,Rslt
                        )
                VALUES
                    (
                    @dateTimeNow
                    ,@rslt
                    );
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@dateTimeNow", dateTimeNow);
            command.Parameters.AddWithValue("@rslt", result);
            return command;
        }
        /// <summary>
        /// ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間の取得用SQLコマンド生成メソッド
        /// </summary>
        /// <param name="connection">MySqlConnectionクラスのインスタンス</param>
        /// <returns>SQLコマンド</returns>
        public MySqlCommand CommandCreationLoginNotPossibleTime(MySqlConnection connection)
        {
            string query = $@"
                SELECT
                    count(*) as cnt
                    ,IFNULL
                        (
                        MAX(t.Datetime)
                        , CURRENT_TIMESTAMP()
                        ) as new
                    ,IFNULL
                        (
                        MIN(t.Datetime)
                        , CURRENT_TIMESTAMP()
                        ) as old
                FROM
                    (
                    SELECT
                        l.Rslt
                        , l.Datetime
                    FROM
                        login_history as l
                    ORDER BY
                        l.Datetime DESC
                    LIMIT
                        3
                    ) as t
                WHERE
                    t.Rslt = 0;
                ";
            MySqlCommand command = new MySqlCommand(query, connection);
            return command;
        }
    }
}
