using System;
//Constructor is a function that is invoked when an object is created. Ideal place to set values to the data members so that object is usable. It has access specifier followed by the name of the class. It can take arguments. It will not have a return type(Not even void). Invoking the constructor will be done when U use the paranthesis while the object is created.  Constructor with no arguments is called as Default Constructor. It is good practise to have a default constructor and supported by parameterized constructors. C# by itself creates a common constructor to all the .NET Types and objects. Create constructors when U have objects associated in UR class, so that in constructors U could instantiate those objects as per UR business needs. 
 //Static classes can also have constructors, we call them as static Constructors. Static Constructors are invoked only once during the execution of the program. It is created using static keyword for UR Constructor. It will not have access specifiers. U cannot invoke the static constructor exlicitly in UR program. If U want a section of code to execute even before UR Main Program executes, then static constructor is created..
namespace SampleConApp
{

  class Dept
  {
    public int DeptID { get; set; }
    public string DeptName { get; set; }

  }

  class Employee
  {
    public Employee() : this(new Dept())
    {

    }
    public Employee(Dept dept)
    {
      DeptDetails = dept;
    }
    public int EmpId { get; set; }
    public string Empname { get; set; }
    public string EmpAddress { get; set; }
    public Dept DeptDetails { get; set; }//Association. A Class having an instance of another class...
  }
  class ConstructorsDemo
  {
    static ConstructorsDemo()
    {
      Console.WriteLine("Some COde to run even before UR Main executes");
    }
    static void Main(string[] args)
    {
      Console.WriteLine("Program begins....");
      Employee emp = new Employee();
      emp.EmpId = 123;
      emp.Empname = "Phaniraj";
      emp.EmpAddress = "Bangalore";
      emp.DeptDetails.DeptID = 1;
      emp.DeptDetails.DeptName = "Training";

      Console.WriteLine("Mr.{0}'s dept is {1}", emp.Empname, emp.DeptDetails.DeptName);
      Console.WriteLine("Program ends");
    }
  }
}
