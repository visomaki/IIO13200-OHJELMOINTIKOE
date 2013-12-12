using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

public class Kirjaus
{
    string name;
    string date;
    int hours;
    int minutes;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Date
    {
        get { return date; }
        set { date = value; }
    }

    public int Hours
    {
        get { return hours; }
        set { hours = value; }
    }

    public int Minutes
    {
        get { return minutes; }
        set { minutes = value; }
    }
}


public class Koodari_Data
{
    private string xml;
    private XDocument document;

	public Koodari_Data(string xml)
	{
        this.xml = xml;
        document = XDocument.Load(xml);
	}

    public void add(Kirjaus kirjaus)
    {
        try {
            document.Root.Add(new XElement("kirjaus", new XElement("nimi", kirjaus.Name), 
                                new XElement("pvm", kirjaus.Date), 
                                new XElement("tunnit", kirjaus.Hours),
                                new XElement("minuutit", kirjaus.Minutes)));

            document.Save(xml);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Kirjaus> getAllByUser(string name)
    {
        List<Kirjaus> kirjaukset = new List<Kirjaus>();

        try
        {
            IEnumerable<XElement> elements =
                    (from el in document.Root.Elements("kirjaus")
                     where el.Element("nimi").Value == name
                     select el);

            foreach (XElement element in elements)
            {
                
                Kirjaus kirjaus = new Kirjaus();

                kirjaus.Name = element.Element("nimi").Value;
                kirjaus.Date = element.Element("pvm").Value;
                kirjaus.Minutes = int.Parse(element.Element("minuutit").Value);
                kirjaus.Hours = int.Parse(element.Element("tunnit").Value);

                kirjaukset.Add(kirjaus);
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }

        return kirjaukset;
    }

    public int getCount()
    {
        return document.Root.Elements().Count();
    }
}