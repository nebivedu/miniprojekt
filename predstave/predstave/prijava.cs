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
        public prijava()
        {
            InitializeComponent();
        }
        BazaConn baza = new BazaConn();
        string connect = BazaConn.connect();
        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {

                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT prijava('" + email.Text + "','" + geslo.Text + "')", con);
                com.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
