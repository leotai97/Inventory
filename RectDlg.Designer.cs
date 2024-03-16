namespace Inventory
{
  partial class RectDlg
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
      this.picColor = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtWidth = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnSetColor = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
      this.SuspendLayout();
      // 
      // picColor
      // 
      this.picColor.Location = new System.Drawing.Point(12, 22);
      this.picColor.Name = "picColor";
      this.picColor.Size = new System.Drawing.Size(100, 50);
      this.picColor.TabIndex = 0;
      this.picColor.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(31, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Color";
      // 
      // txtWidth
      // 
      this.txtWidth.Location = new System.Drawing.Point(130, 22);
      this.txtWidth.Name = "txtWidth";
      this.txtWidth.Size = new System.Drawing.Size(55, 20);
      this.txtWidth.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(127, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(58, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Line Width";
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(222, 9);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(222, 38);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnSetColor
      // 
      this.btnSetColor.Location = new System.Drawing.Point(24, 78);
      this.btnSetColor.Name = "btnSetColor";
      this.btnSetColor.Size = new System.Drawing.Size(75, 23);
      this.btnSetColor.TabIndex = 1;
      this.btnSetColor.Text = "Set Color";
      this.btnSetColor.UseVisualStyleBackColor = true;
      this.btnSetColor.Click += new System.EventHandler(this.btnSetColor_Click);
      // 
      // RectDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(318, 113);
      this.Controls.Add(this.btnSetColor);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtWidth);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.picColor);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "RectDlg";
      this.Text = "Rectangle Color";
      ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox picColor;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtWidth;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnSetColor;
  }
}