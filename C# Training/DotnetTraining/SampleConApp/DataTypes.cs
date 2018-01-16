using System;
namespace SampleConApp
{
  /*
  Data Types in C# are based on the CTS(Common Type system) of the .NET Framework. All data types are derivied from a Class called Object defined in the namespace System.
  The data Types are of 2 types: Value Types and Reference types.
  Value Types:
  Integral Types: byte(Byte), short(Int16), int(Int32), long(Int64)
  Floating types: float(Single), double(Double), decimal(Decimal)
  Other Types:char(Char), bool(Boolean),  
  User Defined types: struct, enum
  NOTE: All Value types are structs. U could declare using the C# keywords or the CTS types.
  Reference types: Arrays, Strings, Classes.
  Value types store the value in their variabls, reference types store the address of the value in them. Value will be created in a large area called HEAP, and its address is stored in the variable.
  Object is similar to void* of C++. 
  */
  class DataTypesDemo
  {
    //If UR Application is having more than one entry points, U could the select the class for the App's entry point by going->Project Properties->Application->Startup OBject and select the class. If the class that U have created the entry point is not found in the Dropdown box, then UR entry point is wrong.
    static void Main(string[] args)
    {
      //rangeDemo();
      conversionDemo();
    }

    private static void conversionDemo()
    {
      //Like any other programming language U cannot convert a value of one data type to another whose range differs. 
      //Smaller range variables can be implicitly converted to larger range variables.
      //The reverse is not possible, but could be done explicitly using C style casting or using a class called Convert. Convert has static functions to convert from any type to another...
      int v1 = int.MaxValue;
      long l1 = v1 + 345;  //Implicit conversion
      checked//use checked for ensuring the safety of variable conversions. If the range is not matching, it gives a Compilation error instead of Runtime Exception. 
      {
        int anotherVal = (int)l1;
        Console.WriteLine($"The new value is {anotherVal}");
      }
      //It is not safe, it can give U abnormal results
      //int anotherVal = Convert.ToInt32(l1);
      
      //Casting or conversions might not be safe if the ranges differ. So always check for arithematic overflow in the project settings..
    }

    private static void rangeDemo()
    {
      Console.WriteLine($"The Range of byte is {byte.MinValue} and {byte.MaxValue}");
      Console.WriteLine($"The Range of Short is {short.MinValue} and {short.MaxValue}");
      Console.WriteLine($"The Range of integer is {int.MinValue} and {int.MaxValue}");
      Console.WriteLine($"The Range of long is {long.MinValue} and {long.MaxValue}");
      Console.WriteLine($"The Range of float is {float.MinValue} and {float.MaxValue}");
      Console.WriteLine($"The Range of double is {double.MinValue} and {double.MaxValue}");
      Console.WriteLine($"The Range of decimal is {decimal.MinValue} and {decimal.MaxValue}");
    }
  }
}