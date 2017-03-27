using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cs430WebApplication
{

    public partial class WebForm3 : System.Web.UI.Page
    {

        private String password;
        private int user_id = 0;
        private String first_name = "";
        private String last_name = "";
        private String user_email = "";
        private String tags = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            name.Text = (string)("Welcome "+Session["first_name"]+"  "+Session["last_name"]);
            tag.Text = (string)("Tags: " + Session["tags"]);
        }
    }
}