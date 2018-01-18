namespace SampleWinApp
{
  partial class Database
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lstNames = new System.Windows.Forms.ListBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtID = new System.Windows.Forms.TextBox();
      this.txtName = new System.Windows.Forms.TextBox();
      this.txtAddress = new System.Windows.Forms.TextBox();
      this.txtDept = new System.Windows.Forms.TextBox();
      this.btnDisplay = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(155, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(350, 28);
      this.label1.TabIndex = 0;
      this.label1.Text = "Employee Monitoring System";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(41, 79);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(233, 28);
      this.label2.TabIndex = 1;
      this.label2.Text = "List of Employees";
      // 
      // lstNames
      // 
      this.lstNames.FormattingEnabled = true;
      this.lstNames.ItemHeight = 28;
      this.lstNames.Location = new System.Drawing.Point(46, 110);
      this.lstNames.Name = "lstNames";
      this.lstNames.Size = new System.Drawing.Size(228, 228);
      this.lstNames.TabIndex = 2;
      this.lstNames.SelectedIndexChanged += new System.EventHandler(this.lstNames_SelectedIndexChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.txtDept);
      this.groupBox1.Controls.Add(this.txtAddress);
      this.groupBox1.Controls.Add(this.txtName);
      this.groupBox1.Controls.Add(this.txtID);
      this.groupBox1.ForeColor = System.Drawing.Color.Gold;
      this.groupBox1.Location = new System.Drawing.Point(291, 82);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(396, 255);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Details";
      // 
      // txtID
      // 
      this.txtID.Location = new System.Drawing.Point(52, 35);
      this.txtID.Name = "txtID";
      this.txtID.Size = new System.Drawing.Size(286, 36);
      this.txtID.TabIndex = 0;
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(52, 87);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(286, 36);
      this.txtName.TabIndex = 1;
      // 
      // txtAddress
      // 
      this.txtAddress.Location = new System.Drawing.Point(52, 138);
      this.txtAddress.Name = "txtAddress";
      this.txtAddress.Size = new System.Drawing.Size(286, 36);
      this.txtAddress.TabIndex = 2;
      // 
      // txtDept
      // 
      this.txtDept.Location = new System.Drawing.Point(52, 192);
      this.txtDept.Name = "txtDept";
      this.txtDept.Size = new System.Drawing.Size(286, 36);
      this.txtDept.TabIndex = 3;
      // 
      // btnDisplay
      // 
      this.btnDisplay.Location = new System.Drawing.Point(46, 344);
      this.btnDisplay.Name = "btnDisplay";
      this.btnDisplay.Size = new System.Drawing.Size(228, 38);
      this.btnDisplay.TabIndex = 4;
      this.btnDisplay.Text = "Display Names";
      this.btnDisplay.UseVisualStyleBackColor = true;
      this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
      // 
      // Database
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Gray;
      this.ClientSize = new System.Drawing.Size(693, 400);
      this.Controls.Add(this.btnDisplay);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.lstNames);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ForeColor = System.Drawing.Color.Gold;
      this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.Name = "Database";
      this.Text = "Database Program";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox lstNames;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtDept;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.Button btnDisplay;
  }
}