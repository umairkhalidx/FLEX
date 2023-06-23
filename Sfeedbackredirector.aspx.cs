using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sfeedbackredirector : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query1 = "select C.ID,C.name from students S join studies st on st.student_ID = S.Roll_num join courses C on C.ID = st.course_ID where S.Roll_num = @username ";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@username", username);
       
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(reader1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            connection.Close();
        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int id;
            if (int.TryParse(DataBinder.Eval(e.Row.DataItem, "ID").ToString(), out id))
            {
                HyperLink hl = new HyperLink();
                hl.NavigateUrl = "newpage.aspx?id=" + id.ToString();
                hl.Text = e.Row.Cells[0].Text;
                e.Row.Cells[0].Controls.Clear();
                e.Row.Cells[0].Controls.Add(hl);
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string cellValue = e.Row.Cells[1].Text;
            Session["MyVariable" + e.Row.RowIndex.ToString()] = cellValue;
        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SHome.aspx");
    }
}