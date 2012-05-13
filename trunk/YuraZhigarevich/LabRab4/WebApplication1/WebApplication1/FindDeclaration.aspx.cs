using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class FindDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int num = DropDownList1.SelectedIndex;
            var path = Server.MapPath(@"db\qqq.mdf");
            string dbLocation = System.IO.Path.GetFullPath(path);
            SqlConnection connection1 = new SqlConnection
           (
            "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
           );
            if (num == 1)
            {
            connection1.Open();
                // Формируем запрос к базе данных
                string sql = "SELECT * FROM Table1";
                SqlCommand command1 = new SqlCommand(sql, connection1);
                SqlDataReader dataReader1 = command1.ExecuteReader();
                // Организуем циклический перебор полученных записей 
                while (dataReader1.Read())
                {
                    TextBox1.Text += dataReader1["Text"] + Environment.NewLine;
                }

                dataReader1.Close();
                connection1.Close();
            }
            if (num == 2)
            {
                connection1.Open();
                // Формируем запрос к базе данных
                string sql = "SELECT * FROM Table2";
                SqlCommand command1 = new SqlCommand(sql, connection1);
                SqlDataReader dataReader1 = command1.ExecuteReader();
                // Организуем циклический перебор полученных записей 
                while (dataReader1.Read())
                {
                    TextBox1.Text += dataReader1["Text2"] + Environment.NewLine;
                }

                dataReader1.Close();
                connection1.Close();
            }
            if (num == 3)
            {
                connection1.Open();
                // Формируем запрос к базе данных
                string sql = "SELECT * FROM Table3";
                SqlCommand command1 = new SqlCommand(sql, connection1);
                SqlDataReader dataReader1 = command1.ExecuteReader();
                // Организуем циклический перебор полученных записей 
                while (dataReader1.Read())
                {
                    TextBox1.Text += dataReader1["Text3"] + Environment.NewLine;
                }

                dataReader1.Close();
                connection1.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
