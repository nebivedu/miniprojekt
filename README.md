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
