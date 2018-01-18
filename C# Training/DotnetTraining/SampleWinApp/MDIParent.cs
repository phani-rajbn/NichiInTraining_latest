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
  public partial class MDIParent : Form
  {
    private int childFormNumber = 0;

    public MDIParent()
    {
      InitializeComponent();
    }
    //Event handler for click of the menu item called calc...
    private void calcToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CalcForm frm = new CalcForm();//create the instance of the form
      frm.MdiParent = this;//assocciate the current MDI Form as parent to the form...
      frm.Show();//display the form...
    }

    private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutBox1 box = new AboutBox1();
      box.ShowDialog();//Makes the form as Modal dialog... 
    }

    private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Database frm = new Database();//name of the form
      frm.MdiParent = this;
      frm.Show();
    }
  }
}
