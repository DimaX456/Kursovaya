drop table register

CREATE TABLE test_db(
id int IDENTITY(1,1) NOT NULL,
type_of varchar(50) NOT NULL,
count_of int NOT NULL,
postavka varchar(50) NOT NULL,
price int NOT NULL,
PRIMARY KEY (id)
);


select * from test_db

INSERT INTO test_db (type_of, count_of, postavka, price) VALUES('Самолет',1,'Барселона',30000)

create table register(
id_user int identity (1,1) not null,
login_user varchar(50) not null,
password_user varchar(50) not null,
is_admin bit
);

select * from register

insert into register (login_user, password_user, is_admin) values ('admin', 'admin', 1)
