using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Ilmot
/// </summary>
/// 

public class Opiskelija
{
    private string firstname;
    private string lastname;
    private string asioid;

    public string Lastname {
        get {return lastname;}
        set {lastname = value;}
    }

    public string FirstName {
        get {return firstname;}
        set {firstname = value;}
    }

    public string AsioID
    {
        get { return asioid; }
        set { asioid = value; }
    }
}

public class Ilmot
{
    string connectionString;
    SqlConnection conn;

	public Ilmot(string connectionString)
	{
        try
        {
            this.connectionString = connectionString;
            conn = new SqlConnection(this.connectionString);
            conn.Open();
        }
        catch (Exception ex)
        {
            throw ex;
        }
	}

    public List<Opiskelija> getAll()
    {
        List<Opiskelija> opiskelijat = new List<Opiskelija>();

        try
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select DISTINCT asioid, lastname, firstname From lasnaolot";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Opiskelija op = new Opiskelija();

                op.FirstName = reader["firstname"].ToString();
                op.Lastname = reader["lastname"].ToString();
                op.AsioID = reader["asioid"].ToString();
                opiskelijat.Add(op);
            }
        }
        catch
        {
        }

        return opiskelijat;
    }
}