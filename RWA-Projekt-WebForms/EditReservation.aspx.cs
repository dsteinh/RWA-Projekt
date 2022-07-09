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
    public partial class EditReservation : System.Web.UI.Page
    {
        int _reservationId;
        private IList<User> _listOfUsers;
        private ApartmentReservation _apartmentReservation;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            _reservationId = int.Parse(Request.QueryString["id"]);

            _listOfUsers = ((DBRepo)Application["database"]).LoadUsers();
            _apartmentReservation = ((DBRepo)Application["database"]).LoadApartmentsReservationById(_reservationId);

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            FillDDL();
            if (ddlRegisterUsers.Items.FindByText(_apartmentReservation.FullName) != null)
            {
                ddlRegisterUsers.Items.FindByText(_apartmentReservation.FullName).Selected = true;
            }
            else
            {
                ddlRegisterUsers.Items[0].Selected = true;

            }
            txtDetails.Text = _apartmentReservation.Details;
            txtEmail.Text = _apartmentReservation.UserEmail;
            txtUnregUser.Text = _apartmentReservation.UserName;

        }

        private void FillDDL()
        {
            ddlRegisterUsers.DataSource = _listOfUsers;
            ddlRegisterUsers.DataBind();
            ddlRegisterUsers.Items.Insert(0, new ListItem("", ""));
        }

        protected void updateReservation_Click(object sender, EventArgs e)
        {
            string details = txtDetails.Text;
            string regUser = ddlRegisterUsers.SelectedItem.Text;
            string unregUser = txtUnregUser.Text;
            string email = txtEmail.Text;

            if (!string.IsNullOrEmpty(regUser))
            {
                ((DBRepo)Application["database"]).UpdateReservation(_reservationId, details, regUser);
            }
            else
            {
                ((DBRepo)Application["database"]).UpdateReservation(_reservationId, details, unregUser, email);
            }

            Response.Redirect(Session["editResUri"].ToString());
        }
    }
}