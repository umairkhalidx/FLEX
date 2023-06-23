using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string prevcourse = "", course = "";
        string query = "SELECT distinct student_id,course_ID FROM studies WHERE student_id = @username";
        string query1 = "SELECT student_ID,course_id, obtained_marks, total_marks FROM quiz WHERE student_ID = @username AND course_id = @course";
        string query2 = "SELECT student_ID,course_id, obtained_marks, total_marks FROM Assignment WHERE student_ID = @username AND course_id = @course";
        string query3 = "SELECT student_ID,course_id, obtained_marks, total_marks FROM sessionals WHERE student_ID = @username AND course_id = @course";
        string query4 = "SELECT student_ID,course_id, obtained_marks, total_marks FROM Project WHERE student_ID = @username AND course_id = @course";
        string query5 = "SELECT student_ID,course_id, obtained_marks, total_marks FROM final WHERE student_ID = @username AND course_id = @course";

        if (!IsPostBack)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();



                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = command.ExecuteReader();

                DropDownList1.DataSource = reader;
                DropDownList1.DataTextField = "course_id";
                DropDownList1.DataValueField = "course_id";
                DropDownList1.DataBind();
                reader.Close();

                course = DropDownList1.SelectedValue;
                Session["course_marks"] = DropDownList1.SelectedValue;



                SqlCommand command1 = new SqlCommand(query1, connection);
                command1.Parameters.AddWithValue("@username", username);
                command1.Parameters.AddWithValue("@course", DropDownList1.SelectedValue) ;
                SqlDataReader reader1 = command1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(reader1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();

                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@username", username);
                command2.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                SqlDataReader reader2 = command2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(reader2);
                GridView2.DataSource = dt2;
                GridView2.DataBind();


                SqlCommand command3 = new SqlCommand(query3, connection);
                command3.Parameters.AddWithValue("@username", username);
                command3.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                SqlDataReader reader3 = command3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(reader3);
                GridView3.DataSource = dt3;
                GridView3.DataBind();

                SqlCommand command4 = new SqlCommand(query4, connection);
                command4.Parameters.AddWithValue("@username", username);
                command4.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                SqlDataReader reader4 = command4.ExecuteReader();
                DataTable dt4 = new DataTable();
                dt4.Load(reader4);
                GridView4.DataSource = dt4;
                GridView4.DataBind();


                SqlCommand command5 = new SqlCommand(query5, connection);
                command5.Parameters.AddWithValue("@username", username);
                command5.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                SqlDataReader reader5 = command5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(reader5);
                GridView5.DataSource = dt5;
                GridView5.DataBind();


            }
        }

        else
        {
            prevcourse = (string)Session["course_marks"];
            course = DropDownList1.SelectedValue;
            if(course!=prevcourse)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Parameters.AddWithValue("@username", username);
                    command1.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    SqlDataReader reader1 = command1.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(reader1);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();

                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@username", username);
                    command2.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    DataTable dt2 = new DataTable();
                    dt2.Load(reader2);
                    GridView2.DataSource = dt2;
                    GridView2.DataBind();


                    SqlCommand command3 = new SqlCommand(query3, connection);
                    command3.Parameters.AddWithValue("@username", username);
                    command3.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    SqlDataReader reader3 = command3.ExecuteReader();
                    DataTable dt3 = new DataTable();
                    dt3.Load(reader3);
                    GridView3.DataSource = dt3;
                    GridView3.DataBind();

                    SqlCommand command4 = new SqlCommand(query4, connection);
                    command4.Parameters.AddWithValue("@username", username);
                    command4.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    SqlDataReader reader4 = command4.ExecuteReader();
                    DataTable dt4 = new DataTable();
                    dt4.Load(reader4);
                    GridView4.DataSource = dt4;
                    GridView4.DataBind();


                    SqlCommand command5 = new SqlCommand(query5, connection);
                    command5.Parameters.AddWithValue("@username", username);
                    command5.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    SqlDataReader reader5 = command5.ExecuteReader();
                    DataTable dt5 = new DataTable();
                    dt5.Load(reader5);
                    GridView5.DataSource = dt5;
                    GridView5.DataBind();


                }

            }
            
        }

    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SHome.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}