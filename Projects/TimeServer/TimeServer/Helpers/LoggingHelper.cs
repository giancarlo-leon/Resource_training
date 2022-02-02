using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TimeServer.Helpers
{
    public static class LoggingHelper
    {
        public static async Task LogError(Exception ex, string info = "")
        {
            string filename = $"LOG_{DateTime.Now.ToString(ConstantHelpers.DATEFORMAT_LOG)}.log";
            string logContent = "";
            if (!Directory.Exists(ConstantHelpers.LOG_PATH))
            {
                Directory.CreateDirectory(ConstantHelpers.LOG_PATH);
            }

            if (String.IsNullOrEmpty(info))
            {
                logContent = ex.ToString() + " - Method: " + info;
            }
            else
            {
                logContent = ex.ToString();
            }
            Console.WriteLine(logContent);
            await File.WriteAllTextAsync(Path.Combine(ConstantHelpers.LOG_PATH,filename), logContent);
        }
    }
}
