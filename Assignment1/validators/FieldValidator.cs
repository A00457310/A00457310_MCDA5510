using Assignment1.loggers;
using System;
using System.Text.RegularExpressions;

namespace Assignment1.validators
{
    class FieldValidator
    {
        Logger logger;

        public FieldValidator()
        {
            this.logger = new Logger();
        }

        public bool isValidRow(string[] row)
        {
            
            if (row.Length != 10)
            {
                return false;
            }

            string firstName = row[0].Replace(" ", "");
            string streetNumber = row[2];
            string streetName = row[3].Replace(" ", "");
            string zipCode = row[6].Replace(" ", "");
            string email = row[9].Replace(" ", "");

            if (!isValidAlphaString(firstName) || String.IsNullOrEmpty(firstName))
            {
                this.logger.error("Invalid record, either FirstName is null or empty or non alpha numeric");
                return false;
            }

            if (!isValidNumeric(streetNumber) || String.IsNullOrEmpty(streetNumber))
            {
                this.logger.error("Invalid record, either Street number value is null or empty or invalid number");
                return false;
            }

            if (!isValidAlphaNumeric(streetName) || String.IsNullOrEmpty(streetName))
            {
                this.logger.error("Invalid record, either Street name value is null or empty or non - alpha numeric");
                return false;
            }

            if (!(zipCode.Trim().Length == 6) && !isValidAlphaNumeric(zipCode) || String.IsNullOrEmpty(zipCode))
            {
                this.logger.error("Invalid record, either Postal Code is null or empty length shlould is 6 or non alpha numeric");
                return false;
            }

            if (!isValidEmail(email))
            {
                this.logger.error("Invalid record, either email is null or empty or not valid format emails : " + row[9]);
                return false;
            }

            return true;
        }

        public bool isValidEmail(string emailId)
        {
            string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            return Regex.IsMatch(emailId, pattern);
        }

        public bool isValidAlphaNumeric(string value)
        {
            string pattern = "^[a-zA-Z0-9]*$";
            return Regex.IsMatch(value, pattern);
        }

        public bool isValidNumeric(string value)
        {
            string pattern = @"^-?[0-9][0-9,\.]+$";
            return Regex.IsMatch(value, pattern);
        }

        public bool isValidAlphaString(string value)
        {
            string pattern = "^[a-zA-Z]*$";
            return Regex.IsMatch(value, pattern);
        }
    }
}
