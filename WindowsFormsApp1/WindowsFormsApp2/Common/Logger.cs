using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Common
{
    public class Logger
    {
        public void LogOutput(Exception ex,DateTime dateTimeNow)
        {
            if (!Directory.Exists(ConstString.ErrorDirectoryPath))
            {
                Directory.CreateDirectory(ConstString.ErrorDirectoryPath);
            }
            string errorInfo = (string.Format(ConstString.ErrorInfo, ex.Message, ex.StackTrace));
            string filePath = Path.Combine(ConstString.ErrorDirectoryPath, ConstString.ErrorFileName);
            using (StreamWriter writer = new StreamWriter(filePath, ConstOthers.Append))
            {
                writer.WriteLine(dateTimeNow.ToString());
                writer.WriteLine(errorInfo);
            }
        }
    }
}
