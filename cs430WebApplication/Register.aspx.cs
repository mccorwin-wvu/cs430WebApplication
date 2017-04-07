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

          

            

           


        }

       
       private String server;
       private String database;
       private String uid;
       private String password;
        private String port;
        private MySqlConnection conn;

        //Response.Write("button clicked");
        // Register(firstName.Value,lastName.Value,email.Value,confirmPassword.Value,tagBox.Value,School.Value);
        protected void Submit_Click(object sender, EventArgs e)

        {
            serverCheck();

            Register(firstName.Value, lastName.Value, email.Value, confirmPassword.Value, tagBox.Value, School.Value);
            conn.Close();
            Response.Redirect("Login.aspx");

        }

        

        public void serverCheck()


        {

            server = "db4free.net";
            database = "cs430dp";
            uid = "mccorwin";
            password = "corwin445";
            port = "3307";

            string connString;
            connString = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={password};";
            conn = new MySqlConnection(connString);
            using (conn)
            {
                conn.Open();
                Response.Write("Connected");
            }

        }



        public bool Register(string firstName, string lastName, string email, string password, string tags, string school)
        {
            string query = $"INSERT INTO Users ( email, first_name, last_name, password, tags, school) VALUES ('{email}','{firstName}','{lastName}','{password}','{tags}','{school}');";

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
            catch (Exception ex)
            {
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