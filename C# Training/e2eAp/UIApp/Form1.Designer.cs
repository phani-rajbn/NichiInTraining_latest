namespace UIApp
{
  partial class MainForm
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
      this.lstTitles = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // lstTitles
      // 
      this.lstTitles.FormattingEnabled = true;
      this.lstTitles.ItemHeight = 28;
      this.lstTitles.Location = new System.Drawing.Point(28, 76);
      this.lstTitles.Name = "lstTitles";
      this.lstTitles.Size = new System.Drawing.Size(154, 200);
      this.lstTitles.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.ClientSize = new System.Drawing.Size(615, 562);
      this.Controls.Add(this.lstTitles);
      this.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.Name = "MainForm";
      this.Text = "UI";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox lstTitles;
  }
}

