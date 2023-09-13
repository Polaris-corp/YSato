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
    public class UsersTableViewController
    {
        UsersService us = new UsersService();
        public DataTable ReadUsersTable()
        {
            return us.ReadUsersTable();
        }
        public DataTable ReadUsersTable(bool deletedUsers)
        {
            return us.ReadUsersTable(deletedUsers);
        }
        public void InsertAccount(string name, string pwd)
        {
            us.InsertAccount(name, pwd);
        }
        public void UpdateAccount(int userId, string name, string pwd)
        {
            us.UpdateAccount(userId, name, pwd);
        }
        public void DeleteAccount(int userId)
        {
            us.DeleteAccount(userId);
        }
        public bool DBAccessCheckIdAndPwd(int userId, string pwd)
        {
            return us.DBAccessCheckIdAndPwd(userId, pwd);
        }
    }
}
