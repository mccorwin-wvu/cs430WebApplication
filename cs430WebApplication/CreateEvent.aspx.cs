using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace cs430WebApplication
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        private int user_id = 0;
        private MySqlConnection conn;



        protected void Page_Load(object sender, EventArgs e)
        {

            user_id = (int)Session["user_id"];

        }

       

        protected void Submit_Event(object sender, EventArgs e)
        {


            conn = ServerCom.serverCheck();


            String date = eventDate.Value;

                

            submitEvent(eventName.Value, date, eventLocation.Value, tags.Value, eventDes.Value, user_id);
            


            Server.Transfer("CreateEvent.aspx");

            conn.Close();





        }



        private bool submitEvent(string name, string dt, string location, string tags, string des, int user_id)
        {
            string query = $"INSERT INTO Events ( event_name, event_dt, event_location, event_tags, event_des, user_id) VALUES ('{name}','{dt}','{location}','{tags}','{des}','{user_id}');";

            try
            {
                if (ServerCom.OpenConnection(conn))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
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

    }





    }
