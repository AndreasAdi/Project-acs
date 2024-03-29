--select 'drop table '||table_name||' cascade constraints purge;' from user_tables;
drop table BARANG cascade constraints purge;
drop table STOK cascade constraints purge;
drop table BRANCH cascade constraints purge;
drop table PEGAWAI cascade constraints purge;
drop table DISTRIBUTOR cascade constraints purge;
drop table HAK_AKSES cascade constraints purge;
drop table GUDANG cascade constraints purge;
drop table ORDER_HEADER cascade constraints purge;
drop table ORDER_DETAIL cascade constraints purge;
CREATE TABLE BARANG(
    ID_BARANG VARCHAR2(10) PRIMARY KEY,
    NAMA_BARANG VARCHAR2(30),
    DETAIL_BARANG VARCHAR2(50)
);

CREATE TABLE STOK(
    ID_BARANG VARCHAR2(10) REFERENCES BARANG(ID_BARANG),
    JUMLAH_STOK NUMBER,
    TANGGAL_MASUK DATE 
);
CREATE TABLE BRANCH (
    ID_BRANCH VARCHAR2 (10) PRIMARY KEY,
    ID_MANAGER VARCHAR2 (10),
    ALAMAT VARCHAR2 (50)
);

CREATE TABLE PEGAWAI(
    ID_PEGAWAI VARCHAR2(10) PRIMARY KEY,
    ID_BRANCH VARCHAR2(10) REFERENCES BRANCH (ID_BRANCH),
    NAMA_PEGAWAI VARCHAR2 (30)
);



CREATE TABLE DISTRIBUTOR(
    ID_DISTRIBUTOR VARCHAR2(10) PRIMARY KEY,
    NAMA_DISTRIBUTOR VARCHAR2 (30),
    ALAMAT_DISTRIBUTOR VARCHAR2 (30)
);
CREATE TABLE HAK_AKSES(
    ID_PEGAWAI VARCHAR2(10) REFERENCES PEGAWAI (ID_PEGAWAI),
    ID_HAK_AKSES VARCHAR2 (10) PRIMARY KEY,
    NAMA_AKSES VARCHAR2 (10)
);

CREATE TABLE ORDER_HEADER(
    ID_ORDER VARCHAR2(10) PRIMARY KEY,
    ID_DISTRIBUTOR VARCHAR2(10) REFERENCES DISTRIBUTOR(ID_DISTRIBUTOR),
    TANGGAL_ORDER DATE,
    SUBTOTAL NUMBER,
    PAJAK NUMBER,   
    STATUS_ORDER NUMBER CHECK (STATUS_ORDER = 0 OR STATUS_ORDER = 1 OR STATUS_ORDER =2)
    --0 BELUM DI APPROVE
    --1 SUDAH DI APPROVE
    --2 DIBATALKAN
);

CREATE TABLE ORDER_DETAIL(
    ID_ORDER VARCHAR2(10) REFERENCES ORDER_HEADER(ID_ORDER),
    ID_BARANG VARCHAR2 (10) REFERENCES BARANG (ID_BARANG),
    JUMLAH_ORDER NUMBER,
    HARGA NUMBER
);

create table GUDANG
(
    ID_GUDANG VARCHAR2 (10) PRIMARY KEY,
    NAMA_GUDANG VARCHAR2 (20),
    ALAMAT_GUDANG VARCHAR2 (30),
    TELEPON_GUDANG NUMBER,
    ID_KEPALA_GUDANG VARCHAR2 (10) 
);


