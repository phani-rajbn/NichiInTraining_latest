using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLibrary;

namespace SampleConApp
{
  class MainProgram
  {
    static void Main(string[] args)
    {
      createProduct();
    }

    private static void createProduct()
    {
      Product p = new Product();
      p.ProductName = getString("Enter the product Name");
      p.ProductID = getInt("Enter the productID");
      p.ProductCost = getDouble("Enter the ProductCost");
      p.ProductStock = getInt("Enter the stock ");
      Console.WriteLine($"The Product Name is {p.ProductName} whose price is {p.ProductCost} and has a stock of around {p.ProductStock}");
    }

    private static double getDouble(string v)
    {
      return double.Parse(getString(v));
    }

    private static int getInt(string v)
    {
      return int.Parse(getString(v));
    }

    private static string getString(string v)
    {
      Console.WriteLine(v);
      return Console.ReadLine();
    }
  }
}
