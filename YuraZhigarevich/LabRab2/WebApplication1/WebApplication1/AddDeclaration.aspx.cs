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
    public partial class AddDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var path = Server.MapPath(@"db\qqq.mdf");
            string dbLocation = System.IO.Path.GetFullPath(path);
            SqlConnection connection1 = new SqlConnection
           (
            "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
           );
            connection1.Open();
          // Формируем запрос к базе данных
            string xxx = TextBox1.Text;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }
    }
}
