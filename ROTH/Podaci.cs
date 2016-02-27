using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lavirint;

namespace ROTH
{
    public partial class Podaci : Form
    {
        private static Podaci instance;
        private int strelci = 0;
        private int macevaoci = 0;
        private int exp = 0;
        private int health = 0;
        private String name;

        public static Podaci INSTANCE
        {
            get 
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Podaci();
                }
                return instance;
            }
        }

        public String NAME
        {
            get { return name; }
            set
            {
                name = value;
                label5.Text = name;
            }
        }

        public int STRELCI
        {
            get { return strelci; }
            set { strelci = value; label2.Text = strelci.ToString(); }
        }

        public int MACEVAOCI
        {
            get { return macevaoci; }
            set { macevaoci = value; label1.Text = macevaoci.ToString(); }
        }

        public int EXP
        {
            get { return exp; }
            set { exp = value; zvezde(); }
        }

        public int HEALTH
        {
            get { return health; }
            set { health = value; progressBar1.Value = health; }
        }

        private Podaci()
        {
            InitializeComponent();
        }

        public void zvezde()
        {
            if (exp >= 3 && exp <= 19)
            {
                pictureBox3.Visible = true;
            }
            else if (exp >= 20 && exp <= 29)
            {
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
            }
            else if (exp >= 30 && exp <= 39)
            {
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
            }
            else if (exp >= 40 && exp <= 49)
            {
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;
            }
            else if (exp >= 50)
            {
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
            }
            else
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
            }
        }

        private void Podaci_Load(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
        }
    }
}
