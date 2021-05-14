using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predstave
{
    class predstava
    {
        public double Id { get; set; }
        public string Ime { get; set; }
        public string Zvrst { get; set; }
        public string Datum { get; set; }
        public string Opis { get; set; }
        public string Lokacija { get; set; }

        public string Kraj { get; set; }


        public predstava()
        {
        }
        public predstava(int id)
        {
            Id = id;

        }
        public predstava(int id, string ime, string zvrst, string datum, string opis, string lokacija)
        {

            Id = id;
            Ime = ime;
            Zvrst = zvrst;
            Datum = datum;
            Opis = opis;
            Lokacija = lokacija;
            

        }
        public predstava(int id, string ime, string zvrst, string datum, string opis, string lokacija,string kraj)
        {

            Id = id;
            Ime = ime;
            Zvrst = zvrst;
            Datum = datum;
            Opis = opis;
            Lokacija = lokacija;
            Kraj = kraj;


        }

        public override string ToString()
        {
            string vstring = Id + Ime + Zvrst + Datum + Opis + Lokacija;

            return vstring;
        }
    }
}
