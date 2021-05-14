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
    }
}
