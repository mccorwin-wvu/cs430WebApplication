using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

namespace cs430WebApplication
{
    public class ServerCom
    {
        public static bool OpenConnection(MySqlConnection conn)
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
                       
                        break;
                    case 1045:
                       
                        break;

                }
                return false;
            }

        }






        public static MySqlConnection serverCheck() {

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

            string connString;
            connString = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={password};";
            conn = new MySqlConnection(connString);
            return conn;
            
        }

    










    }
























}
