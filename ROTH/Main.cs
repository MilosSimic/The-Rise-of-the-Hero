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

namespace Lavirint
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            //MessageBox.Show("nesto");
            //btnLoad_Click(null, null);
          
            inicijalizacijaPretrage();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            TextWriter tw = new StreamWriter("../../lavirint.txt");
           
            tw.WriteLine(State.brojKolona);
            tw.WriteLine(State.brojVrsta);
            for (int i = 0; i < State.brojVrsta; i++)
            {
                for (int j = 0; j < State.brojKolona; j++)
                {
                    tw.WriteLine(State.lavirint[i,j]);
                }
            }
            tw.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {            
            TextReader tw = new StreamReader("../../lavirint.txt");
            this.SuspendLayout();
            State.brojKolona = Convert.ToInt32(tw.ReadLine());
            State.brojVrsta = Convert.ToInt32(tw.ReadLine());
            for (int i = 0; i < State.brojVrsta; i++)
            {
                for (int j = 0; j < State.brojKolona; j++)
                {
                    int tt = Convert.ToInt32(tw.ReadLine());
                    State.lavirint[i,j] = tt;
                }
            }
            tw.Close();
            this.ResumeLayout(false);
            displayPanel1.Refresh();
        }

        public static State pocetnoStanje = null;
        public static State krajnjeStanje = null;
        
        private void inicijalizacijaPretrage() {
            displayPanel1.resetLavirintPoruke();
            for (int i = 0; i < State.brojVrsta; i++)
            {
                for (int j = 0; j < State.brojKolona; j++)
                {
                    int tt = State.lavirint[i,j];
                    if (tt == 2) { // POCETNO STANJE
                        pocetnoStanje = new State();
                        pocetnoStanje.markI = i;
                        pocetnoStanje.markJ = j;
                        displayPanel1.iconI = i;
                        displayPanel1.iconJ = j;
                    }else if (tt == 3)
                    { // KRAJNJE STANJE
                        krajnjeStanje = new State();
                        krajnjeStanje.markI = i;
                        krajnjeStanje.markJ = j;
                    }
                }
            }
        }

        List<State> resenje = new List<State>();
        private void btnResenje_Click(object sender, EventArgs e)
        {
            displayPanel1.resetLavirintPoruke();
            // nacrtati resenje
            int i = 0;
            foreach (State r in resenje)
            {
                displayPanel1.lavirintPoruke[r.markI][r.markJ] = "" + i;
                i++;
            }
            displayPanel1.Refresh();
        }

        private void btnPrviUDubinu_Click(object sender, EventArgs e)
        {
            inicijalizacijaPretrage();
            DeepFirstSearch dfs = new DeepFirstSearch();
            State sp = pocetnoStanje;
            State solution = dfs.search(sp);
            if (solution != null)
            {
                resenje = solution.path();
            }
            displayPanel1.Refresh();
        }

        private void btnPrviUSirinu_Click(object sender, EventArgs e)
        {
            inicijalizacijaPretrage();
            BreadthFirstSearch bfs = new BreadthFirstSearch();
            State sp = pocetnoStanje;
            State solution = bfs.search(sp);
            if (solution != null)
            {
                resenje = solution.path();
            }
            displayPanel1.Refresh();
        }

        private void btnIterativniPrviUDubinu_Click(object sender, EventArgs e)
        {
            inicijalizacijaPretrage();
            IterativeDeepFirstSeach id = new IterativeDeepFirstSeach();
            State s = pocetnoStanje;
            //s.depth = 0;
            for (int i = 0; i < 40; i++)
            {
                State solution = id.search(s, i);
                if (solution != null)
                {
                    resenje = solution.path();
                    displayPanel1.Refresh();
                    return;
                }
            }
            displayPanel1.Refresh();
          

        }

        private void btnBidirekciono_Click(object sender, EventArgs e)
        {
            inicijalizacijaPretrage();
            BiDirectinal bfs = new BiDirectinal();
            State sp = pocetnoStanje;
            List<State> solution = bfs.search(sp);
            if (solution != null)
            {
                resenje = solution[1].path();
                resenje.AddRange(solution[0].path());
            }
            displayPanel1.Refresh();
        }

        private void btnAStar_Click(object sender, EventArgs e)
        {
            inicijalizacijaPretrage();
            AStarSearch astar = new AStarSearch();
            State sp = pocetnoStanje;
            State solution = astar.search(sp);
            if (solution != null)
            {
                resenje = solution.path();
            }
            displayPanel1.Refresh();
        }
    }
}
