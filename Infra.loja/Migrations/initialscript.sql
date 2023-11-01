create table price(
	id int not null primary key , 
	price money not null ,  
	description varchar(255) 
);
create table prodocts(
	id int not null primary key , 
	descricao varchar(255) ,
	price_id int not null foreign key references price(id)
);
