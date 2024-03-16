namespace Inventory
{
  partial class NameLocPickDlg
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
      this.listNamed = new System.Windows.Forms.ListView();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnNameEdit = new System.Windows.Forms.Button();
      this.btnNameRemove = new System.Windows.Forms.Button();
      this.btnNameAdd = new System.Windows.Forms.Button();
      this.btnMovePic = new System.Windows.Forms.Button();
      this.btnMoveName = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // listNamed
      // 
      this.listNamed.FullRowSelect = true;
      this.listNamed.GridLines = true;
      this.listNamed.HideSelection = false;
      this.listNamed.Location = new System.Drawing.Point(12, 12);
      this.listNamed.MultiSelect = false;
      this.listNamed.Name = "listNamed";
      this.listNamed.Size = new System.Drawing.Size(697, 390);
      this.listNamed.TabIndex = 0;
      this.listNamed.UseCompatibleStateImageBehavior = false;
      this.listNamed.View = System.Windows.Forms.View.Details;
      this.listNamed.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listNamed_ColumnClick);
      this.listNamed.DoubleClick += new System.EventHandler(this.listNamed_DoubleClick);
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(311, 415);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(401, 415);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnNameEdit
      // 
      this.btnNameEdit.Location = new System.Drawing.Point(716, 41);
      this.btnNameEdit.Name = "btnNameEdit";
      this.btnNameEdit.Size = new System.Drawing.Size(58, 23);
      this.btnNameEdit.TabIndex = 2;
      this.btnNameEdit.Text = "Edit";
      this.btnNameEdit.UseVisualStyleBackColor = true;
      this.btnNameEdit.Click += new System.EventHandler(this.btnNameEdit_Click);
      // 
      // btnNameRemove
      // 
      this.btnNameRemove.Location = new System.Drawing.Point(715, 70);
      this.btnNameRemove.Name = "btnNameRemove";
      this.btnNameRemove.Size = new System.Drawing.Size(59, 23);
      this.btnNameRemove.TabIndex = 3;
      this.btnNameRemove.Text = "Remove";
      this.btnNameRemove.UseVisualStyleBackColor = true;
      this.btnNameRemove.Click += new System.EventHandler(this.btnNameRemove_Click);
      // 
      // btnNameAdd
      // 
      this.btnNameAdd.Location = new System.Drawing.Point(716, 12);
      this.btnNameAdd.Name = "btnNameAdd";
      this.btnNameAdd.Size = new System.Drawing.Size(58, 23);
      this.btnNameAdd.TabIndex = 1;
      this.btnNameAdd.Text = "Add";
      this.btnNameAdd.UseVisualStyleBackColor = true;
      this.btnNameAdd.Click += new System.EventHandler(this.btnNameAdd_Click);
      // 
      // btnMovePic
      // 
      this.btnMovePic.Location = new System.Drawing.Point(578, 415);
      this.btnMovePic.Name = "btnMovePic";
      this.btnMovePic.Size = new System.Drawing.Size(95, 23);
      this.btnMovePic.TabIndex = 6;
      this.btnMovePic.Text = "Move To Picture";
      this.toolTip1.SetToolTip(this.btnMovePic, "Move inventory items from selected name to loaction to a picture location");
      this.btnMovePic.UseVisualStyleBackColor = true;
      this.btnMovePic.Click += new System.EventHandler(this.btnMovePic_Click);
      // 
      // btnMoveName
      // 
      this.btnMoveName.Location = new System.Drawing.Point(679, 415);
      this.btnMoveName.Name = "btnMoveName";
      this.btnMoveName.Size = new System.Drawing.Size(95, 23);
      this.btnMoveName.TabIndex = 7;
      this.btnMoveName.Text = "Move To Named";
      this.toolTip1.SetToolTip(this.btnMoveName, "Move inventory items from selected name to loaction to a named location");
      this.btnMoveName.UseVisualStyleBackColor = true;
      this.btnMoveName.Click += new System.EventHandler(this.btnMoveName_Click);
      // 
      // NameLocPickDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(786, 450);
      this.Controls.Add(this.btnMoveName);
      this.Controls.Add(this.btnMovePic);
      this.Controls.Add(this.btnNameEdit);
      this.Controls.Add(this.btnNameRemove);
      this.Controls.Add(this.btnNameAdd);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.listNamed);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "NameLocPickDlg";
      this.Text = "Choose Name Location";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listNamed;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnNameEdit;
    private System.Windows.Forms.Button btnNameRemove;
    private System.Windows.Forms.Button btnNameAdd;
    private System.Windows.Forms.Button btnMovePic;
    private System.Windows.Forms.Button btnMoveName;
    private System.Windows.Forms.ToolTip toolTip1;
    public System.Windows.Forms.Button btnCancel;
  }
}