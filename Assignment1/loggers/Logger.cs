using System;
using System.IO;

namespace Assignment1.loggers
{
    class Logger
    {
        string filePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + "\\logs\\log.txt";
        public Logger()
        {
            string folderPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + "\\Logs";
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Folder not exist, creating folder");
                Directory.CreateDirectory(folderPath);
            }

            if (File.Exists(this.filePath))
            {
                File.Delete(this.filePath);
            }
        }

        public void info(String message)
        {
            using (StreamWriter sw = File.AppendText(this.filePath))
            {
                sw.WriteLine("INFO :: " + message);
            }
        }

        public void debug(String message)
        {
            using (StreamWriter sw = File.AppendText(this.filePath))
            {
                sw.WriteLine("DEBUG :: " + message);
            }
        }

        public void error(String message)
        {
            using (StreamWriter sw = File.AppendText(this.filePath))
            {
                sw.WriteLine("ERROR :: " + message);
            }
        }
    }
}