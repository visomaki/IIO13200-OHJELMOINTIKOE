using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tuntikirjanpito_Default : System.Web.UI.Page
{
    Koodari_Data data;

    protected void Page_Load(object sender, EventArgs e)
    {
        string xml = ConfigurationManager.AppSettings["tuntikirjaukset"];
        data = new Koodari_Data(MapPath(xml));
        labelKirjauksetLkm.Text = "Kirjauksia yhteensä: " +  data.getCount().ToString();
    }
}