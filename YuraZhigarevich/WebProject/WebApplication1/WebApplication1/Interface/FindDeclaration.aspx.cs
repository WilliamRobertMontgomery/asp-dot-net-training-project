using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1.Interface
{
    public partial class FindDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 1)
            {
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add(" ---     ");
                DropDownList2.Items.Add("A3");
                DropDownList2.Items.Add("A4");
                DropDownList2.Items.Add("A6");
            }
            if (DropDownList1.SelectedIndex == 2)
            {
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add(" ---     ");
                DropDownList2.Items.Add("3-reihe (E46)");
                DropDownList2.Items.Add("5-reihe (E60)");
                DropDownList2.Items.Add("X5");
            }
            if (DropDownList1.SelectedIndex == 3)
            {
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add(" ---     ");
                DropDownList2.Items.Add("C-klasse (W203)");
                DropDownList2.Items.Add("E-klasse (W211)");
                DropDownList2.Items.Add("S-klasse (W221)");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var num = DropDownList1.SelectedIndex;
            var mod = DropDownList2.SelectedIndex;
            var f = DropDownList3.SelectedIndex;
            var y = DropDownList4.SelectedIndex;
            //TextBox1.Text = num.ToString()+mod+f+y.ToString();

            string s1=null;string s2=null;string s3=null;string s4=null;
                        
            if (f == 0) s3 = "*";if (f == 1) s3 = "бензин";if (f == 2) s3 = "дизель";
            if (y == 0) s4 = "*";if (y == 1) s4 = "2012";if (y == 2) s4 = "2011";if (y == 3) s4 = "2010";
            if (y == 4) s4 = "2009";if (y == 5) s4 = "2008";if (y == 6) s4 = "2007";if (y == 7) s4 = "2006";if (y == 8) s4 = "2005";
            
            //string sql = "SELECT * FROM " + s1 + " WHERE ((" + s1 + ".Model='" + s2 + "') AND (" + s1 + ".Fuel='" + s3 + "') AND (" + s1 + ".Year=" + s4+"))";
            //TextBox1.Text = sql;

            if (num == 1)
            {
                s1 = "Audi";
                if (mod == 0) s2 = "*"; if (mod == 1) s2 = "A3"; 
                if (mod == 2) s2 = "A4"; if (mod == 3) s2 = "A6";
                var path = Server.MapPath(@"..\App_Data\Auto.mdf");
                string dbLocation = System.IO.Path.GetFullPath(path);
                SqlConnection connection1 = new SqlConnection
                 (
                  "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
                 );
                connection1.Open();
                string sql = "SELECT * FROM " + s1 + " WHERE ((" + s1 + ".Model='" + s2 + "') AND (" + s1 + ".Fuel='" + s3 + "') AND (" + s1 + ".Year=" + s4 + "))";
                SqlCommand command1 = new SqlCommand(sql, connection1);
                SqlDataReader dataReader1 = command1.ExecuteReader();
                while (dataReader1.Read())
                {
                    TextBox1.Text = s1 + " ";
                    TextBox1.Text += dataReader1["Model"] + " -- ";
                    TextBox1.Text += dataReader1["Fuel"] + " -- ";
                    TextBox1.Text += dataReader1["Year"] + " год -- ";
                    TextBox1.Text += dataReader1["Price"] + " USD -- (";
                    TextBox1.Text += dataReader1["Owner"] + ")" + Environment.NewLine;
                }

                dataReader1.Close();
                connection1.Close();
                
            }

            if (num == 2)
            {
                s1 = "BMW";
                if (mod == 0) s2 = "*"; if (mod == 1) s2 = "3-reihe (E46)"; 
                if (mod == 2) s2 = "5-reihe (E60)"; if (mod == 3) s2 = "X5";
                var path = Server.MapPath(@"..\App_Data\Auto.mdf");
                string dbLocation = System.IO.Path.GetFullPath(path);
                SqlConnection connection1 = new SqlConnection
                 (
                  "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
                 );
                connection1.Open();
                string sql = "SELECT * FROM " + s1 + " WHERE ((" + s1 + ".Model='" + s2 + "') AND (" + s1 + ".Fuel='" + s3 + "') AND (" + s1 + ".Year=" + s4 + "))";
                SqlCommand command1 = new SqlCommand(sql, connection1);
                SqlDataReader dataReader1 = command1.ExecuteReader();
                while (dataReader1.Read())
                {
                    TextBox1.Text = s1 + " ";
                    TextBox1.Text += dataReader1["Model"] + " -- ";
                    TextBox1.Text += dataReader1["Fuel"] + " -- ";
                    TextBox1.Text += dataReader1["Year"] + " год -- ";
                    TextBox1.Text += dataReader1["Price"] + " USD -- (";
                    TextBox1.Text += dataReader1["Owner"] + ")" + Environment.NewLine;
                }

                dataReader1.Close();
                connection1.Close();
            }

            if (num == 3)
            {
                s1 = "Mercedes";
                if (mod == 0) s2 = "*"; if (mod == 1) s2 = "C-klasse (W203)"; 
                if (mod == 2) s2 = "E-klasse (W211)"; if (mod == 3) s2 = "S-klasse (W221)";
                var path = Server.MapPath(@"..\App_Data\Auto.mdf");
                string dbLocation = System.IO.Path.GetFullPath(path);
                SqlConnection connection1 = new SqlConnection
                 (
                  "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30;User Instance=True"
                 );
                connection1.Open();
                string sql = "SELECT * FROM " + s1 + " WHERE ((" + s1 + ".Model='" + s2 + "') AND (" + s1 + ".Fuel='" + s3 + "') AND (" + s1 + ".Year=" + s4 + "))";
                SqlCommand command1 = new SqlCommand(sql, connection1);
                SqlDataReader dataReader1 = command1.ExecuteReader();
                while (dataReader1.Read())
                {
                    TextBox1.Text = s1 + " ";
                    TextBox1.Text += dataReader1["Model"] + " -- ";
                    TextBox1.Text += dataReader1["Fuel"] + " -- ";
                    TextBox1.Text += dataReader1["Year"] + " год -- ";
                    TextBox1.Text += dataReader1["Price"] + " USD -- (";
                    TextBox1.Text += dataReader1["Owner"] + ")" + Environment.NewLine;
                }

                dataReader1.Close();
                connection1.Close();
            }
            if (TextBox1.Text == null) { TextBox1.Text = "По вашему запросу ничего не найдено!"; }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }
    }
}