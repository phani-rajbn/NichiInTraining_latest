using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWinApp
{
  public partial class CalcForm : Form
  {
    public CalcForm()
    {
      InitializeComponent();
    }

    private void onCheckedEvent(object sender, EventArgs e)
    {
      
      var rd = sender as RadioButton;
      if (rd.Checked == false)
        return;
        var v1 = double.Parse(txtV1.Text);
        var v2 = double.Parse(txtV2.Text);
        var res = 0.0;
        string content = string.Empty;
        switch (rd.Text)
        {
          case "Add":
            res = v1 + v2;
            break;
          case "Subtract":
            res = v1 - v2;
            break;
          case "Multiply":
            res = v1 * v2;
            break;
          default:
            break;
        }
        content = string.Format($"The result of this operation is {res}");
        MessageBox.Show(content);
    }
    //Event handler is a function that is triggered by the program when the user performs the action 
  }
}
