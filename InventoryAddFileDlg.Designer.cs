namespace Inventory
{
  partial class InventoryAddFileDlg
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
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.label7 = new System.Windows.Forms.Label();
      this.cboType = new System.Windows.Forms.ComboBox();
      this.btnFileCancel = new System.Windows.Forms.Button();
      this.btnFileOK = new System.Windows.Forms.Button();
      this.txtFileDesc = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtFileName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnFile = new System.Windows.Forms.Button();
      this.txtFilePath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.btnURLCancel = new System.Windows.Forms.Button();
      this.btnURLOK = new System.Windows.Forms.Button();
      this.txtURLDesc = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtURLName = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtURL = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(768, 300);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.label7);
      this.tabPage1.Controls.Add(this.cboType);
      this.tabPage1.Controls.Add(this.btnFileCancel);
      this.tabPage1.Controls.Add(this.btnFileOK);
      this.tabPage1.Controls.Add(this.txtFileDesc);
      this.tabPage1.Controls.Add(this.label3);
      this.tabPage1.Controls.Add(this.txtFileName);
      this.tabPage1.Controls.Add(this.label2);
      this.tabPage1.Controls.Add(this.btnFile);
      this.tabPage1.Controls.Add(this.txtFilePath);
      this.tabPage1.Controls.Add(this.label1);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(760, 274);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Downloaded Files";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(617, 62);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(50, 13);
      this.label7.TabIndex = 5;
      this.label7.Text = "File Type";
      // 
      // cboType
      // 
      this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboType.FormattingEnabled = true;
      this.cboType.Items.AddRange(new object[] {
            "Image",
            "PDF",
            "Other"});
      this.cboType.Location = new System.Drawing.Point(620, 78);
      this.cboType.Name = "cboType";
      this.cboType.Size = new System.Drawing.Size(126, 21);
      this.cboType.TabIndex = 6;
      // 
      // btnFileCancel
      // 
      this.btnFileCancel.Location = new System.Drawing.Point(382, 229);
      this.btnFileCancel.Name = "btnFileCancel";
      this.btnFileCancel.Size = new System.Drawing.Size(75, 23);
      this.btnFileCancel.TabIndex = 10;
      this.btnFileCancel.Text = "Cancel";
      this.btnFileCancel.UseVisualStyleBackColor = true;
      this.btnFileCancel.Click += new System.EventHandler(this.btnFileCancel_Click);
      // 
      // btnFileOK
      // 
      this.btnFileOK.Location = new System.Drawing.Point(292, 229);
      this.btnFileOK.Name = "btnFileOK";
      this.btnFileOK.Size = new System.Drawing.Size(75, 23);
      this.btnFileOK.TabIndex = 9;
      this.btnFileOK.Text = "OK";
      this.btnFileOK.UseVisualStyleBackColor = true;
      this.btnFileOK.Click += new System.EventHandler(this.btnFileOK_Click);
      // 
      // txtFileDesc
      // 
      this.txtFileDesc.Location = new System.Drawing.Point(10, 127);
      this.txtFileDesc.MaxLength = 1024;
      this.txtFileDesc.Multiline = true;
      this.txtFileDesc.Name = "txtFileDesc";
      this.txtFileDesc.Size = new System.Drawing.Size(736, 89);
      this.txtFileDesc.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 111);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(60, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Description";
      // 
      // txtFileName
      // 
      this.txtFileName.Location = new System.Drawing.Point(9, 78);
      this.txtFileName.MaxLength = 512;
      this.txtFileName.Name = "txtFileName";
      this.txtFileName.Size = new System.Drawing.Size(592, 20);
      this.txtFileName.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 62);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Name";
      // 
      // btnFile
      // 
      this.btnFile.Location = new System.Drawing.Point(726, 27);
      this.btnFile.Name = "btnFile";
      this.btnFile.Size = new System.Drawing.Size(20, 23);
      this.btnFile.TabIndex = 2;
      this.toolTip1.SetToolTip(this.btnFile, "Browse for new downloaded file");
      this.btnFile.UseVisualStyleBackColor = true;
      this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
      // 
      // txtFilePath
      // 
      this.txtFilePath.Location = new System.Drawing.Point(9, 29);
      this.txtFilePath.Name = "txtFilePath";
      this.txtFilePath.Size = new System.Drawing.Size(711, 20);
      this.txtFilePath.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(29, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Path";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.btnURLCancel);
      this.tabPage2.Controls.Add(this.btnURLOK);
      this.tabPage2.Controls.Add(this.txtURLDesc);
      this.tabPage2.Controls.Add(this.label5);
      this.tabPage2.Controls.Add(this.txtURLName);
      this.tabPage2.Controls.Add(this.label6);
      this.tabPage2.Controls.Add(this.txtURL);
      this.tabPage2.Controls.Add(this.label4);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(760, 274);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "URL";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // btnURLCancel
      // 
      this.btnURLCancel.Location = new System.Drawing.Point(371, 228);
      this.btnURLCancel.Name = "btnURLCancel";
      this.btnURLCancel.Size = new System.Drawing.Size(75, 23);
      this.btnURLCancel.TabIndex = 7;
      this.btnURLCancel.Text = "Cancel";
      this.btnURLCancel.UseVisualStyleBackColor = true;
      this.btnURLCancel.Click += new System.EventHandler(this.btnURLCancel_Click);
      // 
      // btnURLOK
      // 
      this.btnURLOK.Location = new System.Drawing.Point(280, 228);
      this.btnURLOK.Name = "btnURLOK";
      this.btnURLOK.Size = new System.Drawing.Size(75, 23);
      this.btnURLOK.TabIndex = 6;
      this.btnURLOK.Text = "OK";
      this.btnURLOK.UseVisualStyleBackColor = true;
      this.btnURLOK.Click += new System.EventHandler(this.btnURLOK_Click);
      // 
      // txtURLDesc
      // 
      this.txtURLDesc.Location = new System.Drawing.Point(10, 126);
      this.txtURLDesc.MaxLength = 1024;
      this.txtURLDesc.Multiline = true;
      this.txtURLDesc.Name = "txtURLDesc";
      this.txtURLDesc.Size = new System.Drawing.Size(736, 89);
      this.txtURLDesc.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 110);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(60, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Description";
      // 
      // txtURLName
      // 
      this.txtURLName.Location = new System.Drawing.Point(9, 77);
      this.txtURLName.MaxLength = 512;
      this.txtURLName.Name = "txtURLName";
      this.txtURLName.Size = new System.Drawing.Size(737, 20);
      this.txtURLName.TabIndex = 3;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 61);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(35, 13);
      this.label6.TabIndex = 2;
      this.label6.Text = "Name";
      // 
      // txtURL
      // 
      this.txtURL.Location = new System.Drawing.Point(9, 29);
      this.txtURL.MaxLength = 1024;
      this.txtURL.Name = "txtURL";
      this.txtURL.Size = new System.Drawing.Size(732, 20);
      this.txtURL.TabIndex = 1;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 13);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(29, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "URL";
      // 
      // InventoryAddFileDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(788, 322);
      this.Controls.Add(this.tabControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InventoryAddFileDlg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Inventory Item Associated File";
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.Button btnFile;
    private System.Windows.Forms.TextBox txtFilePath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TextBox txtURL;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button btnFileCancel;
    private System.Windows.Forms.Button btnFileOK;
    private System.Windows.Forms.TextBox txtFileDesc;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtFileName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnURLCancel;
    private System.Windows.Forms.Button btnURLOK;
    private System.Windows.Forms.TextBox txtURLDesc;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtURLName;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox cboType;
  }
}