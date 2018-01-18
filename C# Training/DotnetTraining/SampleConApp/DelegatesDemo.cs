using System;
namespace SampleConApp
{
  delegate void MyFunc();
  delegate int MathOperation(int a, int b);
  class DelegatesExample
  {
    static void InvokeFunc(MyFunc func)
    {
      if(func != null)
        func();

    }


    static void InvokeMathFunc(MathOperation op)
    {
      //Take inputs
      Console.WriteLine("Enter v1");
      int v1 = int.Parse(Console.ReadLine());

      Console.WriteLine("Enter v2");
      int v2 = int.Parse(Console.ReadLine());
      //Call any math method
      var res = op(v1, v2);
      //Display the result..
      Console.WriteLine("The result is " + res);
    }
    static void Main(string[] args)
    {
      //MyFunc fn = new MyFunc(myFunction);
      InvokeMathFunc(addoperation);
      //InvokeFunc(myFunction);    
      
    }

    static int addoperation(int v1, int v2)
    {
      return v1 + v2;
    }


   
    static void myFunction()
    {
      Console.WriteLine("Statements that execute");
    }
  }
}