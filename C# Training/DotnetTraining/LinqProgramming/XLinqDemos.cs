using System;
using System.Linq;
using System.Xml.Linq;
namespace LinqProgramming
{
  class XLinqDemo
  {
    static void Main(string[] args)
    {
      var doc = XDocument.Load("AllEmployees.xml");
      Console.WriteLine(doc);
    }
  }
}