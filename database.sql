drop table Branch cascade constraint purge;
drop table Pegawai cascade constraint purge;
drop table Gudang cascade constraint purge;
drop table Barang cascade constraint purge;
drop table Transaksi cascade constraint purge;
drop table Stok cascade constraint purge;
drop table Distributor cascade constraint purge;
drop table Kontak_Distributor cascade constraint purge;
drop table Hak_Akses cascade constraint purge;
drop table Order_Header cascade constraint purge;
drop table Order_Detail cascade constraint purge;
drop table list_hak_akses cascade constraint purge;
drop table Payment_Terms cascade constraint purge;
drop table Payment_Type cascade constraint purge;

Create table Payment_Terms
(
    id_Payment_Term varchar2(5)primary key,
    nama varchar2(100)
);

insert into Payment_Terms values ('PT001','Due Upon Receipt');
insert into Payment_Terms values ('PT002','30 days');
insert into Payment_Terms values ('PT003','30 days Of month end');
insert into Payment_Terms values ('PT004','60 days');
insert into Payment_Terms values ('PT005','50-50');
insert into Payment_Terms values ('PT006','Order');
insert into Payment_Terms values ('PT007','Delivery');
insert into Payment_Terms values ('PT008','10 days');  

Create table Payment_Type
(
    id_Payment_type varchar2 (5) primary key,
    nama varchar2 (100)
);

insert into Payment_Type values ('TP001','Cash');
insert into Payment_Type values ('TP002','Bank Transfer');
insert into Payment_Type values ('TP003','Cheque');
insert into Payment_Type values ('TP004','Credit Card');
insert into Payment_Type values ('TP005','Debit Payment Order');

create table Branch
(
    Id_branch   varchar2(8)     primary key,
    Id_manager  varchar2(8)     not null,
    Alamat      varchar2(100)   not null
);
insert into Branch values('CAB001','PEG001','Jalan Dharmahusada Indah Blok A-27');
insert into Branch values('CAB002','PEG002','Jalan Kertajaya Indah IV-K328');
insert into Branch values('CAB003','PEG003','Jalan Sukomanunggal Timur 678');

create table Pegawai
(
    Id_Pegawai      varchar2(8)     primary key,
    Nama_Pegawai    varchar2(30)    not null,
    Password        varchar2(25)    not null,
    Id_Branch       varchar2(8)     references Branch(Id_Branch),
    Manager         number          check(manager = 0 or manager = 1)
);
insert into Pegawai values('PEG001','Joko Prasetyo','jokprast','CAB001',1);
insert into Pegawai values('PEG002','Yohanes Setianto','musiceverywhere','CAB002',1);
insert into Pegawai values('PEG003','Thomas Grant','thomastutututut','CAB003',1);
insert into Pegawai values('PEG004','Kevin Karuniawan','jomblobahagiaTRUST!','CAB001',0);
insert into Pegawai values('PEG005','Maximillian Eka','kopigularen','CAB002',0);
insert into Pegawai values('PEG006','Eka Sanjaya','youresaipul','CAB002',0);

create table Gudang
(
    Id_Gudang           varchar2(8)     primary key,
    Alamat_Gudang       varchar2(50)    not null,
    Telp_Gudang         varchar2(15)    not null,
    Id_Kepala_Gudang    varchar2(8)     references Pegawai(Id_Pegawai)
);
insert into Gudang values('INV001','Jalan Raya Gresik A107','031684356','PEG004');
insert into Gudang values('INV002','Jalan Raya Surabaya-Sidoarjo B-333','031457829','PEG005');

