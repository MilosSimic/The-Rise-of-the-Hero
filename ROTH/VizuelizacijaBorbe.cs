using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lavirint;
using ROTF;

namespace ROTH
{
    public partial class VizuelizacijaBorbe : Form
    {
        private int izbrojao = 0;
        private int vreme = 5;
        Hero hero;
        Selo selo;

        public void popuniStatistiku(String statistika)
        {
            label6.Text = statistika;
        }

        public VizuelizacijaBorbe(Hero me,Selo s)
        {
            InitializeComponent();
            button1.Enabled = false;
            button3.Enabled = false;
            progressBar1.Value = 0;
            progressBar1.Maximum = vreme;
            progressBar1.Minimum = 0;

            progressBar2.Value = 0;
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 100;

            String podaciSela = "Naziv:" + s.NAME + "\n" + "Pozicija:" + s.POZICIJA.X + "," + s.POZICIJA.Y + "\n" + "Zid:" + s.ZID + 
                "\n" + "Broj strelaca:" + s.BROJSTRELACA + "\n" + "Broj macevalaca:" + s.BROJMACEVALACA + "\n";
            String podaciHeroja = "Naziv:" + me.NAME + "\n" + "Pozicija:" + me.POZICIJA.X + "," + me.POZICIJA.Y + "\n" + "Zdravlje:" + 
                me.HEALTH + "\n" + "Iskustvo:" + me.EXPERIENCE + "\n" + "Broj strelaca:" + me.BROJSTRELACA + "\n" + "Broj macevalaca:" + me.BROJMACEVALACA + "\n" + "Broj osvojenih sela:" + me.ukupnoOsvojenih();
            label1.Text = me.NAME;
            label2.Text = s.NAME;
            label5.Text = podaciHeroja;
            label4.Text = podaciSela;

            this.hero = me;
            this.selo = s;

            if (selo.OSVOJIO != null)
            {
                lblMasina.Visible = true;
                lblOstali.Visible = false;
            }
            else
            {
                lblMasina.Visible = false;
                lblOstali.Visible = true;
            }
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
                button3.Enabled = false;
                button1.Enabled = true;
                tabControl1.Enabled = true;
                hero.FAKTOR = progressBar2.Value;
                selo.FAKTOR = 60;
                label7.Text = "Borba je zavrsena....";
                DisplayPanel.INSTANCE.borba(ref hero,ref selo,true);
                /*vizuelizacija za heroja....*/
                DisplayPanel.INSTANCE.popuniHeroja();
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar2.Value > 0)
            {
                progressBar2.Value--;
            }
        }
    }
}
