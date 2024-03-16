using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{

public partial class LoginDlg : Form
{
 public string GPW { get => GetGPW(); }

public LoginDlg()
{
 StartPosition = FormStartPosition.CenterScreen;
 Init();
}

public LoginDlg(Form par)
{
 Owner = par;
 StartPosition = FormStartPosition.CenterParent;
 Init();
}

private void Init()
{
 Encrypt enc=new Encrypt(GPW);
 String pwd, srv, name;
 int i;

 InitializeComponent();

 srv = MainWnd.GetRegSetting("RememberCredentialsServer", "");
 name = MainWnd.GetRegSetting("RememberCredentialsName", "pic_user");
 pwd = MainWnd.GetRegSetting("RememberCredentialsValue", "");

 txtSrv.Text = enc.Decrypt(Encrypt.Decode(srv));
 txtName.Text = enc.Decrypt(Encrypt.Decode(name));
 if (txtName.Text == "")
   txtName.Text = "inv_user";

 i = MainWnd.GetRegSettingInt("RememberCredentials");
 if (i > 0) 
  {
   chkRemember.Checked = true;
   txtPwd.Text = enc.Decrypt(Encrypt.Decode(pwd));
  }
 else
  {
   chkRemember.Checked = false;
   txtPwd.Text = "";
  }
 enc.Dispose();

 chkVisible.Click += new EventHandler(chkVisible_Click);
 btnReset.Click+=new EventHandler(btnReset_Click);
 btnCancel.Click+=new EventHandler(btnCancel_Click);
 btnOK.Click+=new EventHandler(btnOK_Click);
}


public String Connection()
{
 String cs;

 cs = "server=" + txtSrv.Text.Trim() + ";";
 cs += "user =" + txtName.Text.Trim() + ";";
 cs += "database=inventory_v1;port=3306;";
 cs += "password=" + txtPwd.Text.Trim() + ";";
 cs += "ConnectionTimeout=30;";

 return cs;
}

public void SaveSettings()
{
 Encrypt enc = new Encrypt(GPW);
 
 MainWnd.SaveRegSetting("RememberCredentialsServer", Encrypt.Encode(enc.Encryption(txtSrv.Text.Trim())));
 MainWnd.SaveRegSetting("RememberCredentialsName", Encrypt.Encode(enc.Encryption(txtName.Text.Trim())));
 if (chkRemember.Checked == true) 
  {
   MainWnd.SaveRegSetting("RememberCredentialsValue", Encrypt.Encode(enc.Encryption(txtPwd.Text.Trim())));
  }
 else
  {
   MainWnd.SaveRegSetting("RememberCredentialsValue", "");
  }
 enc.Dispose();
}
 
private void chkVisible_Click(Object sender, EventArgs e) 
{
 if (chkVisible.Checked == false)
   txtPwd.PasswordChar = '*';
 else
   txtPwd.PasswordChar = '\0';
}

private void btnReset_Click(Object sender, EventArgs e)
{
 if (MainWnd.Question("Reset database user name to the default value?", MessageBoxButtons.OKCancel) != DialogResult.OK) 
   return;
 txtName.Text = "pic_user";
}  

private void btnCancel_Click(Object sender, EventArgs e)
{
 DialogResult = DialogResult.Cancel;
 Close();
}  

private void btnOK_Click(Object sender, EventArgs e)
{
 if (txtName.Text.Trim().Length == 0) { MainWnd.Response("User name cannot be blank"); return; }
 if (txtPwd.Text.Trim().Length == 0){ MainWnd.Response("Password cannot be blank"); return; }

 if (chkRemember.Checked == true)
   MainWnd.SaveRegSettingInt("RememberCredentials", 1);
 else
   MainWnd.SaveRegSettingInt("RememberCredentials", 0);
  
 DialogResult = DialogResult.OK;
 Close();
}

public static void ResetCredentials()
{
 MainWnd.SaveRegSettingInt("RememberCredentials", 0);
 MainWnd.SaveRegSetting("RememberCredentialsServer", "");
 MainWnd.SaveRegSetting("RememberCredentialsName", "pic_user");
 MainWnd.SaveRegSetting("RememberCredentialsValue", "");
}

private string GetGPW()
{
 string s;

 s =  "asdfawe.afewadsfa";
 s += 10.ToString();
 s += "!@#$$";

 return s;
}

};
}
