using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Common;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        Controller.LoginController loginController = new Controller.LoginController();

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DateTime dateTimeNow = DateTime.Now;
            string loginId = txtUserId.Text;
            string loginPassword = txtPwd.Text;

            if (string.IsNullOrEmpty(loginId) || string.IsNullOrEmpty(loginPassword))
            {
                MessageBox.Show(ConstString.IdEmptyMessage);
                return;
            }
            if (!int.TryParse(loginId, out int userId))
            {
                MessageBox.Show(ConstString.NotIdNumberMessage);
                return;
            }

            try
            {
                HistoryModel history = loginController.DBAccessLoginNotPossibleTime(userId);

                if (loginController.IsLoginLock(history, dateTimeNow))
                {
                    TimeSpan unLockTime = loginController.LoginUnLockTime(history.NewestTimes, dateTimeNow);
                    MessageBox.Show(string.Format(ConstString.LoginImpossible, unLockTime.ToString(@"mm\分ss\秒")));
                    return;
                }

                if (!loginController.DBAccessCheckIdAndPwd(userId, loginPassword))
                {
                    MessageBox.Show(ConstString.NotMatchMessage);
                    loginController.DBAccessTimeStamp(userId, ConstNumber.NgInMySql, dateTimeNow);
                    return;
                }

                loginController.DBAccessTimeStamp(userId, ConstNumber.OkInMySql, dateTimeNow);
                UsersListForm usf = new UsersListForm();
                usf.ShowDialog();
            }

            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogOutput(ex, dateTimeNow);
                MessageBox.Show(ConstString.ErrorMessage);
            }
        }
    }
}
