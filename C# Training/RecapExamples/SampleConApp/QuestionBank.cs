using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
  class QuestionBank
  {
    private List<QuestionInfo> _questions = new List<QuestionInfo>();

    public QuestionBank()
    {
      loadFile();
    }
    private void saveFile()
    {
      StreamWriter writer = new StreamWriter("QuestionBank.txt");
      foreach(QuestionInfo q in _questions)
      {
        string line = string.Format($"{q.QuestionNo},{q.Subject},{q.Question},{q.Choices[0]},{q.Choices[1]},{q.Choices[2]},{q.Choices[3]},{q.CorrectAnswer}");
        writer.WriteLine(line);
      }
      writer.Flush();
      writer.Close();
    }
    private void loadFile()
    {
      _questions = new List<QuestionInfo>();//New paper....
      if (!File.Exists("QuestionBank.txt"))
      {
        return;
      }
      StreamReader reader = new StreamReader("QuestionBank.txt");
      do
      {
        string line = reader.ReadLine();
        string[] data = line.Split(',');
        QuestionInfo info = new QuestionInfo();
        info.QuestionNo = int.Parse(data[0]);
        info.Subject = data[1];
        info.Question = data[2];
        string[] choices = new string[4];
        for (int i = 3; i < 7; i++)
        {
          choices[i - 3] = data[i];
        }
        info.Choices = choices;
        info.CorrectAnswer = data[7];
        _questions.Add(info);
      } while (!reader.EndOfStream);
      reader.Close();
    }
    public void AddNewQuestion(QuestionInfo question)
    {
      if(question != null)
      {
        _questions.Add(question);//Adds the item to the bottom of the list...
        saveFile();
      }
      else
      {
        //Throw an exception....
      }
    }

    public List<QuestionInfo> FindQuestions(string subject)
    {
      loadFile();
      List<QuestionInfo> tempList = new List<QuestionInfo>();
      //Iterate thro the master list..
      foreach (QuestionInfo item in _questions)
      {
        //Filter the item based on the subject and add the item to tempList..
        if(item.Subject == subject)
        {
          tempList.Add(item);
        }
      }
      return tempList;
    }

    public void UpdateQuestion(QuestionInfo question)
    {
      //Iterate thro the master list and find the question based on id..
      for (int i = 0; i < _questions.Count; i++)
      {
        if(_questions[i].QuestionNo == question.QuestionNo)
        {
          //Set the new details to the found QUestion
          _questions[i].Question = question.Question;
          _questions[i].Choices = question.Choices;
          _questions[i].CorrectAnswer = question.CorrectAnswer;
          _questions[i].Subject = question.Subject;
          return;//exit the function...
        }
      }
    }
  }
}
