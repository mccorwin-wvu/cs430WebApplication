using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;
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

            String[] splitdt = date.Split('T');

            String[] newDate = splitdt[0].Split('-');

            String finalDate = newDate[1] + "-" + newDate[2] + "-" + newDate[0];

            String time = DateTime.ParseExact(splitdt[1], "HH:mm", CultureInfo.CurrentCulture).ToString("h:mm tt");



            submitEvent(eventName.Value, finalDate, time, eventLocation.Value, tags.Value, eventDes.Value, user_id);
            


            Server.Transfer("CreateEvent.aspx");

            conn.Close();





        }



        private bool submitEvent(string name, string dt, string time, string location, string tags, string des, int user_id)
        {
            string query = $"INSERT INTO Events ( event_name, event_dt, event_time, event_location, event_tags, event_des, user_id) VALUES ('{name}','{dt}','{time}','{location}','{tags}','{des}','{user_id}');";

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
