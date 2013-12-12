using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tuntikirjanpito_kirjaus : System.Web.UI.Page
{
    Koodari_Data data;

    protected void Page_Init(Object sender, EventArgs e)
    {
        string xml = ConfigurationManager.AppSettings["tuntikirjaukset"];
        data = new Koodari_Data(MapPath(xml));

        tbDate.Text = DateTime.Today.ToShortDateString();
        tbName.Text = User.Identity.Name;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Kirjaus kirjaus = new Kirjaus();
            kirjaus.Date = tbDate.Text;
            kirjaus.Name = tbName.Text;
            kirjaus.Hours = int.Parse(tbHours.Text);
            kirjaus.Minutes = int.Parse(tbMinutes.Text);

            data.add(kirjaus);
            LabelInfo.Text = "Kirjaus tallennettu!";
        }
        catch (Exception ex)
        {
            LabelInfo.Text = "Kirjaus epäonnistui!";
        }
    }
}