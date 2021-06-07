using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataBase;
using System.ServiceModel;

namespace FunkcijeProjekat
{
    public class Funkcije : IFunkcije
    {
        private static DataAccess da = new DataAccess(); // static?
        private static List<DateTime> poslednjeVremeProracunaList = new List<DateTime> { DateTime.Now, DateTime.Now, DateTime.Now };

        public Racunanje FunkcijaMin()
        {
            if (poslednjeVremeProracunaList[0] >= da.DobaviPoslednjeVreme())
                return null;

            List<Merenje> list = da.DobaviMerenja();
            List<Merenje> danas = PreuzmiDanasnja(list);
            Racunanje r = new Racunanje();

            if (danas.Count() == 0)
            {
                Console.WriteLine("Nema danasnjih merenja");
                r.Vrednost = 0;
                r.Naziv = "";
            }
            else
            {
                Merenje min = danas[0];
                foreach (var item in danas)
                {
                    if (item.Vrednost < min.Vrednost)
                        min = item;
                }
                r.Vrednost = min.Vrednost;
                r.Naziv = min.Naziv;
            }
            r.PoslednjeVreme = da.DobaviPoslednjeVreme();
            r.VremeProracuna = DateTime.Now;
            poslednjeVremeProracunaList[0] = r.VremeProracuna;
            r.Id = DataAccess.id;
            da.UpisiURacunanja(r);
            return r;
        }

        public Racunanje FunkcijaMax()
        {
            if (poslednjeVremeProracunaList[1] >= da.DobaviPoslednjeVreme())
                return null;

            List<Merenje> list = da.DobaviMerenja();
            List<Merenje> danas = PreuzmiDanasnja(list);
            Racunanje r = new Racunanje();

            if (danas.Count() == 0)
            {
                Console.WriteLine("Nema danasnjih merenja");
                r.Vrednost = 0;
                r.Naziv = "";

            }
            else
            {
                Merenje max = danas[0];
                foreach (var item in danas)
                {
                    if (item.Vrednost > max.Vrednost)
                        max = item;
                }
                r.Vrednost = max.Vrednost;
                r.Naziv = max.Naziv;

            }
            r.PoslednjeVreme = da.DobaviPoslednjeVreme();
            r.VremeProracuna = DateTime.Now;
            poslednjeVremeProracunaList[1] = r.VremeProracuna;
            r.Id = DataAccess.id;
            da.UpisiURacunanja(r);
            return r;
        }

        public Racunanje FunkcijaAvg()
        {
            if (poslednjeVremeProracunaList[2] >= da.DobaviPoslednjeVreme())
                return null;

            List<Merenje> list = da.DobaviMerenja();
            List<Merenje> danas = PreuzmiDanasnja(list);
            Racunanje r = new Racunanje();

            if (danas.Count() == 0)
            {
                Console.WriteLine("Nema danasnjih merenja");
                r.Vrednost = 0;
            }
            else
            {
                double sum = 0;
                foreach (var item in danas)
                {
                    sum += item.Vrednost;
                }
                r.Vrednost = sum / danas.Count();

            }
            r.Naziv = "";
            r.PoslednjeVreme = da.DobaviPoslednjeVreme();
            r.VremeProracuna = DateTime.Now;
            poslednjeVremeProracunaList[2] = r.VremeProracuna;
            r.Id = DataAccess.id;
            da.UpisiURacunanja(r);
            return r;
        }

        private List<Merenje> PreuzmiDanasnja(List<Merenje> list)
        {
            int danas = DateTime.Now.Day;
            List<Merenje> ret = new List<Merenje>();
            foreach (var item in list)
            {
                if (item.Vreme.Day == danas)
                    ret.Add(item);
            }
            return ret;
        }
    }


}


