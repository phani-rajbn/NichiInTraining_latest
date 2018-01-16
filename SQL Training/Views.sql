--Views are sp objects that are created to encapsulate complex queries with simple data.  They provide alias to UR actual tables. They are not allocated with any memory, its purely virtual. So data is not stored physically in any part of the database. A View is typically created to hide the actual names of UR columns and give aliased names so that it highly hides the actual schema of UR tables...

Create View MyDataView
AS
SELECT EMpName as Name, EmpAddress as Address, DeptName as Dept From Employee, Dept
Where Employee.DeptId = Dept.DeptID

SELECT * FROM MyDataView

