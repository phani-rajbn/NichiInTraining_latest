using System;
using System.Data.SqlClient;
using System.Data;//For datatable
using System.Configuration;
using CommonLib;
using System.Diagnostics;

namespace DataAccessLib
{
  public interface IDataComponent
  {
    void AddNewProduct(string pName, double cost, int catID);
    void UpdateProduct(int pID, double cost, string updatedBy);
    DataTable FindProducts(string catName);
    void DeleteProduct(int pID);
  }
   
  class ConnectedDataComponent : IDataComponent
  {
    private readonly string conString = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
    //So that ConnectionString could be set using config file. 

    private const string insertProduct = "spInsert";
    //set the name of the sp...
    private const string findProduct = "spFind";
    private const string updateProduct = "spUpdate";
    private const string deleteProduct = "spDelete";

    public void AddNewProduct(string pName, double cost, int catID)
    {
      int val = 0;
      SqlConnection sqlCon = new SqlConnection(conString);
      SqlCommand sqlCmd = new SqlCommand(insertProduct, sqlCon);
      sqlCmd.CommandType = CommandType.StoredProcedure;
      sqlCmd.Parameters.AddWithValue("@pName", pName);
      sqlCmd.Parameters.AddWithValue("@pCost", cost);
      sqlCmd.Parameters.AddWithValue("@pQuantity", 1000);
      sqlCmd.Parameters.AddWithValue("@pCatID", catID);
      sqlCmd.Parameters.AddWithValue("@pID", val);
      sqlCmd.Parameters[4].Direction = ParameterDirection.Output;
      
      try
      {
        sqlCon.Open();
        sqlCmd.ExecuteNonQuery();
        val = Convert.ToInt32(sqlCmd.Parameters[4].Value);
        Logger.LogMessage($"Product with ID {val} is inserted", EventLogEntryType.SuccessAudit);
      }
      catch (Exception ex)
      {
        throw new InsertionFailedException("Insertion Failed for this Product", ex);
      }
    }

    public void DeleteProduct(int pID)
    {
      throw new NotImplementedException();
    }

    public DataTable FindProducts(string catName)
    {
      SqlConnection sqlCon = new SqlConnection(conString);
      SqlCommand sqlCmd = new SqlCommand(findProduct, sqlCon);
      sqlCmd.CommandType = CommandType.StoredProcedure;
      sqlCmd.Parameters.AddWithValue("@catName", catName);
      try
      {
        sqlCon.Open();
        var reader = sqlCmd.ExecuteReader();
        //convert the reader to Data Table..
        DataTable table = new DataTable("Products");
        table.Load(reader);
        return table;
      }
      catch(Exception ex)
      {
        throw ex;
      }
      finally
      {
        sqlCon.Close();
      } 
    }

    public void UpdateProduct(int pID, double cost, string updatedBy)
    {
      SqlConnection sqlCon = new SqlConnection(conString);
      SqlCommand sqlCmd = new SqlCommand(updateProduct, sqlCon);
      sqlCmd.CommandType = CommandType.StoredProcedure;
      sqlCmd.Parameters.AddWithValue("@pID", pID);
      sqlCmd.Parameters.AddWithValue("@cost", cost);
      sqlCmd.Parameters.AddWithValue("@updatedBy", updatedBy);
      try
      {
        sqlCon.Open();
        sqlCmd.ExecuteNonQuery();
        Logger.LogMessage($"Product with ID {pID} is updated", EventLogEntryType.SuccessAudit);
      }
      catch (Exception ex)
      {
        throw new InsertionFailedException("Insertion Failed for this Product", ex);
      }
      finally
      {
        sqlCon.Close();
      }
    }
  }

  public static class ComponentFactory
  {
    public static IDataComponent CreateComponent()
    {
      return new ConnectedDataComponent();
    }
  }
}
