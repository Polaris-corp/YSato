using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Common
{
    public static class ConstTime
    {
        public static readonly TimeSpan LoginFailureThreshold = TimeSpan.FromMinutes(5);
    }
}
