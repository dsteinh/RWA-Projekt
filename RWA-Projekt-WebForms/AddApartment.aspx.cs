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
    public partial class AddApartment : System.Web.UI.Page
    {
        private Apartment _newApartment;
        private IList<City> _listOfCities;
        private IList<ApartmentStatus> _listOfStatus;
        private IList<ApartmentOwner> _listOfOwners;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            _listOfCities = ((DBRepo)Application["database"]).LoadCities();
            _listOfStatus = ((DBRepo)Application["database"]).LoadStatus();
            _listOfOwners = ((DBRepo)Application["database"]).LoadOwners();
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            LoadCities();
            LoadStatus();
            LoadOwners();
        }

        private void LoadOwners()
        {
            ddlOwners.DataSource = _listOfOwners;
            ddlOwners.DataBind();
        }

        protected void createApartment_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            City city = _listOfCities.SingleOrDefault(c => c.Name == ddlCity.SelectedItem.Text);
            string address = txtAddress.Text;
            int maxAdults = int.Parse(txtMaxAdults.Text);
            int maxChild = int.Parse(txtMaxChild.Text);
            int totalRooms = int.Parse(txtTotalRooms.Text);
            double price = double.Parse(txtPrice.Text);
            string status = ddlStatus.SelectedItem.Text;
            int beachDistance = int.Parse(txtBeachDistance.Text);
            ApartmentOwner owner = _listOfOwners.SingleOrDefault(o => o.Name == ddlOwners.SelectedItem.Text);

            _newApartment = new Apartment
            {
                Name = name,
                Status = status,
                TotalRooms = totalRooms,
                Price = price,
                City = city,
                Address = address,
                MaxAdults = maxAdults,
                MaxChildren = maxChild,
                BeachDistance = beachDistance,
                Owner = owner
            };
       

            ((DBRepo)Application["database"]).CreateApartment(_newApartment);
            Response.Redirect("Apartments.aspx");
        }
        private void LoadStatus()
        {
            ddlStatus.DataSource = _listOfStatus;
            ddlStatus.DataBind();

        }

        private void LoadCities()
        {

            ddlCity.DataSource = _listOfCities;
            ddlCity.DataBind();

        }
    }
}