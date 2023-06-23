using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Asignstudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AHome.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string username1, password, name, dob, bloodgroup, gender, cnic, nationality, email, contact, campus;
        string father, address, regno, status, semester, degree, batch, city, country;
        username1= TextBox1.Text;
        password = TextBox2.Text;
        name = TextBox3.Text;
        dob = TextBox4.Text;
        bloodgroup = TextBox5.Text;
        gender = TextBox6.Text;
        cnic = TextBox7.Text;
        nationality = TextBox8.Text;
        email = TextBox9.Text;
        contact = TextBox10.Text;
        campus = TextBox11.Text;
        //roll number
        father= TextBox12.Text;
        address= TextBox13.Text;
        regno= TextBox14.Text;
        status = "current";
        semester = TextBox15.Text;
        degree = TextBox16.Text;
        batch = TextBox17.Text;
        city = TextBox18.Text;
        country = TextBox19.Text;

        string role = "student";
        
        SqlConnection connection = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");

        string query = "INSERT INTO users (username, password,role, name, DOB, blood_group, gender, CNIC, nationality, email, contact, campus) VALUES (@username, @password, @role,@name, @dob, @bloodgroup, @gender, @cnic, @nationality, @email, @contact, @campus)";

        string query2 = "INSERT INTO students (Roll_num,father_name,address,reg_no,status,semester,degree,batch,city,country) VALUES (@roll_num,@father,@address,@regno,@status,@semester,@degree,@batch,@city,@country)";

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
            command1.Parameters.AddWithValue("@roll_num", username1);
            command1.Parameters.AddWithValue("@father", father);
            command1.Parameters.AddWithValue("@address", address);
            command1.Parameters.AddWithValue("@regno", regno);
            command1.Parameters.AddWithValue("@status", status);
            command1.Parameters.AddWithValue("@semester", semester);
            command1.Parameters.AddWithValue("@degree", degree);
            command1.Parameters.AddWithValue("@batch", batch);
            command1.Parameters.AddWithValue("@city", city);
            command1.Parameters.AddWithValue("@country", country);
            
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




        connection.Close();
        MessageBox.Show("          SUCCESSFULLY ADDED A NEW STUDENT!          ");
        Response.Redirect("AHome.aspx");

    }
}