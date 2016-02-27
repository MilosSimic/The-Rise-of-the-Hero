using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROTH;
using System.Drawing;



    namespace ROTF
    {

        public struct Pozicija
        {
            public int X;
            public int Y;

            public Pozicija(int x, int y) { 
                X = x; 
                Y = y; 
            }
        }

        public class Hero
        {
            /*ime heroja*/
            private String Name;
            /*koliko ima helta*/
            private int Health;
            /*koliko ima exp-a*/
            private int Experience;
            /*broj boraca i njihove osobine*/
            private Borci borci;
            private int brojMacevalaca;
            private int brojStrelaca;
            private Pozicija pozicijaHeroja;
            Image icon;
            bool naPotezu;
            const int MAX_BROJ_POMERAJA = 3;
            /*spisak sela koja je osvojio*/
            List<Selo> osvojenaSela;
            private int faktor;

            public Hero(int bs, int bm, Pozicija pozicija, String name)
            {
                brojStrelaca = bs;
                brojMacevalaca = bm;
                Health = 100;
                Experience = 0;
                pozicijaHeroja = pozicija;
                borci = new Borci(brojStrelaca, brojMacevalaca);
                osvojenaSela = new List<Selo>();
                this.Name = name;
            }

            public int FAKTOR
            {
                get { return faktor; }
                set { faktor = value; }
            }

            public List<Selo> OSVOJENASELA
            {
                get { return osvojenaSela; }
            }

            public void osvojenoSelo(Selo osvojeno)
            {
                if (!osvojenaSela.Contains(osvojeno))
                {
                    osvojenaSela.Add(osvojeno);
                }
            }

            public void izgubljenoSelo(Selo izgubljeno)
            {
                if (osvojenaSela.Contains(izgubljeno))
                {
                    osvojenaSela.Remove(izgubljeno);
                }
            }

            public int ukupnoOsvojenih()
            {
                return osvojenaSela.Count;
            }

            public bool NAPOTEZU
            {
                get { return naPotezu; }
                set { naPotezu = value; }
            }


            public Image ICON
            {
                get { return icon; }
                set { icon = value; }
            }

            public Pozicija POZICIJA
            {
                get { return pozicijaHeroja; }
                set { pozicijaHeroja = value; }
            }

            public String NAME
            {
                get { return Name; }
                set { Name = value; }
            }

            public int HEALTH
            {
                get { return Health; }
                set { Health = value; }
            }

            public int EXPERIENCE
            {
                get { return Experience; }
                set { Experience = value; }
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

            public void pomeri(Pozicija zeljenaPozicija)
            {
                int pomereno = 0;
                int zadanaHorizontalna = zeljenaPozicija.X;
                int zadanaVertikalna = zeljenaPozicija.Y;
                int mogucaHorizontalna = 0;
                int mogucaVertikalna = 0;
 
                //Opisivanje kretanja heroja
                //Prilikom svakog kretanja heroj ce prvo odraditi maksimalni broj po horizontali(odnosno po horizontalnim gridovima)
                //pa tek onda po vertikali koliko mu preostane poteza
 
                //brojPomeraja(horizontalni) predstavlja ukupnu razdaljinu od
                //mesta gde se nalazi heroj pa do mesta gde je korisnik kliknuo
                //ukoliko je to vise od MAX_BROJ_POMERAJA, vrsi se skaliranje odnosno ne
                //dozovoljava se vise od toga
 
                if (pozicijaHeroja.X != zadanaHorizontalna)
                {
                    int brojPomeraja = Math.Abs(pozicijaHeroja.X - zadanaHorizontalna);
                    if (brojPomeraja >= MAX_BROJ_POMERAJA)
                        brojPomeraja = MAX_BROJ_POMERAJA;
 
                    //predstavlja smer u kome ce se kretati heroj na mapi
                    int horizontalniPomerajHeroja = pozicijaHeroja.X - zadanaHorizontalna;
                    if (horizontalniPomerajHeroja < 0)
                    {
                        mogucaHorizontalna = pozicijaHeroja.X + brojPomeraja;
                        pomereno = brojPomeraja;
                    }
                    else
                    {
                        mogucaHorizontalna = pozicijaHeroja.X - brojPomeraja;
                        pomereno = brojPomeraja;
                    }
                }
                else
                {
                    mogucaHorizontalna = zadanaHorizontalna;
                }
 
 
 
                if (pozicijaHeroja.Y != zadanaVertikalna)
                {
                    int brojPomeraja = Math.Abs(pozicijaHeroja.Y - zadanaVertikalna);
                    if (brojPomeraja >= MAX_BROJ_POMERAJA)
                        brojPomeraja = MAX_BROJ_POMERAJA;
 
                    int brojDozvoljenihPoteza = MAX_BROJ_POMERAJA - pomereno;
 
                    if (brojPomeraja > brojDozvoljenihPoteza)
                        brojPomeraja = brojDozvoljenihPoteza;
 
                    if (pomereno < MAX_BROJ_POMERAJA)
                    {
                        int vertikalniPomerajHeroja = pozicijaHeroja.Y - zadanaVertikalna;
                        if (vertikalniPomerajHeroja < 0)
                        {
                            mogucaVertikalna = pozicijaHeroja.Y + brojPomeraja;
                        }
                        else
                        {
                            mogucaVertikalna = pozicijaHeroja.Y - brojPomeraja;
                        }
                    }
                    else
                    {
                        mogucaVertikalna = pozicijaHeroja.Y;
                    }
                }
                else
                {
                    mogucaVertikalna = pozicijaHeroja.Y;
                }
 
 
                pozicijaHeroja.X = mogucaHorizontalna;
                pozicijaHeroja.Y = mogucaVertikalna;

                /*
                int sIconI = pozicijaHeroja.X;
                int sIconJ = pozicijaHeroja.Y;
                // ovaj deo je da se spreci prolazak kroz zidove
                if (State.lavirint[mogucaHorizontalna, mogucaVertikalna] != 1)
                {
                    //MessageBox.Show("uso");
                    pozicijaHerojaI = mogucaHorizontalna;
                    pozicijaHerojaJ = mogucaVertikalna;
                    InvalidateAdv(pozicijaHerojaI, pozicijaHerojaJ);
                    InvalidateAdv(sIconI, sIconJ);
                }
                else
                {
                    MessageBox.Show("Heroj ne moze stati na neosvojeno sela!");
                }
                 * */
                
            }

            public double napad(double faktor)
            {
                double napad = 0;
                napad += brojMacevalaca * 1.4;
                napad += brojStrelaca * 1.2;
                napad += Experience * faktor;

                return napad;
            }

            public void rezultatBorbe()
            {
                Random rand = new Random();
                brojMacevalaca -= rand.Next(0, brojMacevalaca);
                brojStrelaca -= rand.Next(0, brojStrelaca);
                Experience++;
                Health -= rand.Next(0,Health);

                if(Health < 10){
                    Health = 10;
                }
            }

            public bool sadrzi(Selo s)
            {
                if (osvojenaSela.Contains(s))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }


