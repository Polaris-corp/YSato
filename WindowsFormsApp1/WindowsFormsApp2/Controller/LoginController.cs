using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Common;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2.Controller
{
    public class LoginController
    {
        Service.UsersService usersService = new Service.UsersService();
        Service.HistoryService historyService = new Service.HistoryService();
        
        /// <summary>
        /// IDとPwdの存在と紐づきの確認コントローラー
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <returns>ユーザーIDとログインパスワードが紐づいているかの真偽</returns>
        public bool DBAccessCheckIdAndPwd(int userId, string loginPassword)
        {
            return usersService.DBAccessCheckIdAndPwd(userId, loginPassword);
        }
        /// <summary>
        /// DBのHistoryTable内にログイン履歴を残すコントローラー
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="result">ログイン成否</param>
        public void DBAccessTimeStamp(int userId, int result, DateTime dateTimeNow)
        {
            historyService.DBAccessTimeStamp(userId, result, dateTimeNow);
        }
        /// <summary>
        /// ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間を取得するコントローラー
        /// </summary>
        /// <returns>ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間</returns>
        public HistoryModel DBAccessLoginNotPossibleTime(int userId)
        {
            return historyService.DBAccessLoginNotPossibleTime(userId);
        }
        /// <summary>
        /// ログイン不可時の残り時間表示コントローラー
        /// </summary>
        /// <param name="time">近々のログイン失敗時間</param>
        /// <returns>ログイン可になるまでの残り時間</returns>
        public TimeSpan LoginUnLockTime(DateTime time, DateTime dateTimeNow)
        {
            return historyService.LoginUnLockTime(time, dateTimeNow);
        }
        public bool IsLoginLock(HistoryModel history, DateTime dateTimeNow)
        {
            if (history.LoginFailureCount == ConstNumber.MaxLoginFailures)
            {
                if (history.NewestTimes - history.OldestTimes <= ConstOthers.LoginFailureThreshold)
                {
                    if (dateTimeNow - history.NewestTimes <= ConstOthers.LoginFailureThreshold)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
