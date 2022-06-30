drop database BookStore
create database BookStore
alter database BookStore set recovery simple
go

use BookStore
go

create table Users
(
	Id int not null identity constraint PK_Users primary key,
	[Login] nvarchar(200) constraint Unique_Users_Login unique not null,
	[Password] nvarchar(max) not null,
	[FirstName] nvarchar(max) not null,
	[SecondName] nvarchar(max) not null,
	[ThirdName] nvarchar(max),
	RoleId int not null,
	IsBlocked bit not null,
	RegistrationDate datetime not null,
)
--8507c13416c3051c9dc7ebe90a27f6621427b1438ce24d65800ebcf988f9ab32e1ded94db606423f19ca42867e6af58119e599d7ece722a92fe7774c5262407c 
--jzYFfB7+~G&-
insert into Users values
('dev', '8507c13416c3051c9dc7ebe90a27f6621427b1438ce24d65800ebcf988f9ab32e1ded94db606423f19ca42867e6af58119e599d7ece722a92fe7774c5262407c','dev', 'dev', 'dev', 0, 0, GETDATE()),
('librarian1', '8507c13416c3051c9dc7ebe90a27f6621427b1438ce24d65800ebcf988f9ab32e1ded94db606423f19ca42867e6af58119e599d7ece722a92fe7774c5262407c', 'Афанасьева', 'Татьяна', 'Михайловна', 2, 0, GETDATE()),
('reader1', '8507c13416c3051c9dc7ebe90a27f6621427b1438ce24d65800ebcf988f9ab32e1ded94db606423f19ca42867e6af58119e599d7ece722a92fe7774c5262407c', 'Кириллов', 'Никита', 'Дмитриевич',3, 0, GETDATE()),
('reader2', '8507c13416c3051c9dc7ebe90a27f6621427b1438ce24d65800ebcf988f9ab32e1ded94db606423f19ca42867e6af58119e599d7ece722a92fe7774c5262407c', 'Машникова', 'Кристина', 'Сергеевна',3, 0, GETDATE()),
('admin', '8507c13416c3051c9dc7ebe90a27f6621427b1438ce24d65800ebcf988f9ab32e1ded94db606423f19ca42867e6af58119e599d7ece722a92fe7774c5262407c', 'admin', 'super', 'admin', 1, 0, GETDATE());
go

create table Books (
Id int not null identity constraint PK_Book primary key,
Name nvarchar(max) not null,
AuthorFirstName nvarchar(max),
AuthorSecondName nvarchar(max),
AuthorThirdName nvarchar(max),
DescriptionBook nvarchar(max),
TypeBook int not null,
)
insert into Books VALUES
('Война и мир', 'Лев', 'Толстой', 'Николаевич', 'Роман-эпопея Льва Николаевича Толстого, описывающий русское общество в эпоху войн против Наполеона в 1805-1812 годах. Эпилог романа доводит повествование до 1820 года.', 0),
('Гранотвый браслет','Александр','Куприн','Иванович', 'Повесть Александра Ивановича Куприна, написанная в 1910 году и впервые опубликована в 6-м сборнике альманаха «Земля» в 1911 году. Основана на реальных событиях.', 1);
go

create table BookAndReaders(
Id int not null identity constraint PK_BookAndReader primary key,
IdBook int not null constraint FK_BookId foreign key references Books(Id) on delete cascade,
IdReader int not null constraint FK_ReaderId foreign key references Users(Id) on delete cascade,
)

insert into BookAndReaders VALUES
(2, 3),
(1,4);
go