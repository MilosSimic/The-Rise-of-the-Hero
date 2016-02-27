using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Lavirint;
using ROTH;
using ROTF;

namespace Lavirint
{

    public enum Pobednik
    {
        Covek = -1,
        Masina = 1,
        Niko = 0
    }

    public partial class DisplayPanel : UserControl
    {
        public Selo selo1;
        public Selo selo2;
        public Selo selo3;
        public Selo selo4;
        public Selo selo5;
        public Selo selo6;
        public static Point point;
        public State pocetnoStanje;
        public int Rank = 0;

        public static List<Selo> sela = new List<Selo>();

        private static DisplayPanel instance = null;

        private DisplayPanel()
        {
            InitializeComponent();
            State.lavirint = new int[State.brojVrsta,State.brojKolona];
            lavirintPoruke = new String[State.brojVrsta][];
            for (int i = 0; i < State.brojVrsta; i++)
            {
                lavirintPoruke[i] = new String[State.brojKolona];
            }
            icon = ROTH.Properties.Resources.robot2;
            protivnik = ROTH.Properties.Resources.robot;

            me.ICON = icon;
            me.NAPOTEZU = true;

            /*da vizuelizuje podatke*/
            popuniHeroja();
            popuniMasinu();

            computer.ICON = protivnik;
            computer.NAPOTEZU = false;

            List<Point> pozicije = new List<Point>();

            #region SELA
            Point selo1Pozicija = new Point(2,2);
            Point selo2Pozicija = new Point(3, 5);
            Point selo3Pozicija = new Point(5, 9);
            Point selo4Pozicija = new Point(9, 4);
            Point selo5Pozicija = new Point(8, 6);
            Point selo6Pozicija = new Point(4, 4);

            Random random = new Random();

            selo1 = new Selo(10,10,10,selo1Pozicija);
            selo1.NAME = "selo1";
            selo1.FAKTOROSVOJIVOSTI = random.NextDouble()*10;

            selo2 = new Selo(3, 5, 10, selo2Pozicija);
            selo2.NAME = "selo2";
            selo2.FAKTOROSVOJIVOSTI = random.NextDouble()*10;

            selo3 = new Selo(20, 25, 10, selo3Pozicija);
            selo3.NAME = "selo3";
            selo3.FAKTOROSVOJIVOSTI = random.NextDouble()*10;

            selo4 = new Selo(3, 2, 10, selo4Pozicija);
            selo4.NAME = "selo4";
            selo4.FAKTOROSVOJIVOSTI = random.NextDouble()*10;

            selo5 = new Selo(2, 6, 8, selo5Pozicija);
            selo5.NAME = "selo5";
            selo5.FAKTOROSVOJIVOSTI = random.NextDouble()*10;

            selo6 = new Selo(1, 2, 10, selo6Pozicija);
            selo6.NAME = "selo6";
            selo6.FAKTOROSVOJIVOSTI = random.NextDouble()*10;

            State.lavirint[selo1Pozicija.X, selo1Pozicija.Y] = 1;
            InvalidateAdv(selo1Pozicija.X, selo1Pozicija.Y);

            State.lavirint[selo2Pozicija.X, selo2Pozicija.Y] = 1;
            InvalidateAdv(selo2Pozicija.X, selo2Pozicija.Y);

            State.lavirint[selo3Pozicija.X, selo3Pozicija.Y] = 1;
            InvalidateAdv(selo3Pozicija.X, selo3Pozicija.Y);

            State.lavirint[selo4Pozicija.X, selo4Pozicija.Y] = 1;
            InvalidateAdv(selo4Pozicija.X, selo4Pozicija.Y);

            State.lavirint[selo5Pozicija.X, selo5Pozicija.Y] = 1;
            InvalidateAdv(selo5Pozicija.X, selo5Pozicija.Y);

            State.lavirint[selo6Pozicija.X, selo6Pozicija.Y] = 1;
            InvalidateAdv(selo6Pozicija.X, selo6Pozicija.Y);

            sela.Add(selo1);
            sela.Add(selo2);
            sela.Add(selo3);
            sela.Add(selo4);
            sela.Add(selo5);
            sela.Add(selo6);
            #endregion
        }

       
        public void popuniHeroja()
        {
            Podaci.INSTANCE.MACEVAOCI = me.BROJMACEVALACA;
            Podaci.INSTANCE.STRELCI = me.BROJSTRELACA;
            Podaci.INSTANCE.EXP = me.EXPERIENCE;
            Podaci.INSTANCE.HEALTH = me.HEALTH;
            Podaci.INSTANCE.NAME = me.NAME;
        }

