using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ROTF;
using Lavirint;

namespace ROTH
{
    public partial class Form1 : Form
    {
        private int izbrojao = 0;
        private int vreme = 5;
        Hero hero;
        Selo selo;

        public void popuniStatistiku(String statistika)
        {
            label6.Text = statistika;
        }

        public Form1(Hero me, Selo s)
        {
            InitializeComponent();
            button1.Enabled = false;
            button3.Enabled = false;
            progressBar1.Value = 0;
            progressBar1.Maximum = vreme;
            progressBar1.Minimum = 0;

            this.hero = me;
            this.selo = s;
            
            /*neka ogranicenja...*/
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 100;

            button3.Click += new EventHandler(button3_Click);
            timer1.Tick+=new EventHandler(timer1_Tick);

            progressBar1.Value = 0;
            progressBar2.Value = 0;

            String podaciSela = "Naziv:" + s.NAME + "\n" + "Pozicija:" + s.POZICIJA.X + "," + s.POZICIJA.Y + "\n" + "Zid:" + s.ZID +
                "\n" + "Broj strelaca:" + s.BROJSTRELACA + "\n" + "Broj macevalaca:" + s.BROJMACEVALACA + "\n";
            String podaciHeroja = "Naziv:" + me.NAME + "\n" + "Pozicija:" + me.POZICIJA.X + "," + me.POZICIJA.Y + "\n" + "Zdravlje:" +
                me.HEALTH + "\n" + "Iskustvo:" + me.EXPERIENCE + "\n" + "Broj strelaca:" + s.BROJSTRELACA + "\n" + "Broj macevalaca:" + me.BROJMACEVALACA + "\n" + "Broj osvojenih sela:" + me.ukupnoOsvojenih();

            label1.Text = me.NAME;
            label2.Text = s.NAME;
            label5.Text = podaciHeroja;
            label4.Text = podaciSela;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (izbrojao == vreme)
            {
                timer1.Stop();
                timer2.Stop();
                button1.Enabled = true;
                tabControl1.Enabled = true;
                button3.Enabled = false;
                selo.FAKTOR = progressBar2.Value;
                hero.FAKTOR = 60;
                label7.Text = "Borba je zavrsena....";
                //MessageBox.Show(progressBar2.Value.ToString());
                DisplayPanel.INSTANCE.borba(ref hero, ref selo,false);
                DisplayPanel.INSTANCE.popuniMasinu();
            }
            else
            {
                izbrojao++;
                progressBar1.Value = izbrojao;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            button2.Enabled = false;
            button3.Enabled = true;
            label7.Text = "Borba je u toku...";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (progressBar2.Value < progressBar2.Maximum)
            {
                progressBar2.Value++;
            }
            
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        
        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            button2.Enabled = false;
            button3.Enabled = true;
            label7.Text = "Borba je u toku...";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (progressBar2.Value < progressBar2.Maximum)
            {
                progressBar2.Value++;
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (progressBar2.Value > 0)
            {
                progressBar2.Value--;
            }
        }
    }
    
}
