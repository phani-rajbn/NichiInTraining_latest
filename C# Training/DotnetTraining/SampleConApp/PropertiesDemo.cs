using System;
namespace SampleConApp
{
  //Properties are accessors to data. They have get and set block in them where get block contain the logic of reading the data and set block contain the logic of writing to the data. Properties are used to replace the get and set functions of UR entity class.

  class Expense
  {
    private int _expenseID;
    public int ExpenseID
    {
      get { return _expenseID; }
      set { _expenseID = value; }
    }

    private string _desc;
    public string Description
    {
      get { return _desc; }
      set { _desc = value; }
    }

    private DateTime _date;

    public DateTime DateOfExpense
    {
      get { return _date; }
      set { _date = value; }
    }
    private int _amount;

    public int Amount
    {
      get { return _amount; }
      set { _amount = value; }
    }
  }

  class ExpenseDetail
  {
    //Using automatic Properties...
    public int ExpenseID { get; set; }
    public string Details { get; set; }
    public DateTime Date { get; set; }
    public int Amount { get; set; }
  }

  class BookClass
  {
    //usually data will be private
    private int _bookId;
    private string _title;
    private double _cost;

    public int BookID
    {
      get { return _bookId; }//retrival of the private data thro get
      set { _bookId = value; }//value set by the User
    } 

    public string Title
    {
      get { return _title; }
      set { _title = value; }
    }

    //U set properties for those data that U want to read and write outside the class..
    public double Price
    {
      get { return _cost; }
      set
      {
        _cost = value;
      }//U could perform validation before U set the value;
    }
  }
  class PropertiesDemo
  {
    static void Main(string[] args)
    {
      //expenseExample();
      //bookExample();
      expenseDetailExample();
    }

    private static void expenseDetailExample()
    {
      //throw new NotImplementedException();
      ExpenseDetail detail = new ExpenseDetail();
      detail.ExpenseID = 111;
      detail.Details = "Bike Fuel";
      detail.Amount = 500;
      detail.Date = DateTime.Now.AddDays(-34);
      Console.WriteLine($"The cost of {detail.Details} on the date of {detail.Date.ToLongDateString()} is {detail.Amount}");
    }

    private static void expenseExample()
    {
      Expense ex = new Expense();
      ex.ExpenseID = 123;
      ex.Description = "Movie tickets";
      ex.Amount = 650;
      ex.DateOfExpense = DateTime.Parse("01/12/2017");

      Console.WriteLine($"The cost of {ex.Description} on the date of {ex.DateOfExpense.ToLongDateString()} is {ex.Amount}");
    }

    private static void bookExample()
    {
      BookClass obj = new BookClass();
      obj.BookID = 123;
      obj.Title = "Reading Books";
      obj.Price = 450;

      Console.WriteLine($"The Cost of the Book '{obj.Title}' is {obj.Price}");
    }
  }
}