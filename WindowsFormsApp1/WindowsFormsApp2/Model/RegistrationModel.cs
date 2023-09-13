using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Model
{
    public class RegistrationModel
    {
        public RegistrationModel()
        {
            UserId = "";
            Name = "";
            Pwd = "";
            Deleted = false;
        }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public bool Deleted { get; set; }
    }
}
