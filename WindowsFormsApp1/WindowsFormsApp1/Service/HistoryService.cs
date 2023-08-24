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
        public void DBAccessTimeStamp(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                // 接続の確立
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                return;
            }
        }
        public List<History> DBAccessLatest3Cases(string query)
        {
            List<History> latest3Cases = new List<History>();
            using (MySqlConnection connection = new MySqlConnection(ConstString.CONNECTION_STRING))
            {
                // 接続の確立
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
        public TimeSpan LoginUnLockTime(DateTime time)
        {
            return time.AddMinutes(5) - DateTime.Now;
        }
        public string QueryCreationTime(string loginId, int res)
        {
            string sql = $@"
            INSERT INTO 
                login_history (User_ID, Datetime, Rslt) 
            VALUE 
                ({loginId}, CURRENT_TIMESTAMP, {res})
            ";
            return sql;
        }
        public string QueryCreationLatest3Cases(string loginId)
        {
            string sql = $@"
            SELECT 
                l.Rslt, l.Datetime 
            FROM 
                login_history AS l 
            WHERE 
                l.User_ID={loginId} 
            ORDER BY 
                l.Datetime DESC 
            LIMIT 
                3
            ";
            return sql;
        }
    }
}
