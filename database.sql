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
    Email               varchar2(35)
);
insert into Kontak_Distributor values('DIS001','031 7892346','po@sinarmakmur.com');
insert into Kontak_Distributor values('DIS001','031 3456345','po@sinarmakmur.com');
insert into Kontak_Distributor values('DIS001','031 2536457','po@sinarmakmur.com');
insert into Kontak_Distributor values('DIS002','031 3450234','hamidah@po.cahmen.com');
insert into Kontak_Distributor values('DIS003','031 3345087','jayasentosa@gmail.com');
insert into Kontak_Distributor values('DIS004','031 8594001','ptberliansedaya@gmail.com');
insert into Kontak_Distributor values('DIS005','031 3550087','primaplastindo@gmail.com');
insert into Kontak_Distributor values('DIS006','031 8574898','celina@po.bungapermata.com');
insert into Kontak_Distributor values('DIS006','031 3455435','mahfud@po.bungapermata.com');
insert into Kontak_Distributor values('DIS006','021 5677656','retha@po.bungapermata.com');
insert into Kontak_Distributor values('DIS007','021 4566546','po@sanjayaabadi.com');
insert into Kontak_Distributor values('DIS007','021 4566547','po@sanjayaabadi.com');
insert into Kontak_Distributor values('DIS008','021 5678876','mahkotamakmur@yahoo.com');
insert into Kontak_Distributor values('DIS009','021 8907898','purchaseorder@global.indonesia.com');


create table Hak_Akses
(
    Id_Pegawai      varchar2(8) references Pegawai(Id_Pegawai),
    Id_Hak_Akses    varchar2(8),
    Nama_Akses      varchar2(15),
    constraint PK_HA primary key(Id_Pegawai,Id_Hak_Akses)
);

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
    Pajak                   number(15)  ,
    Subtotal                number(15)  not null,    
    Status_Order            varchar2(1) not null check(Status_Order in ('0' ,'1','2','3','4','5')),
    Id_Pegawai              varchar2(8) references Pegawai(Id_Pegawai)
);
insert into Order_Header values('PO001','DIS001',to_date('10/11/2019','dd/mm/yyyy'),to_date('21/12/2019','dd/mm/yyyy'),10,100000,'5','PEG004');
insert into Order_Header values('PO002','DIS002',to_date('12/11/2019','dd/mm/yyyy'),to_date('23/12/2019','dd/mm/yyyy'),10,150000,'5','PEG004');
insert into Order_Header values('PO003','DIS003',to_date('13/11/2019','dd/mm/yyyy'),to_date('22/12/2019','dd/mm/yyyy'),15,300000,'4','PEG005');
insert into Order_Header values('PO004','DIS001',to_date('15/11/2019','dd/mm/yyyy'),to_date('18/12/2019','dd/mm/yyyy'),10,400000,'2','PEG006');
insert into Order_Header values('PO005','DIS001',to_date('16/11/2019','dd/mm/yyyy'),to_date('21/12/2019','dd/mm/yyyy'),20,2500000,'1','PEG006');
---insert into Order_Header values('PO006','DIS004',to_date('18/11/2019','dd/mm/yyyy'),10,600000,'3');
---insert into Order_Header values('PO007','DIS005',to_date('07/12/2019','dd/mm/yyyy'),10,1000000,'1');

create table Order_Detail
(
    Id_Order        varchar2(8)     references Order_Header(Id_Order) , 
    Id_Barang       varchar2(8)     not null references Barang(Id_Barang) ,
    Nama_Barang     varchar2(30)    not null,
    Jumlah_Order    number(10)      not null,
    Harga           number(15)      not null
);
insert into Order_Detail values('PO001','BRG0001','Bantex Insert Ring Binder 25mm',10,10000);
insert into Order_Detail values('PO002','BRG0004','Sinar Dunia F4 70gsm',5,75000);
insert into Order_Detail values('PO002','BRG0006','Sinar Dunia A4 70gsm',5,75000);
insert into Order_Detail values('PO003','BRG0012','Tinta Blueprint Epson 70ml',10,30000);
insert into Order_Detail values('PO004','BRG0013','Tinta Blueprint Canon 70ml',10,40000);
insert into Order_Detail values('PO005','BRG0015','Krisbow Paper Shedder S290',1,2500000);



commit;