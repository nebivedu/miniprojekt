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
    public partial class profile : Form
    {
        public int Idu = 0;
        public int Prijavlen = 0;
        public profile(int idu, int prijavlen)
        {
            Idu = idu;
            Prijavlen = prijavlen;
            InitializeComponent();
        }

        private void profile_Load(object sender, EventArgs e)
        {

        }
    }
}
