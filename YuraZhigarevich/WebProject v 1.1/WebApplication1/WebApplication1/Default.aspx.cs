using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            var path = Server.MapPath(@"App_Data\Auto.mdf");
            string dbLocation = System.IO.Path.GetFullPath(path);
            SqlConnection connection1 = new SqlConnection
             (
              "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
             );
            connection1.Open();
            string sql = "SELECT * FROM Users";
            SqlCommand command1 = new SqlCommand(sql, connection1);
            SqlDataReader dataReader1 = command1.ExecuteReader();
            string n = null;
            string p = null;

            while (dataReader1.Read())
            {
                n= dataReader1["Name"].ToString();
                p= dataReader1["Password"].ToString();

                if ((Login1.UserName == n) && (Login1.Password == p))
                {
                    e.Authenticated = true;
                    Response.Redirect("Index.aspx");
                }
             /*   else
                {
                    e.Authenticated = false;
                    Response.Redirect("Registration.aspx");
                }*/
            }
            dataReader1.Close();
            connection1.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

    }
}