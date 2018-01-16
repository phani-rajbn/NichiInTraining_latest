create table Category
( 
	CategoryID int primary key identity(1,1),
	CategoryName varchar(100) NOT NULL
)

insert into Category values('Himalaya')
insert into Category values('Patanjali')
insert into Category values('Johnson')
insert into Category values('Swadeshi')
insert into Category values('Dabur')
insert into Category values('Uniliver')

Create table Product
( 
 ProductID int primary key identity(1,1),
 ProductName varchar(50) NOT NULL,
 ProductCost money NOT NULL,
 ProductQuantity decimal(34,15) NOT NULL,
 UpdateDate Date DEFAULT GETDATE(),
 Updater varchar(100),
 CatID int references Category(CategoryID) 
)

SELECT * FROM Category
Insert into Product(ProductName, ProductCost, ProductQuantity,CatID) VALUES('Vaseline Cocoa', 225, 4000, 6)
Insert into Product(ProductName, ProductCost, ProductQuantity,CatID) VALUES('Domex 550ml', 100, 20000, 6)
Insert into Product(ProductName, ProductCost, ProductQuantity,CatID) VALUES('Red label Tea 500gm', 145, 1000, 6)
Insert into Product(ProductName, ProductCost, ProductQuantity,CatID) VALUES('Red label Tea 250gm', 85, 500, 6)
Insert into Product(ProductName, ProductCost, ProductQuantity,CatID) VALUES('Pepsodent 100gm', 60, 4000, 6)

SELECT Count(*) FROM PRODUCT


