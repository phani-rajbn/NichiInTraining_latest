using System;
using System.Data.SqlClient;
using System.Data;
namespace SampleConApp
{
  //U need a connection->open, close, connectionString, command->Execute..., reader->Read.....
  class DatabaseApp
  {
    const string STRCONNECTION = "Data Source=.;Initial Catalog=NichiInDatabase;Integrated Security=True";
    const string SEARCHQUERY = "SELECT PRODUCTNAME, CATEGORY.CATEGORYNAME FROM PRODUCT JOIN CATEGORY ON CATEGORY.CATID = PRODUCT.CATID ORDER BY CATEGORY.CATEGORYNAME";
    const string SEARCHBYCAT = "SELECT PRODUCTNAME FROM PRODUCT JOIN CATEGORY ON CATEGORY.CATID = PRODUCT.CATID WHERE CATEGORY.CATEGORYNAME = @catName";
    const string INSERTCODE = "INSERT INTO PRODUCT(ProductName, ProductCost, ProductQuantity, CatID) VALUES(@pName, @pCost, @pQuantity, @pCat)";
    static void Main(string[] args)
    {
      readProducts();
      //      readProductsByCategory();
      //Console.WriteLine("Enter the Category Name to search");
      //readProductsByCategory(Console.ReadLine());
      //insertRec();
    }

    private static void insertRec()
    {
      SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
      SqlCommand sqlCmd = new SqlCommand(INSERTCODE, sqlCon);
      sqlCmd.Parameters.AddWithValue("@pName", "RIN SUPREME");
      sqlCmd.Parameters.AddWithValue("@pCost", 10);
      sqlCmd.Parameters.AddWithValue("@pQuantity", 4000);
      sqlCmd.Parameters.AddWithValue("@pCat", 6);
      try
      {
        sqlCon.Open();
        int rows = sqlCmd.ExecuteNonQuery();//Used for Single direction Queries:INSERT, DELETE, UPDATE
        Console.WriteLine($"{rows} no of Rows Affected");
      } 
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        sqlCon.Close();
      }
    }

    private static void readProductsByCategory(string catName)
    {
      SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
      SqlCommand sqlCmd = new SqlCommand(SEARCHBYCAT, sqlCon);
      sqlCmd.Parameters.AddWithValue("@catName", catName);
      try
      {
        sqlCon.Open();
        var reader = sqlCmd.ExecuteReader();
        Console.WriteLine("Products of category " + catName);
        while (reader.Read())
        {
           Console.WriteLine($"{reader[0]}");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        sqlCon.Close();
      }
    }

    private static void readProductsByCategory()
    {
      SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
      SqlCommand sqlCmd = new SqlCommand(SEARCHQUERY, sqlCon);
      try
      {
        sqlCon.Open();
        var reader = sqlCmd.ExecuteReader();
        while (reader.Read())
        {
          Console.WriteLine($"{reader[0]} belongs to category {reader[1]}");
        }
      }
      catch (Exception)
      {

        throw;
      }
      finally
      {
        sqlCon.Close();
      }
    }

    private static void readProducts()
    {
      SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
      SqlCommand sqlCmd = new SqlCommand("Select * from Product", sqlCon);
      try
      {
        sqlCon.Open();
        var reader = sqlCmd.ExecuteReader();
        while (reader.Read())
          Console.WriteLine(reader["ProductName"]);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        if (sqlCon.State == ConnectionState.Open)
          sqlCon.Close();
      }
    }
  }
}