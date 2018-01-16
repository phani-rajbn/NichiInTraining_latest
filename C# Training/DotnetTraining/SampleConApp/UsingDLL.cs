using System;
using SampleDll;
namespace SampleConApp
{
  class DllProgram
  {
    static void Main(string[] args)
    {
      FirstComponent com = new FirstComponent();
      var message =  com.WelcomeFunc();
      Console.WriteLine(message);
      Console.ReadKey();
    }
  }
}