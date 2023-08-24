using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        Controller.LoginController lc = new Controller.LoginController();
        // 接続文字列
        private string loginId = "";
        private string loginPassword = "";
        private int matchUser = 0;

        private void login_Click(object sender, EventArgs e)
        {
            //IDとPwdを受け取る
            loginId = textBox1.Text;
            loginPassword = textBox2.Text;
            //入力チェック
            if (string.IsNullOrEmpty(loginId) || string.IsNullOrEmpty(loginPassword))
            {
                MessageBox.Show(ConstString.EMPTY_MESSAGE);
                return;
            }
            try
            {
                //IDの取得
                string user = lc.DBAccessUsersList(loginId);
                //IDチェック
                if (user != loginId)
                {
                    MessageBox.Show(ConstString.NOTUSERS_MESSAGE);
                    return;
                }
                //IDとPwdの紐づきのデータの受け取り
                matchUser = lc.DBAccessCheckPwd(loginId, loginPassword);
                //IDとPwdが紐づいたユーザーがいるかどうかのチェック
                if (matchUser == 0)
                {
                    MessageBox.Show(ConstString.NOT_PWD_MATCH_MESSAGE);
                    lc.DBAccessTimeStamp(loginId, 0);
                    return;
                }
                ////IDのヒストリー直近3件取得
                List<History> history = lc.DBAccessLatest3Cases(loginId);
                //直近3件のログイン失敗チェック
                TimeSpan minus5 = TimeSpan.FromMinutes(5);
                if (history.Count == 3 && history[0].Times - history[2].Times <= minus5)
                {
                    int sum = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        sum += history[i].Result;
                    }
                    if (sum == 0 && DateTime.Now - history[0].Times <= minus5)
                    {
                        //直近のログイン失敗から何分経過しているか
                        TimeSpan t = lc.LoginUnLockTime(history[0].Times);
                        MessageBox.Show(string.Format(ConstString.LOGIN_IMPOSSIBLE, t.ToString(@"mm\分ss\秒")));
                        return;
                    }
                }
                MessageBox.Show(ConstString.LOGIN_MESSAGE);
                lc.DBAccessTimeStamp(loginId, 1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ConstString.ERROR_MESSAGE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}

