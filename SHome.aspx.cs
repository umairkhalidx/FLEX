using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query1 = "Select Roll_num from students where Roll_num = @username";
        string query2 = "select degree from students where Roll_num = @username";
        string query3 = "Select batch from students where Roll_num = @username";
        string query4 = "Select reg_no from students where Roll_num = @username";
        string query5 = "select campus from students S join users U on U.username = S.Roll_num AND S.Roll_num = @username";
        string query6 = "select status from students where Roll_num = @username";
        string query7 = "select name from students S join users U on U.username = S.Roll_num AND S.Roll_num = @username";
        string query8 = "select DOB from students S join users U on U.username = S.Roll_num AND S.Roll_num = @username";
        string query9 = "select blood_group from students S join users U on U.username = S.Roll_num AND S.Roll_num = @username";
        string query10 = "select gender from students S join users U on U.username = S.Roll_num AND S.Roll_num = @username";
        string query11 = "select CNIC from students S join users U on U.username = S.Roll_num AND S.Roll_num = @username";
        string query12 = "select nationality from students S join users U on U.username = S.Roll_num AND S.Roll_num = @username";
        string query13 = "select email from students S join users U on U.username = S.Roll_num AND S.Roll_num = @username";
        string query14 = "select contact from students S join users U on U.username = S.Roll_num AND S.Roll_num = @username";
        string query15 = "select address from students where Roll_num = @username";
        string query16 = "select city from students where Roll_num = @username";
        string query17 = "select country from students where Roll_num = @username";
        string rollNumber, degree, batch, arn,campus,status,name,DOB,blood,gender,cnic,nationality,email,contact,address,city,country;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@username", username);
            connection.Open();
            rollNumber = command1.ExecuteScalar().ToString();

            SqlCommand command2 = new SqlCommand(query2, connection);
            command2.Parameters.AddWithValue("@username", username);
            degree = command2.ExecuteScalar().ToString();


            SqlCommand command3 = new SqlCommand(query3, connection);
            command3.Parameters.AddWithValue("@username", username);
            batch = command3.ExecuteScalar().ToString();

            SqlCommand command4 = new SqlCommand(query4, connection);
            command4.Parameters.AddWithValue("@username", username);
            arn = command4.ExecuteScalar().ToString();


            SqlCommand command5 = new SqlCommand(query5, connection);
            command5.Parameters.AddWithValue("@username", username);
            campus = command5.ExecuteScalar().ToString();


            SqlCommand command6 = new SqlCommand(query6, connection);
            command6.Parameters.AddWithValue("@username", username);
            status = command6.ExecuteScalar().ToString();

            SqlCommand command7 = new SqlCommand(query7, connection);
            command7.Parameters.AddWithValue("@username", username);
            name = command7.ExecuteScalar().ToString();

            SqlCommand command8 = new SqlCommand(query8, connection);
            command8.Parameters.AddWithValue("@username", username);
            DOB = command8.ExecuteScalar().ToString();

            SqlCommand command9 = new SqlCommand(query9, connection);
            command9.Parameters.AddWithValue("@username", username);
            blood = command9.ExecuteScalar().ToString();

            SqlCommand command10 = new SqlCommand(query10, connection);
            command10.Parameters.AddWithValue("@username", username);
            gender = command10.ExecuteScalar().ToString();

            SqlCommand command11 = new SqlCommand(query11, connection);
            command11.Parameters.AddWithValue("@username", username);
            cnic = command11.ExecuteScalar().ToString();

            SqlCommand command12 = new SqlCommand(query12, connection);
            command12.Parameters.AddWithValue("@username", username);
            nationality = command12.ExecuteScalar().ToString();

            SqlCommand command13 = new SqlCommand(query13, connection);
            command13.Parameters.AddWithValue("@username", username);
            email = command13.ExecuteScalar().ToString();

            SqlCommand command14 = new SqlCommand(query14, connection);
            command14.Parameters.AddWithValue("@username", username);
            contact = command14.ExecuteScalar().ToString();

            SqlCommand command15 = new SqlCommand(query15, connection);
            command15.Parameters.AddWithValue("@username", username);
            address = command15.ExecuteScalar().ToString();

            SqlCommand command16 = new SqlCommand(query16, connection);
            command16.Parameters.AddWithValue("@username", username);
            city = command16.ExecuteScalar().ToString();

            SqlCommand command17 = new SqlCommand(query17, connection);
            command17.Parameters.AddWithValue("@username", username);
            country = command17.ExecuteScalar().ToString();


        }

        if (!string.IsNullOrEmpty(rollNumber))
        {
            Label5.Text = rollNumber.ToString();
        }

        if (!string.IsNullOrEmpty(degree))
        {
            Label6.Text = degree.ToString();
        }

        if (!string.IsNullOrEmpty(batch))
        {
            Label7.Text = batch.ToString();
        }
        

        if (!string.IsNullOrEmpty(arn))
        {
            Label8.Text = arn.ToString();
        }

        if (!string.IsNullOrEmpty(campus))
        {
            Label9.Text = campus.ToString();
        }

        if (!string.IsNullOrEmpty(status))
        {
            Label10.Text = status.ToString();
        }

        if (!string.IsNullOrEmpty(name))
        {
            Label11.Text = name.ToString();
        }


        if (!string.IsNullOrEmpty(DOB))
        {
            Label12.Text = DOB.ToString();
        }


        if (!string.IsNullOrEmpty(blood))
        {
            Label13.Text = blood.ToString();
        }


        if (!string.IsNullOrEmpty(gender))
        {
            Label14.Text = gender.ToString();
        }

        if (!string.IsNullOrEmpty(cnic))
        {
            Label17.Text = cnic.ToString();
        }

        if (!string.IsNullOrEmpty(nationality))
        {
            Label18.Text = nationality.ToString();
        }


        if (!string.IsNullOrEmpty(email))
        {
            Label15.Text = email.ToString();
        }


        if (!string.IsNullOrEmpty(contact))
        {
            Label16.Text = contact.ToString();
        }

        if (!string.IsNullOrEmpty(address))
        {
            Label19.Text = address.ToString();
        }

        if (!string.IsNullOrEmpty(city))
        {
            Label20.Text = city.ToString();
        }

        if (!string.IsNullOrEmpty(country))
        {
            Label21.Text = country.ToString();
        }

        if (!IsPostBack)
        {
            string query_a = "SELECT course_ID, total, presents, (presents * 100.0 / total) AS percentage FROM ( SELECT course_ID, COUNT(date) AS total, SUM(CASE WHEN status = 'P' THEN 1 ELSE 0 END) AS presents FROM attendance    WHERE student_ID = @username   GROUP BY course_ID) AS subquery";
            string query_b = "SELECT C.semester, ROUND(SUM(CASE G.grade WHEN 'A+' THEN 4.0 WHEN 'A' THEN 4.0 WHEN 'A-' THEN 3.7 WHEN 'B+' THEN 3.3 WHEN 'B' THEN 3.0 WHEN 'B-' THEN 2.7 WHEN 'C+' THEN 2.3 WHEN 'C' THEN 2.0 WHEN 'C-' THEN 1.7 WHEN 'D+' THEN 1.3 WHEN 'D' THEN 1.0 ELSE 0 END * C.credit_hours) / SUM(C.credit_hours), 2) AS gpa FROM students JOIN grades G ON G.student_ID = students.Roll_num JOIN courses C ON C.ID = G.course_ID WHERE students.Roll_num = @username GROUP BY students.Roll_num, C.semester;\r\n";
          
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command_a = new SqlCommand(query_a, connection);
                command_a.Parameters.AddWithValue("@username", username);
                SqlDataReader reader_a = command_a.ExecuteReader();
                DataTable dt_a = new DataTable();
                dt_a.Load(reader_a);
                reader_a.Close();

                Chart1.Series["Series1"].Points.DataBindXY(dt_a.Rows, "course_ID", dt_a.Rows, "percentage");
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;



                SqlCommand command_b = new SqlCommand(query_b, connection);
                command_b.Parameters.AddWithValue("@username", username);
                SqlDataReader reader_b = command_b.ExecuteReader();
                DataTable dt_b = new DataTable();
                dt_b.Load(reader_b);
                reader_b.Close();


                Chart2.Series["Series2"].Points.DataBindXY(dt_b.Rows, "semester", dt_b.Rows, "gpa");
                Chart2.ChartAreas["ChartArea2"].AxisX.Interval = 1;

                connection.Close();


            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Server.Transfer("SHome.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("Scourseregistration.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("SAttendance.aspx");

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Server.Transfer("SMarks.aspx");
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Server.Transfer("STrans.aspx");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Server.Transfer("SfeedBackRedirector.aspx");
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("LogIn.aspx");
    }
}

 