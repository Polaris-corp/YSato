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
        public string DBAccessGetUserId(string loginId)
        {
            return us.DBAccessGetUserId(us.QueryCreationID(loginId));
        }
        public int DBAccessCheckPwd(string loginId, string loginPassword)
        {
            return us.DBAccessCheckPwd(us.QueryCreationPwd(loginId,loginPassword));
        }
        public void DBAccessTimeStamp(string loginId, int flg)
        {
            hs.DBAccessTimeStamp(hs.QueryCreationTime(loginId, flg));
        }
        public List<History> DBAccessLatest3Cases(string loginId)
        {
            return hs.DBAccessLatest3Cases(hs.QueryCreationLatest3Cases(loginId));
        }
        public TimeSpan LoginUnLockTime(DateTime time)
        {
            return hs.LoginUnLockTime(time);
        }
    }
}
