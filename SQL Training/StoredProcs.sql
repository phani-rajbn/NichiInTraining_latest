--Stored Procedures are group of statements that are created to perform common operations in UR Application. Stored procedures are more optimized than writing regular SQL statements. 
--Every SQL statement is parsed and executed every time U call it. There by frequently used Queries are less optimized. U could create a Stored proc(Function) which is parsed once when the procedure is created, and can be executed n no of times. While U execute, the Stored Proc will not parsed again, there by it is more performance oriented than a regular SQL statement..
sp_columns Dept
Create Procedure InsertEmp
(
  @empName varchar(50),
  @empAddress varchar(100),
  @empSalary money,
  @deptID int,
  @empID int OUTPUT
)
AS

INSERT INTO Employee VALUES(@empName, @empAddress, @empSalary, @deptID);
SET @empID = @@IDENTITY

DECLARE @id INT
SET @id = 0
EXEC InsertEmp @empName ='Mohan Rao', @empAddress ='Bangalore', @empSalary = 55000, @deptId = 4, @empId = @id output

DECLARE @val VARCHAR(10)
SET @val = (SELECT MAX(EmpId) from Employee)
PRINT 'The last ID is ' + @val

ALTER Proc InsertEmpAndDept
(
  @empName varchar(50),
  @empAddress varchar(100),
  @empSalary money,
  @deptName varchar(50),
  @empID int OUTPUT
)
AS
--Create a variable called DeptID
DECLARE @deptid int
DECLARE @id int
SET @id = 0
--Find the dept Id for the given dept
Set @deptid = (SELECT DeptID From Dept WHERE DeptName = @deptName)
IF @deptid IS NULL
--If null, then insert into dept table
BEGIN
	INSERT INTO Dept VALUES(@@deptName)
	SET @deptid = @@IDENTITY	
END
EXECUTE InsertEmp @empName = @empName, @empAddress = @empAddress, @empSalary = @empSalary, @deptID = @deptid, @empID = @id OUTPUT
	PRINT @id
--get the new id of the dept
--insert the id along with other details in the Employee table...
DECLARE @id INT
SET @id = 0
EXEC InsertEmpAndDept @empName = 'Suraj',@empAddress ='Mysore',@empSalary = 52000, @deptName ='Transport',@empID = @id output
 
 SELECT DISTINCT DeptName from Dept
 --Create a procedure called Updatesalary where any employee who is not allocated with any dept should decrement the salary by 10%

 ALTER Proc UpdateSalary
 AS
 UPDATE Employee
 Set EmpSalary = EmpSalary - (EmpSalary / 10)
 WHERE EmpID IN (SELECT EmpID FROM Employee WHERE DeptId is null) 
 
 SELECT * FROM Employee WHERE DeptId iS NULL

 EXEC UpdateSalary

 SELECT * FROM Employee WHERE DeptId iS NULL

 --Transaction is a group of statements that are to be executed as a single unit. If any of the statements fail, other statements that are already executed should role back the execution. If would be either all the statements have to succeed or none of the statements should succeed. 

 -------------------Using Transactions for performing multiple statements as one single unit-------------------

 ALTER TABLE Employee
 ADD CONSTRAINT ck_Address CHECK (EmpAddress IN ('Bangalore','Chennai','Goa', 'Hyderabad','Mumbai', 'Mysore','Pune'))

ALTER Proc InsertEmpAndDeptTrans
(
  @empName varchar(50),
  @empAddress varchar(100),
  @empSalary money,
  @deptName varchar(50),
  @empID int OUTPUT
)
AS
DECLARE @dpId INT
SET @dpId = 0
BEGIN TRAN t
 	set @dpId = (SELECT DeptID from Dept WHERE DeptName = @deptName)
	IF @dpId IS NULL
	BEGIN
		INSERT INTO Dept VALUES(@deptName);
		Set @dpId = @@IDENTITY
		INSERT INTO Employee VALUES(@empName, @empAddress, @empSalary, GetDept(@deptName))
		COMMIT TRAN t
	END	
	ELSE
		ROLLBACK TRAN t
	RETURN @dpId
SELECT DISTINCT EmpAddress FROM Employee

DECLARE @id INT
SET @id = 0
EXEC InsertEmpAndDeptTrans  @empName='TestName', @empAddress ='TestAddress', @empSalary = 55000, @deptName ='TestDept2', @empID = @id OUTPUT 
PRINT @id

SELECT * FROM Dept

Create Proc GetId
@deptName varchar(50)
AS 
SELECT DeptID from Dept where DeptName = @deptName

EXEC GetId 'Sales'
DECLARE @var int
SEt @var =(SELECT MAX(EmpID) AS MAX FROM Employee)
PRINT @var