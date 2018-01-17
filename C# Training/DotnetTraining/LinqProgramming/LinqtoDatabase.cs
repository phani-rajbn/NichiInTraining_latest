using System;
using System.Xml.Linq;
using System.Linq;
namespace LinqProgramming
{
  class LinqDBProgram
  {
    //create a table called Dept->DeptID. DeptName
    //create a table called Employee->EmpID, EmpName, EmpAddres, DeptID
    static void bulkInsertion()
    {
      //Get the XML file
      XDocument doc = XDocument.Load("AllEmployees.xml");
      //Using LINQ we will convert all the elements of the tag Employee in the XML doc to EmpTable objects....
      var empData = from element in doc.Descendants("Employee")
                    select new EmpTable
                    {
                      EmpID = int.Parse(element.Element("EmpID").Value),
                      EmpName = element.Element("EmpName").Value,
                      EmpAddress = element.Element("EmpAddress").Value,
                      DeptId = element.Element("DeptID") == null ? new Nullable<int>() : int.Parse(element.Element("DeptID").Value)
                    };
      //create the Context object
      ExampleDataContext contextObj = new ExampleDataContext();
      //insert the converted EmpTable objects into the EmpTables of the DataContext...
      contextObj.EmpTables.InsertAllOnSubmit(empData.ToList());
      //commit to the database...
      contextObj.SubmitChanges();
    }

    static void insertSingleRecord()
    {
      //var newRec = new XElement("Employee", new XElement("EmpID", 103),
      //                      new XElement("EmpName", "Vinod Kumar"),
      //                      new XElement("EmpAddress", "Mysore"));

      var empRec = new EmpTable
      {
        EmpID = 104,
        EmpName = "Manoj Kumar",
        EmpAddress = "Kolkatta",
        DeptId = 5
      };
      var context = new ExampleDataContext();
      context.EmpTables.InsertOnSubmit(empRec);
      context.SubmitChanges();
    }

    static void displayAllRecords()
    {
      //getNamesAndDepts();


    }

    private static void getNamesAndDepts()
    {
      var data = new ExampleDataContext().EmpTables;
      var namesWithDepts = from emp in data
                           select new
                           {
                             Name = emp.EmpName,
                             Dept = emp.DeptTable.DeptName ?? "Not Allocated"
                           };
      foreach (var name in namesWithDepts)
        Console.WriteLine(name);
    }

    static void deleteRecord()
    {
      Console.WriteLine("Enter the ID to delete");
      int id = int.Parse(Console.ReadLine());
      var context = new ExampleDataContext();
      var rec = (from emp in context.EmpTables
                 where emp.EmpID == id
                 select emp).FirstOrDefault();
      if(rec == null)
        Console.WriteLine("No Emp Found to Delete");
      else
      {
        context.EmpTables.DeleteOnSubmit(rec);
        context.SubmitChanges();
      }
    }

    static void updateRecord()
    {

    }
    static void readRecordsusingStoredProc()
    {

    }
    static void Main(string[] args)
    {
      try
      {
        //bulkInsertion();
        //insertSingleRecord();
        //displayAllRecords();
        deleteRecord();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}