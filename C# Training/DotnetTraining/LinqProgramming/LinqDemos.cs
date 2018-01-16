using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LinqProgramming
{
  class Employee
  {
    public int EmpID { get; set; }
    public string EmpName { get; set; }
    public string EmpAddress { get; set; }
    public int DeptId { get; set; }
  }

  class Dept
  {
    public int DeptID { get; set; }
    public string DeptName { get; set; }
  }

  static class DataComponent
  {

    public static List<Dept> GetAllDepts()
    {
      return new List<Dept>
      {
        new Dept { DeptID = 1, DeptName ="Sales" },
        new Dept { DeptID = 2, DeptName ="Finance" },
        new Dept { DeptID = 3, DeptName ="Admin" },
        new Dept { DeptID = 4, DeptName ="Production" },
        new Dept { DeptID = 5, DeptName ="Labour" },
        new Dept { DeptID = 6, DeptName ="IT" }
      };
    }

    public static List<Employee> GetAllEmployees()
    {
      var fileName = @"../../Employees.csv";
      var reader = new StreamReader(fileName);
      List<Employee> tempList = new List<Employee>();
      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(',');
        var emp = new Employee();
        emp.EmpID = Convert.ToInt32(values[0]);
        emp.EmpName = values[1];
        emp.EmpAddress = values[2];
        emp.DeptId = int.Parse(values[3]);
        tempList.Add(emp);
      }
      reader.Close();
      return tempList;

    }

  }
  class LinqDemos
  {
    static List<Dept> deptCollection = DataComponent.GetAllDepts();
    static List<Employee> collection = DataComponent.GetAllEmployees();
    static void Main(string[] args)
    {
      //displayNames();
      //displayNamesAndAddresses();
      //displayNamesInOrder();
      //displayDistinctCities();
      //displayNamesonPlace();
      //displayNamesGroupedByAddress();
      //displayNamesByAlphabet();
      //displayDistinctDeptIds();
      //displayDeptsWithNames();
      //displayNamesByDeptName();//using group by clause...
      //convertToXml();
    }

    //Performing LINQ operations on XML doc is called as XLINQ...
    private static void convertToXml()
    {
      var elements = new XElement("AllEmployees", from emp in collection
                                                   select new XElement("Employee", 
                            new XElement("EmpID", emp.EmpID),
                            new XElement("EmpName", emp.EmpName),
                            new XElement("EmpAddress", emp.EmpAddress),
                            new XElement("DeptID", emp.DeptId)));
      elements.Save("AllEmployees.xml");
    }

    private static void displayNamesByDeptName()
    {
      var details = from emp in collection
                    join dept in deptCollection on
                    emp.DeptId equals dept.DeptID
                    group new { emp.EmpName, dept.DeptName }
                    by dept.DeptName into g
                    orderby g.Key
                    select g;
      
      foreach(var detail in details)
      {
        Console.WriteLine("People under " + detail.Key);
        foreach(var info in detail)
        {
          Console.WriteLine($"\t{info.EmpName}");
        }
      } 
    }

    private static void displayDeptsWithNames()
    {
      var names = from emp in collection
                  join dept in deptCollection on
                  emp.DeptId equals dept.DeptID
                  select new { emp.EmpName, dept.DeptName };
      foreach(var info in names)
        Console.WriteLine($"{info.EmpName} from {info.DeptName}");
    }

    private static void displayDistinctDeptIds()
    {
      var depts = (from emp in collection
                   orderby emp.DeptId
                   select emp.DeptId).Distinct();
      foreach(var dt in depts)
        Console.WriteLine(dt);
    }

    private static void displayNamesByAlphabet()
    {
      var groups = from emp in collection
                   group emp.EmpName by emp.EmpName[0] into g
                   orderby g.Key
                   select g;
      foreach(var gr in groups)
      {
        Console.WriteLine("Names under " + gr.Key);
        foreach(var name in gr)
          Console.WriteLine("\t" + name);
      }
    }

    private static void displayNamesGroupedByAddress()
    {
      var groups = from emp in collection
                   orderby emp.EmpName 
                   group emp.EmpName by emp.EmpAddress into g
                   orderby g.Key descending
                   select g;
      //It returns a collection of groups, each group has collection of employees

      foreach(var gr in groups)
      {
        Console.WriteLine("People from " + gr.Key);
        foreach(var emp in gr)
        {
          Console.WriteLine("\t" + emp);
        }
        Console.WriteLine();
      }
    }

    private static void displayDistinctCities()
    {
      var cities = (from emp in collection
                    select emp.EmpAddress).Distinct();
      foreach(var city in cities)
        Console.WriteLine(city);
    }

    private static void displayNamesonPlace()
    {
      Console.WriteLine("Enter the name of the city to search");
      string city = Console.ReadLine();
      var records = from emp in collection
                    where emp.EmpAddress == city
                    orderby emp.EmpName
                    select emp.EmpName;
      foreach(var emp in records)
        Console.WriteLine(emp);
    }

    private static void displayNamesInOrder()
    {
      var names = from emp in collection
                  orderby emp.EmpName
                  select emp.EmpName;
      foreach(var name in names)
        Console.WriteLine(name);
    }

    private static void displayNamesAndAddresses()
    {
      //LINQ select always selects a single object....
      var namesAndAddresses = from emp in collection
                              select new { emp.EmpName, emp.EmpAddress };
      foreach(var nA in namesAndAddresses)
        Console.WriteLine($"{nA.EmpName} from {nA.EmpAddress}");
    }

    private static void displayNames()
    {
      //Display all the names...
      var names = from emp in collection
                  select emp.EmpName;
      foreach (var name in names)
        Console.WriteLine(name);
    }
  }

}