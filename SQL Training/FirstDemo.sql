--Why Database? 
--I should be able to read large amount of data and also by large no of people at the same time. Files allows multiple read access and only one Write access. Files are not suited for large no of people.
--Data should accessed like an Enterprise App. Multiple Users with different rights are to be accessing UR data.
--Serialization data could be corrupted easily.
--Oracle, Sql Server, MySQL, 
--There are 2 kinds of database: Relational Dbs(All prominent databases) and Non-Relational Dbs(MongoDb, NO-SQL, Email Stores, Files).   
--SQL Server is a data base for developing rich Applications and store large amount of data in the form of Rows and Columns. This is called as Relational Database. The stds defined is called as RDBMS(Relational Database Management System). The databases are created to store the data as Tables. Each Table will have Rows and Columns. The Columns define the structure of the data and the rows represent the data of the Database. There can be any no of Tables in the database. It is recommended to design the tables based on the Normalization priciples of RDBMS. 
--Every table must have atleast one column that represent unique data for the table. This column is called as PRIMARY key Column. U can have composite primary key columns where the combination of the data in those rows should be unique. U can have only one Primary key which could be either single or composite. But U cannot have more than one column to be primary keys even if U wish to have the other column with unique data. The other column could be added with a new constraint called UNIQUE constraint(Rule).
--If U have columns that have repeated Data, then its good to make that data as a seperate Table. Link the table with the repeated data table. This is called as Relations. When Tables are related, they are called as Relational Database. Its good practise to have all the tables related to one another.  The linking is done thro referencing(Foreign key reference). 
--Eg: A Employee and a Dept. Every Dept has many Employees, each Emp is associated with only one dept. We create a seperate table called Dept(DeptId, Deptname) and another table called Emp(EmpID, EmpName, EmpAddress..., DeptId)where in this case, the Emp.DeptId is a foreign key of the Dept.DeptId. Dept.DeptId is a primary key in the Dept Table. That is referenced in the Emp Table as Foreign key. Rule: When a value is entered in the Emp table, the DeptID value should be that value available in the Dept Table's DeptId.
--U should not have comma seperated values: Book is written by multiple authors, for each book id, U could have n no of authors. Each author could have written multiple books. This is called as Many-to-Many. U should create a common link table whre the Id of the Book comes from the bookTable and the Id of the Author will come from the Author table. As the table is created to link the Book and the Author, this table is called Link Table. 
--For interacting with the database, we use a language called SQL. MS version of SQL is called as T-SQL. Oracle's version is called as PL-SQL. Most of the SQL versions are similar in many aspects, but unique in certain keywords and commands. 
--Create the database in the SQL server: U should be one of the dbCreators or admin users. SQL server maintains Security as Users and Roles. Roles are std User types of the database. Admin is the Role with unlimited privilages. If any user has to create a database, they should have access to a database called Master(Sql Database). The users should be the part of the DbCreators group of the SQL server database. 
Create database NichiInDatabase
GO
Use NichiInDatabase
GO
--SQL language is based on C, one of the primitive languages of the systems. Interactions with the database thro SQL are called as QUERIES.  Queries constitutes Statements, Expressions(CREATE, READ, UPDATE And DELETE), Functions, Stored Procedures,
--U should use the database using use keyword. It can be only once...
Create table Institution
(
 InstitutionId int PRIMARY KEY IDENTITY(1,1),
 Name varchar(100) NOT NULL,
 Address varchar(MAX) NOT NULL,
 City varchar(100) NOT NULL,
 ContractPerson varchar(200),
 PhoneNo bigint
)
Go
--Sp_ are stored Procedures of SQL Server to perform certain common tasks in the database like Renaming, finding, description details and so forth. 
sp_rename 'Institution.Address' ,'InstitutionAddress', 'COLUMN'

--Use this to find the collumns of the table called Instition
sp_columns Student
sp_tables
--Exit the existing database by migrating to another database(Either User defined or System). Perferably for master database
GO
Use Master
DROP DATABASE NichiInDatabase--DROP DATABASE is used for droping the database.
Create table student
(Id int PRIMARY KEY, 
Name varchar(50) NOT NULL, Gender varchar(10) NOT NULL, DateOfBirth DateTime NOT NULL, Address varchar(200) NOT NULL, ParentName varchar(100) NOT NULL, Qualification varchar(100) NOT NULL, ContactNo bigint NOT NULL, Class varchar(5) NOT NULL, Division char)
--SQL is not case sensitive.
sp_rename 'student', 'Student'   
--Inserting records into the table----
--Insert into tableName values()->use this if U have the data matching the columns of the table...
Insert into Institution values('Little Flower School', 'BSK 3rd Stage', 'Bangalore','D-Souza', 66990987)
--Insert into tablename(columns) values()->To insert records to specific columns of the table. The remaining column values will be either NULL or DEFAULT values that U would have set. 
Insert into Institution(Name, City, InstitutionAddress ) VALUES('Sarvodhaya School','Mysore', 'VV Mohala')
 
--Adding new Column into a table....
--If U want to modify the table schema, U should use alter table...
ALTER TABLE Student
ADD InstituteId INT REFERENCES Institution(InstitutionId)
--While adding a new column to an existing table, U should ensure that the new column should not conflict with any constraints that U wish to place in the Column. 

ALTER TABLE STUDENT
DROP CONSTRAINT FK__Student__Institu__1273C1CD
GO
ALTER TABLE STUDENT
DROP COLUMN InstituteId
GO
--Adding Constraints to a table....
Alter table Institution
ADD CONSTRAINT ck_City CHECK (City IN ('Bangalore','Mysore','Hubli'))
--Checks the data to have values within the specified data...... 
Alter table Institution
ADD CONSTRAINT uq_Name UNIQUE(Name)--Name is the column for which U wish to have unique values...
--NOTE: A table will have only one Primary key. If U want another column to have unique  values, then U should use UNIQUE Constraint. There is no limitation on the no of UNIQUE Constraints for a given table. if the data in the column of the table has duplicate data, then the constraint will not be created. U should remove the duplicate data and then add the Constraint...

 
--Droping the Constraint from the table...
Alter table Institution
DROP CONSTRAINT uq_Name

--Removing column from a table....
--DROP is used to drop any object of the table like Column, Constraint, INDEX....
ALTER TABLE STUDENT DROP COLUMN InstituteId
--Drop the table....
DROP TABLE student

