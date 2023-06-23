using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using System.Globalization;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;

public partial class Fassign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string section = (string)Session["section"];
        string course = (string)Session["course_grades"];
        string query1 = "select distinct S.student_id,U.name from studies S join users U on U.username = S.student_id join teaches T on T.course_ID = S.course_id where S.course_id = @course and S.section = @section AND T.faculty_ID = @username group by S.student_id,U.name";

        

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@username", username);
            command1.Parameters.AddWithValue("@section", section);
            command1.Parameters.AddWithValue("@course", course);
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(reader1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            reader1.Close();

            DataTable dt = (DataTable)GridView1.DataSource;
            dt.Columns.Add("TOTAL ABSOLUTES");
            
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {

                row["TOTAL ABSOLUTES"] = (string)Session["absolutes" + i.ToString()];
                i++;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            connection.Close();


        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Fgrades.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
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




        string course = (string)Session["course_grades"];
        foreach (GridViewRow row in GridView1.Rows)
        {
            string grade="";
            string rollNumber = row.Cells[1].Text;
            int abs = Convert.ToInt32(row.Cells[3].Text);

            if (abs >= 90 && abs <= 100)
                grade = "A+";
            else if (abs >= 86 && abs <= 89)
                grade = "A";
            else if(abs >= 82 && abs <= 85)
                grade = "A-";
            else if (abs >= 78 && abs <= 81)
                grade = "B+";
            else if (abs >= 74 && abs <= 77)
                grade = "B";
            else if (abs >= 70 && abs <= 73)
                grade = "B-";
            else if (abs >= 66 && abs <= 69)
                grade = "C+";
            else if (abs >= 62 && abs <= 65)
                grade = "C";
            else if (abs >= 58 && abs <= 61)
                grade = "C-";
            else if (abs >= 54 && abs <= 57)
                grade = "D+";
            else if (abs >= 50 && abs <= 53)
                grade = "D";
            else if (abs <=49)
                grade = "F";

            string query = "INSERT INTO grades (student_ID, course_ID,grade) VALUES ('" + rollNumber + "', '" + course + "', '" + grade + "')";
            SqlCommand comm = new SqlCommand(query, connection);
            comm.ExecuteNonQuery();
            comm.Dispose();
            
        }
        MessageBox.Show("               SUCCESSFUL!               ");
        Response.Redirect("FHome.aspx");

        connection.Close();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Create a connection to the database
        SqlConnection connection = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        connection.Open();
        string username = (string)Session["username"];
        string course = (string)Session["course_grades"];
        // Create a command with the query
        SqlCommand command = new SqlCommand("select distinct student_ID,name,grade from grades join teaches on teaches.course_ID = grades.course_ID join users on users.username = grades.student_ID where teaches.faculty_id = @username AND grades.course_ID = @course", connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@course", course);

        // Create a data adapter to fill the data table
        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        // Export the data to PDF using iTextSharp library
        using (MemoryStream memoryStream = new MemoryStream())
        {
            Document document = new Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            // Add a header to the document
            Paragraph header = new Paragraph("Grade Report\n\n\n");
            header.Alignment = Element.ALIGN_CENTER;
            document.Add(header);

            // Add a table to the document
            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 1f, 2f, 1f });

            // Add column headers to the table
            PdfPCell cell = new PdfPCell(new Phrase("Student ID"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Name"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Grade"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            // Add rows to the table
            foreach (DataRow row in dataTable.Rows)
            {
                cell = new PdfPCell(new Phrase(row["student_ID"].ToString()));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(row["name"].ToString()));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(row["grade"].ToString()));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            // Add the table to the document
            document.Add(table);
            document.Close();

            // Set the response headers to force download of the PDF
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=gradereport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();
        }

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // Create a connection to the database
        SqlConnection connection = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        connection.Open();

        // Create a command with the query
        SqlCommand command = new SqlCommand("select grade,count(*) as count from grades group by grade", connection);

        // Create a data adapter to fill the data table
        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        // Export the data to PDF using iTextSharp library
        using (MemoryStream memoryStream = new MemoryStream())
        {
            Document document = new Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            // Add a header to the document
            Paragraph header = new Paragraph("Count of Grades Report\n\n\n");
            header.Alignment = Element.ALIGN_CENTER;
            document.Add(header);

            // Add a table to the document
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 2f, 1f });

            // Add column headers to the table
            PdfPCell cell = new PdfPCell(new Phrase("Grade"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Count"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            // Add rows to the table
            foreach (DataRow row in dataTable.Rows)
            {
                cell = new PdfPCell(new Phrase(row["grade"].ToString()));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(row["count"].ToString()));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            // Add the table to the document
            document.Add(table);
            document.Close();

            // Set the response headers to force download of the PDF
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=countreport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();
        }

    }
}