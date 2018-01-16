Use NichiInDatabase
GO
--Scalar value functions: SQL server provides Functions that return single value from a Query, This i is called as SVF. SPs cannot be used as an expression inside a Query. U should explicitly call the SP using EXEC command and then store the value inside a declared variable. SELECT Statement returns a Temp Table which contain the Columns and Rows. Columns would be the required values and Rows would be the data extracted from the SELECT Statement.
--SQL Server has many such SVFs in it to perform Aggregate function calls. AVG, MIN, MAX, LENGTH, SUM and many more. DATEDIFF for date related functions....
 
SELECT COUNT(*) as EmpCount FROM Employee WHERE EmpSalary < (SELECT AVG(EmpSalary) FROM Employee)

SELECT MIN(EmpSalary) as MIN, MAX(EmpSalary) as MAX, AVG(EmpSalary) as AVG From Employee

--The Avg Salaries of each dept with the deptname...
SELECT Dept.DeptName, AVG(Employee.EmpSalary) as AvgSalary
FROM Employee JOIN Dept
ON Dept.DeptID = Employee.DeptId
GROUP BY Dept.DeptName 
ORDER BY AvgSalary

--Get the MAx salary of each city...
SELECT Employee.EmpAddress As City, MAX(EmpSalary) as MaxSalary 
from Employee
GROUP BY Employee.EmpAddress
ORDER BY MaxSalary DESC

-----------------STRING BASED FUNCTIONS-----------------------
SELECT UPPER(Employee.EmpName) as Name, LOWER(Employee.EmpAddress) FROM Employee

Update Employee
Set EmpName = CONCAT(EmpName, '    ')-- WHERE EmpID IN (SELECT * FROM Employee WHERE EmpID > 0)

SELECT EmpName FROM Employee WHERE EmpName = 'Rickie Aird     '

SELECT SUBSTRING(EmpName, LEN(EmpName) , 1) FROM Employee
-----------------------------Date Time Functions-----------------------------
SELECT GETDATE() AS DATE --Gets the system date...

DECLARE @currentDate DATE
SET @currentDate = (SELECT GETDATE())
SELECT DATEPART(DD, @currentDate) as DATE,DATEPART(MM, @currentDate) as MONTH,DATEPART(YY, @currentDate) as YEAR

SELECT DATEDIFF(MONTH, '12/01/1976', GetDate())/12 AS AGE

----------------UDFs------------------------------------
Create Function GetDateOnly()
RETURNS DateTime
AS
BEGIN
 Return (SELECT CONVERT(DateTime, Convert(date, GetDate())))
END

SELECT dbo.GetDateOnly()


Create Function GetAvgSalary(@deptName varchar(50))
RETURNS MONEY
AS
BEGIN
  RETURN (SELECT AVG(EmpSalary) FROM Employee JOIN Dept ON DEPT.DeptID = Employee.DeptId
  WHERE Dept.DeptName = @deptName)
END


SELECT dbo.GetAvgSalary('After Sales')

--Create a function called DisplayDate which should get the date in the format of dd/MM/yyyy
SELECT GETDATE()

