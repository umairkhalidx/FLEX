using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

public partial class Fgrades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query1 = "SELECT distinct course_ID FROM teaches WHERE faculty_id = @username";
        string query2 = "select section from teaches WHERE faculty_ID = @username AND course_id = @course";
        string query3 = "select quiz_w from courses where ID = @course";
        string query4 = "select assignment_w from courses where ID = @course";
        string query5 = "select sessionals_w from courses where ID = @course";
        string query6 = "select project_w from courses where ID = @course";
        string query7 = "select finals_w from courses where ID = @course";
        string query_without = "SELECT DISTINCT Q.student_id, Q.obtained_marks_sum1, Q.total_marks_sum1, A.obtained_marks_sum2, A.total_marks_sum2,  S.obtained_marks_sum3,  S.total_marks_sum3,  P.obtained_marks_sum4, P.total_marks_sum4, F.obtained_marks_sum5, F.total_marks_sum5 FROM   (SELECT student_id, \r\n               SUM(obtained_marks) AS obtained_marks_sum1, \r\n               SUM(total_marks)   AS total_marks_sum1 \r\n        FROM   quiz \r\n        WHERE course_id = @course AND faculty_id = @username        GROUP  BY student_id) Q \r\n       JOIN (SELECT student_id, \r\n                    SUM(obtained_marks) AS obtained_marks_sum2, \r\n                    SUM(total_marks)   AS total_marks_sum2 \r\n             FROM   assignment \r\n             WHERE course_id = @course AND faculty_id = @username\r\n             GROUP  BY student_id) A \r\n         ON Q.student_id = A.student_id \r\n       JOIN (SELECT student_id, \r\n                    SUM(obtained_marks) AS obtained_marks_sum3, \r\n                    SUM(total_marks)   AS total_marks_sum3 \r\n             FROM   Sessionals \r\n             WHERE course_id = @course AND faculty_id = @username\r\n             GROUP  BY student_id) S \r\n         ON Q.student_id = S.student_id \r\n       JOIN (SELECT student_id, \r\n                    SUM(obtained_marks) AS obtained_marks_sum4, \r\n                    SUM(total_marks)   AS total_marks_sum4 \r\n             FROM   project \r\n             WHERE course_id = @course AND faculty_id = @username\r\n             GROUP  BY student_id) P \r\n         ON Q.student_id = P.student_id \r\n       JOIN (SELECT student_id, \r\n                    SUM(obtained_marks) AS obtained_marks_sum5, \r\n                    SUM(total_marks)   AS total_marks_sum5 \r\n             FROM   Final \r\n             WHERE course_id = @course AND faculty_id = @username\r\n             GROUP  BY student_id) F \r\n         ON Q.student_id = F.student_id \r\n       JOIN students Se \r\n         ON Se.Roll_num = Q.student_id \r\nWHERE  Se.section = @section;\r\n";
        int quiz_w, assignment_w, sessional_w, project_w, final_w;

        string course = "";
        string previouscourse = "";
        string section = "";
        string previoussection = "";

        if (!IsPostBack)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query1, connection);
                command.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = command.ExecuteReader();

                DropDownList1.DataSource = reader;
                DropDownList1.DataTextField = "course_id";
                DropDownList1.DataValueField = "course_id";
                DropDownList1.DataBind();
                reader.Close();


                course = DropDownList1.SelectedValue;
                Session["course_grades"] = course;


                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@username", username);
                command2.Parameters.AddWithValue("@course", course);
                SqlDataReader reader2 = command2.ExecuteReader();

                DropDownList2.DataSource = reader2;
                DropDownList2.DataTextField = "section";
                DropDownList2.DataValueField = "section";
                DropDownList2.DataBind();
                reader2.Close();

                section = DropDownList2.SelectedValue;
                Session["section"] = section;


                SqlCommand command3 = new SqlCommand(query3, connection);
                command3.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                quiz_w = Convert.ToInt32(command3.ExecuteScalar().ToString());


                SqlCommand command4 = new SqlCommand(query4, connection);
                command4.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                assignment_w = Convert.ToInt32(command4.ExecuteScalar().ToString());



                SqlCommand command5 = new SqlCommand(query5, connection);
                command5.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                sessional_w = Convert.ToInt32(command5.ExecuteScalar().ToString());

                SqlCommand command6 = new SqlCommand(query6, connection);
                command6.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                project_w = Convert.ToInt32(command6.ExecuteScalar().ToString());

                SqlCommand command7 = new SqlCommand(query7, connection);
                command7.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                final_w = Convert.ToInt32(command7.ExecuteScalar().ToString());

                SqlCommand comm3 = new SqlCommand(query_without, connection);
                comm3.Parameters.AddWithValue("@section", section);
                comm3.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                comm3.Parameters.AddWithValue("@username", username);

                SqlDataReader reader3 = comm3.ExecuteReader();
                DataTable dt1 = new DataTable();

                dt1.Columns.Add("Roll number", typeof(string));
                dt1.Columns.Add("QUIZ", typeof(string));
                dt1.Columns.Add("QUIZ TOTAL", typeof(string));
                dt1.Columns.Add("ASSIGNMENT", typeof(string));
                dt1.Columns.Add("ASSIGNMENT TOTAL", typeof(string));
                dt1.Columns.Add("SESSIONAL", typeof(string));
                dt1.Columns.Add("SESSIONAL TOTAL", typeof(string));
                dt1.Columns.Add("PROJECT", typeof(string));
                dt1.Columns.Add("PROJECT TOTAL", typeof(string));
                dt1.Columns.Add("FINAL", typeof(string));
                dt1.Columns.Add("FINAL TOTAL", typeof(string));


                while (reader3.Read())
                {

                    DataRow row = dt1.NewRow();
                    row["Roll number"] = reader3["student_id"].ToString();
                    row["QUIZ"] = reader3["obtained_marks_sum1"].ToString();
                    row["QUIZ TOTAL"] = reader3["total_marks_sum1"].ToString();
                    row["ASSIGNMENT"] = reader3["obtained_marks_sum2"].ToString();
                    row["ASSIGNMENT TOTAL"] = reader3["total_marks_sum2"].ToString();
                    row["SESSIONAL"] = reader3["obtained_marks_sum3"].ToString();
                    row["SESSIONAL TOTAL"] = reader3["total_marks_sum3"].ToString();
                    row["PROJECT"] = reader3["obtained_marks_sum4"].ToString();
                    row["PROJECT TOTAL"] = reader3["total_marks_sum4"].ToString();
                    row["FINAL"] = reader3["obtained_marks_sum5"].ToString();
                    row["FINAL TOTAL"] = reader3["total_marks_sum5"].ToString();

                    // Add the row to the DataTable
                    dt1.Rows.Add(row);
                }

                GridView1.DataSource = dt1;
                GridView1.DataBind();
                reader3.Close();

                int[] absolutes = new int[GridView1.Rows.Count];

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    // Access the first cell of the i - th row
                    int obt_quiz = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
                    int total_quiz = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);

                    int obt_assignment = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                    int total_assignment = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);

                    int obt_sessional = Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
                    int total_sessional = Convert.ToInt32(GridView1.Rows[i].Cells[6].Text);

                    int obt_project = Convert.ToInt32(GridView1.Rows[i].Cells[7].Text);
                    int total_project = Convert.ToInt32(GridView1.Rows[i].Cells[8].Text);

                    int obt_final = Convert.ToInt32(GridView1.Rows[i].Cells[9].Text);
                    int total_final = Convert.ToInt32(GridView1.Rows[i].Cells[10].Text);

                    double a = ((obt_quiz / (double)total_quiz) * quiz_w);
                    double b = ((obt_assignment / (double)total_assignment) * assignment_w);
                    double c = ((obt_sessional / (double)total_sessional) * sessional_w);
                    double d = ((obt_project / (double)total_project) * project_w);
                    double f = ((obt_final / (double)total_final) * final_w);

                    absolutes[i] = Convert.ToInt32(a + b + c + d + f);
                    Session["absolutes" + i.ToString()] = absolutes[i].ToString();
                }

            }
        }

        else
        {
            previouscourse = (string)Session["course_grades"];
            previoussection = (string)Session["section"];
            course = DropDownList1.SelectedValue;
            section = DropDownList2.SelectedValue;
            Session["course_grades"] = DropDownList1.SelectedValue;
            Session["section"] = section;

            if (previouscourse != course || section != previoussection)
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@username", username);
                    command2.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    SqlDataReader reader2 = command2.ExecuteReader();

                    DropDownList2.DataSource = reader2;
                    DropDownList2.DataTextField = "section";
                    DropDownList2.DataValueField = "section";
                    DropDownList2.DataBind();
                    reader2.Close();


                    SqlCommand command3 = new SqlCommand(query3, connection);
                    command3.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    quiz_w = Convert.ToInt32(command3.ExecuteScalar().ToString());


                    SqlCommand command4 = new SqlCommand(query4, connection);
                    command4.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    assignment_w = Convert.ToInt32(command4.ExecuteScalar().ToString());


                    SqlCommand command5 = new SqlCommand(query5, connection);
                    command5.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    sessional_w = Convert.ToInt32(command5.ExecuteScalar().ToString());

                    SqlCommand command6 = new SqlCommand(query6, connection);
                    command6.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    project_w = Convert.ToInt32(command6.ExecuteScalar().ToString());

                    SqlCommand command7 = new SqlCommand(query7, connection);
                    command7.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    final_w = Convert.ToInt32(command7.ExecuteScalar().ToString());



                    SqlCommand comm3 = new SqlCommand(query_without, connection);
                    comm3.Parameters.AddWithValue("@section", section);
                    comm3.Parameters.AddWithValue("@course", DropDownList1.SelectedValue);
                    comm3.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader3 = comm3.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(reader3);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();


                    int[] absolutes = new int[GridView1.Rows.Count];

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        int obt_quiz = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
                        int total_quiz = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);

                        int obt_assignment = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                        int total_assignment = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);

                        int obt_sessional = Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
                        int total_sessional = Convert.ToInt32(GridView1.Rows[i].Cells[6].Text);

                        int obt_project = Convert.ToInt32(GridView1.Rows[i].Cells[7].Text);
                        int total_project = Convert.ToInt32(GridView1.Rows[i].Cells[8].Text);

                        int obt_final = Convert.ToInt32(GridView1.Rows[i].Cells[9].Text);
                        int total_final = Convert.ToInt32(GridView1.Rows[i].Cells[10].Text);

                        double a = ((obt_quiz / (double)total_quiz) * quiz_w);
                        double b = ((obt_assignment / (double)total_assignment) * assignment_w);
                        double c = ((obt_sessional / (double)total_sessional) * sessional_w);
                        double d = ((obt_project / (double)total_project) * project_w);
                        double f = ((obt_final / (double)total_final) * final_w);

                        absolutes[i] = Convert.ToInt32(a + b + c + d + f);
                        Session["absolutes" + i.ToString()] = absolutes[i].ToString();
                        Session["absolutes" + i.ToString()] = absolutes[i].ToString();
                    }

                    connection.Close();

                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("FHome.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("Fassign.aspx");
    }


    protected void GeneratePDF_Click(object sender, EventArgs e)
    {
        // Create a new PDF document
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

        // Create a new MemoryStream to hold the PDF document
        MemoryStream memStream = new MemoryStream();

        // Create a new PdfWriter to write the PDF document to the MemoryStream
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memStream);

        // Open the PDF document
        pdfDoc.Open();

        // Add a title to the PDF document
        Paragraph title = new Paragraph("Evaluation Report\n\n\n");
        title.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(title);

        // Add a table to the PDF document
        PdfPTable pdfTable = new PdfPTable(GridView1.HeaderRow.Cells.Count);
        pdfTable.WidthPercentage = 100;

        // Add table headers
        foreach (TableCell headerCell in GridView1.HeaderRow.Cells)
        {
            pdfTable.AddCell(new PdfPCell(new Phrase(headerCell.Text)));
        }

        // Add table rows
        foreach (GridViewRow gridViewRow in GridView1.Rows)
        {
            foreach (TableCell tableCell in gridViewRow.Cells)
            {
                pdfTable.AddCell(new PdfPCell(new Phrase(tableCell.Text)));
            }
        }

        pdfDoc.Add(pdfTable);

        pdfDoc.Close();
        writer.Close();

        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment;filename=EvaluationReport.pdf");
        Response.BinaryWrite(memStream.ToArray());
        Response.End();
    }



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}