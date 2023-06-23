using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Input;

public partial class Asection : System.Web.UI.Page
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
        using (SqlConnection connection = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"))
        {
            connection.Open();
            string section = "A";
            string query1 = "SELECT course_ID FROM (SELECT course_ID,ROW_NUMBER() OVER (PARTITION BY course_ID ORDER BY student_ID) AS row_num FROM studies) subquery GROUP BY course_ID, CEILING(row_num/50.0) ORDER BY course_ID, CEILING(row_num/50.0)";
            string query2 = "UPDATE studies SET section = @section " +
                   "WHERE course_ID = @name AND student_ID IN " +
                   "(SELECT TOP 50 student_ID FROM studies " +
                   "WHERE course_id = @name AND section is NULL " +
                   "ORDER BY student_ID ASC)";

            string query = "SELECT course_id, COUNT(*) AS count FROM studies GROUP BY course_id HAVING COUNT(*) < 10";
            string query_a = "delete from courses where ID =@courseid ";
            string query_b = "delete from studies where course_ID =@courseID";
            string query_c = "delete from prereq where ID = @courseID";
            List<string> courses = new List<string>();

               
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string courseID = reader["course_id"].ToString();
                    courses.Add(courseID);
                }
                reader.Close();
                

            foreach (string course in courses)
            {

                SqlCommand comm3 = new SqlCommand(query_c, connection);
                comm3.Parameters.AddWithValue("@courseID", course);
                comm3.ExecuteNonQuery();
                comm3.Dispose();

                SqlCommand comm2 = new SqlCommand(query_b, connection);
                comm2.Parameters.AddWithValue("@courseID", course);
                comm2.ExecuteNonQuery();
                comm2.Dispose();


                SqlCommand comm = new SqlCommand(query_a, connection);
                comm.Parameters.AddWithValue("@courseid", course);
                comm.ExecuteNonQuery();
                comm.Dispose();

            }





            SqlCommand command1 = new SqlCommand(query1, connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            string prevName = "";
            if (!reader1.HasRows)
            {
                reader1.Close();
                connection.Close();
            }
            else
            {
                while (reader1.Read())
                {
                    string name = reader1.GetString(0);

                    if (name != prevName)
                        section = "A";

                    if (name == prevName)
                    {
                        section = ((char)(section[0] + 1)).ToString();
                        prevName = name;
                    }

                    using (SqlConnection connection2 = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"))
                    {
                        connection2.Open();

                        int priority = 0;
                        string username = (string)Session["username"];
                        string query_bb = "select top 1 priority from usersforlog order by priority desc";
                        SqlCommand command_b = new SqlCommand(query_bb, connection);
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
                        string query_aa = "insert into usersforlog values(@username,@priority)";

                        using (SqlCommand command_a = new SqlCommand(query_aa, connection))
                        {
                            command_a.Parameters.AddWithValue("@username", username);
                            command_a.Parameters.AddWithValue("@priority", priority);


                            int rowsAffected = command_a.ExecuteNonQuery();

                        }




                        SqlCommand command2 = new SqlCommand(query2, connection2);
                        command2.Parameters.AddWithValue("@name", name);
                        command2.Parameters.AddWithValue("@section", section);
                        command2.ExecuteNonQuery();
                        prevName = name;
                    }
                }
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("Asectionchange.aspx");
    }
}