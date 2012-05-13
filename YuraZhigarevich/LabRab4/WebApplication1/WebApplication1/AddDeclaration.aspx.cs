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
using WebApplication1.BusinessLogic;


namespace WebApplication1
{
    public partial class AddDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int num = DropDownList1.SelectedIndex;
            //TextBox2.Text = num.ToString();

            var path = Server.MapPath(@"db\qqq.mdf");
            var loader = new Loader();
            loader.LoadData(num, TextBox1.Text, path); 
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
