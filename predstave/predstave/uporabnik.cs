using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predstave
{
    class uporabnik
    {
        public double Id { get; set; }
        public string Email { get; set; }
        public string Geslo { get; set; }
        public int Admin { get; set; }
       

        public uporabnik()
        {

        }
        public uporabnik(int id)
        {
            Id = id;

        }
        public uporabnik( string email)
        {

           
            Email = email;
           

        }
        public uporabnik(int id, string email, string geslo, int admin)
        {

            Id = id;
            Email = email;
            Geslo = geslo;
            Admin = admin;
           


        }
        

        public override string ToString()
        {
            string vstring = Id + Email + Geslo + Admin ;

            return vstring;
        }
    }
}
