using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var path = Server.MapPath(@"App_Data\Auto.mdf");
            string dbLocation = System.IO.Path.GetFullPath(path);
            SqlConnection connection1 = new SqlConnection
             (
              "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
             );
            connection1.Open();

            string nn = TextBox1.Text;
            string pp = TextBox2.Text;

            string sql = "INSERT INTO Users (Name, Password) VALUES('" + nn + "', '" + pp + "')";
            SqlCommand command1 = new SqlCommand(sql, connection1);
            SqlDataReader dataReader1 = command1.ExecuteReader();
            
            dataReader1.Close();
            connection1.Close();
            Response.Redirect("Default.aspx");
        }
    }
}