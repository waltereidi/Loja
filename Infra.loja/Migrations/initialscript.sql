
begin transaction
create table permissionsGroup(
	ID_PermissionsGroup int not null  identity(1, 1) primary key , 
	created_at datetime not null default current_timestamp , 
	updated_at datetime , 
	name varchar(255) not null 
);

create table clients(
	ID_Clients int not null identity(1 ,1 ) primary key ,
	created_at datetime not null default current_timestamp , 
	updated_at datetime , 
	email varchar(320) not null, 
	password varchar(30) not null ,
	ID_PermissionsGroup int not null default 1 foreign key references permissionsGroup(ID_PermissionsGroup)
);

create table categories(
	ID_Categories int not null identity(1,1) primary key , 
	created_at datetime not null default current_timestamp,
	updated_at datetime ,
	name varchar(120) not null , 
	description varchar(2048) 
);

create table prices(
	ID_Prices int not null identity(1,1) primary key , 
	created_at datetime not null default current_timestamp,
	updated_at datetime  ,
	price money not null ,  
	description varchar(255) 
);
create table products(
	ID_Products int not null identity(1,1) primary key , 
	created_at datetime not null default current_timestamp,
	updated_at datetime  ,
	name varchar(255) not null,
	description varchar(2048) ,
	ean bigint ,
	sku varchar(64)
);
create table products_storage(
	ID_Products_storage int not null identity( 1, 1) primary key , 
	created_at datetime not null default current_timestamp,
	updated_at datetime ,
	quantity int not null default 0 , 
	description varchar(255),
	ID_Products int not null foreign key references products(ID_Products) 
);
create table category_promotion(
	ID_Category_promotion int not null identity( 1, 1) primary key ,
	created_at datetime not null default current_timestamp ,
	updated_at datetime not null , 
	displayOrder int not null default 1 ,
	ID_Categories int not null foreign key references categories(ID_Categories)
);

create table products_categories(
	ID_Products_categories int not null identity(1 ,1 ) primary key , 
	created_at datetime not null default current_timestamp, 
	updated_at datetime not null , 
	ID_Categories int not null foreign key references categories(ID_Categories),
	ID_Products int not null foreign key references products(ID_Products)
);
create table products_prices(
	ID_Products_prices int not null identity(1, 1 ) primary key , 
	created_at datetime not null default current_timestamp , 
	updated_at datetime not null , 
	ID_Prices int not null foreign key references prices(ID_Prices),
	ID_Products int not null foreign key references products(ID_Products)
);
create table permissions(
	ID_Permissions int not null identity(1 ,1) primary key , 
	created_at datetime not null default current_timestamp , 
	updated_at datetime not null ,
	name varchar(255) not null
);

create table permissions_relation(
	ID_Permissions_relation int not null identity(1, 1 ) primary key , 
	created_at datetime not null default current_timestamp , 
	updated_at datetime not null , 
	ID_PermissionsGroup int not null foreign key references permissionsGroup(ID_PermissionsGroup),
	ID_Permissions int not null foreign key references permissions(ID_Permissions)
);

create table clientsProducts_cart(
	ID_ClientsProducts_Cart int not null identity( 1 ,1 ) primary key , 
	created_at datetime not null default current_timestamp , 
	updated_at datetime not null , 
	ID_Clients int not null foreign key references clients(ID_Clients) , 
	ID_Products int not null foreign key references products(ID_Products) ,
	quantity int not null default 1 ,
	isActive bit not null default 1	
);

create table RequestOrders(
	ID_RequestOrders int not null identity(1 ,1 ) primary key , 
	description nvarchar(2048) null , 
	created_at datetime not null default current_timestamp , 
	updated_at datetime not null , 
);

create table RequestOrders_clientsProducts_Cart(
	ID_RequestOrders_clientsProducts_Cart int not null identity(1 , 1 ) primary key ,
	created_at datetime not null default current_timestamp , 
	updated_at datetime not null ,
	ID_RequestOrders int not null foreign key references requestOrders(ID_RequestOrders),
	ID_ClientsProducts_Cart int not null foreign key references clientsProducts_cart(ID_ClientsProducts_Cart) 
);

SET IDENTITY_INSERT permissionsGroup ON 
insert into permissionsGroup ( ID_PermissionsGroup , created_at , updated_at , name ) values( 1 ,current_timestamp , null , 'Cliente' );
SET IDENTITY_INSERT permissionsGroup OFF 
GO 

SET IDENTITY_INSERT clients ON
insert into clients ( ID_Clients , created_at , updated_at , email , password , ID_PermissionsGroup ) values( 1 , current_timestamp , current_timestamp , 'TestCase' ,'123' ,1  );
SET IDENTITY_INSERT clients OFF 
GO 

SET IDENTITY_INSERT  permissions ON
insert into permissions(ID_Permissions , created_at , updated_at , name) values ( 1 , current_timestamp , current_timestamp , 'TestCase' );
SET IDENTITY_INSERT permissions OFF 
GO 

SET IDENTITY_INSERT permissions_relation ON
insert into permissions_relation (ID_Permissions_relation , created_at , updated_at , ID_PermissionsGroup , ID_Permissions ) values ( 1 , current_timestamp , current_timestamp , 1 , 1 );
SET IDENTITY_INSERT permissions_relation OFF 
GO 
--rollback 
--commit


