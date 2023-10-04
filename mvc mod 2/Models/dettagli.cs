using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mvc_mod_2.Models
{
    public class dettagli
    {
        public int idaggiornamenti { get; set; }
        public DateTime dataAggiornamento { get; set; }
        public string luogo { get; set; }
        public string descrizione { get; set; }
        public string stato { get; set; }
        public int statoint { get; set; }
        public int idordini { get; set; }

        public dettagli()
        { }

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
                dettagli dettaglio = new dettagli();
                while (sqlDataReader.Read())
                {
                    dettaglio.idaggiornamenti = Convert.ToInt32(sqlDataReader["idaggiornamenti"]);
                    dettaglio.dataAggiornamento = Convert.ToDateTime(sqlDataReader["dataAggiornamento"]);
                    dettaglio.descrizione = sqlDataReader["descrizione"].ToString();
                    dettaglio.idordini = Convert.ToInt32(sqlDataReader["idordini"]);
                    dettaglio.stato = sqlDataReader["stato"].ToString();
                    dettaglio.luogo = sqlDataReader["luogo"].ToString();
                    lista.Add(dettaglio);
                }
            }
            catch
            {
                lista.Clear();
            }
            finally { conn.Close(); }
        }
    }
}