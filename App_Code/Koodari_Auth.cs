using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;

/// <summary>
/// Summary description for Koodari_Auth
/// </summary>
public class Koodari_Auth
{
    private string xml;
    private XDocument document;

	public Koodari_Auth(string xml)
	{
        this.xml = xml;
        document = XDocument.Load(xml);
	}

    public bool authenticate(string username, string password)
    {
        IEnumerable<XElement> users =
                (from el in document.Root.Elements("koodari")
                 where el.Element("nimi").Value == username
                 select el);

        if (users.Count() != 1) return false;

        string hashedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

        if (users.First().Element("salasana").Value.ToUpper() == hashedPass.ToUpper())
            return true;

        return false;
    }

    public IEnumerable<string> getUsers()
    {
        IEnumerable<string> users =
                (from el in document.Root.Elements("koodari")
                 select el.Element("nimi").Value);

        return users;
    }
}