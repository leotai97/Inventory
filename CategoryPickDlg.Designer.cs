namespace Inventory
{
  partial class CategoryPickDlg
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
      this.listCat = new System.Windows.Forms.ListView();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnCatEdit = new System.Windows.Forms.Button();
      this.btnCatRemove = new System.Windows.Forms.Button();
      this.btnCatAdd = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // listCat
      // 
      this.listCat.FullRowSelect = true;
      this.listCat.GridLines = true;
      this.listCat.HideSelection = false;
      this.listCat.Location = new System.Drawing.Point(12, 12);
      this.listCat.MultiSelect = false;
      this.listCat.Name = "listCat";
      this.listCat.Size = new System.Drawing.Size(639, 291);
      this.listCat.TabIndex = 0;
      this.listCat.UseCompatibleStateImageBehavior = false;
      this.listCat.View = System.Windows.Forms.View.Details;
      this.listCat.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listCat_ColumnClick);
      this.listCat.DoubleClick += new System.EventHandler(this.listCat_DoubleClick);
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(284, 321);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(380, 321);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnCatEdit
      // 
      this.btnCatEdit.Location = new System.Drawing.Point(666, 41);
      this.btnCatEdit.Name = "btnCatEdit";
      this.btnCatEdit.Size = new System.Drawing.Size(58, 23);
      this.btnCatEdit.TabIndex = 2;
      this.btnCatEdit.Text = "Edit";
      this.btnCatEdit.UseVisualStyleBackColor = true;
      this.btnCatEdit.Click += new System.EventHandler(this.btnCatEdit_Click);
      // 
      // btnCatRemove
      // 
      this.btnCatRemove.Location = new System.Drawing.Point(665, 70);
      this.btnCatRemove.Name = "btnCatRemove";
      this.btnCatRemove.Size = new System.Drawing.Size(59, 23);
      this.btnCatRemove.TabIndex = 3;
      this.btnCatRemove.Text = "Remove";
      this.btnCatRemove.UseVisualStyleBackColor = true;
      this.btnCatRemove.Click += new System.EventHandler(this.btnCatRemove_Click);
      // 
      // btnCatAdd
      // 
      this.btnCatAdd.Location = new System.Drawing.Point(666, 12);
      this.btnCatAdd.Name = "btnCatAdd";
      this.btnCatAdd.Size = new System.Drawing.Size(58, 23);
      this.btnCatAdd.TabIndex = 1;
      this.btnCatAdd.Text = "Add";
      this.btnCatAdd.UseVisualStyleBackColor = true;
      this.btnCatAdd.Click += new System.EventHandler(this.btnCatAdd_Click);
      // 
      // CategoryPickDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(739, 356);
      this.Controls.Add(this.btnCatEdit);
      this.Controls.Add(this.btnCatRemove);
      this.Controls.Add(this.btnCatAdd);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.listCat);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CategoryPickDlg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Categories";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listCat;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnCatEdit;
    private System.Windows.Forms.Button btnCatRemove;
    private System.Windows.Forms.Button btnCatAdd;
  }
}