﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace predstave
{
    public partial class profile : Form
    {
        public int Idu = 0;
        public int Prijavlen = 0;
        public profile(int idu, int prijavlen)
        {
            Idu = idu;
            Prijavlen = prijavlen;
            InitializeComponent();
        }

        private void profile_Load(object sender, EventArgs e)
        {
            bazasql Baza = new bazasql();
            List<uporabnik> upobnik= Baza.emailuporabnika(Idu);
            foreach (uporabnik i in upobnik)
            {

                label2.Text = i.Email;

            }
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prijavlen = 0;
            Form1 form2 = new Form1(Idu, Prijavlen);
            this.Close();
            form2.Show();
        }
    }
}
