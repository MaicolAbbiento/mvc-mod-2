using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace mvc_mod_2.Models
{
    public class dettagli
    {
        public int idaggiornamenti { get; set; }
        public DateTime dataAggiornamento { get; set; }
        public string luogo { get; set; }
        public string descrizione { get; set; }
        public string stato { get; set; }
        public int idordini { get; set; }

        public dettagli()
        { }

        public dettagli(int idaggiornamenti, DateTime dataAggiornamento, string luogo, string descrizione, string stato, int idordini)
        {
            this.idaggiornamenti = idaggiornamenti;
            this.dataAggiornamento = dataAggiornamento;
            this.luogo = luogo;
            this.descrizione = descrizione;
            this.stato = stato;
            this.idordini = idordini;
        }

        public List<dettagli> lista = new List<dettagli>();

        public void dattagli(int id)
        {
            string connetionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connetionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM aggiornamenti where idordini =@idordini", conn);
                cmd.Parameters.AddWithValue("idordini ", id);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();
                int n = 0;
                while (sqlDataReader.Read())
                {
                    n++;
                    dettagli dettaglio = new dettagli(
                    n,
                    Convert.ToDateTime(sqlDataReader["dataAggiornamento"]),
                    sqlDataReader["luogo"].ToString(),
                    sqlDataReader["descrizione"].ToString(),
                    sqlDataReader["stato"].ToString(),
                    Convert.ToInt32(sqlDataReader["idordini"])

                 );
                    lista.Add(dettaglio);
                }
            }
            catch
            {
                lista.Clear();
            }
            finally { conn.Close(); }
        }

        public void instertdettagli(dettagli p)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO aggiornamenti VALUES (@dataAggiornamento , @descrizione,@idordini,@luogo, @stato)", conn);

                cmd.Parameters.AddWithValue("dataAggiornamento", DateTime.Now);
                cmd.Parameters.AddWithValue("descrizione", p.descrizione);
                cmd.Parameters.AddWithValue("idordini", p.idordini);
                cmd.Parameters.AddWithValue("luogo", p.luogo);
                cmd.Parameters.AddWithValue("stato", p.stato);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
        }
    }
}