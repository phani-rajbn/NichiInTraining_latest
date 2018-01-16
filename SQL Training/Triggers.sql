--Triggers are self executing Statements that are automatically invoked whena certain opperation like INSERT, DELETE, UPDATE happens. Triggers dont raise for SELECT statements. So in triggers, we have 3 types of TRIGGERS: INSERTION TRIGGERS, UPDATION TRIGGERS and DELETION TRIGGERS.  Triggers are not explicitly called by any program, rather it is implicitly invoked when the appropriate insertio, deletion or updation happens to the table.
 
 --Add a new column to the dept table called NoOfEmployees which will contain the count of the employees in that dept..
 ALTER TABLE DEPT
 ADD NoOfEmployees int

 DELETE FROM DEPT WHERE DeptID > 9
 SELECT * FROM DEPT
 UPDATE DEPT
 SET NoOfEmployees = (SELECT COUNT(*) FROM Employee WHERE Employee.DeptId =6) WHERE DEPT.DeptID = 6

 Alter trigger trginsert
 on Employee
 AFTER Insert
 AS
 DECLARE @deptId int
 --SELECT * from inserted
 SELECT @deptId = DeptId From inserted
 Update Dept set NoOfEmployees = NoOfEmployees + 1 Where DeptID = @deptId

 Insert into Employee values('TestName', 'Mysore', 55000, 4)

 ALTER trigger trgUpdate
 ON Employee
 After update
 AS
 declare @old int
 declare @new int
 Select @old = DeptId from deleted
 select @new = DeptId from inserted
 Update Dept set NoOfEmployees = NoOfEmployees - (SELECT COUNT(*) FROM deleted) WHERE DeptID = @old
 Update Dept set NoOfEmployees = NoOfEmployees + (SELECT COUNT(*) FROM inserted) WHERE DeptID = @new

Update Employee set DeptId = 7 where EmpID = 67

