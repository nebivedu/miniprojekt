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
using predstave;

namespace predstave
{
    public partial class registracija : Form
    {

        int Idu = 0;
        int Prijavlen = 0;
        public registracija(int idu, int prijavlen)
        {
            InitializeComponent();
            Idu = idu;
            Prijavlen = prijavlen;
        }

        BazaConn baza = new BazaConn();
        string connect = BazaConn.connect();
        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {

                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT registracija('" + email.Text + "','" + geslo.Text + "')", con);
                com.ExecuteNonQuery();

                con.Close();
            }

            
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT iduporabnika('" + email + "','" + geslo + "') ", con);
                NpgsqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);

                    Idu = Id;
                }
                con.Close();
                
            }

            MessageBox.Show(Idu.ToString());
            
            Prijavlen = 1;
            Form1 form1 = new Form1(Idu,Prijavlen);
            this.Hide();
            form1.Show();

        
        }
    }
}
