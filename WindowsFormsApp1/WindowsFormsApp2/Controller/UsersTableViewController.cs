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
    }
}
