namespace Inventory
{
  partial class OpenFileDlg
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
      this.listFiles = new System.Windows.Forms.ListView();
      this.c1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.c2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.c3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.txtFile = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.btnView = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // listFiles
      // 
      this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c1,
            this.c2,
            this.c3});
      this.listFiles.FullRowSelect = true;
      this.listFiles.GridLines = true;
      this.listFiles.HideSelection = false;
      this.listFiles.Location = new System.Drawing.Point(12, 12);
      this.listFiles.MultiSelect = false;
      this.listFiles.Name = "listFiles";
      this.listFiles.Size = new System.Drawing.Size(797, 304);
      this.listFiles.TabIndex = 0;
      this.listFiles.UseCompatibleStateImageBehavior = false;
      this.listFiles.View = System.Windows.Forms.View.Details;
      this.listFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listFiles_ColumnClick);
      this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listFiles_SelectedIndexChanged);
      // 
      // c1
      // 
      this.c1.Text = "File Name";
      // 
      // c2
      // 
      this.c2.Text = "Date Modified";
      // 
      // c3
      // 
      this.c3.Text = "Size";
      // 
      // txtFile
      // 
      this.txtFile.Location = new System.Drawing.Point(12, 344);
      this.txtFile.Name = "txtFile";
      this.txtFile.Size = new System.Drawing.Size(708, 20);
      this.txtFile.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 328);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(68, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Selected File";
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(734, 328);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(734, 357);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnRefresh
      // 
      this.btnRefresh.Location = new System.Drawing.Point(12, 377);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(75, 23);
      this.btnRefresh.TabIndex = 3;
      this.btnRefresh.Text = "Refresh";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // btnView
      // 
      this.btnView.Location = new System.Drawing.Point(93, 377);
      this.btnView.Name = "btnView";
      this.btnView.Size = new System.Drawing.Size(75, 23);
      this.btnView.TabIndex = 6;
      this.btnView.Text = "View";
      this.btnView.UseVisualStyleBackColor = true;
      this.btnView.Click += new System.EventHandler(this.btnView_Click);
      // 
      // OpenFileDlg
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(821, 412);
      this.Controls.Add(this.btnView);
      this.Controls.Add(this.btnRefresh);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtFile);
      this.Controls.Add(this.listFiles);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "OpenFileDlg";
      this.Text = "Select Picture Location File";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListView listFiles;
    private System.Windows.Forms.TextBox txtFile;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.ColumnHeader c1;
    private System.Windows.Forms.ColumnHeader c2;
    private System.Windows.Forms.ColumnHeader c3;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Button btnView;
  }
}