using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class coursedetail6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string course = (string)Session["MyVariable5"];
        string username = (string)Session["username"];
        string connectionString = "Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";
        string query1 = "select U.name from students S\r\njoin teaches T on T.section = S.section\r\njoin courses C on C.ID = T.course_ID\r\njoin faculty F on F.username = T.faculty_ID\r\njoin users U on U.username = F.username\r\nwhere S.roll_num = @username and C.ID = @MyVariable5\r\n";
        string query2 = "select F.subject from students S\r\njoin teaches T on T.section = S.section\r\njoin courses C on C.ID = T.course_ID\r\njoin faculty F on F.username = T.faculty_ID\r\njoin users U on U.username = F.username\r\nwhere S.roll_num = @username and C.ID = @MyVariable5\r\n";
        string query4 = "select F.room_number from students S\r\njoin teaches T on T.section = S.section\r\njoin courses C on C.ID = T.course_ID\r\njoin faculty F on F.username = T.faculty_ID\r\njoin users U on U.username = F.username\r\nwhere S.roll_num = @username and C.ID = @MyVariable5\r\n";
        string query5 = "select F.school_year from students S\r\njoin teaches T on T.section = S.section\r\njoin courses C on C.ID = T.course_ID\r\njoin faculty F on F.username = T.faculty_ID\r\njoin users U on U.username = F.username\r\nwhere S.roll_num = @username and C.ID = @MyVariable5\r\n";
        string query6 = "select F.username from students S\r\njoin teaches T on T.section = S.section\r\njoin courses C on C.ID = T.course_ID\r\njoin faculty F on F.username = T.faculty_ID\r\njoin users U on U.username = F.username\r\nwhere S.roll_num = @username and C.ID = @MyVariable0\r\n";

        string name, subject, room, schoolyear,ID;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@username", username);
            command1.Parameters.AddWithValue("@MyVariable5", course);
            connection.Open();
            name = command1.ExecuteScalar().ToString();


            SqlCommand command2 = new SqlCommand(query2, connection);
            command2.Parameters.AddWithValue("@username", username);
            command2.Parameters.AddWithValue("@MyVariable5", course);
            subject = command2.ExecuteScalar().ToString();



            SqlCommand command4 = new SqlCommand(query4, connection);
            command4.Parameters.AddWithValue("@username", username);
            command4.Parameters.AddWithValue("@MyVariable5", course);
            room = command4.ExecuteScalar().ToString();


            SqlCommand command5 = new SqlCommand(query5, connection);
            command5.Parameters.AddWithValue("@username", username);
            command5.Parameters.AddWithValue("@MyVariable5", course);
            schoolyear = command5.ExecuteScalar().ToString();


            SqlCommand command6 = new SqlCommand(query6, connection);
            command6.Parameters.AddWithValue("@username", username);
            command6.Parameters.AddWithValue("@MyVariable0", course);
            ID = command6.ExecuteScalar().ToString();


        }

        if (!string.IsNullOrEmpty(name))
        {
            Label15.Text = name.ToString();
        }

        if (!string.IsNullOrEmpty(subject))
        {
            Label16.Text = subject.ToString();
        }


        if (!string.IsNullOrEmpty(room))
        {
            Label18.Text = room.ToString();
        }

        if (!string.IsNullOrEmpty(schoolyear))
        {
            Label19.Text = schoolyear.ToString();
        }

        if (!string.IsNullOrEmpty(username))
        {
            Label21.Text = ID.ToString();
        }

        int obtained = 0;

        //table1
        string row1 = Request.Form["1row1"];


        if (row1 == "Option1 1") obtained += 1;
        if (row1 == "Option1 2") obtained += 2;
        if (row1 == "Option1 3") obtained += 3;
        if (row1 == "Option1 4") obtained += 4;
        if (row1 == "Option1 5") obtained += 5;

        string row2 = Request.Form["1row2"];

        if (row2 == "Option1 1") obtained += 1;
        if (row2 == "Option1 2") obtained += 2;
        if (row2 == "Option1 3") obtained += 3;
        if (row2 == "Option1 4") obtained += 4;
        if (row2 == "Option1 5") obtained += 5;

        string row3 = Request.Form["1row3"];

        if (row3 == "Option1 1") obtained += 1;
        if (row3 == "Option1 2") obtained += 2;
        if (row3 == "Option1 3") obtained += 3;
        if (row3 == "Option1 4") obtained += 4;
        if (row3 == "Option1 5") obtained += 5;


        string row4 = Request.Form["1row4"];

        if (row4 == "Option1 1") obtained += 1;
        if (row4 == "Option1 2") obtained += 2;
        if (row4 == "Option1 3") obtained += 3;
        if (row4 == "Option1 4") obtained += 4;
        if (row4 == "Option1 5") obtained += 5;


        string row5 = Request.Form["1row5"];

        if (row5 == "Option1 1") obtained += 1;
        if (row5 == "Option1 2") obtained += 2;
        if (row5 == "Option1 3") obtained += 3;
        if (row5 == "Option1 4") obtained += 4;
        if (row5 == "Option1 5") obtained += 5;

        //table2
        row1 = Request.Form["2row1"];


        if (row1 == "Option2 1") obtained += 1;
        if (row1 == "Option2 2") obtained += 2;
        if (row1 == "Option2 3") obtained += 3;
        if (row1 == "Option2 4") obtained += 4;
        if (row1 == "Option2 5") obtained += 5;

        row2 = Request.Form["2row2"];

        if (row2 == "Option2 1") obtained += 1;
        if (row2 == "Option2 2") obtained += 2;
        if (row2 == "Option2 3") obtained += 3;
        if (row2 == "Option2 4") obtained += 4;
        if (row2 == "Option2 5") obtained += 5;

        row3 = Request.Form["2row3"];

        if (row3 == "Option2 1") obtained += 1;
        if (row3 == "Option2 2") obtained += 2;
        if (row3 == "Option2 3") obtained += 3;
        if (row3 == "Option2 4") obtained += 4;
        if (row3 == "Option2 5") obtained += 5;


        row4 = Request.Form["2row4"];

        if (row4 == "Option2 1") obtained += 1;
        if (row4 == "Option2 2") obtained += 2;
        if (row4 == "Option2 3") obtained += 3;
        if (row4 == "Option2 4") obtained += 4;
        if (row4 == "Option2 5") obtained += 5;


        row5 = Request.Form["2row5"];

        if (row5 == "Option2 1") obtained += 1;
        if (row5 == "Option2 2") obtained += 2;
        if (row5 == "Option2 3") obtained += 3;
        if (row5 == "Option2 4") obtained += 4;
        if (row5 == "Option2 5") obtained += 5;


        string row6 = Request.Form["2row6"];

        if (row6 == "Option2 1") obtained += 1;
        if (row6 == "Option2 2") obtained += 2;
        if (row6 == "Option2 3") obtained += 3;
        if (row6 == "Option2 4") obtained += 4;
        if (row6 == "Option2 5") obtained += 5;


        //table3
        row1 = Request.Form["3row1"];


        if (row1 == "Option3 1") obtained += 1;
        if (row1 == "Option3 2") obtained += 2;
        if (row1 == "Option3 3") obtained += 3;
        if (row1 == "Option3 4") obtained += 4;
        if (row1 == "Option3 5") obtained += 5;

        row2 = Request.Form["3row2"];

        if (row2 == "Option3 1") obtained += 1;
        if (row2 == "Option3 2") obtained += 2;
        if (row2 == "Option3 3") obtained += 3;
        if (row2 == "Option3 4") obtained += 4;
        if (row2 == "Option3 5") obtained += 5;

        row3 = Request.Form["3row3"];

        if (row3 == "Option3 1") obtained += 1;
        if (row3 == "Option3 2") obtained += 2;
        if (row3 == "Option3 3") obtained += 3;
        if (row3 == "Option3 4") obtained += 4;
        if (row3 == "Option3 5") obtained += 5;


        row4 = Request.Form["3row4"];

        if (row4 == "Option3 1") obtained += 1;
        if (row4 == "Option3 2") obtained += 2;
        if (row4 == "Option3 3") obtained += 3;
        if (row4 == "Option3 4") obtained += 4;
        if (row4 == "Option3 5") obtained += 5;


        row5 = Request.Form["3row5"];

        if (row5 == "Option3 1") obtained += 1;
        if (row5 == "Option3 2") obtained += 2;
        if (row5 == "Option3 3") obtained += 3;
        if (row5 == "Option3 4") obtained += 4;
        if (row5 == "Option3 5") obtained += 5;


        //table4
        row1 = Request.Form["4row1"];


        if (row1 == "Option4 1") obtained += 1;
        if (row1 == "Option4 2") obtained += 2;
        if (row1 == "Option4 3") obtained += 3;
        if (row1 == "Option4 4") obtained += 4;
        if (row1 == "Option4 5") obtained += 5;

        row2 = Request.Form["4row2"];

        if (row2 == "Option4 1") obtained += 1;
        if (row2 == "Option4 2") obtained += 2;
        if (row2 == "Option4 3") obtained += 3;
        if (row2 == "Option4 4") obtained += 4;
        if (row2 == "Option4 5") obtained += 5;

        row3 = Request.Form["4row3"];

        if (row3 == "Option4 1") obtained += 1;
        if (row3 == "Option4 2") obtained += 2;
        if (row3 == "Option4 3") obtained += 3;
        if (row3 == "Option4 4") obtained += 4;
        if (row3 == "Option4 5") obtained += 5;


        row4 = Request.Form["4row4"];

        if (row4 == "Option4 1") obtained += 1;
        if (row4 == "Option4 2") obtained += 2;
        if (row4 == "Option4 3") obtained += 3;
        if (row4 == "Option4 4") obtained += 4;
        if (row4 == "Option4 5") obtained += 5;


        double percent = ((double)obtained / 100) * 100;
        Label20.Text = percent.ToString();


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=ALI\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"); //Connection String
        conn.Open();
        string percentage = Label20.Text;
        string comment = TextBox7.Text;

        int priority = 0;
        string username = (string)Session["username"];
        string query_b = "select top 1 priority from usersforlog order by priority desc";
        SqlCommand command_b = new SqlCommand(query_b, conn);
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

        using (SqlCommand command_a = new SqlCommand(query_a, conn))
        {
            command_a.Parameters.AddWithValue("@username", username);
            command_a.Parameters.AddWithValue("@priority", priority);


            int rowsAffected = command_a.ExecuteNonQuery();

        }


        string course = (string)Session["MyVariable5"];
        string ID = Label21.Text;
        string query = "Insert into feedback (student_ID,course_ID,faculty_ID,description,percentage) values ('" + username + "','" + course + "','" + ID + "','" + comment + "' ,'" + percentage + "')";
        SqlCommand comm = new SqlCommand(query, conn);
        comm.ExecuteNonQuery();
        comm.Dispose();

        conn.Close();
        Response.Redirect("SHome.aspx");

    }
}