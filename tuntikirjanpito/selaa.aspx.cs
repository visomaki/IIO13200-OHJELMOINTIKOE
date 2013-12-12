using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tuntikirjanpito_selaa : System.Web.UI.Page
{
    Koodari_Data data;
    Koodari_Auth auth;

    protected void Page_Init(Object sender, EventArgs e)
    {
        string xml_data = ConfigurationManager.AppSettings["tuntikirjaukset"];
        string xml_auth = ConfigurationManager.AppSettings["koodarit"];

        data = new Koodari_Data(MapPath(xml_data));
        auth = new Koodari_Auth(MapPath(xml_auth));

        ddUser.DataSource = auth.getUsers();
        ddUser.DataBind();

        string user = User.Identity.Name;
        updateList(user);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = User.Identity.Name;
    }

    protected void ddUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        updateList(ddUser.SelectedValue);
    }

    private void updateList(string user)
    {
        List<Kirjaus> kirjaukset = data.getAllByUser(user);

        int tunnit = 0;
        int minuutit = 0;

        foreach (Kirjaus k in kirjaukset)
        {
            minuutit += k.Minutes;
            tunnit += k.Hours;
        }

        tunnit += minuutit / 60;

        labelTunnit.Text = "Tunnit yhteensä: " + tunnit;

        gridKirjaukset.DataSource = kirjaukset;
        gridKirjaukset.DataBind();
    }
}