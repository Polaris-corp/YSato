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
            string loginId = textBox1.Text;
            string loginPassword = textBox2.Text;

            //入力チェック
            if (string.IsNullOrEmpty(loginId) || string.IsNullOrEmpty(loginPassword))
            {
                MessageBox.Show(ConstString.EmptyMessage);
                return;
            }
            if (!int.TryParse(loginId, out int userId))
            {
                MessageBox.Show(ConstString.NotIdNumberMessage);
                return;
            }

            try
            {
                //IDの取得
                //IDチェック
                if (!lc.DBAccessUserExistence(userId))
                {
                    MessageBox.Show(ConstString.NotusersMessage);
                    return;
                }

                //IDとPwdの紐づきのデータの受け取り
                //IDとPwdが紐づいたユーザーがいるかどうかのチェック
                if (!lc.DBAccessCheckPwd(userId, loginPassword))
                {
                    MessageBox.Show(ConstString.NotPwdMatchMessage);
                    lc.DBAccessTimeStamp(userId, ConstNumber.NgInMySql, dateTimeNow);
                    return;
                }

                //ログイン履歴(最大3件)のログイン成功回数と最新のログイン失敗時間と最後のログイン失敗時間の取得
                HistoryModel history = lc.DBAccessGetResultAndLoginTime(userId);

                //直近3件のログイン失敗経過時間のチェック
                if (history.LoginFailureCount == ConstNumber.MaxLoginFailures)
                {
                    if (history.NewestTimes - history.OldestTimes <= ConstTime.LoginFailureThreshold)
                    {
                        if (dateTimeNow - history.NewestTimes <= ConstTime.LoginFailureThreshold)
                        {
                            //直近のログイン失敗から何分経過しているか
                            TimeSpan unLockTime = lc.LoginUnLockTime(history.NewestTimes, dateTimeNow);
                            MessageBox.Show(string.Format(ConstString.LoginImpossible, unLockTime.ToString(@"mm\分ss\秒")));
                            return;
                        }
                    }
                }
                MessageBox.Show(ConstString.LoginMessagE);
                lc.DBAccessTimeStamp(userId, ConstNumber.OkInMySql, dateTimeNow);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ConstString.ErrorMessage);
                logger.Error(ex);
            }
        }
    }
}

