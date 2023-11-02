create table category(
	id int not null primary key , 
	name varchar(120) not null , 
	description varchar(2048) 
);

create table price(
	id int not null primary key , 
	price money not null ,  
	description varchar(255) 
);
create table products(
	id int not null primary key , 
	name varchar(255) not null,
	description varchar(2048) ,
	ean bigint ,
	sku varchar(64) ,
	price_id int not null foreign key references price(id),
	category_id int not null foreign key references category(id) , 

);
