using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA_Projekt_WebForms
{
    public partial class Users : System.Web.UI.Page
    {
        private IList<User> _listOfUsers;
        protected void Page_Load(object sender, EventArgs e)
        {

            _listOfUsers = ((DBRepo)Application["database"]).LoadUsers();

            if (!IsPostBack)
            {
                LoadData();
            }
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }

        }

        private void LoadData()
        {
            rptUsers.DataSource = _listOfUsers;
            rptUsers.DataBind();
        }
    }
}