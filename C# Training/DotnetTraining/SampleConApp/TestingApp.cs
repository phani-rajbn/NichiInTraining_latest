using System;
using CommonLib;
using BusinessLayer.Entities;
using BusinessLayer.BusinessObjects;

namespace SampleConApp
{
  class TestApp
  {
    static IBusinessObject  component;
    static void Main(string[] args)
    {
      component = new BusinessLayer.BusinessObjects.ProductBO();
      try
      {
        //component.AddNewProduct("Neam Peel off Mask", 20, 1);
        var data = component.FindProducts("Himalaya");
        foreach (var item in data)
        {
          Console.WriteLine(item.Name);
        }
      }
      catch (Exception r)
      {
        Console.WriteLine(r.Message);
      }
    }
  }
}