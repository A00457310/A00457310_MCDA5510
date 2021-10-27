using System;
using System.IO;
using Assignment1.loggers;
using Assignment1.models;
using Assignment1.parsers;

namespace Assignment1
{
    class Program
    {
        CSVParser csvParser;
        Logger logger;
        static int validRowCount = 0;
        static int inValidRowCount = 0;

        public Program()
        {
            this.csvParser = new CSVParser();
            this.logger = new Logger();
        }

        static void Main(string[] args)
        {
            Program pr = new Program();
            try
            {
                //pr.walk("C:/Users/aksha/Downloads/Sample Data/Test");
                DateTime start = DateTime.Now;
                //pr.walk("C:\\Users\\aksha\\Downloads\\Sample Data\\Sample Data");
                string rootfolder = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                String fileDir = rootfolder + "Sample Data/";
                pr.walk(fileDir);
                DateTime end = DateTime.Now;
                pr.logger.info("Total row count : " + (validRowCount + inValidRowCount));
                pr.logger.info("Total valid row count : " + validRowCount);
                pr.logger.info("Total invalid row count : " + inValidRowCount);
                pr.logger.info("Total execution time in milliseconds : " + (end- start).TotalMilliseconds);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                pr.logger.error(e.Message);
            }
        }



        public void walk(String path)
        {
            this.logger.debug("Traversing path : " + path);
            string[] list = Directory.GetDirectories(path);

            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                Console.WriteLine("File:" + filepath);
                if (!filepath.Contains(".DS_Store"))
                {
                    FileExecutionData data = this.csvParser.parseFile(filepath);
                    validRowCount += data.TotalNumberOfRows;
                    inValidRowCount += data.TotalNumberOfSkippedRows;
                }
            }
        }

    }
}