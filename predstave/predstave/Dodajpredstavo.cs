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
    public partial class Dodajpredstavo : Form
    {
        public Dodajpredstavo()
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

        private void Dodajpredstavo_Load(object sender, EventArgs e)
        {
            lol();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kraj = comboBox1.SelectedItem.ToString();
            bazasql Baza = new bazasql();
            Baza.Insertlokacije(lokacija.Text, kraj);
            Baza.Insertpredstave(ime.Text, zvrst.Text, datum.Text, richTextBox1.Text, lokacija.Text, kraj);


        }
    }
}
