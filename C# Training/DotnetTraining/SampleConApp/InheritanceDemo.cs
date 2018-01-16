using System;
namespace SampleConApp
{
  //As any class is open for extension,  I am creating a new class which inherits from the Base class and I wish to modify the functionality. The Base class should have marked the functions as virtual and UR Class now will notify to the system that it is being modified using override
  namespace DataAccessLayer
  {
    using SampleConApp.Entities;
    using System.Collections.Generic;

    class EmployeeCollection : EmpRepository
    {
      //UR Intention is to modify the existing functions. 
      List<Employee> _empList = new List<Employee>();
      public override void AddNewEmployee(Employee emp)
      {
        if(emp == null)
        {
          //Throw an Exception saying that the Employee was not created properly..
          return;
        }
        _empList.Add(emp);
        //Adds the element to the bottom of the List, similar to Array of Javascript....
      }

      public override Employee[] GetAllEmployees()
      {
        return _empList.ToArray();
      }

      public override void DeleteEmployee(int id)
      {
        foreach(Employee emp in _empList)
        {
          if (emp.EmpID == id)
          {
            _empList.Remove(emp);
            return;
          }
        }
        //Throw an Exception that Emp with this Id was not found to delete.
      }
    }
  }

  class A
  {
    public virtual void TestFunc()
    {
      Console.WriteLine("TestFunc");
    }
  }
  /*
  It is single inheritance(Only one base class at any level).
  It supports multi level inheritance. 
  There is private inheritance in C#. 
  If an method has to be modified in the derived class, then base class should mark the method as virtual and derived class will redefine the function using override.  
  */
  class B : A
  {
    public override void TestFunc()
    {
      Console.WriteLine("Changed function of the TestFunc");
    }
    public void TestFunc2()
    {
      Console.WriteLine("Test Func2");
    }
  }
  class InheritanceExample
  {
    static void Main(string[] args)
    {
      A a = new A();
      a.TestFunc();//A's version of TestFunc...

      B b = new B();
      b.TestFunc();//Will behave like B...
      b.TestFunc2();

      a = new B();//base class obj can be instantiated to derived class
      a.TestFunc();//Calling B's version even though its type of A. 
      //This is called object slicing where the new functions of the derived class will be available for the base class object...
      
    }
  }
}