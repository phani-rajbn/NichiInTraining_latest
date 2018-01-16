using System;
using System.Data;
namespace SampleConApp
{
  
  //interface is like a contract. A class which implements the interface must have public definitions for the methods of the interface. It implies that those methods are guaranteed to be available in the class. interface members are always public, U cannot have access specifiers. interfaces cannot have fields. U can have properties. interface name will be prefixed with I.
  interface ICustomerDB
  {
    void AddNewCustomer(int id, string name, string address, double billAmount);
    void UpdateCustomer(int id, string name, string address, double billAmount);
    void DeleteCustomer(int id);
    DataTable GetAllCustomers();//Represent data as a Table
  }

  class CustomerDB : ICustomerDB
  {
    private DataTable table;
    public CustomerDB()
    {
      table = new DataTable();
      table.Columns.Add(new DataColumn("CustomerID", typeof(int)));
      table.Columns.Add(new DataColumn("CustomerName", typeof(string)));
      table.Columns.Add(new DataColumn("CustomerAddress", typeof(string)));
      table.Columns.Add(new DataColumn("CustomerBill", typeof(double)));
      table.PrimaryKey = new DataColumn[] { table.Columns[0] };
    }
    public void AddNewCustomer(int id, string name, string address, double billAmount)
    {
      //create a new row
      DataRow row = table.NewRow();
      //fill the data into row
      row[0] = id;
      row[1] = name;
      row[2] = address;
      row[3] = billAmount;
      table.Rows.Add(row);
      table.AcceptChanges();
      //save the changes
    }

    public void DeleteCustomer(int id)
    {
      foreach(DataRow row in table.Rows)
      {
        if(row[0].ToString() == id.ToString())
        {
          row.Delete();//Deletes the row..
          table.AcceptChanges();
          return;
        }
      }
    }

    public DataTable GetAllCustomers()
    {
      return table;
    }

    public void UpdateCustomer(int id, string name, string address, double billAmount)
    {
      throw new NotImplementedException("Do it URSelf");
    }
  }
  class InterfaceProgram
  {
    static void Main(string[] args)
    {
      ICustomerDB db = new CustomerDB();//Runtime polymorphism...
      db.AddNewCustomer(123, "Phaniraj", "Bangalore", 6500);
      db.AddNewCustomer(124, "Anand", "Mysore", 1500);
      db.AddNewCustomer(125, "Bhaskar", "Hassan", 500);
      db.AddNewCustomer(126, "Chetan", "Tumkur", 2500);

      var data = db.GetAllCustomers();
      foreach(DataRow row in data.Rows)
      {
        Console.WriteLine($"{row[1]} from {row[2]} spends Rs.{row[3]}");
      }
    }
  }
}