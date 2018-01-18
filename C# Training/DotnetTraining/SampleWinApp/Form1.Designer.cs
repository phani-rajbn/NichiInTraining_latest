namespace SampleWinApp
{
  partial class CalcForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtV1 = new System.Windows.Forms.TextBox();
      this.txtV2 = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.rdDiv = new System.Windows.Forms.RadioButton();
      this.rdMul = new System.Windows.Forms.RadioButton();
      this.rdSub = new System.Windows.Forms.RadioButton();
      this.rdAdd = new System.Windows.Forms.RadioButton();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(141, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(359, 43);
      this.label1.TabIndex = 0;
      this.label1.Text = "Math Calc Program";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(70, 93);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(178, 24);
      this.label2.TabIndex = 1;
      this.label2.Text = "Enter a value:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(70, 135);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(178, 24);
      this.label3.TabIndex = 2;
      this.label3.Text = "Enter a value:";
      // 
      // txtV1
      // 
      this.txtV1.Location = new System.Drawing.Point(254, 90);
      this.txtV1.Name = "txtV1";
      this.txtV1.Size = new System.Drawing.Size(209, 32);
      this.txtV1.TabIndex = 3;
      this.toolTip1.SetToolTip(this.txtV1, "Enter a number to add");
      // 
      // txtV2
      // 
      this.txtV2.Location = new System.Drawing.Point(254, 135);
      this.txtV2.Name = "txtV2";
      this.txtV2.Size = new System.Drawing.Size(209, 32);
      this.txtV2.TabIndex = 4;
      this.toolTip1.SetToolTip(this.txtV2, "Enter the Number to add");
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.rdDiv);
      this.groupBox1.Controls.Add(this.rdMul);
      this.groupBox1.Controls.Add(this.rdSub);
      this.groupBox1.Controls.Add(this.rdAdd);
      this.groupBox1.Location = new System.Drawing.Point(74, 193);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(534, 104);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Operations";
      // 
      // rdDiv
      // 
      this.rdDiv.AutoSize = true;
      this.rdDiv.Location = new System.Drawing.Point(413, 44);
      this.rdDiv.Name = "rdDiv";
      this.rdDiv.Size = new System.Drawing.Size(100, 28);
      this.rdDiv.TabIndex = 3;
      this.rdDiv.TabStop = true;
      this.rdDiv.Text = "Divide";
      this.toolTip1.SetToolTip(this.rdDiv, "Click to divide");
      this.rdDiv.UseVisualStyleBackColor = true;
      this.rdDiv.CheckedChanged += new System.EventHandler(this.onCheckedEvent);
      // 
      // rdMul
      // 
      this.rdMul.AutoSize = true;
      this.rdMul.Location = new System.Drawing.Point(262, 44);
      this.rdMul.Name = "rdMul";
      this.rdMul.Size = new System.Drawing.Size(124, 28);
      this.rdMul.TabIndex = 2;
      this.rdMul.TabStop = true;
      this.rdMul.Text = "Multiply";
      this.toolTip1.SetToolTip(this.rdMul, "Click to Multiply");
      this.rdMul.UseVisualStyleBackColor = true;
      this.rdMul.CheckedChanged += new System.EventHandler(this.onCheckedEvent);
      // 
      // rdSub
      // 
      this.rdSub.AutoSize = true;
      this.rdSub.Location = new System.Drawing.Point(120, 44);
      this.rdSub.Name = "rdSub";
      this.rdSub.Size = new System.Drawing.Size(124, 28);
      this.rdSub.TabIndex = 1;
      this.rdSub.TabStop = true;
      this.rdSub.Text = "Subtract";
      this.toolTip1.SetToolTip(this.rdSub, "Click to Subtract");
      this.rdSub.UseVisualStyleBackColor = true;
      this.rdSub.CheckedChanged += new System.EventHandler(this.onCheckedEvent);
      // 
      // rdAdd
      // 
      this.rdAdd.AutoSize = true;
      this.rdAdd.Location = new System.Drawing.Point(32, 44);
      this.rdAdd.Name = "rdAdd";
      this.rdAdd.Size = new System.Drawing.Size(64, 28);
      this.rdAdd.TabIndex = 0;
      this.rdAdd.TabStop = true;
      this.rdAdd.Text = "Add";
      this.toolTip1.SetToolTip(this.rdAdd, "Click to Add");
      this.rdAdd.UseVisualStyleBackColor = true;
      this.rdAdd.CheckedChanged += new System.EventHandler(this.onCheckedEvent);
      // 
      // CalcForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.ClientSize = new System.Drawing.Size(668, 395);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.txtV2);
      this.Controls.Add(this.txtV1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(6);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CalcForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtV1;
    private System.Windows.Forms.TextBox txtV2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton rdDiv;
    private System.Windows.Forms.RadioButton rdMul;
    private System.Windows.Forms.RadioButton rdSub;
    private System.Windows.Forms.RadioButton rdAdd;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}

