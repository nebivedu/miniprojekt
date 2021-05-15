using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace predstave
{
    class bazasql
    {
        BazaConn baza = new BazaConn();
        string connect = BazaConn.connect();
        public List<predstava> Vsepredstave()
        {
            List<predstava> predstave = new List<predstava>();
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM izpisvsehPredstav()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string Ime = reader.GetString(1);
                    string Zvrst = reader.GetString(2);
                    string Datum = reader.GetString(3);
                    string Opis = reader.GetString(4);
                    string Lokacija = reader.GetString(5);
                    string kraj = reader.GetString(6);
                    predstava nova = new predstava(Id, Ime, Zvrst, Datum, Opis, Lokacija, kraj);
                    predstave.Add(nova);
                }
                con.Close();
                return predstave;
            }
        }
        public List<predstava> idpredstave(int id)
        {
            List<predstava> predstave = new List<predstava>();
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM izpisPredstavid("+id+") ", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string Ime = reader.GetString(1);
                    string Zvrst = reader.GetString(2);
                    string Datum = reader.GetString(3);
                    string Opis = reader.GetString(4);
                    string Lokacija = reader.GetString(5);
                    string Kraj = reader.GetString(6);
                    predstava nova = new predstava(Id, Ime, Zvrst, Datum, Opis, Lokacija,Kraj);
                    predstave.Add(nova);
                }
                con.Close();
                return predstave;
            }
        }
        public List<predstava> krajpredstave(string ime)
        {
            List<predstava> predstave = new List<predstava>();
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM izpisPredstavkraj('" + ime + "') ", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                
                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string Ime = reader.GetString(1);
                    string Zvrst = reader.GetString(2);
                    string Datum = reader.GetString(3);
                    string Opis = reader.GetString(4);
                    string Lokacija = reader.GetString(5);
                    string Kraj = reader.GetString(6);
                    predstava nova = new predstava(Id, Ime, Zvrst, Datum, Opis, Lokacija, Kraj);
                    predstave.Add(nova);
                }
                con.Close();
                return predstave;
            }
        }
        public List<predstava> iscipredstavo(string neki)
        {
            List<predstava> predstave = new List<predstava>();
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM isciPredstavo('"+neki+"')  ", con);
                NpgsqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string Ime = reader.GetString(1);
                    string Zvrst = reader.GetString(2);
                    string Datum = reader.GetString(3);
                    string Opis = reader.GetString(4);
                    string Lokacija = reader.GetString(5);
                    string Kraj = reader.GetString(6);
                    predstava nova = new predstava(Id, Ime, Zvrst, Datum, Opis, Lokacija, Kraj);
                    predstave.Add(nova);
                }
                con.Close();
                return predstave;
            }
        }
        public List<uporabnik> iduporabnika(string email,string geslo)
        {
            List<uporabnik> uporabnik = new List<uporabnik>();
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT iduporabnika('"+email+"','"+geslo+"') ", con);
                NpgsqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);

                    uporabnik nova = new uporabnik(Id);
                    uporabnik.Add(nova);
                }
                con.Close();
                return uporabnik;
            }
        }
        public bool Prijava(string emaill, string passwordd)
        {
            int dela = 0;
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {

                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT Prijava1('" + emaill + "','" + passwordd + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    dela = reader.GetInt32(0);
                }


                if (dela > 0)
                {
                    con.Close();
                    return true;

                }
                else
                {
                    con.Close();
                    return false;

                }

            }
        }
        public List<uporabnik> emailuporabnika(int idu)
        {
            List<uporabnik> uporabnik = new List<uporabnik>();
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM emailselect("+idu+") ", con);
                NpgsqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    string Email = reader.GetString(0);

                    uporabnik nova = new uporabnik(Email);
                    uporabnik.Add(nova);
                }
                con.Close();
                return uporabnik;
            }
        }
        public void Updatepredstave(int id, string ime, string zvrst, string datum, string opis)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT Updatepredstave('" + id + "','" + zvrst + "','" + ime + "','" + datum + "', '" + opis + "')", con);
                com.ExecuteNonQuery();



                con.Close();

            }
        }
        public int admin(int idu)
        {
            int uporabnik = 0;
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM adminvprasaj(" + idu + ")", con);
                NpgsqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);

                    uporabnik = id;
                }
                con.Close();
                return uporabnik;
            }
        }
    }
}
