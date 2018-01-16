--DML Operations are used to perform manipulations of the data like insertion, deletion, updation and Reading. 
--DELETE FROM TABLENAME WHERE COLUMNNAME = 'VALUE'
--UPDATE TABLENAME SET COLNAME = 'VALUE' WHERE COLNAME ='criteria'
Use NichiInDatabase
GO
Update Student Set InstituteId = 4 where Id >= 85

------------SELECT All the Records------
SELECT * FROM Student
--Gets the unique data from the table
SELECT DISTINCT Qualification From Student

SELECT Name AS StudentName, Student.Address as Student_Address From Student
-----------------------Filtering------------------------
SELECT COUNT(NAME) AS STUDENTSTRENGTH FROM STUDENT WHERE InstituteId <= 3
--COUNT is a Scalar Value function which returns single value. Functions like Avg, SUM, MIN, MAX and many more...

SELECT NAME FROM STUDENT WHERE InstituteId <> 4--Not Equal to SQL server.

SELECT NAME FROM STUDENT WHERE InstitutionId BETWEEN 2 and 4

SELECT NAME FROM STUDENT WHERE CITY = 'BANGALORE'

SELECT NAME, City FROM STUDENT WHERE CITY ='Bangalore' AND InstitutionId = 5
SELECT NAME, City FROM STUDENT WHERE CITY ='Bangalore' OR InstitutionId = 5


SELECT NAME, City FROM STUDENT WHERE InstitutionId = 5
DROP TABLE Student
 --------------------ORDER BY FOR SORTING--------------------------------
 SELECT NAME, City FROM STUDENT ORDER BY NAME DESC, CITY ASC
 ------------------------------------------
 SELECT TOP 5 * FROM STUDENT WHERE CITY ='bangalore'

 SELECT TOP 5 NAME FROM STUDENT WHERE CITY ='BANGALORE'

 --Get the data based on pattern....
 SELECT NAME FROM STUDENT WHERE NAME LIKE 'A%'
------------------------------------------------------------------------------------------
 Create table Dept
 (
  DeptID int primary key IDENTITY(1,1),
  DeptName varchar(20) NOT NULL
 )
 GO
 Create table Employee
 (
  EmpID int PRIMARY KEY IDENTITY(1,1),
  EmpName varchar(50) NOT NULL,
  EmpAddress varchar(100) NOT NULL,
  EmpSalary Money NOT NULL,
  DeptId int REFERENCES Dept(DeptId)
 )

 INSERT into Dept values('Admin')
 INSERT into Dept values('Sales')
 INSERT into Dept values('After Sales')
 INSERT into Dept values('Production')
 INSERT into Dept values('Services')
 INSERT into Dept values('Tech Services')
 --------------------------------------------------------------------------------------
 SELECT AVG(EmpSalary) AS AvgSalary, MIN(EmpSalary) as MinSalary, MAX(EmpSalary) as MaxSalary from Employee
 --NOTE: U cannot use Aggregate functions in a where clause. U should use it in a subquery and the result is put in the where clause. 
 SELECT EmpName FROM Employee WHERE EmpSalary < (SELECT AVG(EmpSalary) FROM EMPLOYEE);

SELECT Employee.EmpName, Employee.EmpSalary From Employee where EmpAddress in ('Bangalore','Hyderabad')
---------------------------------------GROUP BY CLAUSE-----------------------------------
SELECT Count(EmpName) as NoOfEmployees, EmpAddress 
FROM Employee
GROUP BY EmpAddress

SELECT EmpName as Name, DeptID as Dept
FROM Employee
GROUP BY DeptId, EmpName 
--Find the Dept and their salary expenditure order by the Total Salaries. 
SELECT DeptID as Dept, SUM(EmpSalary) as TotalSalaries
INTO NewEmpTable--Creates a new table and adds the data along with the schema into this table
FROM EMPLOYEE
WHERE EmpAddress = 'Bangalore'
GROUP BY DeptId
ORDER BY TotalSalaries

SELECT * FROM NewEmpTable--Check for the new table in the database. 


--Get the Depts and their total Salaries whose No of Employees in each dept is more than 30
SELECT DeptId, SUM(EmpSalary) as TotalSalaries FROM Employee
GROUP BY DeptId
HAVING Count(*) >= 20 --Use having if U want to filter the group results based on a condition. 
--Get the DeptId and Total No Of employees of that dept whose salaries are more than the Avg Salary of the Company...
SELECT DeptID as Dept, COUNT(EmpID) as Number  
FROM Employee
WHERE EmpSalary > (SELECT AVG(EmpSalary) FROM Employee)
GROUP BY DeptId 
SELECT DeptId as Dept, COUNT(Empname) FROM EMPLOYEE
GROUP  BY DeptId

--Group By will work only if the clause is a part of the Select statement. If the column is a part of the select statement, it should be the part of group by also...U can have aggregate functions in the select statement without being the part of the group by clause