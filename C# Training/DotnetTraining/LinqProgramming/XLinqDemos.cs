using System;
using System.Linq;
using System.Xml.Linq;
namespace LinqProgramming
{
  class XLinqDemo
  {
    static XDocument doc = XDocument.Load("AllEmployees.xml");
    static void Main(string[] args)
    {
      //readXmlFile();
      readOnlyNames();
      //insertNewRec();
      //deleteRecord();
    }

    private static void deleteRecord()
    {
      Console.WriteLine("Enter the Id of the Employee to delete");
      string id = Console.ReadLine();
      var records = from element in doc.Descendants("Employee")
                    where element.Element("EmpID").Value == id
                    select element;
      var selectedRec = records.FirstOrDefault();//Gets the first record in the linq or default...
      if (selectedRec == null)
        return;
      selectedRec.Remove();
      doc.Save("Copy.xml");

    }

    private static void insertNewRec()
    {
      //create a new element schema
      var newRec = new XElement("Employee", new XElement("EmpID", 102),
                            new XElement("EmpName", "Vinod Kumar"),
                            new XElement("EmpAddress", "Mysore"),
                            new XElement("DeptID", 3));
      //find the last Schema of Employee
      var lastRec = doc.Descendants("Employee").Last();
      //add the new element after the last Schema...
      lastRec.AddAfterSelf(newRec);
      //save the document..
      doc.Save("AllEmployees.xml");
    }

    private static void readOnlyNames()
    {
      var names = from element in doc.Descendants("Employee")
                  select new { Name = element.Element("EmpName").Value, Address = element.Element("EmpAddress").Value };
      foreach(var name in names)
        Console.WriteLine(name);
    }

    private static void readXmlFile()
    {
      Console.WriteLine(doc);
    }
  }
}