
namespace Inventory
{
  partial class LoginDlg
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
      this.txtSrv = new System.Windows.Forms.TextBox();
      this.Label3 = new System.Windows.Forms.Label();
      this.btnReset = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.chkRemember = new System.Windows.Forms.CheckBox();
      this.chkVisible = new System.Windows.Forms.CheckBox();
      this.txtPwd = new System.Windows.Forms.TextBox();
      this.Label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.Label1 = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // txtSrv
      // 
      this.txtSrv.Location = new System.Drawing.Point(12, 25);
      this.txtSrv.Name = "txtSrv";
      this.txtSrv.Size = new System.Drawing.Size(261, 20);
      this.txtSrv.TabIndex = 1;
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(12, 9);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(69, 13);
      this.Label3.TabIndex = 0;
      this.Label3.Text = "Server Name";
      // 
      // btnReset
      // 
      this.btnReset.Location = new System.Drawing.Point(258, 66);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new System.Drawing.Size(20, 21);
      this.btnReset.TabIndex = 4;
      this.toolTip1.SetToolTip(this.btnReset, "Reset Login Information");
      this.btnReset.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(290, 52);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 8;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(290, 23);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 7;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      // 
      // chkRemember
      // 
      this.chkRemember.AutoSize = true;
      this.chkRemember.Location = new System.Drawing.Point(147, 144);
      this.chkRemember.Name = "chkRemember";
      this.chkRemember.Size = new System.Drawing.Size(126, 17);
      this.chkRemember.TabIndex = 10;
      this.chkRemember.Text = "Remember Password";
      this.chkRemember.UseVisualStyleBackColor = true;
      // 
      // chkVisible
      // 
      this.chkVisible.AutoSize = true;
      this.chkVisible.Location = new System.Drawing.Point(15, 144);
      this.chkVisible.Name = "chkVisible";
      this.chkVisible.Size = new System.Drawing.Size(102, 17);
      this.chkVisible.TabIndex = 9;
      this.chkVisible.Text = "Show Password";
      this.chkVisible.UseVisualStyleBackColor = true;
      // 
      // txtPwd
      // 
      this.txtPwd.Location = new System.Drawing.Point(12, 110);
      this.txtPwd.Name = "txtPwd";
      this.txtPwd.PasswordChar = '*';
      this.txtPwd.Size = new System.Drawing.Size(261, 20);
      this.txtPwd.TabIndex = 6;
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(12, 94);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(53, 13);
      this.Label2.TabIndex = 5;
      this.Label2.Text = "Password";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(12, 67);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(240, 20);
      this.txtName.TabIndex = 3;
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(12, 51);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(60, 13);
      this.Label1.TabIndex = 2;
      this.Label1.Text = "User Name";
      // 
      // LoginDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(376, 175);
      this.Controls.Add(this.txtSrv);
      this.Controls.Add(this.Label3);
      this.Controls.Add(this.btnReset);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.chkRemember);
      this.Controls.Add(this.chkVisible);
      this.Controls.Add(this.txtPwd);
      this.Controls.Add(this.Label2);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.Label1);
      this.Name = "LoginDlg";
      this.Text = "Inventory ";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.TextBox txtSrv;
    internal System.Windows.Forms.Label Label3;
    internal System.Windows.Forms.Button btnReset;
    internal System.Windows.Forms.Button btnCancel;
    internal System.Windows.Forms.Button btnOK;
    internal System.Windows.Forms.CheckBox chkRemember;
    internal System.Windows.Forms.CheckBox chkVisible;
    internal System.Windows.Forms.TextBox txtPwd;
    internal System.Windows.Forms.Label Label2;
    internal System.Windows.Forms.TextBox txtName;
    internal System.Windows.Forms.Label Label1;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}