using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


public class Tyontekija
{
    string etunimi;
    string sukunimi;
    int numero;
    string tyosuhde;
    int palkka;

    public string Etunnimi
    {
        get { return etunimi; }
        set { etunimi = value; }
    }

    public string Sukunimi
    {
        get { return sukunimi; }
        set { sukunimi = value; }
    }

    public int Numero
    {
        get { return numero; }
        set { numero = value; }
    }

    public string Tyosuhde
    {
        get { return tyosuhde; }
        set { tyosuhde = value; }
    }

    public int Palkka
    {
        get { return palkka; }
        set { palkka = value; }
    }
}


public partial class teht2 : System.Web.UI.Page
{
    XDocument document;
    List<Tyontekija> tyontekijat;

    protected void Page_Load(object sender, EventArgs e)
    {
        int palkkaYht = 0;
        int vakituisetLkm = 0;
        tyontekijat = new List<Tyontekija>();

        try
        {
            string xml = ConfigurationManager.AppSettings["tyontekijat"];

            document = XDocument.Load(MapPath(xml));
            foreach (XElement element in document.Root.Elements())
            {
                Tyontekija tt = new Tyontekija();

                tt.Etunnimi = element.Element("etunimi").Value;
                tt.Sukunimi = element.Element("sukunimi").Value;
                tt.Numero = int.Parse(element.Element("numero").Value);
                tt.Tyosuhde = element.Element("tyosuhde").Value;
                tt.Palkka = int.Parse(element.Element("palkka").Value);

                tyontekijat.Add(tt);

                if (tt.Tyosuhde.ToLower() == "vakituinen")
                {
                    palkkaYht += tt.Palkka;
                    vakituisetLkm++;
                }
            }

            ttGrid.DataSource = tyontekijat;
            ttGrid.DataBind();
        } catch {

        }

        labelVakituisetKpl.Text = "Vakituisia tyontekijöitä: " + vakituisetLkm;
        labelVakituisetPalkka.Text = "Vakituisten palkka yhteensä: " + palkkaYht;
    }
}