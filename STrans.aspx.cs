using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Strans : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query1 = "Select Roll_num from students where Roll_num = @username";
        string query2 = "select name from students S join users u on u.username = S.Roll_num where Roll_num = @username";
        string query3 = "Select batch from students where Roll_num = @username";
        string query4 = "Select reg_no from students where Roll_num = @username";
        string rollNumber, name, batch, arn;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@username", username);
            rollNumber = command1.ExecuteScalar().ToString();


            SqlCommand command2 = new SqlCommand(query2, connection);
            command2.Parameters.AddWithValue("@username", username);
            name = command2.ExecuteScalar().ToString();


            SqlCommand command3 = new SqlCommand(query3, connection);
            command3.Parameters.AddWithValue("@username", username);
            batch = command3.ExecuteScalar().ToString();


            SqlCommand command4 = new SqlCommand(query4, connection);
            command4.Parameters.AddWithValue("@username", username);
            arn = command4.ExecuteScalar().ToString();


        }

        if (!string.IsNullOrEmpty(rollNumber))
        {
            Label6.Text = rollNumber.ToString();
        }

        if (!string.IsNullOrEmpty(name))
        {
            Label7.Text = name.ToString();
        }

        if (!string.IsNullOrEmpty(batch))
        {
            Label8.Text = batch.ToString();
        }

        if (!string.IsNullOrEmpty(arn))
        {
            Label9.Text = arn.ToString();
        }


        string query5 = "select distinct(S.Roll_num),C.name,C.credit_hours,G.grade from students S join grades G on G.student_ID = S.Roll_num join courses C on C.ID = G.course_ID  WHERE S.Roll_num = @username AND C.semester = 1 ;";
        string query6 = "select distinct(S.Roll_num),C.name,C.credit_hours,G.grade from students S join grades G on G.student_ID = S.Roll_num join courses C on C.ID = G.course_ID  WHERE S.Roll_num = @username AND C.semester = 2 ;";
        string query7 = "select distinct(S.Roll_num),C.name,C.credit_hours,G.grade from students S join grades G on G.student_ID = S.Roll_num join courses C on C.ID = G.course_ID  WHERE S.Roll_num = @username AND C.semester = 3 ;";
        string query8 = "select distinct(S.Roll_num),C.name,C.credit_hours,G.grade from students S join grades G on G.student_ID = S.Roll_num join courses C on C.ID = G.course_ID  WHERE S.Roll_num = @username AND C.semester = 4 ;";
        string query9 = "select distinct(S.Roll_num),C.name,C.credit_hours,G.grade from students S join grades G on G.student_ID = S.Roll_num join courses C on C.ID = G.course_ID  WHERE S.Roll_num = @username AND C.semester = 5 ;";
        string query10 = "select distinct(S.Roll_num),C.name,C.credit_hours,G.grade from students S join grades G on G.student_ID = S.Roll_num join courses C on C.ID = G.course_ID  WHERE S.Roll_num = @username AND C.semester = 6 ;";
        string query11 = "select distinct(S.Roll_num),C.name,C.credit_hours,G.grade from students S join grades G on G.student_ID = S.Roll_num join courses C on C.ID = G.course_ID  WHERE S.Roll_num = @username AND C.semester = 7 ;";
        string query12 = "select distinct(S.Roll_num),C.name,C.credit_hours,G.grade from students S join grades G on G.student_ID = S.Roll_num join courses C on C.ID = G.course_ID  WHERE S.Roll_num = @username AND C.semester = 8 ;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command5 = new SqlCommand(query5, connection);
            command5.Parameters.AddWithValue("@username", username);
            SqlDataReader reader5 = command5.ExecuteReader();
            DataTable dt5 = new DataTable();
            dt5.Load(reader5);
            GridView1.DataSource = dt5;
            GridView1.DataBind();


            SqlCommand command6 = new SqlCommand(query6, connection);
            command6.Parameters.AddWithValue("@username", username);
            SqlDataReader reader6 = command6.ExecuteReader();
            DataTable dt6 = new DataTable();
            dt6.Load(reader6);
            GridView2.DataSource = dt6;
            GridView2.DataBind();


            SqlCommand command7 = new SqlCommand(query7, connection);
            command7.Parameters.AddWithValue("@username", username);
            SqlDataReader reader7 = command7.ExecuteReader();
            DataTable dt7 = new DataTable();
            dt7.Load(reader7);
            GridView3.DataSource = dt7;
            GridView3.DataBind();


            SqlCommand command8 = new SqlCommand(query8, connection);
            command8.Parameters.AddWithValue("@username", username);
            SqlDataReader reader8 = command8.ExecuteReader();
            DataTable dt8 = new DataTable();
            dt8.Load(reader8);
            GridView4.DataSource = dt8;
            GridView4.DataBind();


            SqlCommand command9 = new SqlCommand(query9, connection);
            command9.Parameters.AddWithValue("@username", username);
            SqlDataReader reader9 = command9.ExecuteReader();
            DataTable dt9 = new DataTable();
            dt9.Load(reader9);
            GridView5.DataSource = dt9;
            GridView5.DataBind();


            SqlCommand command10 = new SqlCommand(query10, connection);
            command10.Parameters.AddWithValue("@username", username);
            SqlDataReader reader10 = command10.ExecuteReader();
            DataTable dt10 = new DataTable();
            dt10.Load(reader10);
            GridView6.DataSource = dt10;
            GridView6.DataBind();


            SqlCommand command11 = new SqlCommand(query11, connection);
            command11.Parameters.AddWithValue("@username", username);
            SqlDataReader reader11 = command11.ExecuteReader();
            DataTable dt11 = new DataTable();
            dt11.Load(reader11);
            GridView7.DataSource = dt11;
            GridView7.DataBind();


            SqlCommand command12 = new SqlCommand(query12, connection);
            command12.Parameters.AddWithValue("@username", username);
            SqlDataReader reader12 = command12.ExecuteReader();
            DataTable dt12 = new DataTable();
            dt12.Load(reader12);
            GridView8.DataSource = dt12;
            GridView8.DataBind();
        }



        
        double[] totalGradePoints=new double[8];
        double[] totalCredits = new double [8];
        double[] gpa=new double[8];
        double cgpa = 0;
        double last = 0;

        totalGradePoints[0] = 0;
        totalCredits[0] = 0;

        totalGradePoints[1] = 0;
        totalCredits[1] = 0;
       
        totalGradePoints[2] = 0;
        totalCredits[2] = 0;
        
        totalGradePoints[3] = 0;
        totalCredits[3] = 0;
        
        totalGradePoints[4] = 0;
        totalCredits[4] = 0;
        
        totalGradePoints[5] = 0;
        totalCredits[5] = 0;
        
        totalGradePoints[6] = 0;
        totalCredits[6] = 0;
      
        totalGradePoints[7] = 0;
        totalCredits[7] = 0;


        gpa[0] = 0;
        gpa[1] = 0;
        gpa[2] = 0;
        gpa[3] = 0;
        gpa[4] = 0;
        gpa[5] = 0;
        gpa[6] = 0;
        gpa[7] = 0;
        
        foreach (GridViewRow row in GridView1.Rows)
        {
            string grade = row.Cells[4].Text;
            int credits = int.Parse(row.Cells[3].Text);
            
            
            double gradePoints;
            switch (grade)
            {
                case "A+":
                    gradePoints = 4.0;
                    break;
                case "A":
                    gradePoints = 4.0;
                    break;
                case "A-":
                    gradePoints = 3.7;
                    break;
                case "B+":
                    gradePoints = 3.3;
                    break;
                case "B":
                    gradePoints = 3.0;
                    break;
                case "B-":
                    gradePoints = 2.7;
                    break;
                case "C+":
                    gradePoints = 2.3;
                    break;
                case "C":
                    gradePoints = 2.0;
                    break;
                case "C-":
                    gradePoints = 1.7;
                    break;
                case "D+":
                    gradePoints = 1.3;
                    break;
                case "D":
                    gradePoints = 1.0;
                    break;
                default:
                    gradePoints = 0.0;
                    break;
            }

            totalGradePoints[0] += gradePoints * credits;
            totalCredits[0] += credits;
        }

        if (totalCredits[0] != 0)
        {
            gpa[0] = totalGradePoints[0] / totalCredits[0];
            last = totalCredits[0] + totalCredits[1] + totalCredits[2] + totalCredits[3] + totalCredits[4] + totalCredits[5] + totalCredits[6] + totalCredits[7];
            cgpa = (totalGradePoints[0] / totalCredits[0]);
            cgpa = Math.Round(cgpa, 2);
            Label11.Text = "SGPA: " + gpa[0].ToString();
            Label12.Text = "Credit Hours: " + totalCredits[0].ToString();
            Label34.Text="CGPA: "+cgpa.ToString();
        }




        if (totalCredits[0] == 0)
        {
            Label11.Text = " ";
            Label12.Text = " ";
            Label34.Text = " ";

        }

        foreach (GridViewRow row in GridView2.Rows)
        {
            string grade = row.Cells[4].Text;
            int credits = int.Parse(row.Cells[3].Text);
            double gradePoints;
            switch (grade)
            {
                case "A+":
                    gradePoints = 4.0;
                    break;
                case "A":
                    gradePoints = 4.0;
                    break;
                case "A-":
                    gradePoints = 3.7;
                    break;
                case "B+":
                    gradePoints = 3.3;
                    break;
                case "B":
                    gradePoints = 3.0;
                    break;
                case "B-":
                    gradePoints = 2.7;
                    break;
                case "C+":
                    gradePoints = 2.3;
                    break;
                case "C":
                    gradePoints = 2.0;
                    break;
                case "C-":
                    gradePoints = 1.7;
                    break;
                case "D+":
                    gradePoints = 1.3;
                    break;
                case "D":
                    gradePoints = 1.0;
                    break;
                default:
                    gradePoints = 0.0;
                    break;
            }

            totalGradePoints[1] += gradePoints * credits;
            totalCredits[1] += credits;
        }

        
        if (totalCredits[1] != 0)
        {
            gpa[1] = totalGradePoints[1] / totalCredits[1];
            last = totalCredits[0] + totalCredits[1] + totalCredits[2] + totalCredits[3] + totalCredits[4] + totalCredits[5] + totalCredits[6] + totalCredits[7];
            cgpa = (gpa[0] * totalCredits[0]) + (gpa[1] * totalCredits[1]);
            cgpa = cgpa / last;
            cgpa = Math.Round(cgpa, 2);
            Label14.Text = "SGPA: " + gpa[1].ToString();
            Label13.Text = "Credit Hours: " + totalCredits[1].ToString();
            Label35.Text="CGPA: "+ cgpa.ToString(); 
        }

        if (totalCredits[1] == 0)
        {
            Label13.Text = " ";
            Label14.Text = " ";
            Label35.Text= " ";

        }


        foreach (GridViewRow row in GridView3.Rows)
        {
            string grade = row.Cells[4].Text;
            int credits = int.Parse(row.Cells[3].Text);
            double gradePoints;
            switch (grade)
            {
                case "A+":
                    gradePoints = 4.0;
                    break;
                case "A":
                    gradePoints = 4.0;
                    break;
                case "A-":
                    gradePoints = 3.7;
                    break;
                case "B+":
                    gradePoints = 3.3;
                    break;
                case "B":
                    gradePoints = 3.0;
                    break;
                case "B-":
                    gradePoints = 2.7;
                    break;
                case "C+":
                    gradePoints = 2.3;
                    break;
                case "C":
                    gradePoints = 2.0;
                    break;
                case "C-":
                    gradePoints = 1.7;
                    break;
                case "D+":
                    gradePoints = 1.3;
                    break;
                case "D":
                    gradePoints = 1.0;
                    break;
                default:
                    gradePoints = 0.0;
                    break;
            }

            totalGradePoints[2] += gradePoints * credits;
            totalCredits[2] += credits;
        }

        
        if (totalCredits[2] != 0)
        {
            gpa[2] = totalGradePoints[2] / totalCredits[2];
            last = totalCredits[0] + totalCredits[1] + totalCredits[2] + totalCredits[3] + totalCredits[4] + totalCredits[5] + totalCredits[6] + totalCredits[7];
            cgpa = (gpa[0] * totalCredits[0]) + (gpa[1] * totalCredits[1]) + (gpa[2] * totalCredits[2]); 
            cgpa = cgpa / last;

            cgpa = Math.Round(cgpa, 2);
            Label17.Text = "SGPA: " + gpa[2].ToString();
            Label16.Text = "Credit Hours: " + totalCredits[2].ToString();
            Label36.Text = "CGPA: " + cgpa.ToString();
        }


        if (totalCredits[2] == 0)
        {
            Label17.Text = " ";
            Label16.Text = " ";
            Label36.Text = " ";

        }


        foreach (GridViewRow row in GridView4.Rows)
        {
            string grade = row.Cells[4].Text;
            int credits = int.Parse(row.Cells[3].Text);
            double gradePoints;
            switch (grade)
            {
                case "A+":
                    gradePoints = 4.0;
                    break;
                case "A":
                    gradePoints = 4.0;
                    break;
                case "A-":
                    gradePoints = 3.7;
                    break;
                case "B+":
                    gradePoints = 3.3;
                    break;
                case "B":
                    gradePoints = 3.0;
                    break;
                case "B-":
                    gradePoints = 2.7;
                    break;
                case "C+":
                    gradePoints = 2.3;
                    break;
                case "C":
                    gradePoints = 2.0;
                    break;
                case "C-":
                    gradePoints = 1.7;
                    break;
                case "D+":
                    gradePoints = 1.3;
                    break;
                case "D":
                    gradePoints = 1.0;
                    break;
                default:
                    gradePoints = 0.0;
                    break;
            }

            totalGradePoints[3] += gradePoints * credits;
            totalCredits[3] += credits;
        }

        
        if (totalCredits[3] != 0)
        {
            gpa[3] = totalGradePoints[3] / totalCredits[3];
            last = totalCredits[0] + totalCredits[1] + totalCredits[2] + totalCredits[3] + totalCredits[4] + totalCredits[5] + totalCredits[6] + totalCredits[7];

            cgpa = (gpa[0] * totalCredits[0]) + (gpa[1] * totalCredits[1]) + (gpa[2] * totalCredits[2]) + (gpa[3] * totalCredits[3]); 
            cgpa = cgpa / last;
            cgpa = Math.Round(cgpa, 2);
            Label20.Text = "SGPA: " + gpa[3].ToString();
            Label19.Text = "Credit Hours: " + totalCredits[3].ToString();
            Label37.Text = "CGPA: " + cgpa.ToString();
        }

        if (totalCredits[3] == 0)
        {
            Label19.Text = " ";
            Label20.Text = " ";
            Label37.Text = " ";

        }




        foreach (GridViewRow row in GridView5.Rows)
        {
            string grade = row.Cells[4].Text;
            int credits = int.Parse(row.Cells[3].Text);
            double gradePoints;
            switch (grade)
            {
                case "A+":
                    gradePoints = 4.0;
                    break;
                case "A":
                    gradePoints = 4.0;
                    break;
                case "A-":
                    gradePoints = 3.7;
                    break;
                case "B+":
                    gradePoints = 3.3;
                    break;
                case "B":
                    gradePoints = 3.0;
                    break;
                case "B-":
                    gradePoints = 2.7;
                    break;
                case "C+":
                    gradePoints = 2.3;
                    break;
                case "C":
                    gradePoints = 2.0;
                    break;
                case "C-":
                    gradePoints = 1.7;
                    break;
                case "D+":
                    gradePoints = 1.3;
                    break;
                case "D":
                    gradePoints = 1.0;
                    break;
                default:
                    gradePoints = 0.0;
                    break;
            }

            totalGradePoints[4] += gradePoints * credits;
            totalCredits[4] += credits;
        }

       
        if (totalCredits[4] != 0)
        {
            gpa[4] = totalGradePoints[4] / totalCredits[4];
            last = totalCredits[0] + totalCredits[1] + totalCredits[2] + totalCredits[3] + totalCredits[4] + totalCredits[5] + totalCredits[6] + totalCredits[7];

            cgpa = (gpa[0] * totalCredits[0]) + (gpa[1] * totalCredits[1]) + (gpa[2] * totalCredits[2]) + (gpa[3] * totalCredits[3]) + (gpa[4] * totalCredits[4]);
            cgpa = cgpa / last;
            cgpa = Math.Round(cgpa, 2);
            Label23.Text = "SGPA: " + gpa[4].ToString();
            Label22.Text = "Credit Hours: " + totalCredits[4].ToString();
            Label38.Text = "CGPA: " + cgpa.ToString();
        }



        
        if (totalCredits[4] == 0)
        {
            Label22.Text = " ";
            Label23.Text = " ";
            Label38.Text = " ";

        }




        foreach (GridViewRow row in GridView6.Rows)
        {
            string grade = row.Cells[4].Text;
            int credits = int.Parse(row.Cells[3].Text);
            double gradePoints;
            switch (grade)
            {
                case "A+":
                    gradePoints = 4.0;
                    break;
                case "A":
                    gradePoints = 4.0;
                    break;
                case "A-":
                    gradePoints = 3.7;
                    break;
                case "B+":
                    gradePoints = 3.3;
                    break;
                case "B":
                    gradePoints = 3.0;
                    break;
                case "B-":
                    gradePoints = 2.7;
                    break;
                case "C+":
                    gradePoints = 2.3;
                    break;
                case "C":
                    gradePoints = 2.0;
                    break;
                case "C-":
                    gradePoints = 1.7;
                    break;
                case "D+":
                    gradePoints = 1.3;
                    break;
                case "D":
                    gradePoints = 1.0;
                    break;
                default:
                    gradePoints = 0.0;
                    break;
            }

            totalGradePoints[5] += gradePoints * credits;
            totalCredits[5] += credits;
        }

        
        if (totalCredits[5] != 0)
        {
            gpa[5] = totalGradePoints[5] / totalCredits[5];
            last = totalCredits[0] + totalCredits[1] + totalCredits[2] + totalCredits[3] + totalCredits[4] + totalCredits[5] + totalCredits[6] + totalCredits[7];

            cgpa = (gpa[0] * totalCredits[0]) + (gpa[1] * totalCredits[1]) + (gpa[2] * totalCredits[2]) + (gpa[3] * totalCredits[3]) + (gpa[4] * totalCredits[4]) + (gpa[5] * totalCredits[5]);
            cgpa = cgpa / last;
            cgpa = Math.Round(cgpa, 2);
            Label26.Text = "SGPA: " + gpa[5].ToString();
            Label25.Text = "Credit Hours: " + totalCredits[5].ToString();
            Label39.Text = "CGPA: " + cgpa.ToString();
        }


        if (totalCredits[5] == 0)
        {
            Label25.Text = " ";
            Label26.Text = " ";
            Label39.Text = " ";

        }



        foreach (GridViewRow row in GridView7.Rows)
        {
            string grade = row.Cells[4].Text;
            int credits = int.Parse(row.Cells[3].Text);
            double gradePoints;
            switch (grade)
            {
                case "A+":
                    gradePoints = 4.0;
                    break;
                case "A":
                    gradePoints = 4.0;
                    break;
                case "A-":
                    gradePoints = 3.7;
                    break;
                case "B+":
                    gradePoints = 3.3;
                    break;
                case "B":
                    gradePoints = 3.0;
                    break;
                case "B-":
                    gradePoints = 2.7;
                    break;
                case "C+":
                    gradePoints = 2.3;
                    break;
                case "C":
                    gradePoints = 2.0;
                    break;
                case "C-":
                    gradePoints = 1.7;
                    break;
                case "D+":
                    gradePoints = 1.3;
                    break;
                case "D":
                    gradePoints = 1.0;
                    break;
                default:
                    gradePoints = 0.0;
                    break;
            }

            totalGradePoints[6] += gradePoints * credits;
            totalCredits[6] += credits;
        }

        
        if (totalCredits[6] != 0)
        {
            gpa[6] = totalGradePoints[6] / totalCredits[6];
            last = totalCredits[0] + totalCredits[1] + totalCredits[2] + totalCredits[3] + totalCredits[4] + totalCredits[5] + totalCredits[6] + totalCredits[7];

            cgpa = (gpa[0] * totalCredits[0]) + (gpa[1] * totalCredits[1]) + (gpa[2] * totalCredits[2]) + (gpa[3] * totalCredits[3]) + (gpa[4] * totalCredits[4]) + (gpa[5] * totalCredits[5]) + (gpa[6] * totalCredits[6]);
            cgpa = cgpa / last;
            cgpa = Math.Round(cgpa, 2);
            Label29.Text = "SGPA: " + gpa[6].ToString();
            Label28.Text = "Credit Hours: " + totalCredits[6].ToString();
            Label40.Text = "CGPA: " + cgpa.ToString();
        }


        if (totalCredits[6] == 0)
        {
            Label28.Text = " ";
            Label29.Text = " ";
            Label40.Text = " ";

        }



        foreach (GridViewRow row in GridView8.Rows)
        {
            string grade = row.Cells[4].Text;
            int credits = int.Parse(row.Cells[3].Text);
            double gradePoints;
            switch (grade)
            {
                case "A+":
                    gradePoints = 4.0;
                    break;
                case "A":
                    gradePoints = 4.0;
                    break;
                case "A-":
                    gradePoints = 3.7;
                    break;
                case "B+":
                    gradePoints = 3.3;
                    break;
                case "B":
                    gradePoints = 3.0;
                    break;
                case "B-":
                    gradePoints = 2.7;
                    break;
                case "C+":
                    gradePoints = 2.3;
                    break;
                case "C":
                    gradePoints = 2.0;
                    break;
                case "C-":
                    gradePoints = 1.7;
                    break;
                case "D+":
                    gradePoints = 1.3;
                    break;
                case "D":
                    gradePoints = 1.0;
                    break;
                default:
                    gradePoints = 0.0;
                    break;
            }

            totalGradePoints[7] += gradePoints * credits;
            totalCredits[7] += credits;
        }

        
        if (totalCredits[7] != 0)
        {
            gpa[7] = totalGradePoints[7] / totalCredits[7];
            last = totalCredits[0] + totalCredits[1] + totalCredits[2] + totalCredits[3] + totalCredits[4] + totalCredits[5] + totalCredits[6] + totalCredits[7];

            cgpa = (gpa[0] * totalCredits[0]) + (gpa[1] * totalCredits[1]) + (gpa[2] * totalCredits[2]) + (gpa[3] * totalCredits[3]) + (gpa[4] * totalCredits[4]) + (gpa[5] * totalCredits[5]) + (gpa[6] * totalCredits[6]) + (gpa[7] * totalCredits[7]);
            cgpa = cgpa / last;
            cgpa = Math.Round(cgpa, 2);
            Label32.Text = "SGPA: " + gpa[7].ToString();
            Label31.Text = "Credit Hours: " + totalCredits[7].ToString();
            Label41.Text = "CGPA: " + cgpa.ToString();
        }


        if (totalCredits[7] == 0)
        {
            Label31.Text = " ";
            Label32.Text = " ";
            Label41.Text = " ";
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SHome.aspx");
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}