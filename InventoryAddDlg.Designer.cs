namespace Inventory
{
  partial class InventoryAddDlg
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
      this.cboCat = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.pnlProps = new System.Windows.Forms.GroupBox();
      this.txtLocation = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnChangeLoc = new System.Windows.Forms.Button();
      this.btnCatAdd = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.txtQuantity = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtPrice = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 55);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Category";
      // 
      // cboCat
      // 
      this.cboCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboCat.FormattingEnabled = true;
      this.cboCat.Location = new System.Drawing.Point(11, 71);
      this.cboCat.Name = "cboCat";
      this.cboCat.Size = new System.Drawing.Size(319, 21);
      this.cboCat.TabIndex = 4;
      this.cboCat.SelectedIndexChanged += new System.EventHandler(this.cboCat_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 106);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(58, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Item Name";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(11, 122);
      this.txtName.MaxLength = 512;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(346, 20);
      this.txtName.TabIndex = 7;
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(304, 214);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 14;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(211, 214);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 13;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // pnlProps
      // 
      this.pnlProps.Location = new System.Drawing.Point(365, 13);
      this.pnlProps.Name = "pnlProps";
      this.pnlProps.Size = new System.Drawing.Size(234, 186);
      this.pnlProps.TabIndex = 12;
      this.pnlProps.TabStop = false;
      this.pnlProps.Text = "Property Values";
      // 
      // txtLocation
      // 
      this.txtLocation.Location = new System.Drawing.Point(11, 25);
      this.txtLocation.MaxLength = 512;
      this.txtLocation.Name = "txtLocation";
      this.txtLocation.ReadOnly = true;
      this.txtLocation.Size = new System.Drawing.Size(319, 20);
      this.txtLocation.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(48, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Location";
      // 
      // btnChangeLoc
      // 
      this.btnChangeLoc.Location = new System.Drawing.Point(336, 25);
      this.btnChangeLoc.Name = "btnChangeLoc";
      this.btnChangeLoc.Size = new System.Drawing.Size(21, 20);
      this.btnChangeLoc.TabIndex = 2;
      this.toolTip1.SetToolTip(this.btnChangeLoc, "Change Location");
      this.btnChangeLoc.UseVisualStyleBackColor = true;
      this.btnChangeLoc.Click += new System.EventHandler(this.btnChangeLoc_Click);
      // 
      // btnCatAdd
      // 
      this.btnCatAdd.Location = new System.Drawing.Point(336, 72);
      this.btnCatAdd.Name = "btnCatAdd";
      this.btnCatAdd.Size = new System.Drawing.Size(21, 20);
      this.btnCatAdd.TabIndex = 5;
      this.toolTip1.SetToolTip(this.btnCatAdd, "Add New Category");
      this.btnCatAdd.UseVisualStyleBackColor = true;
      this.btnCatAdd.Click += new System.EventHandler(this.btnCatAdd_Click);
      // 
      // txtQuantity
      // 
      this.txtQuantity.Location = new System.Drawing.Point(11, 170);
      this.txtQuantity.MaxLength = 512;
      this.txtQuantity.Name = "txtQuantity";
      this.txtQuantity.Size = new System.Drawing.Size(118, 20);
      this.txtQuantity.TabIndex = 9;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 154);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(46, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "Quantity";
      // 
      // txtPrice
      // 
      this.txtPrice.Location = new System.Drawing.Point(146, 170);
      this.txtPrice.MaxLength = 512;
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new System.Drawing.Size(128, 20);
      this.txtPrice.TabIndex = 11;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(147, 154);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(78, 13);
      this.label5.TabIndex = 10;
      this.label5.Text = "Price Per Each";
      // 
      // InventoryAddDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(611, 249);
      this.Controls.Add(this.txtPrice);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtQuantity);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.btnCatAdd);
      this.Controls.Add(this.btnChangeLoc);
      this.Controls.Add(this.txtLocation);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.pnlProps);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cboCat);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InventoryAddDlg";
      this.Text = "Add Inventory";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cboCat;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.GroupBox pnlProps;
    private System.Windows.Forms.TextBox txtLocation;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnChangeLoc;
    private System.Windows.Forms.Button btnCatAdd;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.TextBox txtQuantity;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtPrice;
    private System.Windows.Forms.Label label5;
  }
}