using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Windows.Forms;
using System.Xml.Linq;

public partial class LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 

    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        conn.Open();

        string username = TextBox1.Text;
        string password = TextBox2.Text;
        Session["username"] = username;
        string query = "select * from users where username = '" + username + "' AND password = '" + password + "'";
        string query2 = "select role from users where username = @username";
        string role = "";

        SqlCommand command1 = new SqlCommand(query2, conn);
        command1.Parameters.AddWithValue("@username", username);
        role = command1.ExecuteScalar().ToString();
        command1.Dispose();

        SqlCommand cm;
        cm = new SqlCommand(query, conn);
        SqlDataReader res1 = cm.ExecuteReader();
        if (!res1.HasRows)
        {
            MessageBox.Show("          USERNAME OR PASSWORD DON'T MATCH          ");
        }

        else
        {
            

            if (role == "student")
                Server.Transfer("SHome.aspx");
            else if (role == "faculty")
                Server.Transfer("FHome.aspx");
            else if (role == "admin")
                Server.Transfer("AHome.aspx");

            cm.Dispose();
            res1.Close();

        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("Signup.aspx");

    }
}