using System;
using System.Activities.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Windows.Forms;
using System.Xml.Linq;

public partial class setweightages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query1 = "select distinct C.name from teaches T join courses C on T.course_ID = C.ID where faculty_id =@username";

        if (!IsPostBack)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["name"].ToString();
                            Session["coursename"] = id;
                            string optionText = id;
                            string optionValue = id;
                            ListItem item = new ListItem(optionText, optionValue);
                            DropDownList1.Items.Add(item);
                        }
                    }
                }
            }
        }
    }
    

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Fhome.aspx");
    }

    protected void myGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string coursename = (string)Session["coursename"];

        int quizMarks = Convert.ToInt32(Request.Form["quiz"]);
        int assignmentMarks = Convert.ToInt32(Request.Form["assignment"]);
        int sessionalMarks = Convert.ToInt32(Request.Form["sessional"]);
        int projectMarks = Convert.ToInt32(Request.Form["project"]);
        int finalMarks = Convert.ToInt32(Request.Form["final"]);

        if (quizMarks + assignmentMarks + sessionalMarks + projectMarks + finalMarks != 100)
        {
            MessageBox.Show("Weightages do not add up to 100, try again!");
            Response.Redirect("Fsetweightages.aspx");
        }

        if (quizMarks + assignmentMarks  + sessionalMarks + projectMarks + finalMarks == 100)
        {
            string query = "UPDATE courses SET assignment_w = @assignmentMarks, quiz_w= @quizMarks ,sessionals_w = @sessionalMarks, finals_w =@finalMarks, project_w = @projectMarks WHERE name=@coursename;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

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

                SqlCommand comm = new SqlCommand(query, connection);
                comm.Parameters.AddWithValue("@coursename", coursename);
                comm.Parameters.AddWithValue("@assignmentMarks", assignmentMarks);
                comm.Parameters.AddWithValue("@quizMarks", quizMarks);
                comm.Parameters.AddWithValue("@sessionalMarks", sessionalMarks);
                comm.Parameters.AddWithValue("@finalMarks", finalMarks);
                comm.Parameters.AddWithValue("@projectMarks", projectMarks);
                comm.ExecuteNonQuery();
                comm.Dispose();
                connection.Close();
                MessageBox.Show("          Successfully updated!          ");
                Response.Redirect("FHome.aspx");
            }

        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}