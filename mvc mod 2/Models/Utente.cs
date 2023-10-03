using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvc_mod_2.Models
{
    public class Utente
    {
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "nome troppo lungo")]
        [Required(ErrorMessage = "Il Nome è obbligatorio")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "cognome troppo lungo")]
        [Required(ErrorMessage = "Il Cognome è obbligatorio")]
        public string Cognome { get; set; }

        [StringLength(40, MinimumLength = 6, ErrorMessage = "la password deve contenere un minimo di 6 caratteri e un massimo di 40")]
        [Required(ErrorMessage = "la password è obbligatoria")]
        public string Password { get; set; }

        [StringLength(16, MinimumLength = 11, ErrorMessage = "inserire un codice fiscale o una partita iva validi")]
        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [Display(Name = "inserisci codice fiscale o partita iva se azienda")]
        public string codicefiscale { get; set; }

        public bool IsPrivato { get; set; }
        public bool Admin { get; set; }
        public string Errore { get; set; }

        public void addDb(Utente utente)
        {
            string t = utete(utente);

            if (t != utente.codicefiscale)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                    "INSERT INTO cliente  VALUES (@Nome, @Cognome, @codicefiscale , @IsPrivato , @Admin, @Password)", conn);
                    cmd.Parameters.AddWithValue("Nome", utente.Name);
                    cmd.Parameters.AddWithValue("Cognome", utente.Cognome);
                    cmd.Parameters.AddWithValue("codicefiscale", utente.codicefiscale);
                    cmd.Parameters.AddWithValue("IsPrivato ", utente.IsPrivato);
                    cmd.Parameters.AddWithValue("Admin", false);
                    cmd.Parameters.AddWithValue("Password", utente.Password);
                    cmd.ExecuteNonQuery();
                    FormsAuthentication.SetAuthCookie(utente.codicefiscale, false);
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Errore = "elemento gia presente";
            }
        }

        public Utente GetUtentet1(Utente u)
        {
            string conn = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(conn);
            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Select * FROM cliente where codicefiscale=@codicefiscale And Password=@Password", sqlConnection);
                sqlCommand.Parameters.AddWithValue("codicefiscale", u.codicefiscale);
                sqlCommand.Parameters.AddWithValue("Password", u.Password);
                SqlDataReader sqlDataReader;
                sqlDataReader = sqlCommand.ExecuteReader();
                Utente utente = new Utente();
                while (sqlDataReader.Read())
                {
                    utente.ID = Convert.ToInt32(sqlDataReader["Idcliente"]);
                }
                if (utente.ID != 0)
                {
                    FormsAuthentication.SetAuthCookie(u.codicefiscale, false);
                }
                return utente;
            }
            catch
            {
                return u = new Utente();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public string utete(Utente U)
        {
            string conn = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(conn);
            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Select * FROM cliente where codicefiscale=@codicefiscale", sqlConnection);
                sqlCommand.Parameters.AddWithValue("codicefiscale", U.codicefiscale);
                SqlDataReader sqlDataReader;
                sqlDataReader = sqlCommand.ExecuteReader();
                Utente utente = new Utente();
                while (sqlDataReader.Read())
                {
                    utente.codicefiscale = sqlDataReader["codiceFiscale"].ToString();
                }
                return utente.codicefiscale;
            }
            catch
            {
                return "nope";
            }
            finally { sqlConnection.Close(); }
        }

        public int id(string codicefiscale)
        {
            string conn = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(conn);
            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Select * FROM cliente where codicefiscale=@codicefiscale", sqlConnection);
                sqlCommand.Parameters.AddWithValue("codicefiscale", codicefiscale);
                SqlDataReader sqlDataReader;
                sqlDataReader = sqlCommand.ExecuteReader();
                Utente utente = new Utente();
                while (sqlDataReader.Read())
                {
                    utente.ID = Convert.ToInt32(sqlDataReader["Idcliente"]);
                }

                return utente.ID;
            }
            catch
            {
                return 0;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}