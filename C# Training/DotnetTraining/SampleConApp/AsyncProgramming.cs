using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace SampleConApp
{
  //Multi Threading is the usuall way of performing async calls thro UR Functions. Delegates will allow us to use its functions to invoke methods asynchronously without a need to create a seperate thread...
  //Threads are not optimized. Threads are kernel objects, and Applications run on User mode.
  class AsyncProgramming
  {
    static int InvokeFunc(int number)
    {
      int i = 0;
      int x = 0;
      while(i < number)
      {
        x += number;
        Console.WriteLine("The current value in this loop is " + x);
        Thread.Sleep(100);
        i++;
      }
      return x;
    }

    static void CallMe(IAsyncResult r)
    {
      Console.WriteLine("Pew!!!!, atlast completed...");
        AsyncResult actualRes = r as AsyncResult;
        var delegateObj = actualRes.AsyncDelegate as Func<int, int>;
        var retVal = delegateObj.EndInvoke(r);
        Console.WriteLine("The result output :" + retVal);
    }
    static void Main(string[] args)
    {
      Console.WriteLine("Main Program runnning......");
      Console.WriteLine("Into Async Function.....");
      Func<int, int> delFunc = InvokeFunc;
      var res = delFunc.BeginInvoke(10, CallMe, null);
      mainBigJob();
      Console.WriteLine("Main has completed the task....");
      while(res.IsCompleted == false)
      {
        Console.WriteLine("Please wait while we get the result");
        Thread.Sleep(100);
      }
     
      
    }

    private static void mainBigJob()
    {
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine("[Main]'s job in action....");
        Thread.Sleep(100);
      }
    }
  }
}

//Create a Table called Book-BookID, BookTitle, BookCost...
/*
DB Design: Create the table...
Create a DLL project. Create a Entity class Book->BookID, Title, Cost
Create a repository class->AddBook, FindBookByTitle, GetAllTitles, UpdateBookDetails
Create the EDMX and do the job.... 
Design the UI->Single Window.:Title, ListBox, 3 Text Boxes, 3 Buttons->Create new, update and Find...
Handle the events and call the DAL Functions in the UI....
  */
//Create a DAL DLL and using Entity create a CRUD operations

//Create a Win App and develop Master detail WIndowe...