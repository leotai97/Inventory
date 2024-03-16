using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
partial class PurchaseHistoryDlg : Form
{
 public string PurchaseSource { get; private set; }
 public string PurchaseLink { get; private set; }
 public DateTime PurchaseDate { get; private set; }
 public int PurchaseCount { get; private set; }
 public float PurchasePrice { get; private set; }
 

public PurchaseHistoryDlg(Form owner)
{
 InitializeComponent();

 Owner = owner;
 StartPosition = FormStartPosition.CenterParent;

 PurchaseDate = DateTime.Now;
 txtDate.Text = PurchaseDate.ToString(Globals.DateFormat);

 GetSources();
}

public PurchaseHistoryDlg(Form owner, in PurchaseHistory ph)
{

 InitializeComponent();

 Owner = owner;
 StartPosition = FormStartPosition.CenterParent;

 GetSources();

 cboSource.Text = ph.Source;
 txtURL.Text = ph.Link;
 txtDate.Text = ph.PurchaseDate.ToString(Globals.DateFormat);
 txtCount.Text = ph.Amount.ToString();
 txtPrice.Text = ph.Price.ToString("0.00");

 txtID.Text = ph.ID.ToString();

}

private void GetSources()
{
 List<string> sources = PurchaseHistory.GetUniqueSources();

 foreach(string s in sources)
  {
   cboSource.Items.Add(s);
  }
}

private void btnDate_Click(object sender, EventArgs e)
{
 DateTimeDlg dlg;
 DateTime dt;
 string s;

 s = txtDate.Text.Trim();

 if (DateTime.TryParse(s, out dt) == true)
   dlg = new DateTimeDlg(this, dt);
 else
   dlg = new DateTimeDlg(this);
 
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   txtDate.Text = dlg.CurrentDate.ToString(Globals.DateFormat);
  }
 dlg.Dispose();
}

private void btnOK_Click(object sender, EventArgs e)
{
 DateTime dt;
 string s;
 float v; 
 int c;

 s = txtDate.Text.Trim();
 PurchaseDate = DateTime.MinValue;
 if (s.Length != 0)
  {
   if (DateTime.TryParse(s, out dt) == true)
     PurchaseDate = dt;
  }

 PurchaseSource = cboSource.Text.Trim();
 PurchaseLink = txtURL.Text.Trim();

 s = txtPrice.Text.Trim();
 if (s.Length == 0)
  {
   MainWnd.Response("Price per unit cannot be blank");
   return;
  }
 if (float.TryParse(s, out v) == false)
  {
   MainWnd.Response("Price per unit is not numeric");
   return;
  }
 PurchasePrice = v;

 s = txtCount.Text.Trim();
 if (s.Length == 0)
  {
   MainWnd.Response("Counnt cannot be blank");
   return;
  }
 if (int.TryParse(s, out c) == false)
  {
   MainWnd.Response("Count is not numeric");
   return;
  }
 PurchaseCount = c;

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
