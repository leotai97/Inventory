namespace Inventory
{
  partial class PurchaseHistoryDlg
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
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
      this.cboSource = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtURL = new System.Windows.Forms.TextBox();
      this.txtDate = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnDate = new System.Windows.Forms.Button();
      this.txtCount = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtPrice = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.txtID = new System.Windows.Forms.TextBox();
      this.ID = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Source";
      // 
      // cboSource
      // 
      this.cboSource.FormattingEnabled = true;
      this.cboSource.Location = new System.Drawing.Point(12, 25);
      this.cboSource.Name = "cboSource";
      this.cboSource.Size = new System.Drawing.Size(562, 21);
      this.cboSource.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 59);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(29, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "URL";
      // 
      // txtURL
      // 
      this.txtURL.Location = new System.Drawing.Point(15, 75);
      this.txtURL.Name = "txtURL";
      this.txtURL.Size = new System.Drawing.Size(559, 20);
      this.txtURL.TabIndex = 3;
      // 
      // txtDate
      // 
      this.txtDate.Location = new System.Drawing.Point(15, 123);
      this.txtDate.Name = "txtDate";
      this.txtDate.Size = new System.Drawing.Size(197, 20);
      this.txtDate.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 107);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(30, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Date";
      // 
      // btnDate
      // 
      this.btnDate.Location = new System.Drawing.Point(218, 121);
      this.btnDate.Name = "btnDate";
      this.btnDate.Size = new System.Drawing.Size(21, 23);
      this.btnDate.TabIndex = 6;
      this.toolTip1.SetToolTip(this.btnDate, "Get date from calendar");
      this.btnDate.UseVisualStyleBackColor = true;
      this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
      // 
      // txtCount
      // 
      this.txtCount.Location = new System.Drawing.Point(258, 123);
      this.txtCount.Name = "txtCount";
      this.txtCount.Size = new System.Drawing.Size(91, 20);
      this.txtCount.TabIndex = 8;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(255, 107);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(35, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Count";
      // 
      // txtPrice
      // 
      this.txtPrice.Location = new System.Drawing.Point(372, 123);
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new System.Drawing.Size(107, 20);
      this.txtPrice.TabIndex = 10;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(369, 107);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(50, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Price Per";
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(209, 177);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 11;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(304, 177);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 12;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // txtID
      // 
      this.txtID.Location = new System.Drawing.Point(15, 172);
      this.txtID.Name = "txtID";
      this.txtID.ReadOnly = true;
      this.txtID.Size = new System.Drawing.Size(91, 20);
      this.txtID.TabIndex = 14;
      // 
      // ID
      // 
      this.ID.AutoSize = true;
      this.ID.Location = new System.Drawing.Point(12, 156);
      this.ID.Name = "ID";
      this.ID.Size = new System.Drawing.Size(18, 13);
      this.ID.TabIndex = 13;
      this.ID.Text = "ID";
      // 
      // PurchaseHistoryDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(586, 220);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.ID);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.txtPrice);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtCount);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.btnDate);
      this.Controls.Add(this.txtDate);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtURL);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cboSource);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PurchaseHistoryDlg";
      this.Padding = new System.Windows.Forms.Padding(9);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Purchase History";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cboSource;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtURL;
    private System.Windows.Forms.TextBox txtDate;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnDate;
    private System.Windows.Forms.TextBox txtCount;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtPrice;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.Label ID;
  }
}
