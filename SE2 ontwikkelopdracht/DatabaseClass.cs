using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Web.Configuration;


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
                OracleCommand oraCommand = new OracleCommand("INSERT INTO ACCOUNT(Accountnr, naam, wachtwoord) VALUES("+ nr + ", :accNaam, :Password)", connectie);
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

                string medewerker = "nope";

                while (reader.Read())
                {

                    medewerker = Convert.ToString(reader["accountnr"]);

                    return medewerker;
                    
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
                cmd.Parameters.Add(new OracleParameter("zoekterm", "%"+zoekterm+"%"));
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
    }
}