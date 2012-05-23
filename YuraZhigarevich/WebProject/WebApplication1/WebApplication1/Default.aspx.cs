using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
           if ((Login1.UserName == "guest") && (Login1.Password == "guest"))
            {
                e.Authenticated = true;
                Response.Redirect("Index.aspx");
            }
            
        }

    }
}