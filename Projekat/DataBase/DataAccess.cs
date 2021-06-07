﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.IO;

namespace DataBase
{
    public class DataAccess
    {

        public void Min(Racunanje m)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                MySqlCommand cmd = new MySqlCommand($"insert into funkcija2(vreme_proracuna, poslednje_merenje, minimalna_potrosnja) values('{m.VremeProracuna}', '{m.PoslednjeVreme}', {m.Vrednost})", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Max(Racunanje m)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                MySqlCommand cmd = new MySqlCommand($"insert into funkcija3(vreme_proracuna, poslednje_merenje, maksimalna_potrosnja) values('{m.VremeProracuna}', '{m.PoslednjeVreme}', {m.Vrednost})", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Avg(Racunanje m)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                MySqlCommand cmd = new MySqlCommand($"insert into funkcija1(vreme_proracuna, poslednje_merenje, prosecna_potrosnja) values('{m.VremeProracuna}', '{m.PoslednjeVreme}', {m.Vrednost})", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Upisi(string gde, string sta)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                con.Open();
                string komanda = "";

                switch (gde)
                {
                    case "prva": 
                        komanda = "insert into funkcija1(vreme_proracuna, poslednje_merenje, prosecna_potrosnja) values('{k.VremeProracuna}', '{k.PoslednjeVreme}', {k.Vrednost})"; 
                        break;
                    case "druga":
                        komanda = "insert into funkcija1(vreme_proracuna, poslednje_merenje, prosecna_potrosnja) values('{k.VremeProracuna}', '{k.PoslednjeVreme}', {k.Vrednost})";
                        break;
                    case "treca":
                        komanda = "insert into funkcija1(vreme_proracuna, poslednje_merenje, prosecna_potrosnja) values('{k.VremeProracuna}', '{k.PoslednjeVreme}', {k.Vrednost})";
                        break;
                    case "cetvrta":
                        komanda = "insert into funkcija1(vreme_proracuna, poslednje_merenje, prosecna_potrosnja) values('{k.VremeProracuna}', '{k.PoslednjeVreme}', {k.Vrednost})";
                        break;

                }


                MySqlCommand cmd = new MySqlCommand(komanda, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        
        }

        public void UpisiVrednostiZaRegion(string region, DateTime datum_vreme, double vrednost)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                con.Open();

                string komanda = "UPDATE merenja SET vrednost = ?vrednost, vreme = ?vreme WHERE naziv = ?region";

                MySqlCommand cmd = new MySqlCommand(komanda, con);

                cmd.Parameters.Add(new MySqlParameter("vrednost", vrednost));
                cmd.Parameters.Add(new MySqlParameter("vreme", datum_vreme.ToString()));
                cmd.Parameters.Add(new MySqlParameter("region", region));

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Merenje> DobaviMerenja()
        {
            List<Merenje> lista = new List<Merenje>();

            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                con.Open();

                string komanda = "SELECT * FROM merenja";

                MySqlCommand cmd = new MySqlCommand(komanda, con);

                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Merenje temp = new Merenje();

                        //temp.Id = Int32.Parse((rd.GetValue(0).ToString()));
                        temp.Naziv = rd.GetValue(1).ToString();
                        temp.Vreme = DateTime.Parse(rd.GetValue(2).ToString());
                        temp.Vrednost = Double.Parse(rd.GetValue(3).ToString());

                        lista.Add(temp);
                    }
                }
            }

            return lista;
        }

        public List<Racunanje> DobaviRacunanja()
        {
            List<Racunanje> lista = new List<Racunanje>();

            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                con.Open();

                string komanda = "SELECT * FROM racunanja";

                MySqlCommand cmd = new MySqlCommand(komanda, con);

                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Racunanje temp = new Racunanje();

                        //m.Id = Int32.Parse((rd.GetValue(0).ToString()));
                        temp.Naziv = rd.GetValue(1).ToString();
                        temp.VremeProracuna = DateTime.Parse(rd.GetValue(2).ToString());
                        temp.PoslednjeVreme = DateTime.Parse(rd.GetValue(3).ToString());
                        temp.Vrednost = Double.Parse(rd.GetValue(4).ToString());

                        lista.Add(temp);
                    }
                }
            }

            return lista;
        }

        public DateTime DobaviPoslednjeVreme()
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                con.Open();

                string komanda = "SELECT vreme FROM merenja WHERE vreme >= all(select vreme from merenja)";

                MySqlCommand cmd = new MySqlCommand(komanda, con);

                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    return DateTime.Parse(rd.GetValue(0).ToString());
                }
            }
        }

    }
}
