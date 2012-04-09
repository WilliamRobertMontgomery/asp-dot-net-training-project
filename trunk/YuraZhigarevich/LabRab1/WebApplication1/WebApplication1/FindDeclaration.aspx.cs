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

namespace WebApplication1
{
    public partial class FindDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string line,ss;
            ss = "";
            var path = Server.MapPath("output.txt");
            StreamReader f = new StreamReader(path);
            while ((line = f.ReadLine()) != null)
            {
                ss = ss + line+"\n";
                TextBox1.Text = ss;
                //Label1.Text = ss;
                counter++;
            }
            f.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }
    }
}
