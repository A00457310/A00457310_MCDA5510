using System;
using System.IO;

namespace Assignment1.writers
{
    class OutputFIleWriter
    {

        string filePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + "\\Output\\Output.csv";

        public OutputFIleWriter()
        {
            string folderPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + "\\Output";
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Folder not exist, creating folder");
                Directory.CreateDirectory(folderPath);
            }

            if (File.Exists(this.filePath))
            {
                File.Delete(this.filePath);
            }

            using (StreamWriter sw = File.AppendText(this.filePath))
            {
                sw.WriteLine("First Name, Last Name,Street Number, Street, City, Province, Postal Code,Country,Phone Number, email Address, fileDate");
            }
        }

        public void write(String[] content, String date)
        {
            using (StreamWriter sw = File.AppendText(this.filePath))
            {
                sw.WriteLine(string.Join(",", content) + "," + date);
            }
        }
    }
}
