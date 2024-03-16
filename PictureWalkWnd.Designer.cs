namespace Inventory
{
  partial class PictureWalkWnd
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
      this.timerPics = new System.Windows.Forms.Timer(this.components);
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.txtName = new System.Windows.Forms.ToolStripStatusLabel();
      this.picLoc = new System.Windows.Forms.PictureBox();
      this.statusStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picLoc)).BeginInit();
      this.SuspendLayout();
      // 
      // timerPics
      // 
      this.timerPics.Interval = 2500;
      this.timerPics.Tick += new System.EventHandler(this.timerPics_Tick);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtName});
      this.statusStrip1.Location = new System.Drawing.Point(0, 428);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(800, 22);
      this.statusStrip1.TabIndex = 3;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // txtName
      // 
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(785, 17);
      this.txtName.Spring = true;
      // 
      // picLoc
      // 
      this.picLoc.Location = new System.Drawing.Point(12, 12);
      this.picLoc.Name = "picLoc";
      this.picLoc.Size = new System.Drawing.Size(765, 413);
      this.picLoc.TabIndex = 2;
      this.picLoc.TabStop = false;
      this.picLoc.Paint += new System.Windows.Forms.PaintEventHandler(this.picLoc_Paint);
      // 
      // PictureWalkWnd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.picLoc);
      this.Name = "PictureWalkWnd";
      this.Text = "Inventory Location";
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picLoc)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.PictureBox picLoc;
    private System.Windows.Forms.Timer timerPics;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel txtName;
  }
}