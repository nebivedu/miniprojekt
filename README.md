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

create or replace function adminvprasaj(idu int) 
    returns table (
        adminu int
    ) 
    language plpgsql
as $$
begin
    return query 
        SELECT 
        u.adminu
    FROM
        uporabniki u 
    WHERE u.id=idu;

end;$$

create or replace function izpisPredstavid1(idp int) 
	returns table (
		idu int,
        ime VARCHAR,
        zvrst VARCHAR,
        datum VARCHAR,
        opis TEXT,
		lokacija VARCHAR,
		kraj VARCHAR,
		ocena int
	) 
	language plpgsql
as $$
begin
	return query 
		SELECT 
        p.id,p.ime,p.zvrst,p.datum,p.opis,l.ime,k.ime,o.ocena
    FROM
        predstave p INNER JOIN lokacije l ON l.id=p.likacija_id INNER JOIN kraji k ON k.id=l.kraj_id INNER JOIN ocene o ON p.id=o.predstava_id
	WHERE p.id=idp;

end;$$


create or replace function ocenafilma(idp int) 
    returns table (
        
        ocena int
        
    ) 
    language plpgsql
as $$
begin
    return query 
        SELECT 
        o.ocena
    FROM
        predstave p INNER JOIN ocene o ON p.id=o.predstava_id 
    WHERE p.id=idp;

end;$$

CREATE OR REPLACE FUNCTION Updateocena (ocena int, idu int,idp int)
RETURNS void AS $$ DECLARE

BEGIN

UPDATE ocene SET predstava_id = idp WHERE uporabnik_id= idu;

END; $$ LANGUAGE 'plpgsql';

create or replace function ocenafilma5(idp int) 
    returns table (
        ocena float
    ) 
    language plpgsql
as $$
begin
    return query 
        SELECT 
        AVG(o.ocena)
    FROM
        predstave p INNER JOIN ocene o ON p.id=o.predstava_id 
    WHERE p.id=idp;

end;$$

CREATE OR REPLACE FUNCTION avgocene(idp int) 
RETURNS float AS $$ 
DECLARE avrg float; 
BEGIN

SELECT AVG(o.Ocena) INTO avrg FROM ocene o WHERE idp=predstava_id;
RETURN avrg; 
END; $$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION avgocene(idp int) 
RETURNS float AS $$ 
DECLARE avrg float; 
BEGIN

SELECT AVG(o.Ocena) INTO avrg FROM ocene o WHERE idp=predstava_id;
IF(avrg IS null)
	THEN avrg=0;
	END IF;
RETURN avrg; 
END;
$$ LANGUAGE 'plpgsql';


CREATE OR REPLACE FUNCTION izbrispredstave(idp int) 
RETURNS void AS $$ 
DECLARE

BEGIN DELETE FROM predstave p WHERE p.id=idp;

END; $$ LANGUAGE 'plpgsql';


CREATE OR REPLACE FUNCTION izbrisocene(idp int) 
RETURNS void AS $$ 
DECLARE

BEGIN DELETE FROM ocene o WHERE predstava_id=idp;

END; $$ LANGUAGE 'plpgsql';

create or replace function izpisocenjenihuporanik(idu int) 
	returns table (
        ime VARCHAR,
        zvrst VARCHAR,
        lokacija VARCHAR,
        kraj varchar,
		ocena int
	) 
	language plpgsql
as $$
begin
	return query 
		SELECT p.ime,p.zvrst,l.ime,k.ime, o.ocena 
		FROM predstave p INNER JOIN lokacije l ON l.id=p.likacija_id 
		INNER JOIN kraji k ON k.id =l.kraj_id INNER JOIN ocene o ON p.id = o.predstava_id 
		INNER JOIN uporabniki u ON u.id=o.uporabnik_id 
		WHERE u.id=idu;

end;$$
