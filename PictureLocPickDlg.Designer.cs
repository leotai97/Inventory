namespace Inventory
{
  partial class PictureLocPickDlg
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
      this.picLocation = new System.Windows.Forms.PictureBox();
      this.listPics = new System.Windows.Forms.ListView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.picLocation)).BeginInit();
      this.SuspendLayout();
      // 
      // picLocation
      // 
      this.picLocation.Location = new System.Drawing.Point(12, 12);
      this.picLocation.Name = "picLocation";
      this.picLocation.Size = new System.Drawing.Size(339, 385);
      this.picLocation.TabIndex = 0;
      this.picLocation.TabStop = false;
      this.picLocation.Paint += new System.Windows.Forms.PaintEventHandler(this.picLocation_Paint);
      this.picLocation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLocation_MouseDown);
      this.picLocation.MouseLeave += new System.EventHandler(this.picLocation_MouseLeave);
      this.picLocation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picLocation_MouseMove);
      this.picLocation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLocation_MouseUp);
      // 
      // listPics
      // 
      this.listPics.HideSelection = false;
      this.listPics.Location = new System.Drawing.Point(389, 12);
      this.listPics.Name = "listPics";
      this.listPics.Size = new System.Drawing.Size(353, 385);
      this.listPics.TabIndex = 1;
      this.listPics.UseCompatibleStateImageBehavior = false;
      this.listPics.SelectedIndexChanged += new System.EventHandler(this.listPics_SelectedIndexChanged);
      // 
      // imageList1
      // 
      this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
      this.imageList1.ImageSize = new System.Drawing.Size(128, 128);
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // PickPictureLocDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.listPics);
      this.Controls.Add(this.picLocation);
      this.MinimizeBox = false;
      this.Name = "PickPictureLocDlg";
      this.Text = "PIck Picture Location";
      ((System.ComponentModel.ISupportInitialize)(this.picLocation)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox picLocation;
    private System.Windows.Forms.ListView listPics;
    private System.Windows.Forms.ImageList imageList1;
  }
}