using System;

namespace SampleConApp
{
  class HelloClass
  {
    static void Main()
    {
      //firstDemo();
      //inputDemo();
      loopMathOperation();
    }

    private static void loopMathOperation()
    {
      string check = "";
      do
      {
        Console.Clear();
        mathOperation();
        Console.WriteLine("Do U want another Operation?Press Y or N");
        check = Console.ReadLine();
      } while (check.ToUpper() == "Y");
    }

    private static void mathOperation()
    {
      int value1, value2, result =0;
      Console.WriteLine("Enter v1");
      value1 = int.Parse(Console.ReadLine());
      Console.WriteLine("Enter v2");
      value2 = int.Parse(Console.ReadLine());
      Console.WriteLine("Enter the operation as any one: +, -, * or /");
      string operation = Console.ReadLine();
      
      switch (operation)
      {
        case "+":
          result = value1 + value2;
          break;
        case "-":
          result = value1 - value2;
          break;
        case "*":
          result = value1 * value2;
          break;
        case "/":
          result = value1 / value2;
          break;
        default:
          break;//break is required even for default in C#...
      }
      Console.WriteLine($"The Result of this operation is {result}");
      //When U create a local variable, it must be assigned before U use them...
    }

    private static void inputDemo()
    {
      Console.WriteLine("Enter the Name please");
      string name = Console.ReadLine();
      //ReadLine is a method to take the inputs from the user in the Console and return a string representation of it. 
      Console.WriteLine("Enter the Address please");
      string address = Console.ReadLine();

      Console.WriteLine("Enter the Age");
      string age = Console.ReadLine();

      Console.WriteLine($"The Name is {name}, the Address is {address} and the Age is {age}");
    }

    private static void firstDemo()
    {
      //Console is a .NET Class that is defined in a namespace called System which contain functions to interact with Console WIndow. It has static functions to operate on the Window...
      //Main is the entry point for any C# program. Main is a part of a class. Main is case sensitive. Main function should be static function. C# does not support global functions and global variables. So Main is invoked thro the classname by the Runtime.
      //Main can take only string[] as argument or nothing...
      //Main can return either a void or int, no other data type is supported.   
      Console.WriteLine("My Name is Phaniraj");
      Console.WriteLine("I stay in RR Nagar");
      Console.WriteLine("I am from Bangalore");
    }
  }
}