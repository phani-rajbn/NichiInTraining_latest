using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//Collection is an object that internally contain a large no of data on which U could perform a foreach iteration. An object on which we can perform a foreach statement is called as Collection
//In .NET, a Collection is a class that implements an interface called IEnumerable. This interface has one function called GetEnumerator which returns an IEnumerator object thro which U could perform iteration.  

namespace SampleConApp
{
  enum Criteria { Name, Address, Balance}
  class CustomerComparer : IComparer<Customer>
  {
    private Criteria criteria;
    public CustomerComparer(Criteria criteria)
    {
      this.criteria = criteria;
    }
    public int Compare(Customer x, Customer y)
    {
      switch (criteria)
      {
        case Criteria.Name:
          return x.CustomerName.CompareTo(y.CustomerName);
        case Criteria.Address:
          return x.CustomerAddress.CompareTo(y.CustomerAddress);
        case Criteria.Balance:
          if (x.Balance < y.Balance)
            return -1;
          else if (x.Balance > y.Balance)
            return 1;
          else
            return 0;
        default:
          return 0;
      }
    }
  }
  class Customer : IComparable<Customer>
  {
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public int Balance { get; set; }

    public int CompareTo(Customer other)
    {
      //-1(this is less than the other), 0(equal) and 1(this is greater than the other)
      return this.CustomerName.CompareTo(other.CustomerName);
    }
  }

  //U dont need boxing and unboxing if U R using Generic version of collections. So Generics are called as Type safe collections...
  class CustomerRepository : IEnumerable<Customer>
  {
    private void getData()
    {
      var filename = "MOCK_DATA.csv";
      StreamReader reader = new StreamReader(filename);
      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine().Split(',');
        var cst = new Customer();
        cst.CustomerID = int.Parse(line[0]);
        cst.CustomerName = line[1];
        cst.CustomerAddress = line[2];
        cst.Balance = (int)double.Parse(line[3]);
        _allCustomers.Add(cst);
      }
    }
    private List<Customer> _allCustomers;
    public CustomerRepository()
    {
      _allCustomers = new List<Customer>();
      getData();
    }

    public void AddNewCustomer(Customer cst)
    {
      _allCustomers.Add(cst);
    }

    public void RemoveCustomer(int id)
    {
      foreach(var cst in _allCustomers)
      {
        if(cst.CustomerID == id)
        {
          _allCustomers.Remove(cst);
          return;
        }
      }
    }

    //Explicit Implementation....
    IEnumerator IEnumerable.GetEnumerator()
    {
      foreach (Customer cst in _allCustomers)
        yield return cst;
      //yeild that returns the iterator...
      //return _allCustomers.GetEnumerator();
    }

    public int Size
    {
      get
      {
        return _allCustomers.Count;
      }
    }
    public IEnumerator<Customer> GetEnumerator()
    {
      return _allCustomers.GetEnumerator();
    }
    //Indexer in C# is a way of overloading the Subscript operator[] so that U could access the object like an Collection. Using Indexer is like a property. The name of the property will be 'this'. It can be overloaded...
    public Customer this[int index]
    {
      get
      {
        if (index < _allCustomers.Count)
          return _allCustomers[index];
        else
          throw new IndexOutOfRangeException();
      }
    }
    public Customer this[string name]
    {
      get
      {
        foreach(var cst in _allCustomers)
        {
          if (cst.CustomerName == name)
            return cst;
        }
        throw new Exception("No Customer Found");
      }
    }

    public void Sort(Criteria criteria)
    {
      CustomerComparer comparer = new CustomerComparer(criteria);
      _allCustomers.Sort(comparer);
    }
  }
  class CollectionsDemo
  {
    static void Main(string[] args)
    {
      //int[] data = { 2, 3, 4, 5, 6, 5, 5, 5, 5, 5, 5, 5 };
      ////Array is a collection class. 
      //foreach(var item in data)
      //  Console.WriteLine(item);

      CustomerRepository myCustomers = new CustomerRepository();
      //myCustomers.AddNewCustomer(new Customer { CustomerID = 111, CustomerName = "Suresh", CustomerAddress = "bangalore", Balance = 65000 });
      //myCustomers.AddNewCustomer(new Customer { CustomerID = 112, CustomerName = "Gopi", CustomerAddress = "bangalore", Balance = 65000 });
      //myCustomers.AddNewCustomer(new Customer { CustomerID = 113, CustomerName = "Rama", CustomerAddress = "bangalore", Balance = 65000 });
      //myCustomers.AddNewCustomer(new Customer { CustomerID = 114, CustomerName = "Yetish", CustomerAddress = "bangalore", Balance = 65000 });
      //myCustomers.AddNewCustomer(new Customer { CustomerID = 115, CustomerName = "Gopal", CustomerAddress = "bangalore", Balance = 65000 });
      //myCustomers.AddNewCustomer(new Customer { CustomerID = 116, CustomerName = "Manoj", CustomerAddress = "bangalore", Balance = 65000 });
      //foreach(Customer customer in myCustomers)
      //  Console.WriteLine(customer.CustomerName);
      //foreach statement is forward only and readonly
      //IEnumerator<Customer> iterator = myCustomers.GetEnumerator();
      //while (iterator.MoveNext())
      //{
      //  Console.WriteLine(iterator.Current.CustomerName);
      //}
      try
      {
        Console.WriteLine("How U want to sort:Name, Address, Balance");
        Criteria criteria = (Criteria)Enum.Parse(typeof(Criteria), Console.ReadLine());
        myCustomers.Sort(criteria);
        for (int i = 0; i < myCustomers.Size; i++)
        {
          Console.WriteLine($"{myCustomers[i].CustomerName}\t{myCustomers[i].CustomerAddress}\t{myCustomers[i].Balance}");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
     
    }
  }
}