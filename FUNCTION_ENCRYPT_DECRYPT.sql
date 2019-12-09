
---login system dulu  
conn sys as 123 --- habis gitu masukkan password system 
grant execute on dbms_crypto to public;

---conn ke user punya kalian yang buat ngerjakan project ini

--- load database yang lama

---- copy bagian ini sampai bawah
    
CREATE OR REPLACE FUNCTION my_encrypt(
    p_source VARCHAR2,
    p_key    VARCHAR2 )
  RETURN VARCHAR2
AS
BEGIN
  RETURN UTL_RAW.CAST_TO_VARCHAR2 ( DBMS_CRYPTO.encrypt( UTL_RAW.CAST_TO_RAW (p_source), 
       dbms_crypto.DES_CBC_PKCS5, UTL_RAW.CAST_TO_RAW (p_key) ) );
END;
/

CREATE OR REPLACE FUNCTION my_decrypt 
( p_source VARCHAR2, 
  p_key VARCHAR2  )
RETURN VARCHAR2 AS
BEGIN
   RETURN UTL_RAW.CAST_TO_VARCHAR2 ( DBMS_CRYPTO.decrypt( UTL_RAW.CAST_TO_RAW (p_source), dbms_crypto.DES_CBC_PKCS5, UTL_RAW.CAST_TO_RAW (p_key) ) );
END;
/

drop table pegawai cascade constraint purge;
create table Pegawai
(
    Id_Pegawai      varchar2(8)     primary key,
    Nama_Pegawai    varchar2(30)    not null,
    Password        varchar2(200)    not null,
    Id_Branch       varchar2(8)     references Branch(Id_Branch),
    Manager         number          check(manager = 0 or manager = 1)
);
insert into Pegawai values('PEG001','Joko Prasetyo',my_encrypt('jokprast','aplikasi client server'),'CAB001',1);
insert into Pegawai values('PEG002','Yohanes Setianto',my_encrypt('musiceverywhere','aplikasi client server'),'CAB002',1);
insert into Pegawai values('PEG003','Thomas Grant',my_encrypt('thomastutututut','aplikasi client server'),'CAB003',1);
insert into Pegawai values('PEG004','Kevin Karuniawan',my_encrypt('jomblobahagiaTRUST!','aplikasi client server'),'CAB001',0);
insert into Pegawai values('PEG005','Maximillian Eka',my_encrypt('kopigularen','aplikasi client server'),'CAB002',0);
insert into Pegawai values('PEG006','Eka Sanjaya',my_encrypt('youresaipul','aplikasi client server'),'CAB002',0);


commit;