create table Barang
(
    Id_Barang       varchar2(8)     primary key,
    Nama_Barang     varchar2(50)    not null,
    Detail_Barang   varchar2(100)   
);
insert into Barang values('BRG0001','Bantex Insert Ring Binder 25mm','Insert Ring Binder ukuran A4 max 50 halaman');
insert into Barang values('BRG0002','Bantex Insert Ring Binder 50mm','Insert Ring Binder ukuran A4 max 100 halaman');
insert into Barang values('BRG0003','Bantex Insert Ring Binder 100mm','Insert Ring Binder ukuran A4 max 200 halaman');
insert into Barang values('BRG0004','Sinar Dunia F4 70gsm','');
insert into Barang values('BRG0005','Sinar Dunia F4 80gsm','');
insert into Barang values('BRG0006','Sinar Dunia A4 70gsm','');
insert into Barang values('BRG0007','Sinar Dunia A4 80gsm','');
insert into Barang values('BRG0008','Paperline Gold F4 70gsm','');
insert into Barang values('BRG0009','Paperline Gold F4 80gsm','');
insert into Barang values('BRG0010','Paperline Gold A4 70gsm','');
insert into Barang values('BRG0011','Paperline Gold A4 80gsm','');
insert into Barang values('BRG0012','Tinta Blueprint Epson 70ml','');
insert into Barang values('BRG0013','Tinta Blueprint Canon 70ml','');
insert into Barang values('BRG0014','Toner Canon 500gram','');
insert into Barang values('BRG0015','Krisbow Paper Shedder S290','Mesin Penghancur Kertas ukuran 30x25x60');


create table Stok
(
    Id_Barang       varchar2(8)     primary key,
    Jumlah_Stok     number(15),
    Tanggal_Masuk   date
);
insert into Stok values('BRG0001',100,to_date('12/11/2019','dd/mm/yyyy'));
insert into Stok values('BRG0002',250,to_date('16/11/2019','dd/mm/yyyy'));
insert into Stok values('BRG0003',300,to_date('18/11/2019','dd/mm/yyyy'));
insert into Stok values('BRG0006',500,to_date('21/11/2019','dd/mm/yyyy'));
insert into Stok values('BRG0008',7000,to_date('25/11/2019','dd/mm/yyyy'));


create table Distributor
(
    Id_Distributor      varchar2(8)     primary key,
    Nama_Distributor    varchar2(25)    not null,
    Alamat_Distributor  varchar2(50)    not null
);
insert into Distributor values('DIS001','PT SINAR MAKMUR','Jalan Soekarno Hatta 88 Surabaya');
insert into Distributor values('DIS002','PT CAHAYA MENTARI','Jalan HR Mohammand 78 Surabaya');
insert into Distributor values('DIS003','PT JAYA SENTOSA','Jalan Kertajaya Indah I/A-20 Surabaya');
insert into Distributor values('DIS004','PT BERLIAN SEDAYA','Jalan Sulawesi 29 Surabaya');
insert into Distributor values('DIS005','PT PRIMA PLASTINDO','Jalan Pattimura A-201 Gresik');
insert into Distributor values('DIS006','PT BUNGA PERMATA','Jalan Kembang Jempun III-107 Surabaya');
insert into Distributor values('DIS007','PT SANJAYA ABADI','Jalan Boulevard VI-8 Jakarta');
insert into Distributor values('DIS008','PT MAHKOTA MAKMUR','Ruko Alam Sutera J-II/ 30 Jakarta');
insert into Distributor values('DIS009','PT GLOBAL INDONESIA','Jalan Rahman Hakim II/33 Depok');



create table Kontak_Distributor
(
    Id_Distributor      varchar2(8)     references Distributor(Id_Distributor),
    No_Telp             varchar2(15)    not null,
    Staff               varchar(30)     not null,
    Email               varchar2(35)
);
insert into Kontak_Distributor values('DIS001','031 7892346','Agatha','po@sinarmakmur.com');
insert into Kontak_Distributor values('DIS001','031 3456345','Budi','po@sinarmakmur.com');
insert into Kontak_Distributor values('DIS001','031 2536457','Cassandra','po@sinarmakmur.com');
insert into Kontak_Distributor values('DIS002','031 3450234','Hamidah','hamidah@po.cahmen.com');
insert into Kontak_Distributor values('DIS003','031 3345087','Jaya Sentosa','jayasentosa@gmail.com');
insert into Kontak_Distributor values('DIS004','031 8594001','Lilik','ptberliansedaya@gmail.com');
insert into Kontak_Distributor values('DIS005','031 3550087','Rini','primaplastindo@gmail.com');
insert into Kontak_Distributor values('DIS006','031 8574898','Celina','celina@po.bungapermata.com');
insert into Kontak_Distributor values('DIS006','031 3455435','Mahfud','mahfud@po.bungapermata.com');
insert into Kontak_Distributor values('DIS006','021 5677656','Retha','retha@po.bungapermata.com');
insert into Kontak_Distributor values('DIS007','021 4566546','Xaverius','po@sanjayaabadi.com');
insert into Kontak_Distributor values('DIS007','021 4566547','Vincentius','po@sanjayaabadi.com');
insert into Kontak_Distributor values('DIS008','021 5678876','Sutoyo','mahkotamakmur@yahoo.com');
insert into Kontak_Distributor values('DIS009','021 8907898','Edwin','purchaseorder@global.indonesia.com');

