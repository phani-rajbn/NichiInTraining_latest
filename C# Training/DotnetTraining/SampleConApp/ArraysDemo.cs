using System;
namespace SampleConApp
{
  /*
  Array is a reference type in .NET. They are objects of a class called System.Array. This class has properties and functions to get details of the array, copy the array, clone and do other activities with the array objects.
  datatype [] name = new datatype[size]
  datatype [] name = {}//seperated by comma
  datatype [] name = Array.CreateInstance(typeof(datatype), size);
  */

   class Customer
  {
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
  }
  class ArraysDemo
  {
    static void Main(string[] args)
    {
      //firstDemo();
      //twoDArray();
      //jaggedArrays();
      //recap1();
      objectArray();
    }

    private static void objectArray()
    {
      Customer[] customers = new Customer[100];
      for (int i = 0; i < customers.Length; i++)
      {
        customers[i] = new Customer();
      }
      foreach(var cst in customers)
        Console.WriteLine(cst.CustomerName);   
    }

    private static void recap1()
    {
      int[] numbers = new int[10];
      numbers[5] = 234;
      foreach(var item in numbers)
        Console.WriteLine(item);
    }

    private static void jaggedArrays()
    {
      //Array of arrays is called as jagged Array. U will have a fixed no of rows but variable no of columns in each row.. Each row itself is an array which will have variable no of elements..
      //An Array of ClassRooms where each Room has an array of students.
      int[][] classRooms = new int[4][];//4 rows....
      classRooms[0] = new int[] { 4, 5, 6, 7 };
      classRooms[1] = new int[] { 6, 5, 4, 5, 6, 7, 8 };
      classRooms[2] = new int[] { 4, 5 };
      classRooms[3] = new int[] { 6, 7, 8, 5, 4 };
      for (int i = 0; i < classRooms.Length; i++)
      {
        foreach(int item in classRooms[i])
          Console.Write(item +" ");
        Console.WriteLine();
      }

    }

    private static void twoDArray()
    {
      int[,] data = { { 1, 2, 4, 5 }, { 4, 5, 6, 9 }, { 6, 5, 4, 0 } };
      Console.WriteLine($"The no of Dimensions:{data.Rank}");
      Console.WriteLine($"The no of elements:{data.Length}");
      Console.WriteLine($"The no of elements in the Row:{data.GetLength(0)}");
      Console.WriteLine($"The no of elements in the Columns:{data.GetLength(1)}");
      for (int i = 0; i < data.GetLength(0); i++)
      {
        for (int j = 0; j < data.GetLength(1); j++)
        {
          Console.Write(data[i,j] + " ");//Same line
        }
        Console.WriteLine();//Moves to the next line...
      }
    }

    private static void firstDemo()
    {
      string[] fruits = new string[5];//Create the array
      fruits[0] = "Apple";//Assigning values into the elements
      fruits[1] = "Mango";
      fruits[2] = "Orange";
      fruits[3] = "Pineapple";
      fruits[4] = "Chikku";
      foreach (string item in fruits)//item is the element in the array
        Console.WriteLine(item);//it is forward-only and readonly.
      for (int i = 0; i < fruits.Length; i++)
      {
        Console.WriteLine($"The Fruit:{fruits[i]}");
      }//Use this for both back and forth as well as writing to the array.
    }
  }
}