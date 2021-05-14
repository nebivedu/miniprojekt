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
            List<predstava> predstavas = itemsDatabase.Readknjige();
            foreach (predstava i in predstavas)
            {
                string stat = "";
                if (i.Status == 0)
                {
                    stat = "Izposojeno";
                }
                else
                    stat = "Prosto";

                DataKnjige.Rows.Add(new object[] { i.Inventarna, i.Naslov, i.Avtor, i.Leto, i.Oddelek, i.Zalozba, "Izposodi", stat });
                DataKnjige2.Rows.Add(new object[] { i.Inventarna, i.Naslov, i.Avtor, i.Leto, i.Oddelek, i.Zalozba, stat, "Uredi", "Izbriši" });

            }
            for (int i = 0; i < DataKnjige.Rows.Count; i++)
            {
                string stat = Convert.ToString(DataKnjige.Rows[i].Cells[7].Value);
                if (stat == "Izposojeno")
                {

                    DataKnjige.Rows[i].Cells[7].Style.BackColor = Color.Red;
                    DataKnjige2.Rows[i].Cells[6].Style.BackColor = Color.Red;
                    //DataKnjige.Rows[i].Cells[6].Visible = true;
                }
                else if (stat == "Prosto")
                {
                    DataKnjige.Rows[i].Cells[7].Style.BackColor = Color.Green;
                    DataKnjige2.Rows[i].Cells[6].Style.BackColor = Color.Green;
                    //DataKnjige.Rows[i].Cells[6].ReadOnly = true;

                }

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

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