create table list_hak_akses (
    Id_Hak_Akses varchar(8) Primary key,
    Nama_Akses   varchar2(150) not null
);
insert into list_hak_akses Values ('HA001','Akses Lihat Kontak');
insert into list_hak_akses Values ('HA002','Edit Kontak');
insert into list_hak_akses Values ('HA003','Akses Approve dan Batal');
insert into list_hak_akses Values ('HA004','Granter');
insert into list_hak_akses Values ('HA005','Inventory');
insert into list_hak_akses values ('HA006','Master');
insert into list_hak_akses values ('HA007','Lihat Laporan');
insert into list_hak_akses values ('HA008','Make Order');

create table Hak_Akses
(
    Id_Pegawai      varchar2(8) references Pegawai(Id_Pegawai),
    Id_Hak_Akses    varchar2(8) references list_hak_akses(Id_Hak_Akses),
    constraint PK_HA primary key(Id_Pegawai,Id_Hak_Akses)
);
insert into Hak_Akses Values ('PEG001','HA001');
insert into Hak_Akses values ('PEG001','HA008');
insert into Hak_Akses Values ('PEG002','HA002');
insert into Hak_Akses Values ('PEG003','HA003');
insert into Hak_Akses Values ('PEG004','HA004');
insert into Hak_Akses Values ('PEG006','HA006');
insert into Hak_Akses Values ('PEG002','HA007');

create table Transaksi
(
    Id_Barang           varchar2(8)     primary key,
    Nama_Barang         varchar2(50)    not null,
    Harga_Barang        number(15)      not null,
    Id_Distributor      varchar2(8)     not null,
    Tanggal_Transaksi   date            not null
);
insert into Transaksi values('BRG0001','Bantex Insert Ring Binder 25mm',100000,'DIS00',to_date('11/11/2019','dd/mm/yyyy'));
insert into Transaksi values('BRG0002','Bantex Insert Ring Binder 50mm',125000,'DIS00',to_date('13/11/2019','dd/mm/yyyy'));
insert into Transaksi values('BRG0003','Bantex Insert Ring Binder 100mm',150000,'DIS00',to_date('17/11/2019','dd/mm/yyyy'));
insert into Transaksi values('BRG0004','Sinar Dunia F4 70gsm',40000,'DIS00',to_date('27/11/2019','dd/mm/yyyy'));
insert into Transaksi values('BRG0005','Sinar Dunia F4 80gsm',48000,'DIS00',to_date('30/11/2019','dd/mm/yyyy'));

