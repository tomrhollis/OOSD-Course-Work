create table rainchecks
(rain# numeric(6) primary key,
name char(30) not null,
phone numeric(10) check(phone>0), -- constraint
comments varchar(300))

create table raincheck_details
(rain# numeric(6) foreign key references rainchecks(rain#),
item# numeric(8), 
price numeric(10,2),
date_promised datetime,
primary key(rain#,item#))

insert into rainchecks values(1,'bob',1112222, 'sold out early')
insert into raincheck_details values(1,101,10.00,getdate())
insert into raincheck_details values(1,102,10.00,getdate())

alter table rainchecks add email varchar(40)
alter table rainchecks alter column name char(35)
alter table raincheck_details drop column date_promised
alter table raincheck_details add constraint needprice check(price>0)
alter table raincheck_details drop constraint needprice


drop table groupmembership
drop table individuals
drop table groups


create table individuals
(individualid int primary key,
firstname varchar not null,
lastname varchar not null,
address varchar,
phone varchar)

create table groups
(groupid int primary key,
groupname varchar not null,
dues money default 0 check(dues>=0))

create table groupmembership
(groupid int foreign key references groups(groupid),
individualid int foreign key references individuals(individualid),
primary key(groupid, individualid))


