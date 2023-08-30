using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class HistoryModel
    {
        public int LoginFailureCount { get; set; }
        public DateTime NewestTimes { get; set; }
        public DateTime OldestTimes { get; set; }
    }
}
