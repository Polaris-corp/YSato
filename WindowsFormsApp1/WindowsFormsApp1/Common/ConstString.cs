using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Common
{
    public static class ConstString
    {
        public const string ConnectionString = "Server=localhost;User ID=root;Password=1105;Database=login_test";
        public const string EmptyMessage = "IDかPasswordが空です";
        public const string NotIdNumberMessage = "数字を入力してください";
        public const string NotusersMessage = "該当するユーザーが見当たりません";
        public const string NotPwdMatchMessage = "パスワードが間違っています";
        public const string LoginMessagE = "ログインしました";
        public const string LoginImpossible = "あと{0}ログイン出来ません";
        public const string ErrorMessage = "エラーです";
    }
}
