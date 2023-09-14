using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Model;
using WindowsFormsApp2.Service;

namespace WindowsFormsApp2.Controller
{
    public class RegistrationController
    {
        UsersService us = new UsersService();
        /// <summary>
        /// ユーザー情報登録用コントローラー
        /// </summary>
        /// <param name="model">ユーザー情報</param>
        public void InsertAccount(RegistrationModel model)
        {
            us.InsertAccount(model);
        }
        /// <summary>
        /// ユーザー情報変更用コントローラー
        /// </summary>
        /// <param name="model">ユーザー情報</param>
        public void UpdateAccount(RegistrationModel model)
        {
            us.UpdateAccount(model);
        }
    }
}
