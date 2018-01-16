--Joins are linking one or more tables to get a subset of data after merging the tables. Usually data is merged based on the common column data. The Simple Join is the most common way of getting the data. 
SELECT * FROM EMPLOYEE
SELECT * FROM DEPT

--Merge the data of the Employee and the Dept to get EmpNames and the deptNmae
SELECT Employee.Empname, Dept.DeptName --data extraction
FROM Employee INNER JOIN DEPT--tables linking info
ON
Employee.DeptID = Dept.DeptID--Criteria 
--Get the common data of both the tables. 

--Basically there are 4 types of JOINS: 
--INNER JOIN: Simpliest of all the JOINS which returns all the rows where there are atleast one match found in both the tables.
--LEFT JOIN: Returns all the Rows of the left table and the matching rows of the 2nd table. This is required when U have data that has null values where the 1st table may have data that dont have matching records from the second table.(Employees with no Projects) 
--RIGHT JOIN: Returns all the Rows of the right table and the matching rows of the 1st table
--FULL JOIN: Returns all the rows when there is a match in atleast one of the tables(Cartisan product).

sp_columns Employee
UPDATE Employee Set DeptId = NULL WHERE EMpID = 14
---------------LEFT JOIN---------------------
SELECT Employee.EmpName, Dept.DeptName 
FROM Employee LEFT JOIN DEPT
ON Dept.DeptID = Employee.DeptId
------------------------Right outer join-------------------------------
INSERT INTO DEPT VALUES('HR')
-- U want common data of the employees and all the depts of the Company...
SELECT EmpName, DeptName From employee right join dept
on employee.deptid  = dept.deptid
----Full Join combines all the data of both the tables both common and uncommon.
 
