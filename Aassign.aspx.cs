using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Windows.Forms;
using System.Web.UI.WebControls.Expressions;
using System.Collections;

public partial class Aassign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query1 = "select C.ID,C.name from courses C";
        
        string course = "";
        string previouscourse = "";
        
        if (!IsPostBack)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["id"].ToString();
                            string name = reader["name"].ToString();
                            string optionText = id + " - " + name;
                            string optionValue = id;
                            ListItem item = new ListItem(optionText, optionValue);
                            DropDownList1.Items.Add(item);
                        }
                    }
                }
                
                course = DropDownList1.SelectedValue;
                Session["course_assign"] = course;
                connection.Close();

            }
        }
        else
        {
            previouscourse = (string)Session["SelectedOption1"];
            course = DropDownList1.SelectedValue;
            Session["course_assign"] = course;

            if (previouscourse != course)
            {
                
                
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AHome.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        string course = DropDownList1.SelectedValue;
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string query1 = "select count(*) from studies where student_ID = @id";
        int totalcourses = 0;
        bool flag = false;
        string query2 = "select prereq_ID from prereq where ID = @course";
        string prereq = "";
     
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();


            SqlCommand command = new SqlCommand(query1, connection);
            command.Parameters.AddWithValue("@id", id);
            totalcourses = Convert.ToInt32(command.ExecuteScalar().ToString());


            if (totalcourses >= 6)
            {
                connection.Close();
                MessageBox.Show("          CANNOT REGISTER MORE THAN 6 COURSES!          ");
            }

            else
            {
                
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@course", course);
                object result = command2.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    prereq = result.ToString();
                    string query3 = "select grade from grades where course_ID = @prereq AND student_ID = @id AND grade != 'F'";
                    SqlCommand command3 = new SqlCommand(query3, connection);
                    command3.Parameters.AddWithValue("@prereq", prereq);
                    command3.Parameters.AddWithValue("@id", id);
                    object result2 = command3.ExecuteScalar();
                    if(result2 != DBNull.Value && result2 != null)
                    {
                        flag = true;
                    }

                    else
                    {
                        flag = false;
                    }



                }
                else
                {
                    flag = true;
                }


                if (flag)
                {
                    string query = "INSERT INTO studies (student_id, course_id) VALUES ('" + id + "', '" + course + "')";
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



                    MessageBox.Show("          REGISTRATION SUCCESFUL!          ");

                }
                else
                {
                    MessageBox.Show("          PREREQ COURSE NOT PASSED!          ");

                }


            }

            connection.Close();

            Response.Redirect("AHome.aspx");


        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}