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
    public partial class prijava : Form
    {
        public int Idu = 0;
        public int Prijavlen = 0;
        public prijava(int idu, int prijavlen)
        {
            Idu = idu;
            Prijavlen = prijavlen;
            InitializeComponent();
        }
        BazaConn baza = new BazaConn();
        string connect = BazaConn.connect();
        private void button1_Click(object sender, EventArgs e)
        {
            bazasql bazaa = new bazasql();
            string email1 = email.Text;
            string password1 = geslo.Text;
            bool dela = bazaa.Prijava(email1, password1);
            if (dela == true)
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connect))
                {
                    con.Open();

                    NpgsqlCommand com = new NpgsqlCommand("SELECT iduporabnika('" + email.Text + "','" + geslo.Text + "') ", con);
                    NpgsqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(0);

                        Idu = Id;
                    }
                    con.Close();

                }
                //MessageBox.Show(Idu.ToString());
                Prijavlen = 1;
                Form1 lol1 = new Form1(Idu, Prijavlen);
                lol1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Prijava neuspešna");
                email.Clear();
                geslo.Clear();

            }
        }
    }
}
