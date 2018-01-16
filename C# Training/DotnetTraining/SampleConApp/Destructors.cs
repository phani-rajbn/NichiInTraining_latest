using System;
using System.Threading;
namespace SampleConApp
{

  class SomeComponent : IDisposable
  {
    
    private int _no;
    public SomeComponent(int no)
    {
      _no = no;
      Console.WriteLine($"Some Component no {_no} is created");
    }

    ~SomeComponent()
    {
      //Destructors will not have access specifiers and return types. They cannot be explicitly invoked. System will invoke at appropriately when the object is no longer having any reference of it in the program 
      //.NET has a component called GC(Garbage Collector) which will ensure that the unused objects are destroyed frequently using a certain alogirithm. 
      Console.WriteLine($"Component {_no} is Removed");
    }

    public void Dispose()
    {
      Console.WriteLine($"Component {_no} is Removed");
      GC.SuppressFinalize(this);
    }
  }
  class Destructors
  {
    static void Main()
    {
      for (int i = 0; i <5; i++)
      {
        Thread.Sleep(1000);
        using (SomeComponent com = new SomeComponent(i + 1))
        {
          
        };
        //com.Dispose();//Explict invocation of Dispose function
      }
    }
  }
}
