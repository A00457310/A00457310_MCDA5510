using Assignment1.loggers;
using Assignment1.models;
using Assignment1.validators;
using Assignment1.writers;
using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace Assignment1.parsers
{
    class CSVParser
    {

        FieldValidator validator;
        OutputFIleWriter writer;
        Logger logger;

        public CSVParser()
        {
            this.validator = new FieldValidator();
            this.writer = new OutputFIleWriter();
            this.logger = new Logger();
        }

        public FileExecutionData parseFile(String fileName)
        {
            FileExecutionData fileExecutionData = new FileExecutionData();
            string[] fileNameSplit = fileName.Split("\\");
            String fileDate = fileNameSplit[fileNameSplit.Length - 4] + "/" + fileNameSplit[fileNameSplit.Length - 3] + "/" + fileNameSplit[fileNameSplit.Length - 2];
            
            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.ReadLine();
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        bool isValid = this.validator.isValidRow(fields);

                        if (isValid)
                        {
                            fileExecutionData.TotalNumberOfRows++;
                            this.writer.write(fields, fileDate);
                        } else fileExecutionData.TotalNumberOfSkippedRows++;
                    }
                }

                return fileExecutionData;

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
                this.logger.error(ioe.Message);
                return fileExecutionData;
            }

        }
    }
}
