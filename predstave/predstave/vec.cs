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
    public partial class vec : Form
    {
        int Id;
        int Prijavlen= 0;
        int Idu = 0;
        public vec(int id, int prijavlen,int idu)
        {
            InitializeComponent();
            Id = id;
            Prijavlen = prijavlen;
            Idu = idu;
        }
        public void deli()
        {
            bazasql Baza = new bazasql();
            List<predstava> ocena1 = Baza.filmocena(Id);
            foreach (predstava i in ocena1)
            {

                ocenalabel.Text ="Povprečna ocena: "+ i.Id.ToString();

            }
        }
        public void lol()
        {
            button1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            richTextBox1.Visible = false;
            button2.Visible = false;
            
            textBox5.Enabled = false; textBox4.Enabled = false;
            bazasql Baza = new bazasql();
            List<predstava> predstava = Baza.idpredstave(Id);

            foreach (predstava i in predstava)
            {

                Ime.Text = i.Ime;
                Zvrst.Text = i.Zvrst;
                Datum.Text = i.Datum; 
                opis.Text = i.Opis;
                Lokacija.Text = i.Lokacija;
                Kraj.Text = i.Kraj;
                
            }
            
            
        }

        private void vec_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            comboBox1.Visible = false;
            button4.Visible = false;
            lol();
            deli();
            if(Prijavlen>0)
            {
                button3.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = true;
                bazasql Baza = new bazasql();
                int lol = Baza.admin(Idu);
                //MessageBox.Show(lol.ToString());
                if (lol>0)
                {
                    button1.Enabled = true;
                    button4.Visible = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            richTextBox1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            comboBox1.Visible = true;
            button4.Visible = true;
            textBox5.Enabled = false; textBox4.Enabled = false;

            bazasql Baza = new bazasql();
            List<predstava> predstava = Baza.idpredstave(Id);

            foreach (predstava i in predstava)
            {

                textBox1.Text = i.Ime;
                textBox2.Text = i.Zvrst;
                textBox3.Text = i.Datum;
                richTextBox1.Text = i.Opis;
                textBox4.Text = i.Lokacija;
                textBox5.Text = i.Kraj;
                


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bazasql Baza = new bazasql();
            Baza.Updatepredstave(Id,textBox2.Text, textBox1.Text,textBox3.Text,richTextBox1.Text);
            lol();
            if (Prijavlen > 0)
            {
                button1.Visible = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ocena = comboBox1.SelectedIndex+1;
            MessageBox.Show(ocena.ToString());
            MessageBox.Show(Id.ToString());
            MessageBox.Show(Idu.ToString());
            bazasql Baza = new bazasql();
            Baza.Insertocena(ocena,Id,Idu);
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bazasql Baza = new bazasql();
            Baza.deletepredstave(Id);
            Baza.deleteocene(Id);
            
            
        }
    }
}
