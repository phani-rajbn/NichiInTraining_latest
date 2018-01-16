using System;
namespace SampleConApp
{
  //create a class for a book{BookId, Title, Cost, PublisherName} and create 4 objects of the book and display them...
  //create the objects of 5 Books as an array and display the titles of all the books in the array.(Create an Array of books and display the book titles using a foreach statement).
  //Create a class called Expense{Id, Details, Date, Amount}. Create an Array of 10 expenses. Retrive allExpenses by date, Highest Expense and Lowestt expense..
   //mailTo:phanirajbn@gmail.com

  class Book
  {
    int _id;
    string _title;
    double _cost;
    string _publisher;

    public void SetDetails(int id, string title, string publisher, double price)
    {
      _id = id;
      _cost = price;
      _title = title;
      _publisher = publisher;
    }

    public string GetTitle()
    {
      return _title;
    }
    
    public double GetPrice()
    {
      return _cost;
    }
    public void DisplayAllDetails()
    {
      Console.WriteLine($"The Title:{_title}\nThe Publisher:{_publisher}\nThe Cost:{_cost}");
    } 
  }
  class Employee
  {
    //data will be private...
    int _empID;
    string _empName;
    string _empAddress;
    
    internal void SetDetails(int id, string name, string address)
    {
      _empID = id;
      _empName = name;
      _empAddress = address;
      Console.WriteLine("Details are set");
    }

    internal void DisplayDetails()
    {
      Console.WriteLine($"The Name is {_empName} from {_empAddress} with ID as {_empID}");
    }
  }
  class ClassesAndObjects
  {
    static void Main(string[] args)
    {
      //A Class is a Prototype..
      //Employee emp = new Employee();//created an object..
      ////Using this object, will call the methods...
      ////Take the inputs from the user and display the details..
      //emp.SetDetails(123, "Phaniraj", "Bangalore");
      //emp.DisplayDetails();

      //Book bk1 = new Book();
      //bk1.SetDetails(1, "Professional C#", "Wrox", 650);
      //bk1.DisplayAllDetails();

      Book[] books = new Book[2];
      for (int i = 0; i < 2; i++)
      {
        Book bk = new Book();
        var title = UIHelper.GetString("Enter the title");
        var pub = UIHelper.GetString("Enter the Publisher");
        var cost = UIHelper.GetDouble("Enter the Price");
        var id = UIHelper.GetInteger("Enter the ID");
        bk.SetDetails(id, title, pub, cost);
        books[i] = bk;
      }

      foreach(Book bk in books)
        Console.WriteLine(bk.GetTitle());
    }
  }
}