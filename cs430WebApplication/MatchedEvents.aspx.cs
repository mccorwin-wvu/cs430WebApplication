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
using System.Text.RegularExpressions;
namespace cs430WebApplication
{
    public partial class WebForm6 : System.Web.UI.Page

    {
        private String user_tags ="";



        protected void Page_Load(object sender, EventArgs e)
        {
            user_tags = (String)Session["tags"];

            String[] head = { "Event Name", "Event Date", "Event Time", "Event Location", "Event Tags", "Event Description" };
            if (!this.IsPostBack)
            {
                //Populating a DataTable from database.
                DataTable dt = this.sortData(this.GetData(), user_tags);

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

            using (conn = new MySqlConnection(connString))
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


        private DataTable sortData(DataTable table, String tags)
        {


            table.Columns.Add("tagCount", typeof(Int32));


            foreach (DataRow row in table.Rows)
            {

                int count = 0;
                String [] tagsEvent = row["event_tags"].ToString().Split(',');
                String[] tagsUser = tags.Split(',');

                foreach(String ut in tagsUser)
                {
                    foreach(String et in tagsEvent)
                    {
                        string utNoSpace = Regex.Replace(ut, @"\s", "");
                        string etNoSpace = Regex.Replace(et, @"\s", "");

                        if(String.Equals(utNoSpace, etNoSpace, StringComparison.OrdinalIgnoreCase))
                        {

                            count = count + 1;

                        }

                    }

             }
                row["tagCount"] = count;




            }

            DataView dv = table.DefaultView;
            dv.Sort = "tagCount desc";
            DataTable sortedDT = dv.ToTable();

            return sortedDT;



        }




    }
}
