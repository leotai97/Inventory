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
public partial class NameLocEditDlg : Form
{
 public string LocName { get; private set; }
 public string LocDesc { get; private set; }

public NameLocEditDlg(Form own)
{
 InitializeComponent();

 Owner = own;
 StartPosition = FormStartPosition.CenterParent;

}

public NameLocEditDlg(Form own, in NameLocation loc)
{
 InitializeComponent();

 Owner = own;
 StartPosition = FormStartPosition.CenterParent;

 txtName.Text = loc.Name;
 txtDesc.Text = loc.Desc;
 txtID.Text = loc.ID.ToString();
}

private void btnOK_Click(object sender, EventArgs e)
{
 string n, d;

 n = txtName.Text.Trim();
 d = txtDesc.Text.Trim();

 if (n.Length == 0)
  {
   MainWnd.Response("Name cannot be blank");
   return;
  }

 LocName = n;
 LocDesc = d;

 DialogResult = DialogResult.OK;
 Close();
}

private void btnCancel_Click(object sender, EventArgs e)
{
 DialogResult = DialogResult.Cancel;
 Close();
}

};
}
