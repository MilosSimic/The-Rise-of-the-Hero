using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using ROTH;

namespace Lavirint
{
    public partial class Main : Form
    {
        private static Main instance = null;

        public Main()
        {
            InitializeComponent();
            //btnLoad_Click(null, null);
            //inicijalizacijaPretrage();
        }

        public static Main INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new Main();
                return instance;
            }
        }

       

        public static State pocetnoStanje = null;
        public static State krajnjeStanje = null;

        private void inicijalizacijaPretrage(AStarSearch astar)
        {
            /*iniccijalizacija pocetnog stanja koje je u svakom potezu trenutna pozicija protivnika*/
            pocetnoStanje = new State();
            //dajem mu poziciju gde se nalazi computer kad je na potezu
            pocetnoStanje.markI = DisplayPanel.INSTANCE.computer.POZICIJA.X;
            pocetnoStanje.markJ = DisplayPanel.INSTANCE.computer.POZICIJA.Y;

            krajnjeStanje = new State();

            astar.search(pocetnoStanje);

            krajnjeStanje.markI = astar.getPoint().X;
            krajnjeStanje.markJ = astar.getPoint().Y;

           
        }

        private void btnPrviUDubinu_Click(object sender, EventArgs e)
        {
            Podaci.INSTANCE.ShowDialog();
        }

        private void btnPrviUSirinu_Click(object sender, EventArgs e)
        {
            
            Podaci2.INSTANCE.ShowDialog();
        }



        private void btnAStar_Click(object sender, EventArgs e)
        {
            inicijalizujAstar();
            MessageBox.Show("Igra je počela!");
        }

        //metoda prima dve int vrednosti
        //1 igra se nova partija
        //2 zavrsava se igra
        public void pobedio(int i)
        {
            if (i == 1)
                System.Windows.Forms.Application.Restart();
            else if (i == 2)
                System.Windows.Forms.Application.Exit();
        }

        public void inicijalizujAstar()
        {
            AStarSearch astar = new AStarSearch();
            /*Inicijalizujem pocetno stanje tako da prima 
             * koordinate kompa koje on ima na pocetku partije (9,9)
             * */
            pocetnoStanje = new State();
            pocetnoStanje.markI = DisplayPanel.INSTANCE.computer.POZICIJA.X;
            pocetnoStanje.markJ = DisplayPanel.INSTANCE.computer.POZICIJA.Y;

            krajnjeStanje = new State();

            State sp = pocetnoStanje;
            State ss = astar.search(pocetnoStanje);

            /* Nakon sto se zavrsi pretraga, krajnjeStanje
                 * dobija koordinate sela koje je najbolje napasti
                 * po heuristickoj funkciji
                 * */

            krajnjeStanje.markI = astar.getPoint().X;
            krajnjeStanje.markJ = astar.getPoint().Y;
            
            State solution = krajnjeStanje;

            inicijalizacijaPretrage(astar);
            
            displayPanel1.Refresh();
        }
    }
}
