using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2.Controller
{
    public class LoginController
    {
        Service.UsersService us = new Service.UsersService();
        Service.HistoryService hs = new Service.HistoryService();
        /// <summary>
        /// DBにログインIDと合致するUserIDが存在するか確認するコントローラー
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <returns>合致するUserIDが存在するかの真偽</returns>
        public bool DBAccessUserExistence(int userId)
        {
            return us.DBAccessUserExistence(userId);
        }
        /// <summary>
        /// IDとPwdの紐づき確認コントローラー
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <returns>ユーザーIDとログインパスワードが紐づいているかの真偽</returns>
        public bool DBAccessCheckPwd(int userId, string loginPassword)
        {
            return us.DBAccessCheckPwd(userId, loginPassword);
        }
        /// <summary>
        /// DBのHistoryTable内にログイン履歴を残すコントローラー
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="result">ログイン成否</param>
        public void DBAccessTimeStamp(int userId, int result, DateTime dateTimeNow)
        {
            hs.DBAccessTimeStamp(userId, result, dateTimeNow);
        }
        /// <summary>
        /// ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間を取得するコントローラー
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <returns>ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間</returns>
        public HistoryModel DBAccessGetResultAndLoginTime(int userId)
        {
            return hs.DBAccessGetResultAndLoginTime(userId);
        }
        /// <summary>
        /// ログイン不可時の残り時間表示コントローラー
        /// </summary>
        /// <param name="time">近々のログイン失敗時間</param>
        /// <returns>ログイン可になるまでの残り時間</returns>
        public TimeSpan LoginUnLockTime(DateTime time, DateTime dateTimeNow)
        {
            return hs.LoginUnLockTime(time, dateTimeNow);
        }
    }
}
