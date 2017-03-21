using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace cs430WebApplication
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            serverCheck();

            

           


        }

       
       private String server;
       private String database;
       private String uid;
       private String password;
        private MySqlConnection conn;

        //Response.Write("button clicked");
        // Register(firstName.Value,lastName.Value,email.Value,confirmPassword.Value,tagBox.Value,School.Value);
        protected void Submit_Click(object sender, EventArgs e)

        {

            Register(firstName.Value, lastName.Value, email.Value, confirmPassword.Value, tagBox.Value, School.Value);
            Response.Redirect("Login.aspx");

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }



        public void serverCheck()


        {

            server = "us-cdbr-azure-east2-d.cloudapp.net";
            database = "cs430dp";
            uid = "bde01a074310a7";
            password = "2316fdf1";

            string connString;
            connString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            conn = new MySqlConnection(connString);
            using (conn)
            {
                conn.Open();
                Response.Write("connected");
            }

        }



        public bool Register(string firstName, string lastName, string email, string password, string tags, string school)
        {
            string query = $"INSERT INTO users ( email, first_name, last_name, password, tags, school) VALUES ('{email}','{firstName}','{lastName}','{password}','{tags}','{school}');";
            Response.Write("registering");

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query,conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
                }

                else
                {
                    conn.Close();
                    return false;

                }

            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }

        }

        public bool IsLogin(string email, string pass)
        {



            string query = $"SELECT * users FROM useres WHERE email= '{email}' AND password= '{pass}';";


            try
            {
                if (OpenConnection())
                {

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        conn.Close();
                        return true;

                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }

            catch(Exception ex) {


                conn.Close();
                return false;

            }







        }





        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;


            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert connection to server failed!", true);
                        break;
                    case 1045:
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Server Username or password is incorrect!", true);
                        break;

                }
                return false;
            }
        }

        
    }
}