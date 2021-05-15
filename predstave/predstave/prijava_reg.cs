using System;
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
    public partial class prijava_reg : Form
    {
        int Idu = 0;
        int Prijavlen = 0;
        public prijava_reg(int idu,int prijavlen)
        {
            InitializeComponent();
            Idu = idu;
            Prijavlen = prijavlen;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            registracija form3 = new registracija(Idu, Prijavlen);
            this.Close();
            form3.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            prijava form4 = new prijava(Idu,Prijavlen);
            this.Hide();
            form4.Show();
        }
    }
}