create table Order_Header
(
    Id_Order                varchar2(8) primary key,
    Id_Distributor          varchar2(8) not null references distributor(Id_Distributor),
    Tanggal_Order           date        not null,
    Plan_Date_Delivery      date        ,
    Subtotal                number(15)  not null,    
    Status_Order            varchar2(1) not null check(Status_Order in ('0' ,'1','2','3','4','5','6')),
    Id_Pegawai              varchar2(8) references Pegawai(Id_Pegawai),
    id_Payment_Term         varchar2(5) references Payment_Terms(id_Payment_Term),
    id_Payment_Type         varchar2(5) references Payment_Type(id_Payment_Type),
    Id_branch               varchar(5) references Branch(Id_branch)
);
insert into Order_Header values('PO001','DIS001',to_date('10/11/2019','dd/mm/yyyy'),to_date('21/12/2019','dd/mm/yyyy'),100000,1,'PEG004','PT001','TP001','CAB001');
insert into Order_Header values('PO002','DIS002',to_date('12/11/2019','dd/mm/yyyy'),to_date('23/12/2019','dd/mm/yyyy'),150000,1,'PEG004','PT002','TP003','CAB001');
insert into Order_Header values('PO003','DIS003',to_date('13/11/2019','dd/mm/yyyy'),to_date('22/12/2019','dd/mm/yyyy'),300000,1,'PEG005','PT004','TP004','CAB001');
insert into Order_Header values('PO004','DIS001',to_date('15/11/2019','dd/mm/yyyy'),to_date('18/12/2019','dd/mm/yyyy'),400000,1,'PEG006','PT005','TP001','CAB001');
insert into Order_Header values('PO005','DIS001',to_date('16/11/2019','dd/mm/yyyy'),to_date('21/12/2019','dd/mm/yyyy'),2500000,1,'PEG006','PT006','TP002','CAB002');
---insert into Order_Header values('PO006','DIS004',to_date('18/11/2019','dd/mm/yyyy'),10,600000,'3');
---insert into Order_Header values('PO007','DIS005',to_date('07/12/2019','dd/mm/yyyy'),10,1000000,'1');
insert into Order_Header values('PO006','DIS001',to_date('16/11/2019','dd/mm/yyyy'),to_date('21/12/2019','dd/mm/yyyy'),2500000,1,'PEG006','PT002','TP003','CAB002');
insert into Order_Header values('PO008','DIS001',to_date('16/11/2019','dd/mm/yyyy'),to_date('21/12/2019','dd/mm/yyyy'),2500000,1,'PEG006','PT004','TP001','CAB001');
insert into Order_Header values('PO007','DIS001',to_date('16/11/2019','dd/mm/yyyy'),to_date('21/12/2019','dd/mm/yyyy'),2500000,1,'PEG006','PT004','TP001','CAB002');


create table Order_Detail
(
    Id_Order        varchar2(8)     references Order_Header(Id_Order) , 
    Id_Barang       varchar2(8)     not null references Barang(Id_Barang) ,
    Nama_Barang     varchar2(100)   not null,
    Jumlah_Order    number(10)      not null,
    Pajak           number(10)      not null,
    Harga           number(15)      not null,
    Diskon          number(15)      not null,
    total_kotor     number(15)      not null,
    total_bersih    number(15)      not null
);
insert into Order_Detail values('PO001','BRG0001','Bantex Insert Ring Binder 25mm',10,10,10000);
insert into Order_Detail values('PO002','BRG0004','Sinar Dunia F4 70gsm',5,10,75000);
insert into Order_Detail values('PO002','BRG0006','Sinar Dunia A4 70gsm',5,5,75000);
insert into Order_Detail values('PO003','BRG0012','Tinta Blueprint Epson 70ml',10,10,30000);
insert into Order_Detail values('PO004','BRG0013','Tinta Blueprint Canon 70ml',10,5,40000);
insert into Order_Detail values('PO005','BRG0015','Krisbow Paper Shedder S290',1,5,2500000);
insert into Order_Detail values('PO006','BRG0015','Krisbow Paper Shedder S290',1,10,2500000);
 


Create Or Replace Function AUTOGEN_ID RETURN varchar2
IS
depan varchar2(2);
URUT NUMBER;
KODE varchar2(8);
begin
  depan := 'PO';

  SELECT COUNT (ID_ORDER)+1 INTO URUT FROM Order_Header;

  KODE := depan ||LPAD(URUT,3,'0');

  RETURN KODE;
end;
/


-- CREATE OR REPLACE TRIGGER Subtotal BEFORE UPDATE ON order_detail
-- FOR EACH ROW
-- DECLARE
-- tsub number;
-- BEGIN
-- tsub := :NEW.HARGA * :NEW.JUMLAH_order;
--     UPDATE order_header SET SUBTOTAL= SUBTOTAL+ tsub WHERE ID_ORDER = :NEW.ID_ORDER;
-- END;
-- /   

-- CREATE OR REPLACE TRIGGER pajak BEFORE UPDATE ON order_header
-- FOR EACH ROW
-- DECLARE
-- BEGIN
--     UPDATE order_header SET SUBTOTAL= SUBTOTAL - (:new.pajak * Subtotal /100) WHERE ID_ORDER = :NEW.ID_ORDER;
-- END;
-- /     


commit;