        public void popuniMasinu()
        {
            Podaci2.INSTANCE.MACEVAOCI = computer.BROJMACEVALACA;
            Podaci2.INSTANCE.STRELCI = computer.BROJSTRELACA;
            Podaci2.INSTANCE.EXP = computer.EXPERIENCE;
            Podaci2.INSTANCE.HEALTH = computer.HEALTH;
            Podaci2.INSTANCE.NAME = computer.NAME;
        }

        //metoda se poziva iz metode borba, samo ukoliko heroj osvoji selo
        //zaduzena je za evidenciju osvojenih sela, sto od strane ljudskog igraca
        //sto od strane kompjutera
        //sluzi izmedju ostalog da bi na kraju pomogla u proglasenju pobednika
        //na osnovu zauzetih sela
        public void zauzmiSelo(Hero hero, Selo selo)
        {
            foreach (Selo s in me.OSVOJENASELA)
            {

            }
            selo.OSVOJIO = hero;
        }

        public double faktor(int vresnost)
        {
            if (vresnost == 100)
            {
                return 2.0;
            }
            else if (vresnost >= 90 || vresnost < 99)
            {
                return 1.9;
            }
            else if (vresnost >= 80 || vresnost < 89)
            {
                return 1.8;
            }
            else if (vresnost >= 70 || vresnost < 79)
            {
                return 1.7;
            }
            else if (vresnost >= 60 || vresnost < 69)
            {
                return 1.6;
            }
            else if (vresnost >= 50 || vresnost < 59)
            {
                return 1.5;

            }
            else if (vresnost >= 40 || vresnost < 49)
            {
                return 1.4;
            }
            else if (vresnost >= 30 || vresnost < 39)
            {
                return 1.3;
            }
            else if (vresnost >= 20 || vresnost < 29)
            {
                return 1.2;
            }
            else if (vresnost >= 10 || vresnost < 19)
            {
                return 1.1;
            }
            else if (vresnost >= 1 || vresnost < 9)
            {
                return 1.0;
            }

            return 0;
        }


        public void borba2(ref Hero hero, ref Selo selo)
        {
            Random rand = new Random();
            double rezultat = 0;

            rezultat = (hero.napad(1.6) * rand.NextDouble() * 10) - (selo.odbrana(1.6) * rand.NextDouble() * 10);
        
            if (rezultat > 0)
            {
                /*pobeda heroja*/
                hero.rezultatBorbe();
                selo.rezultatBorbe();
                hero.BROJMACEVALACA += selo.BROJMACEVALACA;
                hero.BROJSTRELACA += selo.BROJSTRELACA;

                zauzmiSelo(hero, selo);
                if (me.NAPOTEZU)
                {
                    State.lavirint[selo.POZICIJA.X, selo.POZICIJA.Y] = 2;
                    selo.OSVOJENO = false;
                    selo.OSVOJIO = me;
                    InvalidateAdv(selo.POZICIJA.X, selo.POZICIJA.Y);

                }
                else
                {
                    State.lavirint[selo.POZICIJA.X, selo.POZICIJA.Y] = 3;
                    selo.OSVOJENO = true;
                    selo.OSVOJIO = computer;
                    InvalidateAdv(selo.POZICIJA.X, selo.POZICIJA.Y);
                }
            }
            else
            {
                /*pobeda sela*/
                hero.rezultatBorbe();
                selo.rezultatBorbe();
                selo.rebuild();
            }
            if (proveriKrajIgre())
            {
            }
        }

