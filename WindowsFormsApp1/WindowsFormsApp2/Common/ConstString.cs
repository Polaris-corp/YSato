using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Common
{
    public static class ConstString
    {
        public const string ConnectionString = "Server=localhost;User ID=root;Password=1105;Database=login_test";
        public const string RegistrationString = "登録";
        public const string ChangeString = "変更";
        public const string EmptyMessage = "IDかPasswordが空です";
        public const string NotIdNumberMessage = "数字を入力してください";
        public const string NotMatchMessage = "IDかパスワードが間違っています";
        public const string LoginMessage = "ログインしました";
        public const string LoginImpossible = "あと{0}ログイン出来ません";
        public const string ErrorMessage = "エラーです";
        public const string ErrorDirectoryPath = @".\ErrorLogs";
        public const string ErrorFileName = "ErrorLogs.log";
        public const string ErrorInfo = "ERRORMESSAGE:{0}\r\nSTACKTRACE:{1}";
    }
}
