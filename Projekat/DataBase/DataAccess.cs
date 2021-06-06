using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataBase
{
    public class DataAccess
    {

        public void min(Racunanje m)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                MySqlCommand cmd = new MySqlCommand($"insert into funkcija2(vreme_proracuna, poslednje_merenje, minimalna_potrosnja) values('{m.VremeProracuna}', '{m.PoslednjeVreme}', {m.Vrednost})", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void max(Racunanje m)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                MySqlCommand cmd = new MySqlCommand($"insert into funkcija3(vreme_proracuna, poslednje_merenje, maksimalna_potrosnja) values('{m.VremeProracuna}', '{m.PoslednjeVreme}', {m.Vrednost})", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void dev(Racunanje m)
        {
            using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15"))
            {
                MySqlCommand cmd = new MySqlCommand($"insert into funkcija1(vreme_proracuna, poslednje_merenje, prosecna_potrosnja) values('{m.VremeProracuna}', '{m.PoslednjeVreme}', {m.Vrednost})", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void upisi(string gde, string sta)
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
                        Merenje m = new Merenje();

                        //m.Id = Int32.Parse((rd.GetValue(0).ToString()));
                        m.Naziv = rd.GetValue(1).ToString();
                        m.Vreme = DateTime.Parse(rd.GetValue(2).ToString());
                        m.Vrednost = Double.Parse(rd.GetValue(3).ToString());

                        lista.Add(m);
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
