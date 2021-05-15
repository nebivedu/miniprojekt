# miniprojekt


create or replace function izpisPredstavfinale() 
	returns table (
		idu int,
        ime VARCHAR,
        zvrst VARCHAR,
        datum VARCHAR,
        opis TEXT,
		lokacija VARCHAR
	) 
	language plpgsql
as $$
begin
	return query 
		SELECT 
        p.id,p.ime,p.zvrst,p.datum,p.opis,l.ime
    FROM
        predstave p INNER JOIN lokacije l ON l.id=p.likacija_id;

end;$$

create or replace function izpisPredstavid(idp int) 
	returns table (
		idu int,
        ime VARCHAR,
        zvrst VARCHAR,
        datum VARCHAR,
        opis TEXT,
		lokacija VARCHAR,
		kraj VARCHAR
	) 
	language plpgsql
as $$
begin
	return query 
		SELECT 
        p.id,p.ime,p.zvrst,p.datum,p.opis,l.ime,k.ime
    FROM
        predstave p INNER JOIN lokacije l ON l.id=p.likacija_id INNER JOIN kraji k ON k.id=l.kraj_id
	WHERE p.id=idp;

end;$$

create or replace function izpisPredstavkraj(imek varchar) 
	returns table (
		idu int,
        ime VARCHAR,
        zvrst VARCHAR,
        datum VARCHAR,
        opis TEXT,
		lokacija VARCHAR,
		kraj VARCHAR
	) 
	language plpgsql
as $$
begin
	return query 
		SELECT 
        p.id,p.ime,p.zvrst,p.datum,p.opis,l.ime,k.ime
    FROM
        predstave p INNER JOIN lokacije l ON l.id=p.likacija_id INNER JOIN kraji k ON k.id=l.kraj_id
	WHERE k.ime=imek;

end;$$

create or replace function izpisvsehPredstav() 
    returns table (
        idu int,
        ime VARCHAR,
        zvrst VARCHAR,
        datum VARCHAR,
        opis TEXT,
        lokacija VARCHAR,
        kraj VARCHAR
    ) 
    language plpgsql
as $$
begin
    return query 
        SELECT 
        p.id,p.ime,p.zvrst,p.datum,p.opis,l.ime,k.ime
    FROM
        predstave p INNER JOIN lokacije l ON l.id=p.likacija_id INNER JOIN kraji k ON k.id=l.kraj_id;


end;$$

create or replace function isciPredstavo(neki varchar) 
	returns table (
		idu int,
        ime VARCHAR,
        zvrst VARCHAR,
        datum VARCHAR,
        opis TEXT,
		lokacija VARCHAR,
		kraj VARCHAR
	) 
	language plpgsql
as $$
begin
	return query 
		SELECT 
        p.id,p.ime,p.zvrst,p.datum,p.opis,l.ime,k.ime
    FROM
        predstave p INNER JOIN lokacije l ON l.id=p.likacija_id INNER JOIN kraji k ON k.id=l.kraj_id
	WHERE LOWER(p.ime) LIKE neki OR LOWER(p.zvrst) LIKE neki OR LOWER(p.opis) LIKE neki  OR LOWER(l.ime) LIKE neki  OR LOWER(k.ime) LIKE neki;

end;$$


create or replace function registracija(emaill VARCHAR, gesloo VARCHAR)
DECLARE
BEGIN
INSERT INTO uporabniki(email,geslo) VALUES(emaill,gesloo);
END;

create or replace function iduporabnika(emaill varchar,gesloo varchar) 
    returns table (
        idu int
    ) 
    language plpgsql
as $$
begin
    return query 
        SELECT 
        u.id
    FROM
        uporabniki u 
    WHERE email=emaill AND geslo=gesloo;

end;$$

create or replace function prijava1(emaill varchar,gesloo varchar) 
    returns table (
        idu int
    ) 
    language plpgsql
as $$
begin
    return query 
        SELECT 
        u.id
    FROM
        uporabniki u 
    WHERE email=emaill AND geslo=gesloo;

end;$$


create or replace function emailselect(idu int) 
    returns table (
        email varchar
    ) 
    language plpgsql
as $$
begin
    return query 
        SELECT 
        u.email
    FROM
        uporabniki u 
    WHERE u.id=idu;

end;$$

CREATE OR REPLACE FUNCTION Updatepredstave(idp int,imep varchar,zvrstp varchar,datump varchar,opisp varchar) 
RETURNS void AS $$ DECLARE

BEGIN

UPDATE predstave SET ime=imep,zvrst=zvrstp,datum=datump,opis=opisp  WHERE id = idp;

END; $$ LANGUAGE 'plpgsql';
