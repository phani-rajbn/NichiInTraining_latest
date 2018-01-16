using System;
using System.IO;//For File IO operations...
namespace SampleConApp
{
  class FileIO
  {
    static void Main(string[] args)
    {
      //writeToFile();
      readFromFile();
    }

    private static void readFromFile()
    {
      StreamReader reader = new StreamReader("TempFile.txt");
      string content = reader.ReadToEnd();
      Console.WriteLine(content);
    }

    private static void writeToFile()
    {
      StreamWriter writer = new StreamWriter("TempFile.txt", true);
      writer.WriteLine("Test 123");
      writer.Close();
      Console.ReadKey();
    }
  }
}
