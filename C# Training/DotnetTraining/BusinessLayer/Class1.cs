using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Entities;
using CommonLib;
using DataAccessLib;
using System.Data;

namespace BusinessLayer
{
  namespace Entities
  {
    public class Product
    {
      public int ProductID { get; set; }
      public string Name { get; set; }
      public double Cost { get; set; }
      public string  Updater { get; set; }
      public int Quantity { get; set; }
      public int CategoryID { get; set; }
    }
  }

  namespace BusinessObjects
  {
    public interface IBusinessObject
    {
      void AddNewProduct(Product newProduct);
      void UpdateProduct(Product oldProduct);
      List<Product> FindProducts(string catName);
      void DeleteProduct(int pID);
    }

    public class ProductBO : IBusinessObject
    {
      private static IDataComponent com = ComponentFactory.CreateComponent();
      public void AddNewProduct(Product newProduct)
      {
        if (newProduct == null)
          throw new Exception("Product details are not there");
        //Check all the business rules of the App....
        try
        {
          com.AddNewProduct(newProduct.Name, newProduct.Cost, newProduct.CategoryID);
        }
        catch (InsertionFailedException ex)
        {
          throw ex;
        }
      }

      public void DeleteProduct(int pID)
      {
        com.DeleteProduct(pID);
      }

      public List<Product> FindProducts(string catName)
      {
        var data = com.FindProducts(catName);
        List<Product> _products = new List<Product>();
        foreach(DataRow row in data.Rows)
        {
          var p = new Product();
          p.ProductID = Convert.ToInt32(row[0]);
          p.Name = row[1].ToString();
          if (row[5] != null)
            p.Updater = row[5].ToString();
          p.Cost = Convert.ToDouble(row[2]);         
          _products.Add(p);
        }
        return _products;

      }

      public void UpdateProduct(Product oldProduct)
      {
        try
        {
          com.UpdateProduct(oldProduct.ProductID, oldProduct.Cost, oldProduct.Updater);
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }
  }
}
