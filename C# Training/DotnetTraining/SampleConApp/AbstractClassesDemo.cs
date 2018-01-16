using System;
using System.Globalization;

namespace SampleConApp
{
  //Abstract classes are classes that have atleast one abstract method. An Abstract method is a function which has no implementation in it. The implemention will be provided by the child class. Abstract means not clear. Certain functions might not be implementable at initial stages. So later stages will have clear understanding on the requirement and clients would implement them...

  abstract class Account
  {
    public Account()
    {
      //A function that is used to set values to UR data to suit UR requirements...
      Balance = 5000;
    }
    public int AccountNo { get; set; }
    public string CustomerName { get; set; }
    public double Balance { get; private set; }

    public void CreditAmount(double amount)
    {
      Balance += amount;
    }

    public void DebitAmount(double amount)
    {
      if(Balance >= amount)
      {
        Balance -= amount;
      }
      else
      {

      }
    }

    public abstract void CalculateInterest(); 
  }

  //Any class which derives this class must implement the abstract methods. 
  class SBAccount : Account
  {
    public override void CalculateInterest()
    {
      double amount = Balance * 1 / 12 * 6.5 / 100;
      CreditAmount(amount);
    }
  }

  class RDAccount : Account
  {
    //Abstract methods are implemented using override keyword....
    public override void CalculateInterest()
    {
      //Google to find RD Formula...
    }
  }
  class AbstractClassDemo
  {
    //Abstract classes are incomplete, U cannot instantiate them..U should use Runtime Polymorphism to work those objects
    static void Main(string[] args)
    {
      Account acc = new SBAccount();
      acc.AccountNo = 34244;
      acc.CustomerName = "Phaniraj";
      acc.CreditAmount(12000);
      acc.DebitAmount(500);
      acc.CalculateInterest();//Calculate interest based on SBAccc..
      //Console.WriteLine($"The Current balance is {acc.Balance.ToString("C")}");
      Console.WriteLine($"The Current Balance is {acc.Balance:C}");
      Console.WriteLine($"The Current Balance is {acc.Balance.ToString("C", new CultureInfo("EN-US"))}");
    }
  }
}
/*
In Abstract class, U should have atleast one abstract method.
Derived class must implement all the abstract methods.
Abstract classes cannot be instantiated. 
If a class contains all abstract methods in it, it should be created as Interface. 
*/