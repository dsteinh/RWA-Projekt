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
    public partial class NewTag : System.Web.UI.Page
    {
        IList<TagType> _listOfTagTypes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            _listOfTagTypes = ((DBRepo)Application["database"]).LoadTagTypes();
            

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            FillDDL();
        }

        protected void createTag_Click(object sender, EventArgs e)
        {
            string name = txtTagName.Text;
            string type = ddlTagType.SelectedItem.Text;
            ((DBRepo)Application["database"]).CreateTag(name,type);
            Response.Redirect("Tags.aspx");
        }
        private void FillDDL()
        {
            ddlTagType.DataSource = _listOfTagTypes;
            ddlTagType.DataBind();
            
        }
    }
}