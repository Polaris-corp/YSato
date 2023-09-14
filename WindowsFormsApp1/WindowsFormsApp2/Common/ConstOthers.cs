using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Common
{
    public static class ConstOthers
    {
        public static readonly TimeSpan LoginFailureThreshold = TimeSpan.FromMinutes(5);
        public const bool OverWrite = false;
        public const bool Append = true;
        public const bool IsDeletedUser = true;
    }
}
