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
    public partial class Apartments : System.Web.UI.Page
    {
        private IList<Apartment> _listOfApartmants;
        private IList<City> _listOfCities;
        private IList<ApartmentStatus> _listOfStatus;
        protected void Page_Load(object sender, EventArgs e)
        {
            _listOfApartmants = ((DBRepo)Application["database"]).LoadAllApartments();
            _listOfCities = ((DBRepo)Application["database"]).LoadCities();
            _listOfStatus = ((DBRepo)Application["database"]).LoadStatus();

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
            LoadApartments(_listOfApartmants);
            LoadCities();
            LoadStatus();
        }

        private void LoadStatus()
        {
            ddlStatus.DataSource = _listOfStatus;
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("Any", ""));
        }

        private void LoadCities()
        {
            ddlCity.DataSource = _listOfCities;
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("Any", ""));
        }

        private void LoadApartments(IList<Apartment> loa)
        {
            rptApartments.DataSource = loa;
            rptApartments.DataBind();
        }

        protected void addApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddApartment.aspx");
        }

        protected void rptApartments_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            ((DBRepo)Application["database"]).DeleteApartmentById(id);
            Response.Redirect("Apartments.aspx");
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCity.SelectedItem.Text == ddlCity.Items[0].Text)
            {
                
                LoadApartments(_listOfApartmants);
            }
            else
            {
                IList<Apartment> _listOfApartmantsByCities = ((DBRepo)Application["database"]).LoadApartmentByCityName(ddlCity.SelectedItem.Text);
                LoadApartments(_listOfApartmantsByCities);
            }
            
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedItem.Text == ddlStatus.Items[0].Text)
            {

                LoadApartments(_listOfApartmants);
            }
            else
            {
                IList<Apartment> _listOfApartmantsByStatus = ((DBRepo)Application["database"]).LoadApartmantsByStatus(ddlStatus.SelectedItem.Text);
                LoadApartments(_listOfApartmantsByStatus);
            }
        }
    }
}