using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SampleWinApp
{
  public partial class Database : Form
  {
    public Database()
    {
      InitializeComponent();
    }

    private void btnDisplay_Click(object sender, EventArgs e)
    {
      //create the datacontext
      var context = new NichiInDatabaseEntities();
      //fetch the names
      var names = from emp in context.EmpTables
                  orderby emp.EmpName
                  select emp.EmpName;
      //associate the names to the listbox...
      lstNames.DataSource = names.ToList();
    }

    private void lstNames_SelectedIndexChanged(object sender, EventArgs e)
    {
      var context = new NichiInDatabaseEntities();
      var name = lstNames.Text;
      var selected = (from emp in context.EmpTables
                      where emp.EmpName == name
                      select emp).FirstOrDefault();
      populateData(selected);
    }

    private void populateData(EmpTable selected)
    {
      txtID.Text = selected.EmpID.ToString();
      txtName.Text = selected.EmpName;
      txtAddress.Text = selected.EmpAddress;
      txtDept.Text = selected.DeptTable.DeptName;
    }
  }
}
