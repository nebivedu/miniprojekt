﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

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

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM izpisPredstavid(" + id+") ", con);
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
        public void Insertlokacije(string ime, string kraj)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM  Dodajlokacijo('" + ime + "','" + kraj + "')", con);
                com.ExecuteNonQuery();



                con.Close();

            }
        }
        public void Insertpredstave(string ime, string zvrst, string datum, string opis, string lokacija,string kraj)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM  Dodajpredstavo('" + ime + "', '" + zvrst + "', '" + datum + "', '" + opis + "', '" + lokacija + "',' " + kraj + "')", con);
                com.ExecuteNonQuery();



                con.Close();

            }
        }
        public List<predstava> filmocena(int id)
        {
            List<predstava> ocena1 = new List<predstava>();
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM avgocene(" + id+ ") ", con);
                NpgsqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    double Ocena = reader.GetDouble(0);
                    
                    predstava nova = new predstava(Convert.ToInt32(Ocena));
                    ocena1.Add(nova);
                    //MessageBox.Show(Ocena.ToString());
                }
                con.Close();
                return ocena1;
            }
        }
        public void Insertocena(int ocena, int idp,int idu)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                int lol = idp;
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO ocene(ocena, predstava_id, uporabnik_id) VALUES("+ocena+","+idp+","+idu+");", con);
                    com.ExecuteNonQuery();



                con.Close();

            }
        }
        public void deletepredstave(int idp )
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("DELETE FROM ocene WHERE predstava_id=" + idp +"", con);
                com.ExecuteNonQuery();



                con.Close();

            }
        }
        public void deleteocene(int idp)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("DELETE FROM predstave p WHERE p.id=" + idp + "", con);
                com.ExecuteNonQuery();



                con.Close();

            }
        }
        public List<predstava> izpisuserocene(int idu)
        {
            List<predstava> predstave = new List<predstava>();
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM izpisocenjenihuporanik(" + idu + ")  ", con);
                NpgsqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    
                    string Ime = reader.GetString(0);
                    string Zvrst = reader.GetString(1);
                    string Lokacija = reader.GetString(2);
                    string Kraj = reader.GetString(3);
                    int ocena = reader.GetInt32(4);
                    predstava nova = new predstava( Ime, Zvrst, Lokacija, Kraj, ocena);
                    predstave.Add(nova);
                }
                con.Close();
                return predstave;
            }
        }
    }
}