        public void borba(ref Hero hero,ref Selo selo,bool atc)
        {
            Random rand = new Random();
            double factor = 0;
            double rezultat = 0;

            if (atc)
            {
                factor = faktor(hero.FAKTOR);
                rezultat = (hero.napad(factor) * rand.NextDouble() * 10) - (selo.odbrana(1.6) * rand.NextDouble() * 10);
            }
            else 
            {
                factor = faktor(selo.FAKTOR);
                rezultat = (hero.napad(1.6) * rand.NextDouble() * 10) - (selo.odbrana(factor) * rand.NextDouble() * 10);
            }



            if (rezultat > 0)
            {
                /*pobeda heroja*/
                hero.rezultatBorbe();
                selo.rezultatBorbe();
                hero.BROJMACEVALACA += selo.BROJMACEVALACA;
                hero.BROJSTRELACA += selo.BROJSTRELACA;

                zauzmiSelo(hero, selo);
                if (me.NAPOTEZU)
                {
                    State.lavirint[selo.POZICIJA.X, selo.POZICIJA.Y] = 2;
                    /*Selo s = nadjiSelo(new Pozicija(selo.POZICIJA.X, selo.POZICIJA.Y));
                    roboticOsvojio.Remove(s);
                    sela.Add(s);*/
                    selo.OSVOJENO = false;
                    selo.OSVOJIO = me;
                    /**/
                    InvalidateAdv(selo.POZICIJA.X, selo.POZICIJA.Y);
                    
                }
                else
                {
                    State.lavirint[selo.POZICIJA.X, selo.POZICIJA.Y] = 3;
                    /*Selo s = nadjiSelo(new Pozicija(selo.POZICIJA.X, selo.POZICIJA.Y));
                    roboticOsvojio.Add(s);
                    sela.Remove(s);*/
                    /**/
                    selo.OSVOJENO = true;
                    selo.OSVOJIO = computer;
                    /**/
                    InvalidateAdv(selo.POZICIJA.X, selo.POZICIJA.Y);
                }
            }
            else
            {
                /*pobeda sela*/
                hero.rezultatBorbe();
                selo.rezultatBorbe();
                selo.rebuild();
            }
            if (proveriKrajIgre())
            {
            }
        }

        public static DisplayPanel INSTANCE{
            get
            {
                if (instance == null)
                    instance = new DisplayPanel();
                return instance;
            }
        }

        public String[][] lavirintPoruke;
        public int X, Y;
        public int iconI = 0;
        public int iconJ = 0;
        Image icon = null;
        Image protivnik = null;
        public Hero me = new Hero(1000,1010,new Pozicija(0,0), "HUMAN");
        public Hero computer = new Hero(100, 100, new Pozicija(9, 9), "COMPUTER");
        public static Hero prosledjujemUSearch = null;

        public int protivnikI = State.brojVrsta - 1;
        public int protivnikJ = State.brojKolona - 1;

        //klik na selo
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int eX = e.X;
            int eY = e.Y;
            Rectangle rec = this.ClientRectangle;
            int width = rec.Width;
            int height = rec.Height;
            int dx = (int)(width / State.brojKolona);
            int dy = (int)(height / State.brojVrsta);

            int j = eX / dx;
            int i = eY / dy;
            Point tempPozcijaSela = new Point(i,j);

