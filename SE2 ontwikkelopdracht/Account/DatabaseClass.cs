using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Web.Configuration;


namespace SE2_ontwikkelopdracht.Account
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

                OracleCommand cmd = new OracleCommand("SELECT MEDEWERKER from ACCOUNT WHERE EMAILADDRESS ='" + email + "' AND PASSWORD ='" + password + "'", connectie);
                OracleDataReader reader = cmd.ExecuteReader();
                OracleDataAdapter da = new OracleDataAdapter(cmd);

                string medewerker;

                while (reader.Read())
                {

                    medewerker = Convert.ToString(reader["MEDEWERKER"]);

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
    }
}