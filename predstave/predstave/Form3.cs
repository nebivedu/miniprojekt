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
    public partial class Form3 : Form
    {
        

        public Form3()
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

                NpgsqlCommand com = new NpgsqlCommand("SELECT registracija('" + email.Text + "','" + geslo.Text + "')", con);
                com.ExecuteNonQuery();

                con.Close();
            }
            
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        
        }
    }
}
