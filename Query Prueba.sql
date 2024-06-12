--create database pruebafinanzauto
--use pruebafinanzauto

Create table Document(
	Id int primary key identity(1,1),
	DescriptionDoc varchar(200),
	DateCreate date not null default getDate()
)

insert into Document values ('CC', Getdate())

create table Student(
	Id int primary key identity(1,1),
	Document int not null,
	Number varchar(20) not null,
	NameStudent varchar(150) not null,
	LastName varchar(150) not null,
	DateCreate datetime not null default getDate(),
	"State" bit not null default 1
	foreign key (Document)  references Document(Id)
)

create table Curses(
	IdCurse int Primary key identity(1,1),
	NameCurse varchar(150)not null,
	DateCreate datetime not null default getDate(),
	DateModify datetime not null,
	"State" bit not null default 1
)

Create table Calification (
	Id int primary key identity(1,1),
	Student int not null, 
	Curse int not null,
	Item varchar(150) not null,
	Val int not null,
	foreign key (Student) references Student(Id),
	foreign key (Curse) references Curses (IdCurse)
)

