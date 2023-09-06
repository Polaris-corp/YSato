using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Service;

namespace WindowsFormsApp2.Controller
{
    public class RegistrationController
    {
        UsersService us = new UsersService();
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
    }
}
