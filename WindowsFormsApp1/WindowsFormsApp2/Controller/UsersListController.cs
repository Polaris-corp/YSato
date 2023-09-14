using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Service;

namespace WindowsFormsApp2.Controller
{
    public class UsersListController
    {
        UsersService us = new UsersService();
        /// <summary>
        /// ユーザー一覧をDataTableで取得するコントローラー
        /// </summary>
        /// <returns>ユーザー一覧のDataTable</returns>
        public DataTable ReadUsersTable()
        {
            return us.ReadUsersTable();
        }
        /// <summary>
        /// ユーザー一覧をDataTableで取得するコントローラー
        /// </summary>
        /// <param name="deletedUsers">削除済みユーザーかどうかの真偽</param>
        /// <returns>ユーザー一覧のDataTable</returns>
        public DataTable ReadUsersTable(bool deletedUsers)
        {
            return us.ReadUsersTable(deletedUsers);
        }
    }
}
