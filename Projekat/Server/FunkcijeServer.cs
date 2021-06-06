﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using MySql.Data.MySqlClient;

namespace Server
{
    class FunkcijeServer : IFunkcije
    {
        public void funkcija1(string a, double b)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            { 
                MySqlCommand cmd = new MySqlCommand($"insert into funkcija1(vreme_proracuna, poslednje_merenje, prosecna_potrosnja) values('{a}', '{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}', {b})", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void funkcija2(string a, double b)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                MySqlCommand cmd = new MySqlCommand($"insert into funkcija2(vreme_proracuna, poslednje_merenje, minimalna_potrosnja) values('{a}', '{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}', {b})", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void funkcija3(string a, double b)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                MySqlCommand cmd = new MySqlCommand($"insert into funkcija3(vreme_proracuna, poslednje_merenje, maksimalna_potrosnja) values('{a}', '{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}', {b})", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
