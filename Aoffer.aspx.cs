using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Aoffer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AHome.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        string name = TextBox2.Text;
        string credits = TextBox3.Text;
        string semester = TextBox5.Text;
        

        SqlConnection connection = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        connection.Open();
 
        string query = "INSERT INTO courses (ID,name,credit_hours,semester) VALUES ('" + id + "', '" + name + "', '" + credits + "', '" + semester + "')";
        SqlCommand comm = new SqlCommand(query, connection);
        comm.ExecuteNonQuery();
        comm.Dispose();

        int priority = 0;
        string username = (string)Session["username"];
        string query_b = "select top 1 priority from usersforlog order by priority desc";
        SqlCommand command_b = new SqlCommand(query_b, connection);
        object result1 = command_b.ExecuteScalar();
        if (result1 != null && result1 != DBNull.Value)
        {
            priority = Convert.ToInt32(result1.ToString());
        }
        else
        {
            priority = 0;
        }


        priority++;
        string query_a = "insert into usersforlog values(@username,@priority)";

        using (SqlCommand command_a = new SqlCommand(query_a, connection))
        {
            command_a.Parameters.AddWithValue("@username", username);
            command_a.Parameters.AddWithValue("@priority", priority);


            int rowsAffected = command_a.ExecuteNonQuery();

        }




        connection.Close();

        MessageBox.Show("          SUCCESSFULLY ADDED A NEW COURSE!          ");
        Response.Redirect("AHome.aspx");
         
    }
}