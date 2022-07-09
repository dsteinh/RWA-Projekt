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
    public partial class Tags : System.Web.UI.Page
    {
        IList<Tag> _listOfTags;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            _listOfTags = ((DBRepo)Application["database"]).LoadTags();
           // _listOfTagTypes = ((DBRepo)Application["database"]).LoadTagTypes();

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            rptTags.DataSource = _listOfTags;
            rptTags.DataBind();
        }

        protected void rptTags_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            ((DBRepo)Application["database"]).DeleteTagById(Id);
            ReloadData();
        }

        private void ReloadData()
        {
            rptTags.DataSource = null;
            _listOfTags = ((DBRepo)Application["database"]).LoadTags();
            rptTags.DataBind();
            LoadData();
        }
        public bool IsApartmentsUsingZero(object o)
        {
            if ((int)o == 0)
            {
                return true;
            }
            return false;
        }

        protected void addTag_Click(object sender, EventArgs e)
        {

            Response.Redirect("NewTag.aspx");
        }
    }
}