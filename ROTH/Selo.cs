using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROTF;
using System.Drawing;

namespace ROTH
{

    public class Selo
    {
        private String Name;
        private int zid;
        private Borci borci;
        private double faktorOsvojivosti;
        private int brojStrelaca;
        private int brojMacevalaca;
        private double heuristika;
        /*kordinate sela*/
        private Point pozicija;
        /*Heroj koji vlada*/
        Hero hero;
        const int MAX_ZID = 10;
        private bool protivnikOsvojio;
        private int faktor;

        public Selo(int bs, int bm, int z, Point pz)
        {
            this.pozicija = pz;
            zid = z;
            brojMacevalaca = bm;
            brojStrelaca = bs;
            faktorOsvojivosti = 0;
            borci = new Borci(brojStrelaca, brojMacevalaca);
            protivnikOsvojio = false;
        }

        public int FAKTOR
        {
            get { return faktor; }
            set { faktor = value; }
        }

        public bool OSVOJENO
        {
            get { return protivnikOsvojio; }
            set { protivnikOsvojio = value; }
        }

        public Hero OSVOJIO
        {
            get { return hero; }
            set { hero = value; }
        }

        public double HEURISTIKA
        {
            get { return heuristika; }
            set { heuristika = value; }
        }

        public double FAKTOROSVOJIVOSTI
        {
            get { return faktorOsvojivosti; }
            set { faktorOsvojivosti = value; }
        }

        public String NAME
        {
            get { return Name; }
            set { Name = value; }
        }

        public int BROJSTRELACA
        {
            get { return brojStrelaca; }
            set { brojStrelaca = value; }
        }

        public int BROJMACEVALACA
        {
            get { return brojMacevalaca; }
            set { brojMacevalaca = value; }
        }

        public int ZID
        {
            get { return zid; }
            set { zid = value; }
        }

        public Point POZICIJA
        {
            get { return pozicija; }
        }

        public double odbrana(double faktor)
        {
            double odbrana = 0;
            odbrana += brojMacevalaca * 1.4;
            odbrana += brojStrelaca * 1.2;
            odbrana += faktorOsvojivosti * faktor;

            return odbrana;
        }

        public void rebuild()
        {
            if(zid < MAX_ZID){
                zid++;
            }
        }

        public void rezultatBorbe(){
            Random rand = new Random();
            brojMacevalaca -= rand.Next(0, brojMacevalaca);
            brojStrelaca -= rand.Next(0, brojStrelaca);
            faktorOsvojivosti++;
            zid -= rand.Next(0, zid);

            if (zid < 2)
            {
                zid = 2;
            }
        }
    }
}
