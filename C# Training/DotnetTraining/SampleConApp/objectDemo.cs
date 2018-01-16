using System;
namespace SampleConApp
{
  //object is the universal data type of .NET. All data types both .NET Types and custom types are derived from System.Object. object is the keyword in C#.
  //object can store any type of data in it. It is similar to void* of C/C++
  class ObjectClass
  {
    static void createTable(int val)
    {
      //Display the multiplication Table...
      for (int i = 1; i <= 10; i++)
      {
        Console.WriteLine($"{val}X{i}={val* i}");
      }
    }

    static void getAnalysis(params int[] values)
    {
      int minVal = 0;
      for (int i = 0; i < values.Length; i++)
      {
        if (i == 0)
          minVal = values[i];
        else if(values[i] < minVal)
          minVal = values[i];
      }
      Console.WriteLine("The Max value in this list is ");
      Console.WriteLine("The Min value in this list is " + minVal);
      Console.WriteLine("The Avg value of this list");
    }
    static  object GetDefaultValue(string dataType)
    {
      switch (dataType)
      {
        case "int":
          return 0;
        case "float":
          return 0.0F;
        case "string":
          return "hellow world";
        default:
          return null;
      }
    }
    static void Main(string[] args)
    {
      createTable(5);
      Console.ReadLine();
      getAnalysis(131, 3, 4, 56, 7, 8, 8, 5, 9, 9, 9, 9);
      object value = GetDefaultValue("string");//implicit conversion(BOXED VALUE)...
      string iVal = (string)value;//Unboxing should be converted to the same type from which it was boxed...
      Console.WriteLine("The value is " + iVal);
      string strVal = value.ToString();//Unboxing is explicit...

      Console.WriteLine("The upper case is " + strVal.ToUpper());
      Console.WriteLine("The internal datatype is " + value.GetType().FullName);
      if(value.GetHashCode().Equals("Mangle".GetHashCode()))
        Console.WriteLine("They are same");
      else
        Console.WriteLine("They are not same");
      /*object class has got 4 functions to perform the common operations: 
      ToString->converts the data to string. 
      GetType->Gets the internal Type information of the object.
      Equals->To check the logical Equivalence of the object
      GetHashCode->Evaluates the internal HashCode of the object.
      As the object is derived by every .NET Type, the functions of the object are available for all the datatypes of .NET..
      */
    }
  }
}
//Write a program that takes an input of a number and it should display the multiplication table of that number....
 