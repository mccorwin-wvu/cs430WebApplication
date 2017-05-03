using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace cs430WebApplication
{
    public partial class WebForm5 : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            String[] head = { "Event Name", "Event Date", "Event Time", "Event Location", "Event Tags", "Event Description" };
            if (!this.IsPostBack)
            {
                //Populating a DataTable from database.
                DataTable dt = this.GetData();

                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                //Table start.
                html.Append("<table border = '1'>");

                //Building the Header row.
                html.Append("<tr>");
                foreach (String column in head)
                {
                    html.Append("<th>");
                    html.Append(column);
                    html.Append("</th>");
                }
                html.Append("</tr>");

                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }

                //Table end.
                html.Append("</table>");
                

                //Append the HTML string to Placeholder.
                events.Controls.Add(new Literal { Text = html.ToString() });
            }







        }
       


        private DataTable GetData()
        {
            String server;
            String database;
            String uid;
            String password;
            String port;

            MySqlConnection conn;


            server = "db4free.net";
            database = "cs430dp";
            uid = "mccorwin";
            password = "corwin445";
            port = "3307";




            String connString = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={password};";
           
            using ( conn = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT event_name, event_dt, event_time, event_location, event_tags, event_des FROM Events"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = conn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            
                            return dt;
                        }
                    }
                }
            }
        }






    }









}