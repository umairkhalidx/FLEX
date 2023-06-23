using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Asectionchange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query1 = "select distinct course_id from studies where student_ID= @id";
        string query2 = "select name from sections";
        string course = "";
        string id, previousid;
        if (!IsPostBack)
        {
            id = TextBox1.Text;
            Session["TextBox1"] = id;


        }
        else
        {
            previousid = (string)Session["TextBox1"];
            id = TextBox1.Text;
            Session["TextBox1"] = id;
            if (id != previousid)
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader1 = command1.ExecuteReader();

                    DropDownList1.DataSource = reader1;
                    DropDownList1.DataTextField = "course_id";
                    DropDownList1.DataValueField = "course_id";
                    DropDownList1.DataBind();
                    reader1.Close();


                    course = DropDownList1.SelectedValue;
                    Session["course_change"] = course;

                    SqlCommand command2 = new SqlCommand(query2, connection);
                    SqlDataReader reader2 = command2.ExecuteReader();

                    DropDownList2.DataSource = reader2;
                    DropDownList2.DataTextField = "name";
                    DropDownList2.DataValueField = "name";
                    DropDownList2.DataBind();
                    reader2.Close();

                    connection.Close();
                }
            }
        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Asection.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";

        string id = TextBox1.Text;
        string course = DropDownList1.SelectedValue;
        string section = DropDownList2.SelectedValue;
        string query1 = "select count(*) from studies where course_ID = @course and section = @section";
        string query2 = "update studies set section = @section where course_ID=@course and student_ID=@id";
        int count = 0;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@course", course);
            command1.Parameters.AddWithValue("@section", section);
            count = Convert.ToInt32(command1.ExecuteScalar().ToString());
            command1.Dispose();
            if(count<50)
            {
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




                SqlCommand comm = new SqlCommand(query2, connection);
                comm.Parameters.AddWithValue("@course", course);
                comm.Parameters.AddWithValue("@section", section);
                comm.Parameters.AddWithValue("@id", id);

                comm.ExecuteNonQuery();
                comm.Dispose();
                connection.Close();
                MessageBox.Show("          SECTION CHANGED SUCCESSFULLY!          ");
                Server.Transfer("AHome.aspx");
            }

            else
            {
                MessageBox.Show("          SECTION NOT AVAILABLE!          ");
                Response.Redirect("Asection.aspx");
            }


            connection.Close();
        }
        
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}