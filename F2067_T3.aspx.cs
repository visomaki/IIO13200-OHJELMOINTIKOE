using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class F2067_T3 : System.Web.UI.Page
{
    Koodari_Auth auth;

    protected void Page_Load(object sender, EventArgs e)
    {
        string xml = ConfigurationManager.AppSettings["koodarit"];
        auth = new Koodari_Auth(MapPath(xml));
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (auth.authenticate(LoginUser.UserName, LoginUser.Password)){
                FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
            }
            else
            {
                lblNotes.Text = "Autentikointi epäonnistui";
            }
        }
        catch (Exception ex)
        {
            lblNotes.Text = "Autentikointipalvelua ei voi käyttää, yritä hetken päästä uudelleen";
        }
    }
}