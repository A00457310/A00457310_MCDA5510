namespace Assignment1.models
{
    class FileExecutionData
    {
        public int totalNumberOfValidRows = 0;
        public int totalNumberOfSkippedRows = 0;
        
        public int TotalNumberOfRows { get { return totalNumberOfValidRows; } set { totalNumberOfValidRows = value; } }
        public int TotalNumberOfSkippedRows { get { return totalNumberOfSkippedRows; } set { totalNumberOfSkippedRows = value; } }
    }
}
