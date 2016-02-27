using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ROTH;
using System.Drawing;
using System.Windows.Forms;

namespace Lavirint
{
    class AStarSearch
    {
        Point point = new Point();
        /**/

        //Search setuje vrednost pointa 
        //koji odredjuje na osnovu heuristike koje 
        //ce biti zadnje stanje
        public State search(State pocetnoStanje)
        {
            /*lista stanja za obradu*/
            List<State> stanjaZaObradu = new List<State>();
            /*napravimo hash tabelu nacin da pamtimo predjen put*/
            Hashtable predjeniPut = new Hashtable();
            /*ubacimo pocetno stanje u stanje za obradu i pustimo algoritam*/
            stanjaZaObradu.Add(pocetnoStanje);
            /*radimo dok ima nesto da se obradi*/
            while (stanjaZaObradu.Count > 0)
            {
                /*stanje na obradi*/
                /*od svih stanja odaberi najbolji...*/
                State naObradi = getBest(stanjaZaObradu);

                /*proverimo da li smo prosli kroz njega,da li sam vec bio ovde ako nismo dodamo naslednike*/
                if (!predjeniPut.ContainsKey(naObradi.GetHashCode()))
                {
                    predjeniPut.Add(naObradi.GetHashCode(), null);/*null jer ne cuvamo stanja*/
                    /*uzmemo naslednike*/
                    List<State> sledecaStanja = naObradi.mogucaSledecaStanja(DisplayPanel.sela);

                    /*uzmemo svako naslednika i dodamo u stanje za obradu*/
                    foreach (State s in sledecaStanja)
                    {
                        stanjaZaObradu.Add(s);
                        // MessageBox.Show("stanja:" + s.markI + " " + s.markJ);
                    }

                }

                stanjaZaObradu.Remove(naObradi);
            }
           
            return null;
        }

        /*Heuristicka funkcija*/
        public double heuristicalStateFunction(State s)
        {
            foreach (Selo temp in DisplayPanel.sela)
            {
                if (temp != null)
                    temp.HEURISTIKA = ((temp.BROJSTRELACA + temp.BROJMACEVALACA + temp.ZID) / 10) + temp.FAKTOROSVOJIVOSTI;
            }

            //pocetne vrednosti
            double rez = DisplayPanel.sela[0].HEURISTIKA;
            point.X = DisplayPanel.sela[0].POZICIJA.X;
            point.Y = DisplayPanel.sela[0].POZICIJA.Y;

            foreach (Selo temp in DisplayPanel.sela)
            {
                if (temp.HEURISTIKA < rez && temp.OSVOJENO == false)
                {
                    rez = temp.HEURISTIKA;
                    point.X = temp.POZICIJA.X;
                    point.Y = temp.POZICIJA.Y;
                }
            }
            
            return rez;
        }

        public Point getPoint()
        {
            return point;
        }

        /*funkcija koja iz liste uzima najbolji po heuristickoj funkciji*/
        public State getBest(List<State> stanja)
        {
            State rez=null;/*za slucaj da nema nicega,indikator da ne valja nesto*/
            /*trazimo najbolji minimum*/
            double min = Double.MaxValue;/*svaki sledeci broj ce biti od njega jer je ovo neka ogromna vrednost a 
                                        * svaki sledeci ce to pregaziti*/

            /*kroz sva stanja i naci najbolje po heuristickoj funkciji*/
            foreach (State s in stanja)
            {
                
                double h = heuristicalStateFunction(s);
                if (h < min)
                {
                    min = h;
                    rez = s;
                }
            }
            return rez;
        }
    }
}
