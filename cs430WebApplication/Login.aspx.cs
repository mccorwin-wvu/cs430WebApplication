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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            serverCheck();

        }

        private String server;
        private String database;
        private String uid;
        private String password;
        private int user_id = 0;
        private String first_name = "";
        private String last_name = "";
        private String user_email = "";
        private String tags = "";

        private MySqlConnection conn;


        protected void Submit_Click(object sender, EventArgs e)
        {



            if (IsLogin(em.Value, pass.Value))
            {


                Session["user_id"] = user_id;
                Session["first_name"] = first_name;
                Session["last_name"] = last_name;
                Session["user_email"] = user_email;
                Session["tags"] = tags;

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



            string query = $"SELECT * FROM users WHERE email = '{email}' AND password= '{pass}';";
            

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

            catch (Exception ex)
            {


                conn.Close();
                return false;

            }







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
                Response.Write("Connected");
            }

        }

        
    }


}