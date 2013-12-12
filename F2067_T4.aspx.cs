using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class F2067_T4 : System.Web.UI.Page
{
    private Ilmot ilmot;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string connString = ConfigurationManager.ConnectionStrings["Ilmot"].ConnectionString;
            ilmot = new Ilmot(connString);
        }
        catch
        {
            labelInfo.Text = "Tietokantayhteyden luonti epäonnistui!";
            return;
        }

        gridOpiskelijat.DataSource = ilmot.getAll();
        gridOpiskelijat.DataBind();
    }
}