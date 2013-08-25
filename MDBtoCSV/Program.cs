using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;

namespace MDBtoCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string srcFile = args[0];
            string srcTable = args[1];
            string outFile = args[2];
            string contents = getContents(srcFile, srcTable);
            writeFile(contents, outFile);
            Console.ReadLine();
        }

        static OleDbConnection getConn(string srcFile)
        {
            // Return an Access connection string

            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + srcFile + ";User Id=admin;Password=;";
            OleDbConnection conn = new OleDbConnection(connStr);
            return conn;
        }

        static string getContents(string srcFile, string srcTable)
        {
            OleDbConnection conn = getConn(srcFile);
            conn.Open();
            OleDbCommand accessCommand = new OleDbCommand("SELECT * FROM " + srcTable, conn);
            OleDbDataReader accessReader = accessCommand.ExecuteReader();
            StringBuilder contents = new System.Text.StringBuilder();
            int headerWidth = accessReader.FieldCount;
            for (int i = 0; i < headerWidth; i++)
            {
                contents.AppendFormat("{0}, ", accessReader.GetName(i));
            }
            contents.AppendFormat("\n");
            while (accessReader.Read())
            {
                int rowWidth = accessReader.FieldCount;
                for (int i = 0; i < rowWidth; i++)
                {
                    if (i < rowWidth - 1)
                    {
                        contents.AppendFormat("{0}, ", accessReader[i].ToString());
                    }
                    else if (i == rowWidth - 1)
                    {
                        contents.AppendFormat("{0}\n", accessReader[i].ToString());
                    }
                }
            }
            accessReader.Close();
            conn.Close();
            return contents.ToString();
        }

        static void writeFile(string contents, string outFile)
        {
            System.IO.File.WriteAllText(outFile, contents);
        }
    }
}
