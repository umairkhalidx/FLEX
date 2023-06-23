using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Areport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);


        pdfDoc.Open();


        Paragraph title = new Paragraph("OFFERED COURSES REPORT\n\n\n");
        title.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(title);

        // Add a table to the PDF document
        PdfPTable pdfTable = new PdfPTable(3);
        pdfTable.WidthPercentage = 100;

        // Add table headers
        pdfTable.AddCell(new PdfPCell(new Phrase("ID")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Name")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Credit Hours")));

        // Retrieve course data from the database and add rows to the table
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string query = "SELECT ID, name, credit_hours FROM courses";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand comm = new SqlCommand(query, conn))
            {
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["ID"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["name"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["credit_hours"].ToString())));
                }
                conn.Close();
            }
        }

        pdfDoc.Add(pdfTable);

        pdfDoc.Close();

        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment;filename=offeredoursesReport.pdf");
        Response.Write(pdfDoc);
        Response.End();

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("Asectionreport.aspx");
    }


    protected void Button4_Click(object sender, EventArgs e)
    {
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        // Open the PDF document
        pdfDoc.Open();

        // Add a title to the PDF document
        Paragraph title = new Paragraph("Course Allocation Report\n\n\n");
        title.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(title);

        // Add a table to the PDF document
        PdfPTable pdfTable = new PdfPTable(5);
        pdfTable.WidthPercentage = 100;

        // Add table headers
        pdfTable.AddCell(new PdfPCell(new Phrase("Course ID")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Course Name")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Credit Hours")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Section")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Faculty Name")));

        // Retrieve data from the database and add rows to the table
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string query = "select distinct C.ID,C.name,C.credit_hours,T.section,U.name from courses C join teaches T on T.course_id = C.ID join users U on U.username = T.faculty_ID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand comm = new SqlCommand(query, conn))
            {
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["ID"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["name"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["credit_hours"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["section"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["name"].ToString())));
                }

                conn.Close();
            }
        }

        pdfDoc.Add(pdfTable);

        pdfDoc.Close();

        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment;filename=CourseallocationReport.pdf");
        Response.Write(pdfDoc);
        Response.End();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        // Create a new PDF document
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

        // Create a PDF writer to write the document to the response stream
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        // Open the PDF document
        pdfDoc.Open();

        // Add a title to the document
        Paragraph title = new Paragraph("LOG TABLE REPORT\n\n\n");
        title.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(title);

        // Add a table to the document
        PdfPTable pdfTable = new PdfPTable(5);
        pdfTable.WidthPercentage = 100;

        // Add table headers
        pdfTable.AddCell(new PdfPCell(new Phrase("Log ID")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Table Name")));
        pdfTable.AddCell(new PdfPCell(new Phrase("User ID")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Change Date")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Change Type")));

        // Retrieve data from the database and add rows to the table
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string query = "SELECT log_id, table_name, user_id, change_date, change_type FROM log_table";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand comm = new SqlCommand(query, conn))
            {
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["log_id"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["table_name"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["user_id"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["change_date"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["change_type"].ToString())));
                }

                conn.Close();
            }
        }

        // Add the table to the document
        pdfDoc.Add(pdfTable);

        // Close the PDF document
        pdfDoc.Close();

        // Set the response headers to download the generated PDF file
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment;filename=logTableReport.pdf");
        Response.Write(pdfDoc);
        Response.End();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AHome.aspx");
    }
}