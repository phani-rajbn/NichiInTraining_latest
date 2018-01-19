using System;
using System.Threading;
//Process: Is an instance of an executable. A File which has an extension .exe is called as Executable. A file which creates a process and executes the program is called as an Executable. U can create multiple instances of the same executable where each instance has its own memory, address space and data which will not affect the other instance.  This private address space is called Process. The isolated memory is called Process boundary.
//Each process has its own memory and will not be allowed to write into another process. It could be done with sp care called IPC. 
//Each process has its sequence of execution called THREAD. The Thread is the one which performs the tasks and process is simply a boundary that ensures that it is secured. A Process should work well with a single thread which is also called as UI Thread or Main Thread. When the Main Thread returns, the proces ends. 
//Sometimes, if U want to execute another block of code parallelly, then U create threads. 
//In .NET, a thread is represented by a class called Thread defined in the namespacec System.Threading.
namespace SampleConApp
{
  class ThreadingDemo
  {
    static void CustomFunc()
    {
      //Use typeof operator if U R using static function, else pass this operator...
      Monitor.Enter(typeof(ThreadingDemo));
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine("Thread BeepNo.#" + i);
        Thread.Sleep(1000);//Thread's static function called Sleep wil make the executing thread to sleep...
      }
      Monitor.Exit(typeof(ThreadingDemo));
    }
    //Thread functions takes only object as its arg....
    static void FuncWithArg(object arg)
    {
      //arg is an array...
      if(arg is Array)
      {
        var array = arg as Array;
        foreach (var item in array)
        {
          if(Convert.ToChar(item) =='6')
          {
              Thread.CurrentThread.Suspend();
          }
          Thread.Sleep(100);
          Console.Write(item);
        }
      //arg be the max in the loop
      //int max = Convert.ToInt32(arg);
      //for (int i = 0; i < max; i++)
      //{
      //  Console.WriteLine("Thread BeepNo.#" + i);
      //  Thread.Sleep(1000);
      }
    }
    static void Main(string[] args)
    {
     // SingleThreadDemo();
      MultipleThreadsDemo();
    }

    private static void MultipleThreadsDemo()
    {
      Thread th1 = new Thread(CustomFunc);
      Thread th2 = new Thread(CustomFunc);
      th1.Start();
      th2.Start();
    }

    private static void SingleThreadDemo()
    {
      Console.WriteLine("Main Thread has started");
      //A thread object requires an instance of a delegate called ThreadStart which could delegate to any void function that does not take any args...
      Thread thread = new Thread(FuncWithArg);
      thread.Start("A 6 thread object requires an instance of a delegate called ThreadStart  which could delegate to any void function that does not take any args".ToCharArray());
      MainRelatedFunc();
      if (thread.ThreadState == ThreadState.Suspended)
        thread.Resume();
      Console.WriteLine("Main Thread has ended");
      Console.WriteLine("App is exiting....");
    }

    private static void MainRelatedFunc()
    {
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine(" Main Thread BeepNo.#" + i);
        Thread.Sleep(1000);
      }
    }
  }
}

 

