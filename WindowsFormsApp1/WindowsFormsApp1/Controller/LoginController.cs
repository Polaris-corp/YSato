using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Controller
{
    public class LoginController
    {
        Service.UsersService us = new Service.UsersService();
        Service.HistoryService hs = new Service.HistoryService();
        /// <summary>
        /// DBからUserIDを取得するコントローラー
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <returns>UserID</returns>
        public string DBAccessGetUserId(string loginId)
        {
            return us.DBAccessGetUserId(us.QueryCreationID(loginId));
        }
        /// <summary>
        /// IDとPwdの紐づき確認コントローラー
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="loginPassword">ログインパスワード</param>
        /// <returns>UserID</returns>
        public int DBAccessCheckPwd(string loginId, string loginPassword)
        {
            return us.DBAccessCheckPwd(us.QueryCreationPwd(loginId,loginPassword));
        }
        /// <summary>
        /// DBのHistoryTable内にログイン履歴を残すコントローラー
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="flg">ログイン成否</param>
        public void DBAccessTimeStamp(string loginId, int flg)
        {
            hs.DBAccessTimeStamp(hs.QueryCreationTime(loginId, flg));
        }
        /// <summary>
        /// 直近3件のログイン履歴を取得するコントローラー
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <returns>ログイン履歴(直近3件)</returns>
        public List<History> DBAccessLatest3Cases(string loginId)
        {
            return hs.DBAccessLatest3Cases(hs.QueryCreationLatest3Cases(loginId));
        }
        /// <summary>
        /// ログイン不可時の残り時間表示コントローラー
        /// </summary>
        /// <param name="time">近々のログイン失敗時間</param>
        /// <returns>ログイン可になるまでの残り時間</returns>
        public TimeSpan LoginUnLockTime(DateTime time)
        {
            return hs.LoginUnLockTime(time);
        }
    }
}
