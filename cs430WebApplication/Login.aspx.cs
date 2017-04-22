using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace cs430WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        private String server;
        private String database;
        private String uid;
        private String password;
        private String port;
        private int user_id = 0;
        private String first_name = "";
        private String last_name = "";
        private String user_email = "";
        private String school = "";
        private String tags = "";
        private int priv = -1;

        private MySqlConnection conn;


        protected void RegisterPage(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");

        }

        protected void LoginRequest(object sender, EventArgs e)
        {
            serverCheck();


            if (IsLogin(loginEmail.Value, loginPassword.Value))
            {


                Session["user_id"] = user_id;
                Session["first_name"] = first_name;
                Session["last_name"] = last_name;
                Session["user_email"] = user_email;
                Session["tags"] = tags;
                Session["school"] = school;
                Session["priv"] = priv;


                conn.Close();

                Server.Transfer("UserHomePage.aspx");



                


            }


            Response.Redirect("Login.aspx");

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


        

        public bool IsLogin(string email, string pass)
        {



            string query = $"SELECT * FROM Users WHERE email = '{email}' AND password= '{pass}';";
            

            try
            {
                if (OpenConnection())
                {

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        

                        user_id = reader.GetInt32(0);
                        first_name = reader.GetString(2);
                        last_name = reader.GetString(3);
                        user_email = reader.GetString(1);
                        tags = reader.GetString(5);
                        school = reader.GetString(6);
                        priv = reader.GetInt32(7);




                       
                        reader.Close();
                      
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

            catch (Exception ex)
            {


                conn.Close();
                return false;

            }







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

        
    }


}