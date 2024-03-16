namespace Inventory
{
  partial class OptionsDlg
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
      this.txtPicLoc = new System.Windows.Forms.TextBox();
      this.btnPicLoc = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnFileLoc = new System.Windows.Forms.Button();
      this.txtInvFiles = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnClose = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.txtDownload = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.btnDownload = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(152, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Picture Location JPG Directory";
      // 
      // txtPicLoc
      // 
      this.txtPicLoc.Location = new System.Drawing.Point(15, 25);
      this.txtPicLoc.Name = "txtPicLoc";
      this.txtPicLoc.ReadOnly = true;
      this.txtPicLoc.Size = new System.Drawing.Size(518, 20);
      this.txtPicLoc.TabIndex = 1;
      // 
      // btnPicLoc
      // 
      this.btnPicLoc.Location = new System.Drawing.Point(539, 23);
      this.btnPicLoc.Name = "btnPicLoc";
      this.btnPicLoc.Size = new System.Drawing.Size(22, 23);
      this.btnPicLoc.TabIndex = 2;
      this.toolTip1.SetToolTip(this.btnPicLoc, "Choose Directory");
      this.btnPicLoc.UseVisualStyleBackColor = true;
      this.btnPicLoc.Click += new System.EventHandler(this.btnPicLoc_Click);
      // 
      // btnFileLoc
      // 
      this.btnFileLoc.Location = new System.Drawing.Point(539, 102);
      this.btnFileLoc.Name = "btnFileLoc";
      this.btnFileLoc.Size = new System.Drawing.Size(22, 23);
      this.btnFileLoc.TabIndex = 6;
      this.toolTip1.SetToolTip(this.btnFileLoc, "Choose Directory");
      this.btnFileLoc.UseVisualStyleBackColor = true;
      this.btnFileLoc.Click += new System.EventHandler(this.btnFileLoc_Click);
      // 
      // txtInvFiles
      // 
      this.txtInvFiles.Location = new System.Drawing.Point(15, 103);
      this.txtInvFiles.Name = "txtInvFiles";
      this.txtInvFiles.ReadOnly = true;
      this.txtInvFiles.Size = new System.Drawing.Size(518, 20);
      this.txtInvFiles.TabIndex = 5;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 87);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(196, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Inventory JPG, PDF, Misc File Directory ";
      // 
      // btnClose
      // 
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Location = new System.Drawing.Point(486, 256);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 13;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(12, 256);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(418, 33);
      this.label3.TabIndex = 12;
      this.label3.Text = "These directories are computer dependant so the program can work on several machi" +
    "nes in the network.";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(15, 48);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(546, 27);
      this.label4.TabIndex = 3;
      this.label4.Text = "Place location pictures in this directory and the program will allow you to choos" +
    "e them as is and it will not modiify the file names. Prepare these files beforeh" +
    "and.";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(15, 126);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(518, 45);
      this.label5.TabIndex = 7;
      this.label5.Text = "Pictures in this directory will be automatically named and managed as they are ad" +
    "ded to each inventory item. Be aware that when inventory items are deleted assoc" +
    "iated files will be deleted as well.";
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(15, 203);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(546, 27);
      this.label6.TabIndex = 11;
      this.label6.Text = "The program will browse this directory for images, PDFs, and other files download" +
    "ed from web pages that are to be associated with inventory items.";
      // 
      // txtDownload
      // 
      this.txtDownload.Location = new System.Drawing.Point(15, 180);
      this.txtDownload.Name = "txtDownload";
      this.txtDownload.ReadOnly = true;
      this.txtDownload.Size = new System.Drawing.Size(518, 20);
      this.txtDownload.TabIndex = 9;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(12, 164);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(100, 13);
      this.label7.TabIndex = 8;
      this.label7.Text = "Download Directory";
      // 
      // btnDownload
      // 
      this.btnDownload.Location = new System.Drawing.Point(539, 179);
      this.btnDownload.Name = "btnDownload";
      this.btnDownload.Size = new System.Drawing.Size(22, 23);
      this.btnDownload.TabIndex = 10;
      this.toolTip1.SetToolTip(this.btnDownload, "Choose Directory");
      this.btnDownload.UseVisualStyleBackColor = true;
      this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
      // 
      // OptionsDlg
      // 
      this.AcceptButton = this.btnClose;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnClose;
      this.ClientSize = new System.Drawing.Size(573, 296);
      this.Controls.Add(this.btnDownload);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txtDownload);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnFileLoc);
      this.Controls.Add(this.txtInvFiles);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnPicLoc);
      this.Controls.Add(this.txtPicLoc);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "OptionsDlg";
      this.Text = "Optons";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtPicLoc;
    private System.Windows.Forms.Button btnPicLoc;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button btnFileLoc;
    private System.Windows.Forms.TextBox txtInvFiles;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtDownload;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button btnDownload;
  }
}