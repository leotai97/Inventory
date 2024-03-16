namespace Inventory
{
  partial class PictureChooseDlg
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
      this.listPics = new System.Windows.Forms.ListView();
      this.btnAddPic = new System.Windows.Forms.Button();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.btnDropLoc = new System.Windows.Forms.Button();
      this.btnEdit = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // listPics
      // 
      this.listPics.HideSelection = false;
      this.listPics.Location = new System.Drawing.Point(12, 12);
      this.listPics.Name = "listPics";
      this.listPics.Size = new System.Drawing.Size(683, 426);
      this.listPics.TabIndex = 0;
      this.listPics.UseCompatibleStateImageBehavior = false;
      this.listPics.DoubleClick += new System.EventHandler(this.listPics_DoubleClick);
      // 
      // btnAddPic
      // 
      this.btnAddPic.Location = new System.Drawing.Point(702, 41);
      this.btnAddPic.Name = "btnAddPic";
      this.btnAddPic.Size = new System.Drawing.Size(101, 23);
      this.btnAddPic.TabIndex = 2;
      this.btnAddPic.Text = "Add Location";
      this.btnAddPic.UseVisualStyleBackColor = true;
      this.btnAddPic.Click += new System.EventHandler(this.btnAddPic_Click);
      // 
      // imageList1
      // 
      this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
      this.imageList1.ImageSize = new System.Drawing.Size(128, 128);
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // btnDropLoc
      // 
      this.btnDropLoc.Location = new System.Drawing.Point(701, 70);
      this.btnDropLoc.Name = "btnDropLoc";
      this.btnDropLoc.Size = new System.Drawing.Size(101, 23);
      this.btnDropLoc.TabIndex = 3;
      this.btnDropLoc.Text = "Drop Location";
      this.btnDropLoc.UseVisualStyleBackColor = true;
      this.btnDropLoc.Click += new System.EventHandler(this.btnDropLoc_Click);
      // 
      // btnEdit
      // 
      this.btnEdit.Location = new System.Drawing.Point(702, 12);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(101, 23);
      this.btnEdit.TabIndex = 1;
      this.btnEdit.Text = "Edit Location";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // btnClose
      // 
      this.btnClose.Location = new System.Drawing.Point(702, 415);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(101, 23);
      this.btnClose.TabIndex = 4;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // PictureChooseDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(815, 450);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnEdit);
      this.Controls.Add(this.btnDropLoc);
      this.Controls.Add(this.btnAddPic);
      this.Controls.Add(this.listPics);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PictureChooseDlg";
      this.Text = "Picture Locations";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listPics;
    private System.Windows.Forms.Button btnAddPic;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.Button btnDropLoc;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnClose;
  }
}