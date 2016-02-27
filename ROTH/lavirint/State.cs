using System;
using System.Collections.Generic;
using System.Text;
using ROTF;
using ROTH;

namespace Lavirint
{
    public class State
    {
        public static int brojVrsta = 10;
        public static int brojKolona = 10;
        public static int[,] lavirint;
        public int depth;
        State parent;
        public int markI,markJ;/*markI vrsta,markJ kolona*/
        /*dodato za kutiju*/
        public bool kutija = false;

        /*pravi i uvezuje sledece stanje*/
        public State sledeceStanje(int markI,int markJ)/*kutija dodato da znamo da li smo pokupili stanje da ne ispada vec da svi naslednici imaju*/
        {
            State rez = new State();
            rez.markI = markI;
            rez.markJ = markJ;
            rez.parent = this;/*roditeljsko stanje onaj koji ga je na[ravio*/
           
            return rez;
        }

        /*vracamo listu svih mogucis cvorova u koja mozemo da predjemo specificno za lavirint*/
        public List<State> mogucaSledecaStanja(List<Selo> sela)
        {
            List<State> rez = new List<State>();
            List<Selo> listaSela = sela;

            /*prolazimo kroz celu tabelu i popunjavamo moguca sledeca stanja*/
            foreach(Selo s in listaSela){
                if(s.OSVOJENO==false)
                    rez.Add(sledeceStanje(s.POZICIJA.X, s.POZICIJA.Y));
            }
            return rez;

        }

        /*provera da li je kraj*/
        public bool isKrajnjeStanje()
        {
            return Main.krajnjeStanje.markI==markI && Main.krajnjeStanje.markJ==markJ;
        }

        /*sprecavanje petlji,kretanje u krug necemo da idemo u krug i duzim putevima,
        ne pamtimo stanja u kojima smo bili u hesh tabelu key stanja,
        ako je key tu bio sam vec u tom stablu.Key su kordinate 100*vrsta+kolona jedinstveni int ne 10,
        jer dvocifrene pozicije prave problem,ako imamo trocifrene kolone onda *10000*/
        public override int GetHashCode()/*preklopili smo*/
        {
            //return 100*markI+markJ;
            /*sada su dozvoljene petlje jer mozemo da pokupimo kutju pa da istim putem izadjemo*/
            int kut = 0;
            if (kutija)
            {
                kut = 1000;
            }

            return kut + (100 * markI + markJ);
        }

       
        public List<State> path()
        {
            List<State> putanja = new List<State>();
            State tt = this;
            while (tt != null)
            {
                putanja.Insert(0, tt);
                tt = tt.parent;
            }
            return putanja;
        }

        
    }
}
