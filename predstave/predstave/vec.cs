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
    public partial class vec : Form
    {
        int Id;
        public vec(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void vec_Load(object sender, EventArgs e)
        {
            
            bazasql Baza = new bazasql();
            List<predstava> predstava = Baza.idpredstave(Id);

            foreach (predstava i in predstava)
            {

                label1.Text = i.Ime;
                label2.Text = i.Zvrst;
                label3.Text = i.Opis;
                label4.Text = i.Datum;
                label5.Text = i.Kraj;
            }
        }
    }
}
