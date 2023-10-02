using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Model;

namespace UnitTestProject1
{
    class TestModel
    {
        public TestModel()
        {
            HistoryModel = new HistoryModel();
        }
        public HistoryModel HistoryModel { get; set; }
        public DateTime ClickTime { get; set; }
        public bool Result { get; set; }
    }
}
