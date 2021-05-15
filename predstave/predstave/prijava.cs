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
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                int dela = 0;
                bool lep = false;
                {

                    con.Open();

                    NpgsqlCommand com = new NpgsqlCommand("SELECT prijava('" + email.Text + "','" + geslo.Text + "')", con);
                    NpgsqlDataReader reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        dela = reader.GetInt32(0);
                    }


                    if (dela == 1)
                    {
                        lep =true;
                    }
                    else
                    {
                        lep= false;
                    }
                    con.Close();
                }
            }
        }
    }
}
