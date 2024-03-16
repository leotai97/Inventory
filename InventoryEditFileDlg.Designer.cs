namespace Inventory
{
  partial class InventoryEditFileDlg
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
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.txtDesc = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtID = new System.Windows.Forms.TextBox();
      this.ID = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(389, 176);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 16;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(308, 176);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 15;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // txtDesc
      // 
      this.txtDesc.Location = new System.Drawing.Point(16, 74);
      this.txtDesc.MaxLength = 1024;
      this.txtDesc.Multiline = true;
      this.txtDesc.Name = "txtDesc";
      this.txtDesc.Size = new System.Drawing.Size(736, 89);
      this.txtDesc.TabIndex = 14;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 58);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(60, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Description";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(15, 25);
      this.txtName.MaxLength = 512;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(737, 20);
      this.txtName.TabIndex = 12;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Name";
      // 
      // txtID
      // 
      this.txtID.Location = new System.Drawing.Point(16, 182);
      this.txtID.Name = "txtID";
      this.txtID.ReadOnly = true;
      this.txtID.Size = new System.Drawing.Size(91, 20);
      this.txtID.TabIndex = 18;
      // 
      // ID
      // 
      this.ID.AutoSize = true;
      this.ID.Location = new System.Drawing.Point(13, 166);
      this.ID.Name = "ID";
      this.ID.Size = new System.Drawing.Size(18, 13);
      this.ID.TabIndex = 17;
      this.ID.Text = "ID";
      // 
      // InventoryEditFileDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(768, 211);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.ID);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.txtDesc);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InventoryEditFileDlg";
      this.Text = "Edit Inventory File ";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.TextBox txtDesc;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.Label ID;
  }
}