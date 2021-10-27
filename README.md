# ed-A00457310_MCDA5510
Assignment 1 MCDA5510

The solution is divided into below directory structure.
1) loggers -> Contains the logger used for the assignment, can log debug, info and error logs.
2) models -> Contains the data structure used for transmitting information between classes.
3) parsers -> Container the parser used for parsing the csv file.
4) validators -> Conatins the file for all the validations used in the solution.
5) writers -> Contains the file writer responsible for storing data to file.

Below are the validations used for different csv columns.
1) First Name -> Must be a non empty non null alphanumeric string.
2) Street Number -> Must be a non empty non null numeric string.
3) Street Name -> Must be a non empty non null alphanumeric string.
4) Zip Code -> Must be a non empty non null alphanumeric string of length 6.
5) Email -> Must be a non null non empty string seggregated by @