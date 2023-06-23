using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query1 = "Select username from faculty where username = @username";
        string query2 = "select subject from faculty where username = @username";
        string query3 = "Select room_number from faculty where username = @username";
        string query4 = "Select school_year from faculty where username = @username";
        string query5 = "select campus from faculty F join users U on U.username = F.username AND F.username = @username";
        string query7 = "select name from faculty F join users U on U.username = F.username AND F.username = @username";
        string query8 = "select DOB from faculty F join users U on U.username = F.username AND F.username = @username";
        string query9 = "select blood_group from faculty F join users U on U.username = F.username AND F.username = @username";
        string query10 = "select gender from faculty F join users U on U.username = F.username AND F.username = @username";
        string query11 = "select CNIC from faculty F join users U on U.username = F.username AND F.username = @username";
        string query12 = "select nationality from faculty F join users U on U.username = F.username AND F.username = @username";
        string query13 = "select email from faculty F join users U on U.username = F.username AND F.username = @username";
        string query14 = "select contact from faculty F join users U on U.username = F.username AND F.username = @username";
        string ID, subject, roomnumber, schoolyear, campus, name, DOB, blood, gender, cnic, nationality, email, contact;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@username", username);
            ID = command1.ExecuteScalar().ToString();

            SqlCommand command2 = new SqlCommand(query2, connection);
            command2.Parameters.AddWithValue("@username", username);
            subject = command2.ExecuteScalar().ToString();


            SqlCommand command3 = new SqlCommand(query3, connection);
            command3.Parameters.AddWithValue("@username", username);
            roomnumber = command3.ExecuteScalar().ToString();

            SqlCommand command4 = new SqlCommand(query4, connection);
            command4.Parameters.AddWithValue("@username", username);
            schoolyear= command4.ExecuteScalar().ToString();


            SqlCommand command5 = new SqlCommand(query5, connection);
            command5.Parameters.AddWithValue("@username", username);
            campus = command5.ExecuteScalar().ToString();


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


            connection.Close();
        }

        if (!string.IsNullOrEmpty(ID))
        {
            Label5.Text = ID.ToString();
        }

        if (!string.IsNullOrEmpty(subject))
        {
            Label6.Text = subject.ToString();
        }

        if (!string.IsNullOrEmpty(roomnumber))
        {
            Label7.Text = roomnumber.ToString();
        }


        if (!string.IsNullOrEmpty(schoolyear))
        {
            Label8.Text = schoolyear.ToString();
        }

        if (!string.IsNullOrEmpty(campus))
        {
            Label9.Text = campus.ToString();
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

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Server.Transfer("FHome.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("Fattendance.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("Fmarks.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Server.Transfer("Fsetweightages.aspx");

    }


    protected void Button5_Click(object sender, EventArgs e)
    {
        Server.Transfer("Fgrades.aspx");
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("LogIn.aspx");
    }


    protected void Button9_Click(object sender, EventArgs e)
    {
        // Create a connection to the database
        SqlConnection connection = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        connection.Open();
        string username = (string)Session["username"];
        // Create a command with the query
        SqlCommand command = new SqlCommand("select student_ID,name,description,percentage from feedback join users on users.username = feedback.student_ID where faculty_ID = @username", connection);
        command.Parameters.AddWithValue("@username", username);

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
            Paragraph header = new Paragraph("Feedback Report");
            header.Alignment = Element.ALIGN_CENTER;
            document.Add(header);

            // Add a table to the document
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 1f, 2f, 3f, 1f });

            // Add column headers to the table
            PdfPCell cell = new PdfPCell(new Phrase("Student ID"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Name"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Description"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Percentage"));
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

                cell = new PdfPCell(new Phrase(row["description"].ToString()));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(row["percentage"].ToString()));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            // Add the table to the document
            document.Add(table);
            document.Close();

            // Set the response headers to force download of the PDF
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=feedbackreport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();
        }

    }
}