 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
 
public partial class Aalot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string query1 = "select faculty.username,users.name from faculty join users on users.username= faculty.username";
        string query2 = "select ID,name from courses";
        string query3 = "select name from sections";

        if (!IsPostBack)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                DropDownList1.Items.Clear();
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["username"].ToString();
                            string name = reader["name"].ToString();
                            string optionText = id + " - " + name;
                            string optionValue = id;
                            ListItem item = new ListItem(optionText, optionValue);
                            DropDownList1.Items.Add(item);
                        }
                        reader.Close();
                    }
                }
                Session["faculty_alot"] = DropDownList1.SelectedValue;
                connection.Close();


                connection.Open();
                DropDownList2.Items.Clear();
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["ID"].ToString();
                            string name = reader["name"].ToString();
                            string optionText = id + " - " + name;
                            string optionValue = id;
                            ListItem item = new ListItem(optionText, optionValue);
                            DropDownList2.Items.Add(item);
                        }
                    }
                }
                Session["course_alot"]= DropDownList2.SelectedValue;
                connection.Close();

                connection.Open();
                DropDownList3.Items.Clear();
                using (SqlCommand command = new SqlCommand(query3, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            string optionText = name;
                            string optionValue = name;
                            ListItem item = new ListItem(optionText, optionValue);
                            DropDownList3.Items.Add(item);
                        }
                    }
                }
                Session["section_alot"] = DropDownList3.SelectedValue;
                connection.Close();



            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AHome.aspx");

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";

        string faculty_ID = (string)Session["faculty_alot"];
        string section_ID = (string)Session["section_alot"];
        string course_ID = (string)Session["course_alot"];
        string query1 = "select count(*) from teaches where faculty_id = @faculty_ID";
        int count = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
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




            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@faculty_id", faculty_ID);
            count = Convert.ToInt32(command1.ExecuteScalar().ToString());
            if(count<3)
            {
                string query2 = "INSERT INTO teaches (faculty_ID, section, course_ID) VALUES ('" + faculty_ID + "','" + section_ID + "','" + course_ID + "')";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.ExecuteNonQuery();
                command2.Dispose();
                MessageBox.Show("          SUCCESSFULLY ALOTTED!          ");
                connection.Close();
            }
            else
            {
                MessageBox.Show("          THIS TEACHER IS ALREADY TEACHING 3 COURSES!          ");
                connection.Close();
            }

        }



    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}