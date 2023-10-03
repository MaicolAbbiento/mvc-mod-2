﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mvc_mod_2.Models
{
    public class Ordini
    {
        public int Id { get; set; }
        public DateTime Dataspedizione { get; set; }
        public string DataSpedizionestring { get; set; }
        public decimal Peso { get; set; }
        public string Citta { get; set; }
        public string Indirizzo { get; set; }

        public string NominativoDestinatario { get; set; }
        public decimal costo { get; set; }
        public string costoString { get; set; }
        public string descrizione { get; set; }
        public DateTime Datecosegna { get; set; }
        public string DataConsegnastring { get; set; }
        public int idcliente { get; set; }
        public string codicefiscale { get; set; }
        public List<Ordini> ordini = new List<Ordini>();

        public Ordini(int id, DateTime dataspedizione, decimal peso, string citta, string indirizzo, string nominativoDestinatario, decimal costo, string descrizione, DateTime datecosegna)
        {
            Id = id;

            Dataspedizione = dataspedizione;
            Peso = peso;
            Citta = citta;
            Indirizzo = indirizzo;
            NominativoDestinatario = nominativoDestinatario;
            this.costo = costo;
            this.descrizione = descrizione;
            Datecosegna = datecosegna; ;
        }

        public Ordini()
        { }

        public List<Ordini> getspedizione(Ordini p)
        {
            Utente utente = new Utente();
            p.idcliente = utente.id(p.codicefiscale);
            if (p.Id == 0)
            {
                string connetionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM ordini where idcliente=@idcliente", conn);
                cmd.Parameters.AddWithValue("idcliente", p.idcliente);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Ordini ordine = new Ordini(

                        Convert.ToInt32(sqlDataReader["Idordini"]),
                        Convert.ToDateTime(sqlDataReader["Dataspedizione"]),
                        Convert.ToDecimal(sqlDataReader["peso"]),
                        sqlDataReader["Città"].ToString(),
                        sqlDataReader["Indirizzo"].ToString(),
                        sqlDataReader["NominativoDestinatario"].ToString(),
                         Convert.ToInt32(sqlDataReader["costo"]),
                        sqlDataReader["descrizione"].ToString(),
                       Convert.ToDateTime(sqlDataReader["Dataconsegna"])
                       );
                    ordini.Add(ordine);
                }
                conn.Close();
                return ordini;
            }
            else
            {
                string connetionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM ordini where idcliente=@idcliente", conn);
                cmd.Parameters.AddWithValue("idcliente", p.idcliente);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Ordini ordine = new Ordini(

                         Convert.ToInt32(sqlDataReader["Idordini"]),
                         Convert.ToDateTime(sqlDataReader["Dataspedizione"]),
                         Convert.ToDecimal(sqlDataReader["peso"]),
                         sqlDataReader["Città"].ToString(),
                         sqlDataReader["Indirizzo"].ToString(),
                         sqlDataReader["NominativoDestinatario"].ToString(),
                          Convert.ToInt32(sqlDataReader["costo"]),
                         sqlDataReader["descrizione"].ToString(),
                        Convert.ToDateTime(sqlDataReader["Dataconsegna"])
                        )
                    ;
                    ordini.Add(ordine);
                }
                conn.Close();
                return ordini;
            }
        }
        public List<Ordini> getAllspedizioni()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ordini ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Ordini ordine = new Ordini(

                    Convert.ToInt32(sqlDataReader["Idordini"]),
                    Convert.ToDateTime(sqlDataReader["Dataspedizione"]),
                    Convert.ToDecimal(sqlDataReader["peso"]),
                    sqlDataReader["Città"].ToString(),
                    sqlDataReader["Indirizzo"].ToString(),
                    sqlDataReader["NominativoDestinatario"].ToString(),
                     Convert.ToInt32(sqlDataReader["costo"]),
                    sqlDataReader["descrizione"].ToString(),
                   Convert.ToDateTime(sqlDataReader["Dataconsegna"])
                   );
                ordini.Add(ordine);
            }
            conn.Close();
            return ordini;
        }
    }
}