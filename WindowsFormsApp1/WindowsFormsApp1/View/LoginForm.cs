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
using WindowsFormsApp1.Common;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        Controller.LoginController lc = new Controller.LoginController();
        Logger logger = Logger.GetInstance();

        private void login_Click(object sender, EventArgs e)
        {
            //IDとPwdを受け取る
            DateTime dateTimeNow = DateTime.Now;
            string userId = textBox1.Text;
            string loginPassword = textBox2.Text;
            int matchUserId = 0;
            //入力チェック
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(loginPassword))
            {
                MessageBox.Show(ConstString.EMPTY_MESSAGE);
                return;
            }

            try
            {
                //IDの取得
                //IDチェック
                if (!lc.DBAccessUserExistence(userId))
                {
                    MessageBox.Show(ConstString.NOTUSERS_MESSAGE);
                    return;
                }
                //IDとPwdの紐づきのデータの受け取り
                matchUserId = lc.DBAccessCheckPwd(userId, loginPassword);
                //IDとPwdが紐づいたユーザーがいるかどうかのチェック
                if (matchUserId == 0)
                {
                    MessageBox.Show(ConstString.NOT_PWD_MATCH_MESSAGE);
                    lc.DBAccessTimeStamp(userId, 0 ,dateTimeNow);
                    return;
                }
                //ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間の取得
                HistoryModel history = lc.DBAccessGetResultAndLoginTime(userId);
                //直近3件のログイン失敗チェック
                TimeSpan minutes5 = TimeSpan.FromMinutes(5);
                if (history.LoginFailureCount == 3 && history.NewestTimes - history.OldestTimes <= minutes5)
                {
                    if (dateTimeNow - history.NewestTimes <= minutes5)
                    {
                        //直近のログイン失敗から何分経過しているか
                        TimeSpan unLockTime = lc.LoginUnLockTime(history.NewestTimes,dateTimeNow);
                        MessageBox.Show(string.Format(ConstString.LOGIN_IMPOSSIBLE, unLockTime.ToString(@"mm\分ss\秒")));
                        return;
                    }
                }
                MessageBox.Show(ConstString.LOGIN_MESSAGE);
                lc.DBAccessTimeStamp(userId, 1, dateTimeNow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ConstString.ERROR_MESSAGE);
                logger.Error(ex);
            }
        }
    }
}

