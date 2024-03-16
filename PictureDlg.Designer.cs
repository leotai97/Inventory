namespace Inventory
{
  partial class PictureDlg
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
      this.picLoc = new System.Windows.Forms.PictureBox();
      this.listChildren = new System.Windows.Forms.ListView();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnSetChildLoc = new System.Windows.Forms.Button();
      this.btnDropChild = new System.Windows.Forms.Button();
      this.btnEditLocation = new System.Windows.Forms.Button();
      this.btnAddChild = new System.Windows.Forms.Button();
      this.btnSetPic = new System.Windows.Forms.Button();
      this.pnlControls = new System.Windows.Forms.Panel();
      this.txtOrder = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.btnMoveSubItems = new System.Windows.Forms.Button();
      this.txtSubDesc = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtSubName = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.btnAddNoPicChild = new System.Windows.Forms.Button();
      this.btnSetRect = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.txtDesc = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtFile = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnMoveToName = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.picLoc)).BeginInit();
      this.pnlControls.SuspendLayout();
      this.SuspendLayout();
      // 
      // picLoc
      // 
      this.picLoc.Location = new System.Drawing.Point(12, 12);
      this.picLoc.Name = "picLoc";
      this.picLoc.Size = new System.Drawing.Size(829, 270);
      this.picLoc.TabIndex = 0;
      this.picLoc.TabStop = false;
      this.picLoc.Paint += new System.Windows.Forms.PaintEventHandler(this.picLoc_Paint);
      this.picLoc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLoc_MouseDown);
      this.picLoc.MouseLeave += new System.EventHandler(this.picLoc_MouseLeave);
      this.picLoc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picLoc_MouseMove);
      this.picLoc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLoc_MouseUp);
      // 
      // listChildren
      // 
      this.listChildren.FullRowSelect = true;
      this.listChildren.GridLines = true;
      this.listChildren.HideSelection = false;
      this.listChildren.Location = new System.Drawing.Point(12, 299);
      this.listChildren.MultiSelect = false;
      this.listChildren.Name = "listChildren";
      this.listChildren.Size = new System.Drawing.Size(829, 138);
      this.listChildren.TabIndex = 0;
      this.listChildren.UseCompatibleStateImageBehavior = false;
      this.listChildren.View = System.Windows.Forms.View.Details;
      this.listChildren.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listChildren_ColumnClick);
      this.listChildren.SelectedIndexChanged += new System.EventHandler(this.listChildren_SelectedIndexChanged);
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(782, 54);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(109, 23);
      this.btnSave.TabIndex = 20;
      this.btnSave.Text = "Save Text";
      this.toolTip1.SetToolTip(this.btnSave, "Save changes to the name and description of the open location");
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnSetChildLoc
      // 
      this.btnSetChildLoc.Location = new System.Drawing.Point(247, 93);
      this.btnSetChildLoc.Name = "btnSetChildLoc";
      this.btnSetChildLoc.Size = new System.Drawing.Size(87, 23);
      this.btnSetChildLoc.TabIndex = 8;
      this.btnSetChildLoc.Text = "Save Sub Loc";
      this.toolTip1.SetToolTip(this.btnSetChildLoc, "Save the currently selected sub locations rectacle, the sub name and sub descript" +
        "ion");
      this.btnSetChildLoc.UseVisualStyleBackColor = true;
      this.btnSetChildLoc.Click += new System.EventHandler(this.btnSetChildLoc_Click);
      // 
      // btnDropChild
      // 
      this.btnDropChild.Location = new System.Drawing.Point(340, 93);
      this.btnDropChild.Name = "btnDropChild";
      this.btnDropChild.Size = new System.Drawing.Size(114, 23);
      this.btnDropChild.TabIndex = 9;
      this.btnDropChild.Text = "Drop Sub Location";
      this.toolTip1.SetToolTip(this.btnDropChild, "Delete the currrently selected sub location");
      this.btnDropChild.UseVisualStyleBackColor = true;
      this.btnDropChild.Click += new System.EventHandler(this.btnDropChild_Click);
      // 
      // btnEditLocation
      // 
      this.btnEditLocation.Location = new System.Drawing.Point(782, 83);
      this.btnEditLocation.Name = "btnEditLocation";
      this.btnEditLocation.Size = new System.Drawing.Size(109, 23);
      this.btnEditLocation.TabIndex = 21;
      this.btnEditLocation.Text = "Edit Sub Location";
      this.toolTip1.SetToolTip(this.btnEditLocation, "Open the selected pictured sub location for editing in this dialog ");
      this.btnEditLocation.UseVisualStyleBackColor = true;
      this.btnEditLocation.Click += new System.EventHandler(this.btnEditLocation_Click);
      // 
      // btnAddChild
      // 
      this.btnAddChild.Location = new System.Drawing.Point(16, 93);
      this.btnAddChild.Name = "btnAddChild";
      this.btnAddChild.Size = new System.Drawing.Size(100, 23);
      this.btnAddChild.TabIndex = 6;
      this.btnAddChild.Text = "Add Pic Location";
      this.toolTip1.SetToolTip(this.btnAddChild, "Add a new sub picture location with a picture to the current picture location tha" +
        "t is open");
      this.btnAddChild.UseVisualStyleBackColor = true;
      this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
      // 
      // btnSetPic
      // 
      this.btnSetPic.Location = new System.Drawing.Point(782, 25);
      this.btnSetPic.Name = "btnSetPic";
      this.btnSetPic.Size = new System.Drawing.Size(109, 23);
      this.btnSetPic.TabIndex = 19;
      this.btnSetPic.Text = "Set Picture";
      this.toolTip1.SetToolTip(this.btnSetPic, "Change the image of the picture location");
      this.btnSetPic.UseVisualStyleBackColor = true;
      this.btnSetPic.Click += new System.EventHandler(this.btnSetPic_Click);
      // 
      // pnlControls
      // 
      this.pnlControls.Controls.Add(this.btnMoveToName);
      this.pnlControls.Controls.Add(this.txtOrder);
      this.pnlControls.Controls.Add(this.label6);
      this.pnlControls.Controls.Add(this.btnMoveSubItems);
      this.pnlControls.Controls.Add(this.txtSubDesc);
      this.pnlControls.Controls.Add(this.label5);
      this.pnlControls.Controls.Add(this.btnEditLocation);
      this.pnlControls.Controls.Add(this.txtSubName);
      this.pnlControls.Controls.Add(this.label4);
      this.pnlControls.Controls.Add(this.btnAddNoPicChild);
      this.pnlControls.Controls.Add(this.btnSetRect);
      this.pnlControls.Controls.Add(this.btnOK);
      this.pnlControls.Controls.Add(this.txtDesc);
      this.pnlControls.Controls.Add(this.label3);
      this.pnlControls.Controls.Add(this.btnSave);
      this.pnlControls.Controls.Add(this.btnDropChild);
      this.pnlControls.Controls.Add(this.btnSetChildLoc);
      this.pnlControls.Controls.Add(this.txtFile);
      this.pnlControls.Controls.Add(this.label2);
      this.pnlControls.Controls.Add(this.txtName);
      this.pnlControls.Controls.Add(this.btnAddChild);
      this.pnlControls.Controls.Add(this.label1);
      this.pnlControls.Controls.Add(this.btnSetPic);
      this.pnlControls.Location = new System.Drawing.Point(12, 463);
      this.pnlControls.Name = "pnlControls";
      this.pnlControls.Size = new System.Drawing.Size(900, 175);
      this.pnlControls.TabIndex = 0;
      // 
      // txtOrder
      // 
      this.txtOrder.Location = new System.Drawing.Point(242, 135);
      this.txtOrder.Name = "txtOrder";
      this.txtOrder.Size = new System.Drawing.Size(50, 20);
      this.txtOrder.TabIndex = 16;
      this.txtOrder.TextChanged += new System.EventHandler(this.txtOrder_TextChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(239, 119);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(33, 13);
      this.label6.TabIndex = 15;
      this.label6.Text = "Order";
      // 
      // btnMoveSubItems
      // 
      this.btnMoveSubItems.Location = new System.Drawing.Point(566, 92);
      this.btnMoveSubItems.Name = "btnMoveSubItems";
      this.btnMoveSubItems.Size = new System.Drawing.Size(98, 23);
      this.btnMoveSubItems.TabIndex = 11;
      this.btnMoveSubItems.Text = "Move To Picture";
      this.toolTip1.SetToolTip(this.btnMoveSubItems, "Move items from the selected sub location to another existing sub location ");
      this.btnMoveSubItems.UseVisualStyleBackColor = true;
      this.btnMoveSubItems.Click += new System.EventHandler(this.btnMoveSubItems_Click);
      // 
      // txtSubDesc
      // 
      this.txtSubDesc.Location = new System.Drawing.Point(298, 135);
      this.txtSubDesc.MaxLength = 1024;
      this.txtSubDesc.Name = "txtSubDesc";
      this.txtSubDesc.Size = new System.Drawing.Size(470, 20);
      this.txtSubDesc.TabIndex = 18;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(295, 119);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(126, 13);
      this.label5.TabIndex = 17;
      this.label5.Text = "Sub Location Description";
      // 
      // txtSubName
      // 
      this.txtSubName.Location = new System.Drawing.Point(16, 135);
      this.txtSubName.MaxLength = 256;
      this.txtSubName.Name = "txtSubName";
      this.txtSubName.Size = new System.Drawing.Size(219, 20);
      this.txtSubName.TabIndex = 14;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(13, 119);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(101, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Sub Location Name";
      // 
      // btnAddNoPicChild
      // 
      this.btnAddNoPicChild.Location = new System.Drawing.Point(122, 93);
      this.btnAddNoPicChild.Name = "btnAddNoPicChild";
      this.btnAddNoPicChild.Size = new System.Drawing.Size(119, 23);
      this.btnAddNoPicChild.TabIndex = 7;
      this.btnAddNoPicChild.Text = "Add No Pic Location";
      this.toolTip1.SetToolTip(this.btnAddNoPicChild, "Add a sub location with no picture, this would be the final destination for inven" +
        "tory items");
      this.btnAddNoPicChild.UseVisualStyleBackColor = true;
      this.btnAddNoPicChild.Click += new System.EventHandler(this.btnAddNoPicChild_Click);
      // 
      // btnSetRect
      // 
      this.btnSetRect.Location = new System.Drawing.Point(460, 92);
      this.btnSetRect.Name = "btnSetRect";
      this.btnSetRect.Size = new System.Drawing.Size(100, 23);
      this.btnSetRect.TabIndex = 10;
      this.btnSetRect.Text = "Set Rect Color";
      this.toolTip1.SetToolTip(this.btnSetRect, "Set the line color and width of the rectangle");
      this.btnSetRect.UseVisualStyleBackColor = true;
      this.btnSetRect.Click += new System.EventHandler(this.btnSetRect_Click);
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(782, 132);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(109, 23);
      this.btnOK.TabIndex = 22;
      this.btnOK.Text = "Close";
      this.toolTip1.SetToolTip(this.btnOK, "Close the dialog");
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // txtDesc
      // 
      this.txtDesc.Location = new System.Drawing.Point(16, 66);
      this.txtDesc.MaxLength = 1024;
      this.txtDesc.Name = "txtDesc";
      this.txtDesc.Size = new System.Drawing.Size(752, 20);
      this.txtDesc.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(13, 50);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(60, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Description";
      // 
      // txtFile
      // 
      this.txtFile.Location = new System.Drawing.Point(334, 27);
      this.txtFile.Name = "txtFile";
      this.txtFile.ReadOnly = true;
      this.txtFile.Size = new System.Drawing.Size(434, 20);
      this.txtFile.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(331, 11);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(90, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Picture File Name";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(16, 27);
      this.txtName.MaxLength = 256;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(305, 20);
      this.txtName.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 11);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(79, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Location Name";
      // 
      // btnMoveToName
      // 
      this.btnMoveToName.Location = new System.Drawing.Point(670, 92);
      this.btnMoveToName.Name = "btnMoveToName";
      this.btnMoveToName.Size = new System.Drawing.Size(98, 23);
      this.btnMoveToName.TabIndex = 12;
      this.btnMoveToName.Text = "Move To Name";
      this.toolTip1.SetToolTip(this.btnMoveToName, "Move items from the selected sub location to a named location\r\n ");
      this.btnMoveToName.UseVisualStyleBackColor = true;
      this.btnMoveToName.Click += new System.EventHandler(this.btnMoveToName_Click);
      // 
      // PictureDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(924, 684);
      this.Controls.Add(this.pnlControls);
      this.Controls.Add(this.listChildren);
      this.Controls.Add(this.picLoc);
      this.MinimizeBox = false;
      this.Name = "PictureDlg";
      this.Text = "Picture Location";
      ((System.ComponentModel.ISupportInitialize)(this.picLoc)).EndInit();
      this.pnlControls.ResumeLayout(false);
      this.pnlControls.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox picLoc;
    private System.Windows.Forms.ListView listChildren;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnSetChildLoc;
    private System.Windows.Forms.Button btnDropChild;
    private System.Windows.Forms.Button btnEditLocation;
    private System.Windows.Forms.Button btnAddChild;
    private System.Windows.Forms.Button btnSetPic;
    private System.Windows.Forms.Panel pnlControls;
    private System.Windows.Forms.TextBox txtFile;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtDesc;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnSetRect;
    private System.Windows.Forms.Button btnAddNoPicChild;
    private System.Windows.Forms.TextBox txtSubDesc;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtSubName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button btnMoveSubItems;
    private System.Windows.Forms.TextBox txtOrder;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button btnMoveToName;
  }
}