namespace Inventory
{
  partial class CategoryDlg
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
      this.txtName = new System.Windows.Forms.TextBox();
      this.btnOK = new System.Windows.Forms.Button();
      this.txtDesc = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.listProps = new System.Windows.Forms.ListView();
      this.c1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.c2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.c3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btnPropEdit = new System.Windows.Forms.Button();
      this.btnPropDel = new System.Windows.Forms.Button();
      this.btnPropAdd = new System.Windows.Forms.Button();
      this.txtNotes = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnSave = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.txtDir = new System.Windows.Forms.TextBox();
      this.txtID = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(80, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Category Name";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(15, 25);
      this.txtName.MaxLength = 256;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(496, 20);
      this.txtName.TabIndex = 1;
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(274, 554);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 15;
      this.btnOK.Text = "Close";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // txtDesc
      // 
      this.txtDesc.Location = new System.Drawing.Point(15, 74);
      this.txtDesc.MaxLength = 1024;
      this.txtDesc.Multiline = true;
      this.txtDesc.Name = "txtDesc";
      this.txtDesc.Size = new System.Drawing.Size(591, 78);
      this.txtDesc.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 58);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(60, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Description";
      // 
      // listProps
      // 
      this.listProps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c1,
            this.c2,
            this.c3});
      this.listProps.FullRowSelect = true;
      this.listProps.GridLines = true;
      this.listProps.HideSelection = false;
      this.listProps.Location = new System.Drawing.Point(15, 394);
      this.listProps.MultiSelect = false;
      this.listProps.Name = "listProps";
      this.listProps.Size = new System.Drawing.Size(518, 146);
      this.listProps.TabIndex = 11;
      this.listProps.UseCompatibleStateImageBehavior = false;
      this.listProps.View = System.Windows.Forms.View.Details;
      // 
      // c1
      // 
      this.c1.Text = "Property Name";
      this.c1.Width = 333;
      // 
      // c2
      // 
      this.c2.Text = "Is Primary";
      this.c2.Width = 78;
      // 
      // c3
      // 
      this.c3.Text = "ID";
      this.c3.Width = 77;
      // 
      // btnPropEdit
      // 
      this.btnPropEdit.Location = new System.Drawing.Point(549, 423);
      this.btnPropEdit.Name = "btnPropEdit";
      this.btnPropEdit.Size = new System.Drawing.Size(57, 23);
      this.btnPropEdit.TabIndex = 13;
      this.btnPropEdit.Text = "Edit";
      this.toolTip1.SetToolTip(this.btnPropEdit, "Edit selected property");
      this.btnPropEdit.UseVisualStyleBackColor = true;
      this.btnPropEdit.Click += new System.EventHandler(this.btnPropEdit_Click);
      // 
      // btnPropDel
      // 
      this.btnPropDel.Location = new System.Drawing.Point(549, 452);
      this.btnPropDel.Name = "btnPropDel";
      this.btnPropDel.Size = new System.Drawing.Size(57, 23);
      this.btnPropDel.TabIndex = 14;
      this.btnPropDel.Text = "Delete";
      this.toolTip1.SetToolTip(this.btnPropDel, "Delete selected property");
      this.btnPropDel.UseVisualStyleBackColor = true;
      this.btnPropDel.Click += new System.EventHandler(this.btnPropDel_Click);
      // 
      // btnPropAdd
      // 
      this.btnPropAdd.Location = new System.Drawing.Point(549, 394);
      this.btnPropAdd.Name = "btnPropAdd";
      this.btnPropAdd.Size = new System.Drawing.Size(57, 23);
      this.btnPropAdd.TabIndex = 12;
      this.btnPropAdd.Text = "Add";
      this.toolTip1.SetToolTip(this.btnPropAdd, "Add a new category property");
      this.btnPropAdd.UseVisualStyleBackColor = true;
      this.btnPropAdd.Click += new System.EventHandler(this.btnPropAdd_Click);
      // 
      // txtNotes
      // 
      this.txtNotes.Location = new System.Drawing.Point(12, 180);
      this.txtNotes.MaxLength = 32000;
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.Size = new System.Drawing.Size(591, 137);
      this.txtNotes.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 164);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(35, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Notes";
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(530, 23);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(76, 23);
      this.btnSave.TabIndex = 6;
      this.btnSave.Text = "Save Text";
      this.toolTip1.SetToolTip(this.btnSave, "Save changes to name, description, and notes");
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 340);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(149, 13);
      this.label5.TabIndex = 7;
      this.label5.Text = "Category Files Directory Name";
      // 
      // txtDir
      // 
      this.txtDir.Location = new System.Drawing.Point(15, 356);
      this.txtDir.Name = "txtDir";
      this.txtDir.ReadOnly = true;
      this.txtDir.Size = new System.Drawing.Size(146, 20);
      this.txtDir.TabIndex = 8;
      // 
      // txtID
      // 
      this.txtID.Location = new System.Drawing.Point(177, 356);
      this.txtID.Name = "txtID";
      this.txtID.ReadOnly = true;
      this.txtID.Size = new System.Drawing.Size(102, 20);
      this.txtID.TabIndex = 10;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(174, 340);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(18, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "ID";
      // 
      // CategoryDlg
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(619, 589);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtDir);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.txtNotes);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnPropAdd);
      this.Controls.Add(this.btnPropDel);
      this.Controls.Add(this.btnPropEdit);
      this.Controls.Add(this.listProps);
      this.Controls.Add(this.txtDesc);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CategoryDlg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Category";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.TextBox txtDesc;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListView listProps;
    private System.Windows.Forms.ColumnHeader c1;
    private System.Windows.Forms.ColumnHeader c2;
    private System.Windows.Forms.Button btnPropEdit;
    private System.Windows.Forms.Button btnPropDel;
    private System.Windows.Forms.Button btnPropAdd;
    private System.Windows.Forms.TextBox txtNotes;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.ColumnHeader c3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtDir;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.Label label4;
  }
}