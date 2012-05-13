using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication1.BusinessLogic
{
    public class Loader
    {
        public void LoadData(int number, string xxx, string path)
        {

            if (number == 1)
            {
                string dbLocation = System.IO.Path.GetFullPath(path);
                SqlConnection connection1 = new SqlConnection
               (
                "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
               );
                connection1.Open();
                // Формируем запрос к базе данных
                string sql = "insert into Table1 (Text) Values(@text)";
                SqlCommand command1 = new SqlCommand(sql, connection1);
                var param = command1.CreateParameter();
                param.ParameterName = "@text";
                param.Value = xxx;
                command1.Parameters.Add(param);

                SqlDataReader dataReader1 = command1.ExecuteReader();
                dataReader1.Close();
                connection1.Close();
            }
            if (number == 2)
            {
                string dbLocation = System.IO.Path.GetFullPath(path);
                SqlConnection connection1 = new SqlConnection
               (
                "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
               );
                connection1.Open();
                // Формируем запрос к базе данных
                string sql = "insert into Table2 (Text2) Values(@text)";
                SqlCommand command1 = new SqlCommand(sql, connection1);
                var param = command1.CreateParameter();
                param.ParameterName = "@text";
                param.Value = xxx;
                command1.Parameters.Add(param);

                SqlDataReader dataReader1 = command1.ExecuteReader();
                dataReader1.Close();
                connection1.Close();
            }
            if (number == 3)
            {
                string dbLocation = System.IO.Path.GetFullPath(path);
                SqlConnection connection1 = new SqlConnection
               (
                "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
               );
                connection1.Open();
                // Формируем запрос к базе данных
                string sql = "insert into Table3 (Text3) Values(@text)";
                SqlCommand command1 = new SqlCommand(sql, connection1);
                var param = command1.CreateParameter();
                param.ParameterName = "@text";
                param.Value = xxx;
                command1.Parameters.Add(param);

                SqlDataReader dataReader1 = command1.ExecuteReader();
                dataReader1.Close();
                connection1.Close();
            }
        }
    }
}