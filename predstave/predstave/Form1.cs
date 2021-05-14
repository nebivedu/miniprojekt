using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace predstave
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BazaConn baza = new BazaConn();
        string connect = BazaConn.connect();
        public void lol()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM kraji", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string ime = reader.GetString(1);
                    comboBox1.Items.Add(ime);
                }


                con.Close();
            }
        }
        public void imep()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                List<string> list = new List<string>();
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT ime FROM predstave", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string ime = reader.GetString(0);
                    string izpis = ime ;
                    list.Add(izpis);
                    //listBox1.Items.Add(ime);

                }


                con.Close();
            }
        }
        public void formload()
        {
            datapredstave.Rows.Clear();
            bazasql Baza = new bazasql();
            List<predstava> predstava = Baza.Vsepredstave();

            foreach (predstava i in predstava)
            {

                datapredstave.Rows.Add(new object[] { i.Id, i.Ime, i.Zvrst, i.Datum, i.Opis, i.Lokacija, "Več"});
                

            }
            

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lol();
            imep();
            formload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string id = listBox1.SelectedIndex.ToString();
            //BazaConn baza = new BazaConn();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                
                    vec pod = new vec();
                    pod.ShowDialog();

                
                

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
