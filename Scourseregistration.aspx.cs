using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public partial class Courseregistration : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query1 = "SELECT ID,name from courses";
        string query2 = "select count(*) as totalcourses from studies where student_ID = @username";
        
        string selectedcourse, course;
        int totalcourses = 0;
        
        if (!IsPostBack)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command1 = new SqlCommand(query1, connection);
                command1.Parameters.AddWithValue("@username", username);

                SqlDataReader reader1 = command1.ExecuteReader();

                DropDownList1.DataSource = reader1;
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();
                reader1.Close();

                Session["selectedcoursereg"] = DropDownList1.SelectedValue;
                selectedcourse = (string)Session["selectedcoursereg"];

                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@username", username);
                totalcourses = Convert.ToInt32(command2.ExecuteScalar().ToString());


                Session["totalcoursesreg"] = totalcourses;
            }

        }
        else
        {
            string previouscourse = (string)Session["selectedcoursereg"];
            selectedcourse = DropDownList1.SelectedValue;

            if (previouscourse != selectedcourse)
            {


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@username", username);
                    totalcourses = Convert.ToInt32(command2.ExecuteScalar().ToString());

                    Session["totalcoursesreg"] = totalcourses;
                }
            }
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        int coursestaken = (int)Session["totalcoursesreg"];
        bool flag = false;
        string course = DropDownList1.SelectedValue;
        string id = (string)Session["username"];
        string query2 = "select prereq_ID from prereq where ID = @course";
        string prereq = "";
        
        if (coursestaken >= 6)
        {

            MessageBox.Show("          CANNOT REGISTER MORE THAN 6 COURSES!          ");
            Response.Redirect("Scourseregistration.aspx");
        }
        else
        {

            SqlConnection connection = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
            connection.Open();

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
                if (result2 != DBNull.Value && result2 != null)
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



                string query3 = "Insert into studies (student_ID,course_ID) values ('" + id + "','" + course + "')";
                SqlCommand command3 = new SqlCommand(query3, connection);
                command3.ExecuteNonQuery();
                command3.Dispose();
                connection.Close();
                MessageBox.Show("          SUCCESSFULLY REGISTERED!          ");
            }
            else
            {
                MessageBox.Show("          PREREQ COURSE NOT PASSED!          ");
            }
            Response.Redirect("SHome.aspx");

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("SHome.aspx");

    }
}

   
