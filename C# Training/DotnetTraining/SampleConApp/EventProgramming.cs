using System;
namespace SampleConApp
{
  //Events are actions performed by the user on the object. Technically events are objects of delegates with keyword event..
  //.NET gives 2 delegates for void functions(Action) and non-void functions(Func). U could use these delegates instead of creating uR own...
  class Employee
  {
    private int _empID;
    private string _empName;
    public event Action EmpIDChanged = null;
    public event Action EmpNameChanged = null;
    public int EmpID
    {
      get { return _empID; }
      set
      {
        _empID = value;
        if(EmpIDChanged != null)
          EmpIDChanged();
      }
    }

    public string EmpName
    {
      get { return _empName; }
      set
      {
        _empName = value;
        if (EmpNameChanged != null)
          EmpNameChanged();
      }
    }
  }

  class EventsDemo
  {
    static void Main(string[] args)
    {
      Employee emp = new Employee();
      emp.EmpIDChanged += idAdded;
      emp.EmpNameChanged += nameAdded;
      emp.EmpID = 123;
      emp.EmpName = "Phaniraj";
    }
    static void idAdded()
    {
      Console.WriteLine("Employee ID is set");
    }

    static void nameAdded()
    {
      Console.WriteLine("Employee name is set");
    }
  }
}