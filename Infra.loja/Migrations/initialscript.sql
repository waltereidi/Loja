create table clients(
	id int not null identity(1 ,1 ) primary key ,
	created_at datetime not null default current_timestamp , 
	updated_at datetime , 
	email varchar(320) not null, 
	password varchar(30) not null 
	);

create table category(
	id int not null identity(1,1) primary key , 
	created_at datetime not null default current_timestamp,
	updated_at datetime ,
	name varchar(120) not null , 
	description varchar(2048) 
);

create table prices(
	id int not null identity(1,1) primary key , 
	created_at datetime not null default current_timestamp,
	updated_at datetime  ,
	price money not null ,  
	description varchar(255) 
);
create table products(
	id int not null identity(1,1) primary key , 
	created_at datetime not null default current_timestamp,
	updated_at datetime  ,
	name varchar(255) not null,
	description varchar(2048) ,
	ean bigint ,
	sku varchar(64) ,
	price_Id int not null foreign key references prices(id),
	category_Id int not null foreign key references category(id) , 

);
