using System;
//OOP is a programming stategy for developing complex applications using features like Reuseability, Inheritance, Polymorphism, Encapsulation.
//OOP is based on SOLID Principles of Programming:
/*
 Single Responsibility Principle: One class should do only one task. It should not mix multiple tasks in one class. U should create seperate classes for seperate Tasks like INputs, Validations, Data Access, Business rules implementation, UI Interactions to name a few.. 
 Classes that represent the data of UR App are called as Entity Classes.
 Classes that interact with the database are called DAL Components
 Classes that enforce the business rules are called as Business objects
 Classes that perform the validation are called Validation Classes.
  
 Open Close Principle: A Class is closed for modification but open for extension. 

 Luskov's Substitution Principle: A Base class object could be substituteed by any of the derived classes leading to concept called Runtime Polymorphism.
 Interface Segregation Principle.
 Dependency Inversion Principle. 
*/
namespace SampleConApp
{
  namespace Entities
  {
    public class Employee
    {
      public int EmpID { get; set; }
      public string EmpName { get; set; }
      public string EmpAddress { get; set; }
    }
  }

  namespace DataAccessLayer
  {
    class EmpRepository
    {
      Entities.Employee[] _data;
      public EmpRepository()
      {
        _data = new Entities.Employee[100];//Array is fixed in size...
      }

      //Find the first occurance of null object in the Array and assign the value of the new employee into the array...
      public virtual void AddNewEmployee(Entities.Employee emp)
      {
        for (int i = 0; i < _data.Length; i++)
        {
          //For a reference type array, all elements will be null
          if(_data[i] == null)
          {
            _data[i] = new Entities.Employee();
            _data[i].EmpID = emp.EmpID;
            _data[i].EmpName = emp.EmpName;
            _data[i].EmpAddress = emp.EmpAddress;
            return;//exit the function...
          }
        }
        //Raise an exception to tell that no more employees could be added...
      }

      public virtual void DeleteEmployee(int id)
      {
        for (int i = 0; i < _data.Length; i++)
        {
          if(_data[i] != null && _data[i].EmpID == id)
          {
            _data[i] = null;//Removing the existing data...
          }
        }
      }

      public virtual Entities.Employee[] GetAllEmployees()
      {
        //Currently U might have a mixed data of actual Employees and null. This function should remove all the null objects and create a new Copy of Array that contains valid Employees..
        Entities.Employee[] tempList = new Entities.Employee[0];
        foreach(Entities.Employee emp in _data)
        {
          if(emp != null)
          {
            var temp = tempList.Clone() as Entities.Employee[];//Creates a Copy of the Array.
            tempList = new Entities.Employee[temp.Length + 1];
            temp.CopyTo(tempList, 0);
            tempList[tempList.Length - 1] = emp;
          }
        }
        return tempList;
      }
    }
  }

  namespace UILayer
  {
    using System.IO;
    using Entities;
    using DataAccessLayer;
    class OOPConcepts
    {
      static EmpRepository _empData = new EmployeeCollection();
      //This is Runtime Polymorphism._empData will n  ow behave like EmployeeCollection instead of EmpRepository...
      static void Main(string[] args)
      {
        string filepath = args[0];//Get the first arg
        StreamReader reader = new StreamReader(filepath);
        string menu = reader.ReadToEnd();
        bool processing = true;
        do
        {
          Console.Clear();
          string choice = UIHelper.GetString(menu);
          processing = processMenu(choice);
        } while (processing);
      }

      private static bool processMenu(string choice)
      {
        switch (choice)
        {
          case "1":
            addEmpToDb();
            return true;
          case "2":
            deleteEmpFromDb();
            return true;
          case "3":
            displayAll();
            return true;
          default:
            return false;
        }
      }

      private static void displayAll()
      {
        var data = _empData.GetAllEmployees();
        foreach(Employee emp in data)
        {
          Console.WriteLine($"{emp.EmpName} from {emp.EmpAddress}");
        }
        Console.ReadLine();
      }

      private static void deleteEmpFromDb()
      {
        int empId = UIHelper.GetInteger("Enter the ID of the Employee tod delete");
        _empData.DeleteEmployee(empId);
        Console.WriteLine("Employee deleted successfully");
      }

      private static void addEmpToDb()
      {
        Employee emp = new Employee();
        emp.EmpID = UIHelper.GetInteger("Enter the ID");
        emp.EmpName = UIHelper.GetString("Enter the Name");
        emp.EmpAddress = UIHelper.GetString("Enter the Address");
        _empData.AddNewEmployee(emp);
        Console.WriteLine("Employee added successfully");
      }
    }
  }
}