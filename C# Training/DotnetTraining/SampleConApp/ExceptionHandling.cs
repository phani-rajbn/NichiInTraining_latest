using System;
namespace SampleConApp
{
  //All Exceptions in .NET are objects of a class derived from System.Exception. There are Exception classes for all kinds of common exceptions that arise in realtime apps. DivisionByZero, FileNotFound, NullReference, ArithematicOverFlow, IndexOutOfRange are some of the Excceptions. All Exception classes will be suffixed with Exception
  //A->B->C->D
  class InvalidInputException : ApplicationException
  {
    public InvalidInputException() :this("Value should be within 1 to 199")
    {

    }

    public InvalidInputException(string message ="Value should be within 1 to 199") :base(message)
    {

    }

    public InvalidInputException(string message, Exception innerEx) : base(message, innerEx)
    {

    }
  }
  class ExceptionDemo
  {
    static void firstExample()
    {
      RETRY:
      try
      {

        //code that could raise an excception
        //int v1 = 123;
        //int v2 = 10;
        //Console.WriteLine(v1/v2);

        Console.WriteLine("Enter UR Age");
        int age = int.Parse(Console.ReadLine());
      }

      catch (FormatException)
      {
        Console.WriteLine("Invalid Number, inserted value should be integer");
        //Console.WriteLine(fEx);//WriteLine method always evaluates an object to its ToString() method...
        goto RETRY;
      }
      catch (OverflowException)
      {
        Console.WriteLine("The Value is either too large or too small to hold an integer");
        goto RETRY;
      }
      catch (Exception genEx)
      {
        //Console.WriteLine("Unknown Error ocurred");
        Console.WriteLine(genEx.Message);
        goto RETRY;
      }
      finally
      {
        //Clean up execution which is called after every try or catch block
        Console.WriteLine("App has ended");
      }
    }
    static void Main(string[] args)
    {
      //firstExample();
      throwingExceptionDemo();
    }

    private static void throwingExceptionDemo()
    {
      RETRY:
      try {
        Console.WriteLine("Enter a valid number");
        int value = int.Parse(Console.ReadLine());
        if ((value < 1) || (value > 200))
          throw new InvalidInputException();
         Console.WriteLine("Good to have the right value");
      }
      catch (FormatException)
      {
        Console.WriteLine("expected integer");
        goto RETRY;
      }
      catch (OverflowException)
      {
        Console.WriteLine("Not in the range of integer");
        goto RETRY;
      }
      catch (InvalidInputException auEx)
      {
        Console.WriteLine(auEx.Message);
      }
      catch(Exception genEx)
      {
        Console.WriteLine("OOPS!!! Something happened");
        Console.WriteLine(genEx.Message);
      }
    }
  }
}