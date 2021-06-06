using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using MySql.Data.MySqlClient;
using DataBase;

namespace Server
{
    class FunkcijeServer : IFunkcije
    {
        private DataAccess da;
        public void funkcija1(Merenje m)
        {
            List<Merenje> list = da.DobaviMerenja();
            Merenje min = list[0];
            foreach (var item in list)
            {
                if (item.Vrednost < min.Vrednost)
                    min = item;
            }
            Racunanje r = new Racunanje();
            r.Vrednost = min.Vrednost;
            r.Naziv = min.Naziv;
            r.PoslednjeVreme = da.DobaviPoslednjeVreme();
            r.VremeProracuna = DateTime.Now;
            da.min(r);
        }

        public void funkcija2(Merenje m)
        {
            List<Merenje> list = da.DobaviMerenja();
            Merenje max = list[0];
            foreach (var item in list)
            {
                if (item.Vrednost > max.Vrednost)
                    max = item;
            }
            Racunanje r = new Racunanje();
            r.Vrednost = max.Vrednost;
            r.Naziv = max.Naziv;
            r.PoslednjeVreme = da.DobaviPoslednjeVreme();
            r.VremeProracuna = DateTime.Now;
            da.max(r);
        }

        public void funkcija3(Merenje m)
        {
            List<Merenje> list = da.DobaviMerenja();
            Merenje dev = list[0]; // kako se racuna dev?
            foreach (var item in list)
            {
                if (item.Vrednost > dev.Vrednost)
                    dev = item;
            }
            Racunanje r = new Racunanje();
            r.Vrednost = dev.Vrednost;
            r.Naziv = dev.Naziv;
            r.PoslednjeVreme = da.DobaviPoslednjeVreme();
            r.VremeProracuna = DateTime.Now;
            da.dev(r);
        }
    }
}
