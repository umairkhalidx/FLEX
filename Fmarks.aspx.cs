using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

public partial class Fmarks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query1 = "SELECT distinct course_ID FROM teaches WHERE faculty_id = @username";
        string query2 = "select section from teaches WHERE faculty_ID = @username AND course_id = @course";
        string query3 = "select student_id as roll,name from studies join users on users.username = studies.student_id where course_id = @course AND section = @section";

        string course = "";
        string previouscourse = "";
        string section = "";
        string previoussection = "";

        if (!IsPostBack)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command1 = new SqlCommand(query1, connection);
                command1.Parameters.AddWithValue("@username", username);
                SqlDataReader reader1 = command1.ExecuteReader();

                DropDownList1.DataSource = reader1;
                DropDownList1.DataTextField = "course_id";
                DropDownList1.DataValueField = "course_id";
                DropDownList1.DataBind();
                reader1.Close();
                
                course = DropDownList1.SelectedValue;
                Session["course_marks"] = course;

                
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@username", username);
                command2.Parameters.AddWithValue("@course", course);
                SqlDataReader reader2 = command2.ExecuteReader();

                DropDownList2.DataSource = reader2;
                DropDownList2.DataTextField = "section";
                DropDownList2.DataValueField = "section";
                DropDownList2.DataBind();
                reader2.Close();
                
                section = DropDownList2.SelectedValue;
                Session["section"] = section;


                SqlCommand command3 = new SqlCommand(query3, connection);
                command3.Parameters.AddWithValue("@section", section);
                command3.Parameters.AddWithValue("@course", course);
                SqlDataReader reader3 = command3.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(reader3);
                GridView1.DataSource = dt1;
                GridView1.DataBind();

                connection.Close();

            }
        }
        else
        {
            previouscourse = (string)Session["course_marks"];
            previoussection = (string)Session["section"];
            course = DropDownList1.SelectedValue;
            section = DropDownList2.SelectedValue;

            if (previouscourse != course || section != previoussection)
            {
                Session["course_marks"] = course;
                section = DropDownList2.SelectedValue;
                Session["section"] = section;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@username", username);
                    command2.Parameters.AddWithValue("@course", course);
                    SqlDataReader reader2 = command2.ExecuteReader();

                    DropDownList2.DataSource = reader2;
                    DropDownList2.DataTextField = "section";
                    DropDownList2.DataValueField = "section";
                    DropDownList2.DataBind();
                    reader2.Close();
                   


                    SqlCommand command3 = new SqlCommand(query3, connection);
                    command3.Parameters.AddWithValue("@section", section);
                    command3.Parameters.AddWithValue("@course", course);
                    SqlDataReader reader3 = command3.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(reader3);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();

                    connection.Close();

                }
            }

        }

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button9_Click(object sender, EventArgs e)
    {

        TextBox firstTextBox = GridView1.Rows[0].Cells[3].FindControl("TotalMarksTextBox") as TextBox;
        string totalMarksValue = firstTextBox.Text;

        foreach (GridViewRow row in GridView1.Rows)
        {
            TextBox textBox = row.Cells[3].FindControl("TotalMarksTextBox") as TextBox;
            textBox.Text = totalMarksValue;
        }
    }

    


    protected void Button8_Click(object sender, EventArgs e)
    {
        Response.Redirect("FHome.aspx");
    }

    protected void Button10_Click(object sender, EventArgs e)
    {


        SqlConnection connection = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        connection.Open();
       


        string username = (string)Session["username"];

        int priority = 0;
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


        string course = DropDownList1.SelectedValue;
        string section = DropDownList2.SelectedValue;
        string type=DropDownList3.SelectedValue;
        
            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox ObtainedTextBox = (TextBox)row.FindControl("ObtainedTextBox");
                TextBox TotalTextBox = (TextBox)row.FindControl("TotalMarksTextBox");

                string obtainedValue = ObtainedTextBox.Text;
                string totalValue = TotalTextBox.Text;
                string rollNumber = row.Cells[1].Text;


                string query = "INSERT INTO " + type + " (obtained_marks, total_marks, course_id, student_id, faculty_id) VALUES ('" + obtainedValue + "', '" + totalValue + "', '" + course + "', '" + rollNumber + "', '" + username + "')";
                SqlCommand comm = new SqlCommand(query, connection);

                comm.ExecuteNonQuery();
                comm.Dispose();


            }

            connection.Close();
            Response.Redirect("FHome.aspx");

    }

    
    protected void Button11_Click(object sender, EventArgs e)
    {

        
    }


    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}