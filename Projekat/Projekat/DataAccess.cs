using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    public class DataAccess
    {
    /*    private bool povezan;

        public static int br = 0;
        public string Naziv { get; }
        public bool Povezan { get => povezan; set => povezan = value; }

        public DataAccess()
        {
            Naziv = "DA_" + br++;
            povezan = true;
        }

        public DataAccess(string naziv)
        {
            Naziv = naziv;
            br++;
            povezan = true;
        }

        public bool Create(int kljuc,Komponenta komp)
        {
            if (povezan == false)
                return false;

            bool ret = false;

            if (!baza.ContainsKey(kljuc))
            {
                baza.Add(kljuc, komp);
                ret = true;
            }
            return ret;
        }

        public Komponenta Read(int kljuc)
        {
            if (povezan == false)
                return null;

            return baza[kljuc];
        }

        public bool Delete(int kljuc)
        {
            if (povezan == false)
                return false;

            return baza.Remove(kljuc);
        }

        public bool Update(int kljuc, double vrednost)
        {
            if (povezan == false)
                return false;

            bool ret = false;

            if (baza.ContainsKey(kljuc))
            {
                if (baza[kljuc].Vrednost != vrednost)
                {
                    baza[kljuc].Vrednost = vrednost;
                    ret = true;
                }
            }
            else
            {
                ret = Create(kljuc, new Komponenta("",vrednost));
            }
            return ret;
        }

        public bool Con() 
        {
            return povezan = true;
        }

        public bool DCon()
        {
            return povezan = false;
        }
        */
    }
}
