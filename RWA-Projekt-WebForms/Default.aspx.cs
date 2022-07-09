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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelForma.Visible = true;
                PanelIspis.Visible = false;

                HttpCookie loginCookie = new HttpCookie("Admin");
                loginCookie.Values["Name"] = "admin";
                loginCookie.Values["Password"] = "admin";
                loginCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(loginCookie);
            }
            if (Session["user"] != null)
            {
                Response.Redirect("Apartments.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                HttpCookie loginCookie = Request.Cookies["Admin"];
                var username = txtUsername.Text;
                var password = txtPassword.Text;

                User user = null;
                Session["user"] = user;

                if (username == loginCookie.Values["Name"] && password == loginCookie.Values["Password"])
                {
                    user = new User
                    {
                        Username = username,
                        Password = password
                    };
                }


                if (user == null)
                {
                    PanelIspis.Visible = true;
                    PanelForma.Visible = true;

                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    Session["user"] = user;
                    Response.Redirect("Apartments.aspx");
                }
            }
        }
    }
}