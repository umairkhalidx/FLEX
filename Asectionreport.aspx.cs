using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Asectionreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";

        string query = "select name from sections";

        if (!IsPostBack)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command1 = new SqlCommand(query, connection);

                SqlDataReader reader1 = command1.ExecuteReader();

                DropDownList1.DataSource = reader1;
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "name";
                DropDownList1.DataBind();

                reader1.Close();

            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string section = DropDownList1.SelectedValue;


        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);


        pdfDoc.Open();


        Paragraph title = new Paragraph("Students section report\n\n\n");
        title.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(title);

        
        PdfPTable pdfTable = new PdfPTable(3);
        pdfTable.WidthPercentage = 100;


        pdfTable.AddCell(new PdfPCell(new Phrase("Roll Number")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Student Name")));
        pdfTable.AddCell(new PdfPCell(new Phrase("Section")));

        
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string query = "SELECT DISTINCT S.roll_num, U.name, st.section FROM students S JOIN studies st ON st.student_id = S.roll_Num JOIN users U ON U.username = S.Roll_num WHERE st.section = @section order by S.Roll_num asc";
       
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand comm = new SqlCommand(query, conn))
            {
                conn.Open();
                comm.Parameters.AddWithValue("@section", section);

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["roll_num"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["name"].ToString())));
                    pdfTable.AddCell(new PdfPCell(new Phrase(reader["section"].ToString())));
                }
                conn.Close();
            }
        }

        pdfDoc.Add(pdfTable);

        pdfDoc.Close();

        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment;filename=Studentsectionreport.pdf");
        Response.Write(pdfDoc);
        Response.End();
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Areport.aspx");
    }
}