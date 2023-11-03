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
	priceId int not null foreign key references price(id),
	categoryId int not null foreign key references category(id) , 

);
