using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Web.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using Oracle.DataAccess.Client;
using System.Data;


namespace SE2_ontwikkelopdracht
{
    public class DatabaseClass
    {
        private OracleConnection connectie = new OracleConnection();
        public void Connectieopen()
        {
            try
            {
                connectie = new OracleConnection();
                connectie.ConnectionString = WebConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
                connectie.Open();
            }
            catch
            {
                connectie.Close();
            }

        }

        public void InsertAcc(string accNaam, string Password)
        {
            int nr = GetAccNr() + 1;
            try
            {
                Connectieopen();
                OracleCommand oraCommand = new OracleCommand("INSERT INTO ACCOUNT(Accountnr, naam, wachtwoord) VALUES(" + nr + ", :accNaam, :Password)", connectie);
                oraCommand.Parameters.Add(new OracleParameter("accNaam", accNaam));
                oraCommand.Parameters.Add(new OracleParameter("Password", Password));

                oraCommand.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                connectie.Close();
            }
        }

        public int GetAccNr()
        {
            int temp = 1;
            string sql = "SELECT MAX(ACCOUNTNR) AS ACCOUNTNR FROM ACCOUNT";
            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp = Convert.ToInt32(reader["ACCOUNTNR"]);
                    return temp;
                }
                return temp;
            }
            catch (OracleException ex)
            {

            }
            finally { connectie.Close(); }
            return temp;
        }

        public string Logincheck(String email, string password)
        {

            try
            {
                Connectieopen();

                OracleCommand cmd = new OracleCommand("SELECT accountnr from ACCOUNT WHERE naam = :email AND wachtwoord = :password", connectie);
                cmd.Parameters.Add(new OracleParameter("password", password));
                cmd.Parameters.Add(new OracleParameter("email", email));
                OracleDataReader reader = cmd.ExecuteReader();
                OracleDataAdapter da = new OracleDataAdapter(cmd);

                string accnr = "nope";

                while (reader.Read())
                {

                    accnr = Convert.ToString(reader["accountnr"]);

                    return accnr;

                }



            }

            catch (OracleException exc)
            {
            }
            finally
            {
                connectie.Close();
            }
            return null;
        }

        public DataSet GetInfo(string zoekterm)
        {

            string sql = "SELECT OMSCHRIJVING, VRAAGPRIJS FROM ADVERTENTIE WHERE OMSCHRIJVING LIKE :zoekterm ORDER BY ADVERTENTIENR DESC";

            DataSet ds = new DataSet();

            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                cmd.Parameters.Add(new OracleParameter("zoekterm", "%" + zoekterm + "%"));
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                // Fill the DataSet.
                adapter.Fill(ds);
                return ds;

            }
            catch (OracleException e)
            {
            }
            finally
            {
                connectie.Close();
            }
            return ds;
        }

        public DataSet GetCat(string catnr)
        {

            string sql = "SELECT a.OMSCHRIJVING, a.VRAAGPRIJS FROM ADVERTENTIE a , CATEGORIE c WHERE c.categorienr = a.categorienr and c.categorienr = :catnr ORDER BY ADVERTENTIENR DESC";

            DataSet ds = new DataSet();

            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                cmd.Parameters.Add(new OracleParameter("catnr", catnr));
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                // Fill the DataSet.
                adapter.Fill(ds);
                return ds;

            }
            catch (OracleException e)
            {
            }
            finally
            {
                connectie.Close();
            }
            return ds;
        }

        public int GetAdvNr()
        {
            int temp = 1;
            string sql = "SELECT MAX(Advertentienr) AS Advertentienr FROM AdverTentie";
            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp = Convert.ToInt32(reader["Advertentienr"]);
                    return temp;
                }
                return temp;
            }
            catch (OracleException ex)
            {

            }
            finally { connectie.Close(); }
            return temp;
        }

        public int GetFotoNr()
        {
            int temp = 1;
            string sql = "SELECT MAX(FotoNr) AS FotoNr FROM FOTO";
            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp = Convert.ToInt32(reader["FotoNr"]);
                    return temp;
                }
                return temp;
            }
            catch (OracleException ex)
            {

            }
            finally { connectie.Close(); }
            return temp;
        }

        public void InsertAdv(string CatNr, string Accnr, string Omschrijving, string prijs)
        {

            int advnr = GetAdvNr() + 1;
            try
            {
                Connectieopen();
                OracleCommand oraCommand = new OracleCommand("INSERT INTO ADVERTENTIE VALUES(:advNr, :accNr, :catNr, :omschrijving, :prijs )", connectie);
                oraCommand.Parameters.Add(new OracleParameter("advNr", advnr));
                oraCommand.Parameters.Add(new OracleParameter("accNr", Accnr));
                oraCommand.Parameters.Add(new OracleParameter("catNr", CatNr));
                oraCommand.Parameters.Add(new OracleParameter("omschrijving", Omschrijving));
                oraCommand.Parameters.Add(new OracleParameter("prijs", prijs));

                oraCommand.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {

            }
            finally
            {
                connectie.Close();
            }

        }
        public void InsertFoto(string path)
        {

            int fotonr = GetFotoNr() + 1;
            int advnr = GetAdvNr();
            try
            {
                Connectieopen();
                OracleCommand oraCommand = new OracleCommand("INSERT INTO Foto VALUES(:fotonr, :advnr, :path )", connectie);
                oraCommand.Parameters.Add(new OracleParameter("fotonr", fotonr));
                oraCommand.Parameters.Add(new OracleParameter("advnr", advnr));
                oraCommand.Parameters.Add(new OracleParameter("path", path));

                oraCommand.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {

            }
            finally
            {
                connectie.Close();
            }
        }
        public List<string> GetURL(string advnr)
        {
            List<string> urls = new List<string>();
            string sql = "SELECT URLLINK FROM FOTO WHERE ADVERTENTIENR = :advnr";
            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                cmd.Parameters.Add(new OracleParameter("advnr", advnr));
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    urls.Add(Convert.ToString(reader["URLLINK"]));

                }
                return urls;
            }
            catch (OracleException ex)
            {

            }
            finally { connectie.Close(); }
            return urls;
        }
        
    }
}