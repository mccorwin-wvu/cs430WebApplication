using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace cs430WebApplication
{

    public partial class WebForm3 : System.Web.UI.Page
    {

        private String userPassword;
        private int user_id = 0;
        private String first_name = "";
        private String last_name = "";
        private String user_email = "";
        private String school = "";
        private String tags = "";
        private int priv = -1;





        protected void Page_Load(object sender, EventArgs e)
        {

            first_name = (String)Session["first_name"];
            userPassword = (String)Session["password"];
            user_id = (int)Session["user_id"];
            last_name = (String)Session["last_name"];
            user_email = (String)Session["user_email"];
            school = (String)Session["school"];
            tags = (String)Session["tags"];
            priv = (int)Session["priv"];

            helpTagBox.InnerText = "Current Tags: "+tags;

            if(priv == 0)
            {
                CreateEvent.Enabled = false;
                CreateEvent.CssClass = "buttonLogDisabled";
            }

            

            


        }

        private String server;
        private String database;
        private String uid;
        private String password;
        private String port;

        private MySqlConnection conn;

        protected void SubmitNewTags(object sender, EventArgs e)


        {
            
            serverCheck();

            helpTagBox.InnerText = "Current Tags: " + tagBox.Value;

            changeTags(user_id, tagBox.Value);

            

            





        }

        protected void CreateEventPage(object sender, EventArgs e) {

            Session["user_id"] = user_id;
            
            

            
            Response.Redirect("CreateEvent.aspx");






        }


        



        private String changeTags(int user_id, string newTags)
        {



            
            string query = $" UPDATE Users SET tags = '{newTags}' WHERE user_id = '{user_id}';";

         


            try
            {
                if (OpenConnection())
                {

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    return newTags;
                }

                else
                {
                    
                    conn.Close();
                    return "";
                }
                
                
            }

            catch (Exception ex)
            {


                conn.Close();
                return "";

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