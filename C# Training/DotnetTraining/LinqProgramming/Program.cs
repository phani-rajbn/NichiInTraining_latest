using System;
using System.Collections.Generic;
using System.Linq;
/*
	Implicitly typed local variables 
	Anonymous Types 
	Extension Methods 
	Object and Collection Initializer 
	Lambda Expressions 
	Query Expressions 
*/
namespace LinqProgramming
{
  class Patient
  {
    public string PatientName { get; set; }
    public string Address { get; set; }
  }

  
  static class ExtensionMethods
  {
    public static int GetNoOfWords(this string strValue)
    {
      //logic for getting the words
      var words = strValue.Split(' ');
      return words.Length;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      //usingVarkeyword();
      //anonymousTypes();
      //extensionMethods();
      //objectInitializationSyntax();

      List<string> data = new List<string>{ "Tanush", "Rakesh", "Anoop", "Girish", "Prashant", "Harish", "Siddu", "Phaniraj" };
      var names = from emp in data
                  where emp == "Rakesh"
                  select emp;//select * from data where value like %''%
      data.Add("Suman");
      data.Add("Mohan");
      //LINQ EXpression will execute only if U iterate the result using foreach... 
      //LINQ Expression always returns IEnumerable<T> object which will have to be iterated to get the results, even if its a single record...

      foreach (var name in names)//ExecuteReader method....
        Console.WriteLine(name);
    }

    private static void objectInitializationSyntax()
    {
      Patient p = new Patient { PatientName = "testName", Address = "Bangalore" };
      var myList = new List<string> { "Apple", "Mango", "Orange" };
      foreach (var item in myList)
      {
        Console.WriteLine(item);
      }
    }

    private static void extensionMethods()
    {
      string text = "C# supports strongly typed implicit variable declarations";
      int result = text.GetNoOfWords();
      Console.WriteLine("The result is " + result);
    }

    private static void anonymousTypes()
    {
      var emp = new { EmpID = 123, EmpName = "Phaniraj", EmpAddress = "Bangalore" };
      Console.WriteLine("The name of the employee is " + emp.EmpName);
    }

    private static void usingVarkeyword()
    {
      //var is implicit typed variable. It used to create local variables. It is purely for convinience. It is type safe. The variable takes the data type based on the value it is assigned to...
      //var is used only on local variables, it cannot be used as field, property type, arguments or return type of a function. It helps in creating the using variables in a easy manner. var must be assigned at the same statement of declaration 
      var p = new Patient { Address = "RR Nagar", PatientName = "Phaniraj" };
      object p1 = new Patient { Address = "RR Nagar", PatientName = "Phaniraj" };
      //object will have boxed values.. U should unbox before use....
      Console.WriteLine(p.PatientName);
      Console.WriteLine((p1 as Patient).PatientName);
    }
  }
}
