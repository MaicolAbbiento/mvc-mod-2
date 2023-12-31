﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public Ordini(int id, string citta)
        {
            Id = id;
            Citta = citta;
        }

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM ordini where idcliente=@idcliente and idordini = @idordini ", conn);
                cmd.Parameters.AddWithValue("idcliente", p.idcliente);
                cmd.Parameters.AddWithValue("idordini", p.Id);
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
                    Convert.ToInt64(sqlDataReader["costo"]),
                    sqlDataReader["descrizione"].ToString(),
                   Convert.ToDateTime(sqlDataReader["Dataconsegna"])
                   );
                ordini.Add(ordine);
            }
            conn.Close();
            return ordini;
        }

        public void modificaOrdine(Ordini p)
        {
            string connetionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connetionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = " update ordini set Dataspedizione = @Dataspedizione, peso = @peso, città = @città, indirizzo = @indirizzo, nominativoDestinatario = @nominativoDestinatario, costo = @costo, descrizione = @descrizione, Dataconsegna= @Dataconsegna where Idordini = @Idordini ";
                cmd.Parameters.AddWithValue("Dataspedizione", p.Dataspedizione);
                cmd.Parameters.AddWithValue("peso", p.Peso);
                cmd.Parameters.AddWithValue("città", p.Citta);
                cmd.Parameters.AddWithValue("indirizzo", p.Indirizzo);
                cmd.Parameters.AddWithValue("nominativoDestinatario", p.NominativoDestinatario);
                cmd.Parameters.AddWithValue("costo", p.costo);
                cmd.Parameters.AddWithValue("descrizione", p.descrizione);
                cmd.Parameters.AddWithValue("Dataconsegna", p.Datecosegna);
                cmd.Parameters.AddWithValue("Idordini", p.Id);
                int IsOk = cmd.ExecuteNonQuery();
            }
            catch { }
            finally { conn.Close(); }
        }

        public void elminaOrdine(int id)
        {
            string connetionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connetionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete ordini where Idordini = @Idordini";
                cmd.Parameters.AddWithValue("Idordini", id);
                int IsOk = cmd.ExecuteNonQuery();
            }
            catch { }
            finally { conn.Close(); }
        }

        public Ordini getspedizione(int id)
        {
            string connetionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ordini where Idordini=@Idordini ", conn);
            cmd.Parameters.AddWithValue("Idordini", id);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();
            Ordini ordine = new Ordini();

            while (sqlDataReader.Read())
            {
                ordine.Id = Convert.ToInt32(sqlDataReader["Idordini"]);
                ordine.Dataspedizione = Convert.ToDateTime(sqlDataReader["Dataspedizione"]);
                ordine.Peso = Convert.ToDecimal(sqlDataReader["peso"]);
                ordine.Citta = sqlDataReader["Città"].ToString();
                ordine.Indirizzo = sqlDataReader["Indirizzo"].ToString();
                ordine.NominativoDestinatario = sqlDataReader["NominativoDestinatario"].ToString();
                ordine.costo = Convert.ToInt64(sqlDataReader["costo"]);
                ordine.descrizione = sqlDataReader["descrizione"].ToString();
                ordine.Datecosegna = Convert.ToDateTime(sqlDataReader["Dataconsegna"]);
                ordine.idcliente = Convert.ToInt32(sqlDataReader["Idcliente"]);
            }
            conn.Close();
            return ordine;
        }

        public void getqeury(int p1)
        {
            string connetionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connetionString);
            try
            {
                SqlCommand cmd;
                if (p1 == 1)
                {
                    cmd = new SqlCommand("SELECT * FROM ordini where Dataconsegna=CONVERT (date, GETDATE())", conn);
                }
                else
                {
                    cmd = new SqlCommand("SELECT * FROM ordini where Dataconsegna > @Dataconsegna", conn);
                    cmd.Parameters.AddWithValue("Dataconsegna", DateTime.Now);
                }
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
            }
            catch { }
            finally { conn.Close(); }
        }

        public void query3()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connetionString);
            try
            {
                SqlCommand cmd = new SqlCommand("select città, count(*) as numero from ordini group by città", conn);
                SqlDataReader sqlDataReader;
                conn.Open();
                sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Ordini ordine = new Ordini
                        (
                        Convert.ToInt32(sqlDataReader["numero"]),
                        sqlDataReader["Città"].ToString()
                        );

                    ordini.Add(ordine);
                }
            }
            catch { }
            finally { conn.Close(); }
        }
    }
}