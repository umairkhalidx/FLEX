using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {



        Server.Transfer("LogIn.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string username1, password, name, dob, bloodgroup, gender, cnic, nationality, email, contact, campus;
        username1 = TextBox1.Text;
        password = TextBox2.Text;
        name = TextBox3.Text;
        dob = TextBox4.Text;
        bloodgroup = TextBox5.Text;
        gender = TextBox6.Text;
        cnic= TextBox7.Text;
        nationality = TextBox8.Text;
        email = TextBox9.Text;
        contact = TextBox10.Text;
        campus = TextBox11.Text;
        string role = "admin";
        //DateTime dateOfBirth = DateTime.ParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //string sqlDateOfBirth = dateOfBirth.ToString("yyyy-MM-dd");

        SqlConnection connection = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        
        string query = "INSERT INTO users (username, password,role, name, DOB, blood_group, gender, CNIC, nationality, email, contact, campus) VALUES (@username, @password, @role,@name, @dob, @bloodgroup, @gender, @cnic, @nationality, @email, @contact, @campus)";

        string query2 = "INSERT INTO admin (username) VALUES (@username)";

        using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username1);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@dob", dob);
                command.Parameters.AddWithValue("@bloodgroup", bloodgroup);
                command.Parameters.AddWithValue("@gender", gender);
                command.Parameters.AddWithValue("@cnic", cnic);
                command.Parameters.AddWithValue("@nationality", nationality);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@contact", contact);
                command.Parameters.AddWithValue("@campus", campus);
                
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }

        using (SqlCommand command1 = new SqlCommand(query2, connection))
        {
            command1.Parameters.AddWithValue("@username", username1);
            
            connection.Open();
            int rowsAffected = command1.ExecuteNonQuery();
            
        }



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



        MessageBox.Show("          SUCCESSFULLY ADDED A NEW ADMIN!          ");
        Response.Redirect("LogIn.aspx");
    
    }
}