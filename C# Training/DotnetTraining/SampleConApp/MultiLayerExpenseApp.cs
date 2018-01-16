using System;
namespace SampleConApp
{
  namespace Entities
  {
    [Serializable]
    public class Expense
    {
      private int no = 0;
      public Expense()
      {
        no++;
        ExpenseID = no;
      }
      public int ExpenseID { get; set; }
      public string Details { get; set; }
      public double Amount { get; set; }
      public DateTime Date { get; set; }
    }
  }

  namespace DataLayer
  {
    using Entities;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;
    interface IDataComponent
    {
      void AddExpense(Expense ex);
      void UpdateExpense(Expense ex);
      List<Expense> FindExpense(DateTime date);
      List<Expense> FindExpense(string info);
    }

    class BinaryDataComponent : IDataComponent
    {
      private List<Expense> _expenses = new List<Expense>();

      private void serialize()
      {
        FileStream fs = new FileStream("Expenses.bin", FileMode.OpenOrCreate, FileAccess.Write);
        BinaryFormatter fm = new BinaryFormatter();
        fm.Serialize(fs, _expenses);//Serializing the expenses Collection...
        fs.Close();
      }

      private void deserialize()
      {
        FileStream fs = new FileStream("Expenses.bin", FileMode.OpenOrCreate, FileAccess.Read);
        BinaryFormatter fm = new BinaryFormatter();
        _expenses = fm.Deserialize(fs) as List<Expense>;
        fs.Close();
      }
      public void AddExpense(Expense ex)
      {
        _expenses.Add(ex);
        serialize();  
      }

      public List<Expense> FindExpense(string info)
      {
        deserialize();
        List<Expense> tempList = new List<Expense>();
        foreach(Expense ex in _expenses)
        {
          if (ex.Details.Contains(info))
            tempList.Add(ex);
        }
        return tempList;
      }

      public List<Expense> FindExpense(DateTime date)
      {
        deserialize();
        List<Expense> tempList = new List<Expense>();
        foreach (Expense ex in _expenses)
        {
          if (ex.Date.ToShortDateString() == date.ToShortDateString())
            tempList.Add(ex);
        }
        return tempList;
      }

      public void UpdateExpense(Expense ex)
      {
        throw new NotImplementedException("Do it Urself!!!!");
      }
    }

    class XmlDataComponent : IDataComponent
    {
      List<Expense> _expenses = new List<Expense>();
      private void serialize()
      {
        FileStream fs = new FileStream("Expenses.xml", FileMode.OpenOrCreate, FileAccess.Write);
        XmlSerializer fm = new XmlSerializer(typeof(List<Expense>));
        fm.Serialize(fs, _expenses);
        fs.Close();
      }

      private void deserialize()
      {
        FileStream fs = new FileStream("Expenses.xml", FileMode.OpenOrCreate, FileAccess.Read);
        XmlSerializer fm = new XmlSerializer(typeof(List<Expense>));
        _expenses = fm.Deserialize(fs) as List<Expense>;
        fs.Close();
      }
      public void AddExpense(Expense ex)
      {
        _expenses.Add(ex);
        serialize();
      }

      public List<Expense> FindExpense(string info)
      {
        deserialize();
        List<Expense> tempList = new List<Expense>();
        foreach (Expense ex in _expenses)
        {
          if (ex.Details.Contains(info))
            tempList.Add(ex);
        }
        return tempList;
      }

      public List<Expense> FindExpense(DateTime date)
      {
        deserialize();
        List<Expense> tempList = new List<Expense>();
        foreach (Expense ex in _expenses)
        {
          if (ex.Date.ToShortDateString() == date.ToShortDateString())
            tempList.Add(ex);
        }
        return tempList;
      }

      public void UpdateExpense(Expense ex)
      {
        throw new NotImplementedException("Do it again with XMl");
      }
    }
  }
  namespace CommonUtilities
  {
    using System.Configuration;
    using DataLayer;
    static class DataFactory
    {
      public static IDataComponent CreateComponent()
      {
        string className = ConfigurationManager.AppSettings["ClassName"];
        IDataComponent component = Activator.CreateInstance(Type.GetType(className)) as IDataComponent;
        return component;
      }
    }
  }
  namespace UILayer
  {
    using DataLayer;
    using Entities;
    using System.Collections.Generic;

    static class UIHelper
    {
      public static int GetInteger(String question)
      {
        return int.Parse(GetString(question));
      }

      public static string GetString(string question)
      {
        Console.WriteLine(question);
        return Console.ReadLine();
      }

      public static double GetDouble(string question)
      {
        return double.Parse(GetString(question));
      }

      public static DateTime GetDate(string question)
      {
        return DateTime.Parse(GetString(question));
      }
    }
    class MainClass {

      private static IDataComponent com;
      static string getMenu()
      {
        Console.WriteLine("Expense Manager Software");
        Console.WriteLine("Press 1 to add a new Expense");
        Console.WriteLine("Press 2 to update an Expense");
        Console.WriteLine("Press 3 to find Expense by date");
        Console.WriteLine("Press 4 to find Expense by Detail");
        return Console.ReadLine();
      }
      static void Main(string[] args)
      {
        com = CommonUtilities.DataFactory.CreateComponent();
        bool processing = true;
        do
        {
          string choice = getMenu();
          processing = processMenu(choice);
        } while (processing);
      }

      private static bool processMenu(string choice)
      {
        switch (choice)
        {
          case "1":
            createNewExpense();
            return true;
          case "2":
            updateExpense();
            return true;
          case "3":
            displayExpenseByDate();
            return true;
          case "4":
            displayExpenseByDetail();
            return true;
          default:
            return false;
        }
      }

      private static void displayExpenseByDetail()
      {
        string info = UIHelper.GetString("Enter the detail or a part of it...");
        List<Expense> list = com.FindExpense(info);
        foreach (Expense item in list)
          Console.WriteLine($"Amount of Rs.{item.Amount} was spent for {item.Details} on {item.Date.ToShortDateString()}");
      }

      private static void displayExpenseByDate()
      {
        DateTime dt = UIHelper.GetDate("Enter the Date to find the expense as dd-MM-yyyy");
        List<Expense> list = com.FindExpense(dt);
        foreach(Expense item in list)
          Console.WriteLine($"Amount of Rs.{item.Amount} was spent for {item.Details} on {item.Date.ToShortDateString()}");
      }

      private static void updateExpense()
      {
        try
        {
          com.UpdateExpense(null);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }

      private static void createNewExpense()
      {
        RETRY:
        try
        {
          Expense ex = new Expense();
          ex.Details = UIHelper.GetString("Enter the details of the Expense");
          ex.Amount = UIHelper.GetDouble("Enter the Amount of the Expense");
          ex.Date = UIHelper.GetDate("Enter the date of expense as dd-MM-yyyy");
          com.AddExpense(ex);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          goto RETRY;
        }
      }
    }
  }
}