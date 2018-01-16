using System;
using static SampleConApp.UIHelper;
//Function is a block of code that is created to encapsulate it and refer it by a name. Repeated code would be usually grouped as functions and consumed in our application. 
//visibility return_type func_name(data_type parameterName)
/*
If U create a function within a class, it is accessible within it. 
Static functions are acessible anywhere in the class.
Normal functions are not accessible in the static functions directly.
Outside the class, U have to access the normal functions only thro the instance of the class. Static Functions are accessed thro the name of the class.  Use the .operator to refer the methods of the class. 
Visibility:private(Only within the class), protected(Within the class and its derived classes), internal(Within the project), public(Anywhere within the Application).
 If U have a class with only static functions, then U could make the class as static, so that U dont create an instance of the class. 
 If any function is very frequently used in an Application, its good practise to make it as static function...
 Parameter types in C#:
 in parameter: default parameters that are passed by value. The parameter value is unique to the function...
  ref parameter: initialize the value by the caller and is modified in the function..
  out parameter: parameters which are retaining the values that is set within the function, callers need not intialize the values, as they must be set within the function.
  params: Allowing variable no of arguments to be passed to a function..
*/
namespace SampleConApp
{
  static class Arithematic
  {
    internal static void GetAllValues(double v1, double v2, out double addeval, out double subVal, out double mulVal, ref double divVal)
    {
      //out parameter expects the values for those parameters to be set by the function...
      addeval = v1 + v2;
      subVal = v1 - v2;
      mulVal = v1 * v2;
      if (v2 != 0)
        divVal = v1 / v2;
    }
    internal static double AddFunc(double value1, double value2)
    {
      return value1 + value2;
    }

    internal static double SubFunc(double value1, double value2)
    {
      return value1 - value2;
    }

    internal static double MulFunc(double value1, double value2)
    {
      return value1 * value2;
    }
    internal static double DivFunc(double value1, double value2)
    {
      return value1 / value2;
    }
  }

  class UIHelper
  {
    public static string GetString(string  question)
    {
      Console.WriteLine(question);
      return Console.ReadLine();
    }
    public static int GetInteger(string question)
    {
      return int.Parse(GetString(question));
    }

    public static double GetDouble(string question)
    {
      return double.Parse(GetString(question));
    }
  }
  class FunctionsDemo
  {
    
    static void Main(string[] args)
    {
      //staticFunctionDemo();
      multiplreturnValueDemo();
    }

    private static void multiplreturnValueDemo()
    {
      //declare all the out parameters...
      double res1, res2, res3, res4 = 123/*It is ref value*/;
      Arithematic.GetAllValues(123, 0, out res1, out res2, out res3, ref res4);
      Console.WriteLine("The added value is " + res1);
      Console.WriteLine("The Subtracted value is " + res2);
      Console.WriteLine("The Multiplied value is " + res3);
      Console.WriteLine("The Divided value is " + res4);
    }

    private static void staticFunctionDemo()
    {
      int v1 = GetInteger("Enter an integer");
      int v2 = GetInteger("Enter an integer");
      string op = GetString("Enter the operator: + or - or * or /");
      double res = 0;
      switch (op)
      {
        case "+":
          res = Arithematic.AddFunc(v1, v2);
          break;
        case "-":
          res = Arithematic.SubFunc(v1, v2);
          break;
        case "*":
          res = Arithematic.MulFunc(v1, v2);
          break;
        default:
          break;
      }
      Console.WriteLine($"The result of this operation is {res}");
    }
  }
}