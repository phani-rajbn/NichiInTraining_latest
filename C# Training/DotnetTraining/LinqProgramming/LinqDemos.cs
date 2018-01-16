using System;
using System.Collections.Generic;
using System.IO;
namespace LinqProgramming
{
  class Employee
  {
    public int EmpID { get; set; }
    public string EmpName { get; set; }
    public string EmpAddress { get; set; }
    public int DeptId { get; set; }
  }

  static class DataComponent
  {
    public static List<Employee> GetAllEmployees()
    {
      var fileName = @"C:\Users\Phani Raj\Desktop\Current Training\C# Training\DotnetTraining\LinqProgramming\Employees.csv";
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
      return tempList;

    }
  }
  class LinqDemos
  {
    static List<Employee> collection = DataComponent.GetAllEmployees();
    static void Main(string[] args)
    {


    }
  }

}