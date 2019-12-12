create or replace function fautoinvendor
( param in varchar2)
return varchar2
is
    tempmax varchar2(30) := '';
    hasilakhir varchar2(30) := '';
begin
    select substr(max(Distributor.id_Distributor),4,3) into tempmax from Distributor;
    hasilakhir := 'DIS' || lpad(to_number(tempmax+1),3,'0');
    return hasilakhir;
end;
/
show err;


select fautoinvendor('asdf') from dual;


create or replace function fautoinkontakvendor
( param in varchar2)
return varchar2
is
    tempmax varchar2(30) := '';
    hasilakhir varchar2(30) := '';
begin
    select substr(max(kontak_distributor.id_kontak),4,3) into tempmax from kontak_distributor;
    hasilakhir := 'KDS' || lpad(to_number(tempmax+1),3,'0');
    return hasilakhir;
end;
/
show err;

select fautoinkontakvendor('asdf') from dual;