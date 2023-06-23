using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string username = (string)Session["username"];
        string query7 = "select name from admin F join users U on U.username = F.username AND F.username = @username";
        string query8 = "select DOB from admin F join users U on U.username = F.username AND F.username = @username";
        string query9 = "select blood_group from admin F join users U on U.username = F.username AND F.username = @username";
        string query10 = "select gender from admin F join users U on U.username = F.username AND F.username = @username";
        string query11 = "select CNIC from admin F join users U on U.username = F.username AND F.username = @username";
        string query12 = "select nationality from admin F join users U on U.username = F.username AND F.username = @username";
        string query13 = "select email from admin F join users U on U.username = F.username AND F.username = @username";
        string query14 = "select contact from admin F join users U on U.username = F.username AND F.username = @username";
        string name, DOB, blood, gender, cnic, nationality, email, contact;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            

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
        Response.Redirect("AHome.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("Aoffer.aspx");

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("Aassign.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Server.Transfer("Asection.aspx");
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Server.Transfer("Aalot.aspx");
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("LogIn.aspx");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Server.Transfer("Areport.aspx");
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        Server.Transfer("Asignstudent.aspx");
    }

    protected void Button9_Click(object sender, EventArgs e)
    {

        Server.Transfer("Asignteacher.aspx");
    }
}