using System;
using System.IO;

namespace SampleConApp
{

  static class UIComponent
  {
    public static int GetInt(string question)
    {
      return int.Parse(GetString(question));
    }

    public static string GetString(string question)
    {
      Console.WriteLine(question);
      return Console.ReadLine();
    }
  }

  static class FileIO
  {
    public static string ReadFile(string filename)
    {
      StreamReader reader = new StreamReader(filename);
      return reader.ReadToEnd();
    }

    public static void WriteFile(string fileName, string content)
    {
      StreamWriter writer = new StreamWriter(fileName);
      writer.WriteLine(content);
      writer.Close();
    } 
  }
  class Program
  {
    //object of the QuestionBank...
    static QuestionBank qp = new QuestionBank();
    static string menuFile = @"C:\Users\Phani Raj\Desktop\Current Training\C# Training\RecapExamples\SampleConApp\Menu.txt";
    static void Main(string[] args)
    {
      string menu = FileIO.ReadFile(menuFile);
      bool @continue = true;
      do
      {
        string choice = UIComponent.GetString(menu);
        @continue = processMenu(choice);
      } while (@continue);
    }

    private static bool processMenu(string choice)
    {
      switch (choice.ToUpper())
      {
        default:
          return false;
        case "N":
          QuestionInfo question = createQuestion();
          qp.AddNewQuestion(question);
          return true;
        case "U":

          return true;
        case "F":
          string subject = UIComponent.GetString("Enter the Subject to find the Questions");
          var questions = qp.FindQuestions(subject);
          foreach (QuestionInfo info in questions)
            displayQuestion(info);
          return true;
      }
    }

    private static void displayQuestion(QuestionInfo question)
    {
      Console.WriteLine($"Question No: {question.QuestionNo}");
      Console.WriteLine($"Subject: {question.Subject}");
      Console.WriteLine($"Question: {question.Question}");
      Console.WriteLine($"A: {question.Choices[0]}");
      Console.WriteLine($"B: {question.Choices[1]}");
      Console.WriteLine($"C: {question.Choices[2]}");
      Console.WriteLine($"D: {question.Choices[3]}");
      Console.WriteLine($"Right Answer: {question.CorrectAnswer}");
    }

    private static QuestionInfo createQuestion()
    {
      QuestionInfo info = new QuestionInfo();
      info.QuestionNo = UIComponent.GetInt("Enter the Question No:");
      info.Subject = UIComponent.GetString("Enter the Subject");
      info.Question = UIComponent.GetString("Enter the Question");
      string[] choices = new string[4];
      for (int i = 0; i < 4; i++)
      {
        choices[i] = UIComponent.GetString($"Enter the Choice{i+1}");
      }
      info.Choices = choices;
      info.CorrectAnswer = UIComponent.GetString("Enter the Right Choice as A, B, C or D");
      return info;
    }
  }
}