            popuniHeroja();
            popuniMasinu();

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                moveIcon(i, j);
                foreach (Selo s in sela)
                {
                    if (s.POZICIJA.X == me.POZICIJA.X && s.POZICIJA.Y == me.POZICIJA.Y)
                    {
                        if (s.OSVOJIO == null || !s.OSVOJIO.Equals(me))
                        {
                            VizuelizacijaBorbe vb = new VizuelizacijaBorbe(me, s);
                            vb.Show();
                            return;
                        }
                    }
                }
            }
            else
            {
                foreach (Selo s in sela)
                {
                    if (s.POZICIJA.Equals(tempPozcijaSela))
                    {
                        String stampa = "Ime:" + s.NAME + "\n" + "Broj strelaca:" + s.BROJSTRELACA + "\n" + "Broj macevalaca:" + s.BROJMACEVALACA + "\n" + "Zid:" + s.ZID;
                        MessageBox.Show(stampa);
                    }
                }
            }

        }

        public Selo nadjiSelo(Pozicija pozicija)
        {
            foreach (Selo s in sela)
            {
                if (s.POZICIJA.X == pozicija.X && s.POZICIJA.Y == pozicija.Y)
                {
                    return s;
                }
            }

            return null;
        }

        //Metoda proverava da li se doslo do kraja partije
        //odnosno da li su sva sela osvojena
        //poziva se nakon svakog odigranog poteza
        private bool proveriKrajIgre()
        {
            bool flag = false;
            foreach (Selo selo in sela)
            {
                if (State.lavirint[selo.POZICIJA.X, selo.POZICIJA.Y] == 1)
                    return false;
            }
            //return true;
            flag = true;
            if (flag)
            {
                //Main.INSTANCE.pobedio();
                int brSelaIgrac = 0;
                int brSelaKomp = 0;
                foreach (Selo s in sela)
                {
                    if (s.OSVOJIO.NAME.Equals(me.NAME))
                    {
                        brSelaIgrac++;
                    }
                    else
                        brSelaKomp++;
                }

                String pobednik = "";
                if (brSelaIgrac == brSelaKomp)
                {
                    pobednik = "Partija je neresna!";
                }
                else if (brSelaIgrac > brSelaKomp)
                {
                    pobednik = "Pobednik je Igrac!";
                }
                else
                {
                    pobednik = "Pobednik je kompjuter!";
                }
                String krajIgre = "Igra se zavrsila " + "\n";
                       krajIgre += "Igrac je osvojio: " + brSelaIgrac + "\n";
                       krajIgre += "Kompjuter je osvojio: " + brSelaKomp + "\n";
                       krajIgre+=  pobednik + "\n";
                       krajIgre += "Zelite li novu partiju?";
                if (MessageBox.Show(krajIgre, "Obavestenje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Main.INSTANCE.pobedio(1);
                }
                else
                {
                    Main.INSTANCE.pobedio(2);
                }
                
                
            }
            return true;
        }

        //pomeranje heroja
        public void moveIcon(int dI, int dJ)
        {
            popuniHeroja();
            popuniMasinu();
            if (me.NAPOTEZU)
            {
                int staraPozicijaX = me.POZICIJA.X;
                int staraPozicijaY = me.POZICIJA.Y;

                me.pomeri(new Pozicija(dI, dJ));
                me.NAPOTEZU = false;
                computer.NAPOTEZU = true;
                
                InvalidateAdv(me.POZICIJA.X, me.POZICIJA.Y);
                InvalidateAdv(staraPozicijaX, staraPozicijaY);
            }
            if (computer.NAPOTEZU)
            {
                int staraPozicijaX = computer.POZICIJA.X;
                int staraPozicijaY = computer.POZICIJA.Y;

                /*svaki put kad je komp na potezu radi se pretraga 
                 * da se utvrdi koje selo je najbolje napasti
                 * */
                AStarSearch pretraga = new AStarSearch();
                /*pocetnoStanje dobija koordinate trenutne pozicije
                 * komp-a
                 * */
                pocetnoStanje = new State();
                pocetnoStanje.markI = computer.POZICIJA.X;
                pocetnoStanje.markJ = computer.POZICIJA.Y;

                /*Prosledjuje se pocetno stanje, da bi se 
                 * odredilo koje je najbolje sledece stanje
                 * */
                State najbolje = pretraga.search(pocetnoStanje);

                /* Nakon sto se zavrsi pretraga, krajnjeStanje
                 * dobija koordinate sela koje je najbolje napasti
                 * po heuristickoj funkciji
                 * */
                State krajnjeStanje = new State();
                krajnjeStanje.markI = pretraga.getPoint().X;
                krajnjeStanje.markJ = pretraga.getPoint().Y;
       
                if(krajnjeStanje.markI == computer.POZICIJA.X && krajnjeStanje.markJ == computer.POZICIJA.Y)
                {
                    /*ova metoda vrsi borbu kompjutera kada dodje do ciljnog sela*/
                    Selo temp = nadjiSelo(new Pozicija(krajnjeStanje.markI,krajnjeStanje.markJ));

                    if (temp != null)
                    {
                        if (temp.OSVOJIO != null && temp.OSVOJIO.Equals(me))
                        {
                            Form1 fm1 = new Form1(computer, temp);
                            fm1.ShowDialog();
                        }
                        else
                        {
                            borba2(ref computer, ref temp);
                        }
                    }
                }

                /*Komp se pomera u pravcu sela
                 * */
                computer.pomeri(new Pozicija(krajnjeStanje.markI, krajnjeStanje.markJ));

                /*Nakon sto se pomeri za odredjen broj mesta,
                 * komp nije vise na potezu
                 * */
                computer.NAPOTEZU = false;
                me.NAPOTEZU = true;

                /*Brise se ikonica na staroj poziciji i iscrtava na novoj
                 * */
                InvalidateAdv(computer.POZICIJA.X, computer.POZICIJA.Y);
                InvalidateAdv(staraPozicijaX, staraPozicijaY);
            }

        }

        #region USED FUNCTIONS

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            lavirintPoruke[iconI][iconJ] = lavirintPoruke[iconI][iconJ] + e.KeyChar;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyData == Keys.Back) {
                int n = lavirintPoruke[iconI][iconJ].Length;
                if(n > 1){
                    lavirintPoruke[iconI][iconJ] = lavirintPoruke[iconI][iconJ].Substring(0, n - 2); 
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                moveIcon(0, -1);
                return true;
            }
            else if (keyData == Keys.Right)
            {
                moveIcon(0, 1);
                return true;
            }
            else if (keyData == Keys.Down)
            {
                moveIcon(1, 0);
                return true;
            }
            else if (keyData == Keys.Up)
            {
                moveIcon(-1, 0);
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public void move(int i, int j)
        {
            moveIcon(i, j);
        }

        public void InvalidateAdv(int i, int j)
        {
            Rectangle rec = this.ClientRectangle;
            int width = rec.Width;
            int height = rec.Height;
            int dx = (int)(width / State.brojKolona);
            int dy = (int)(height / State.brojVrsta);
            Rectangle tt1 = new Rectangle(j * dx, i * dy, dx, dy);
            this.Invalidate(tt1);
        }

        public void resetLavirintPoruke()
        {
            lavirintPoruke = new String[State.brojVrsta][];
            for (int i = 0; i < State.brojVrsta; i++)
            {
                lavirintPoruke[i] = new String[State.brojKolona];
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics gr = e.Graphics;
            gr.FillRectangle(Brushes.White, this.ClientRectangle);

            Rectangle rec = this.ClientRectangle;

            // nacrtaj grid
            int width = rec.Width;
            int height = rec.Height;
            int dx = (int)(width / State.brojKolona);
            int dy = (int)(height / State.brojVrsta);

            for (int j = 0; j < State.brojKolona; j++)
            {
                Color c = Color.FromArgb(40, Color.Gray);
                int xx = dx * j;
                int y0 = 0;
                int yH = height;
                gr.DrawLine(new Pen(c), xx, y0, xx, yH);
            }
            for (int i = 0; i < State.brojVrsta; i++)
            {
                Color c = Color.FromArgb(40, Color.Gray);
                int yy = dy * i;
                int x0 = 0;
                int xH = width;
                gr.DrawLine(new Pen(c), x0, yy, xH, yy);
            }

            for (int i = 0; i < State.brojVrsta; i++)
            {
                for (int j = 0; j < State.brojKolona; j++)
                {
                    int xx = (int)(dx / 2) + dx * j;
                    int yy = (int)(dy / 2) + dy * i;

                    Font f = new Font(FontFamily.GenericSerif, 8);
                    Rectangle r = new Rectangle(dx * j + 2, dy * i + 2, dx - 4, dy - 4);
                    Color cc1 = Color.FromArgb(100, Color.White);
                    Color cc2 = Color.FromArgb(100, Color.White);
                    if (i == X && j == Y)
                    {
                        cc1 = Color.FromArgb(100, Color.YellowGreen);
                        cc2 = Color.FromArgb(20, Color.YellowGreen);
                    }
                    int tt = State.lavirint[i, j];
                    switch (tt)
                    {
                        case 1:
                            cc2 = Color.FromArgb(100, Color.Gray);
                            break;
                        case 2:
                            cc2 = Color.FromArgb(100, Color.Green);
                            break;
                        case 3:
                            cc2 = Color.FromArgb(100, Color.Red);
                            break;
                        /*ja dodao ovo je kutija i crta se ovom bojom*/
                        case 4:
                            cc2 = Color.FromArgb(100, Color.Blue);
                            break;
                    }
                    String ttS = lavirintPoruke[i][j];
                    gr.FillRectangle(new SolidBrush(cc2), r);
                    gr.DrawRectangle(new Pen(cc1, 2), r);
                    SizeF sf = gr.MeasureString("" + ttS, f);
                    gr.DrawString("" + ttS, f, Brushes.Black, xx - sf.Width / 2, yy - sf.Height / 2);
                }
            }

            // nacrtati iconu
            gr.DrawImage(me.ICON, dx * me.POZICIJA.Y + dx / 2 - icon.Width / 2, dy * me.POZICIJA.X + dy / 2 - icon.Height / 2);
            gr.DrawImage(computer.ICON, dx * computer.POZICIJA.Y + dx / 2 - protivnik.Width / 2, dy * computer.POZICIJA.X + dy / 2 - protivnik.Height / 2);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int eX = e.X;
            int eY = e.Y;
            Rectangle rec = this.ClientRectangle;
            int width = rec.Width;
            int height = rec.Height;
            int dx = (int)(width / State.brojKolona);
            int dy = (int)(height / State.brojVrsta);

            int j = eX / dx;
            int i = eY / dy;

            if (X != i || Y != j)
            {
                int sX = X;
                int sY = Y;
                X = i;
                Y = j;
                InvalidateAdv(X, Y);
                InvalidateAdv(sX, sY);
            }
        }
    }
#endregion
}
