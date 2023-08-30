using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Common
{
    public static class ConstString
    {
        public const string CONNECTION_STRING = "Server=localhost;User ID=root;Password=1105;Database=login_test";
        public const string EMPTY_MESSAGE = "IDかPasswordが空です";
        public const string NOTUSERS_MESSAGE = "該当するユーザーが見当たりません";
        public const string NOT_PWD_MATCH_MESSAGE = "パスワードが間違っています";
        public const string LOGIN_MESSAGE = "ログインしました";
        public const string LOGIN_IMPOSSIBLE = "あと{0}ログイン出来ません";
        public const string ERROR_MESSAGE = "エラーです";
    }
}
