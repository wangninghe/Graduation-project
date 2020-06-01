create database YACompany

create table Staff(
StaffID int primary key identity(1,1),
StaffName nvarchar(50),
StaffSex char(2) ,
StaffAge int ,
StaffPhone int,
StaffPost int foreign key references Post(PostID),
StaffSite nvarchar(50),
StaffDorm int foreign key references Dorm(DormID)
)
create table Dorm(
DormID int primary key identity(1,1),
DormName nvarchar(50),
DormDetails nvarchar(50)
)
create table Post(
PostID int primary key identity(1,1),
PostName nvarchar(50)
)
create table Wages(
WagesID int primary key identity(1,1),
PostID int foreign key references Post(PostID),
Salary money
)
create table Sell(
SellID int primary key identity(1,1),
WarehouseID int foreign key references Warehouse(WarehouseID),
SellTime datetime ,
SellNum int
)
create table Warehouse(
WarehouseID int primary key identity(1,1),
WarehouseName nvarchar(50),
WarehouseNum int ,
WarehouseDeta nvarchar(50)
)
create table Buy(
Buy int primary key identity(1,1),
WarehouseID int		,
BuyTime datetime,
BuyNum int
)
create table Collect(
CollectID int primary key identity(1,1),
CollectMoney money,
CollectDetai nvarchar(50),
CollectTime datetime 
)
create table Pay(
PayID int primary key identity(1,1),
PaytMoney money,
PayDetai nvarchar(50),
PayTime datetime 
)