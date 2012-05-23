using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication1.BusinessLogic
{
    public class Loader
    {
        public void LoadData(string xxx, string path)
        {
                string dbLocation = System.IO.Path.GetFullPath(path);
                SqlConnection connection1 = new SqlConnection
                 (
                  "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
                 );
                connection1.Open();
                string sql = xxx;
                SqlCommand command1 = new SqlCommand(sql, connection1);
                SqlDataReader dataReader1 = command1.ExecuteReader();

                dataReader1.Close();
                connection1.Close();
        }
    }
}