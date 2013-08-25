# MDBtoCSV

> This is a simple console application targeting the .net 4.5 framework that will
convert a single table in an Access Database (.mdb) file to a .csv file that can
be opened in a text editor or as a spreadsheet in a program such as Microsoft
Excel. The first line of the .csv file will contain the column names of the
table and the remaining lines will each contain a row.

## Use

>    MDBtoCSV &lt;path to source file> &lt;table name> &lt;path to destination file>

## To Do

> Right now, there's nothing in the way of error handling or explicit error messages to the user.
In other words, it works if you use it right and it doesn't if you don't.