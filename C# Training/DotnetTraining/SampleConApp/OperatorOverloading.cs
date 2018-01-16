using System;
namespace SampleConApp
{
  class Employee 
  {
    public int EmpID { get; set; }
    public string EmpName { get; set; }
    public int EmpSalary { get; set; }
    /*
    Operators can be overloaded thro static functions. U should use operator keyword to illustrate that the specific operator is being overloaded. If it is a binary operator, U must have 2 operands.
    If U R overloading the == Operator, U must override the EqualsTo and GetHashCode Function of the System.Object..
    HashCode is a unique identified by the object. Every data type in C# has a HashCode. U could use the Hashcode of the property that UR using to perform the == operation as UR object's HashCode.  
    Use operator overloading on objects that U want to perform computional logic using simple operators. usually performed on Financial Calculations and mathematical Software.
    */
    public static bool operator ==(Employee emp, Employee emp2)
    {
      return emp.EmpID == emp2.EmpID;
    }

    public static bool operator !=(Employee emp, Employee emp2)
    {
      return emp.EmpID != emp2.EmpID;
    }

    public static Employee operator +(Employee emp, int salary)
    {
      emp.EmpSalary += salary;
      return emp;
    }

    public static Employee operator -(Employee emp, int salary)
    {
      emp.EmpSalary -= salary;
      return emp;
    }
    public override bool Equals(object obj)
    {
      if(obj is Employee)
      {
        var emp = obj as Employee;//Unboxing a reference type...
        return this.EmpID == emp.EmpID;
      }
      return false;
    }
    
    public override int GetHashCode()
    {
      return this.EmpID.GetHashCode();
    }

    public override string ToString()
    {
      return string.Format($"Name:{EmpName}\tSalary:{EmpSalary}"); ;
    }
  }
  class OperatorDemo
  {
    static void Main(string[] args)
    {
      Employee emp = new Employee { EmpID = 123, EmpName = "Phaniraj", EmpSalary = 50000 };
      Employee emp2 = new Employee { EmpID = 123, EmpName = "Phaniraj", EmpSalary = 50000 };
      if(emp == emp2)
        Console.WriteLine("They are same employees");
      else
        Console.WriteLine("They are different Employees");
      emp += 5000;//Incrementing the salary using + operator...
      Console.WriteLine(emp);
    }
  }
}