create table clients(
	ID_Clients int not null identity(1 ,1 ) primary key ,
	created_at datetime not null default current_timestamp , 
	updated_at datetime , 
	email varchar(320) not null, 
	password varchar(30) not null 
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
	sku varchar(64) ,
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
create table permissionsGroup(
	ID_PermissionsGroup int not null  identity(1, 1) primary key , 
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

