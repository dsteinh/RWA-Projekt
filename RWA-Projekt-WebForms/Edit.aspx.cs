using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RWA_Projekt_WebForms
{

    public partial class Edit : System.Web.UI.Page
    {
        private Apartment _apartmentToEdit;
        private IList<City> _listOfCities;
        private IList<ApartmentStatus> _listOfStatus;
        private IList<ApartmentReservation> _listOfApartmentReservations;
        private IList<ApartmentPicture> _listOfApartmentPictures;
        private string _apartmentId;
        private string _city;
        private string _status;
        IList<Tag> _listOfUsedTags;
        IList<Tag> _listOfTags;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            lblResult.Visible = false;
            _apartmentId = Request.QueryString["id"];
       
            int.TryParse(_apartmentId, out int id);

            _apartmentToEdit = ((DBRepo)Application["database"]).LoadApartmentByID(id);
            _listOfCities = ((DBRepo)Application["database"]).LoadCities();
            _listOfStatus = ((DBRepo)Application["database"]).LoadStatus();
            _listOfApartmentReservations = ((DBRepo)Application["database"]).LoadApartmentsReservationsByApartmentId(id);
            _listOfApartmentPictures = ((DBRepo)Application["database"]).LoadAllApartmentPictures(id);
            _listOfUsedTags = ((DBRepo)Application["database"]).LoadTagsByApartmentId(id);
            _listOfTags = ((DBRepo)Application["database"]).LoadTags();

            if (!IsPostBack)
            {
                LoadData();
            }
            

        }

        private void LoadData()
        {
            LoadApartments();
            LoadReservation();
            LoadApartmentPictures();
            LoadUsedTags();
            LoadTags();
        }

        private void LoadTags()
        {
            ddlTags.DataSource = _listOfTags;
            ddlTags.DataBind();
        }

        private  void LoadUsedTags()
        {
            rptTags.DataSource = _listOfUsedTags;
            rptTags.DataBind();
        }

        private void LoadApartmentPictures()
        {
            rptPictures.DataSource = _listOfApartmentPictures;
            rptPictures.DataBind();
        }

        private void LoadReservation()
        {
            rptReservations.DataSource = _listOfApartmentReservations;
            rptReservations.DataBind();
        }

        private void LoadApartments()
        {
            _city = Request.QueryString["city"].ToString();
            _status = Request.QueryString["status"].ToString();
            LoadCities();
            LoadStatus();
            txtName.Text = _apartmentToEdit.Name.ToString();
            ddlCity.Items.FindByText(_city).Selected = true;
            txtAddress.Text = _apartmentToEdit.Address.ToString();
            txtMaxAdults.Text = _apartmentToEdit.MaxAdults.ToString();
            txtMaxChild.Text = _apartmentToEdit.MaxChildren.ToString();
            txtTotalRooms.Text = _apartmentToEdit.TotalRooms.ToString();
            txtPrice.Text = _apartmentToEdit.Price.ToString();
            ddlStatus.Items.FindByText(_status).Selected = true;
            txtBeachDistance.Text = _apartmentToEdit.BeachDistance.ToString();
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
        protected void updateApartment_Click(object sender, EventArgs e)
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

            _apartmentToEdit.Name = name;
            _apartmentToEdit.Status = status;
            _apartmentToEdit.TotalRooms = totalRooms;
            _apartmentToEdit.Price = price;
            _apartmentToEdit.City = city;
            _apartmentToEdit.Address = address;
            _apartmentToEdit.MaxAdults = maxAdults;
            _apartmentToEdit.MaxChildren = maxChild;
            _apartmentToEdit.BeachDistance = beachDistance;

            ((DBRepo)Application["database"]).UpdateApartment(_apartmentToEdit);
        }
   

        protected void editReservation_Click(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string path = HttpContext.Current.Request.Url.AbsoluteUri;
            Session["editResUri"] = path;
            Response.Redirect($"EditReservation?id={id}");
            

            
        }

        protected void btnAddPicture_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(_apartmentId);
            byte[] imageBytes = FileUpload1.FileBytes;
            string base64String = Convert.ToBase64String(imageBytes);
            string fileName = FileUpload1.FileName;

            if (string.IsNullOrEmpty(base64String))
            {
                return;
            }

            ApartmentPicture picture = new ApartmentPicture
            {
                Base64Content = base64String,
                Name = fileName,
            };

            ((DBRepo)Application["database"]).CreatePicture(id, picture);
            ReloadPage();
        }

        private void ReloadPage()
        {
            string path = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(path);
        }

        protected void DeletePicture_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            ((DBRepo)Application["database"]).DeletePictureById(Id);
            ReloadPage();
        }

        protected void rptTags_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int tagId = Convert.ToInt32(e.CommandArgument.ToString());
            int.TryParse(_apartmentId, out int apId);
            ((DBRepo)Application["database"]).RemoveTagById(tagId, apId);
            ReloadPage();
        }

        protected void btnAddTag_Click(object sender, EventArgs e)
        {
            string tag = ddlTags.SelectedItem.Text;
            int.TryParse(_apartmentId, out int apId);
            ((DBRepo)Application["database"]).AddTagToApartment(tag, apId);
            ReloadPage();
        }
    }
}