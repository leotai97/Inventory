using Org.BouncyCastle.Crypto.Generators;
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
public partial class RectDlg : Form
{
 public Color RectColor { get; private set; }
 public int LineWidth { get; private set; }

public RectDlg(Form par, Color rc, int wl)
{

 Owner = par;
 InitializeComponent();

 RectColor = rc;
 LineWidth = wl;

 picColor.BackColor = RectColor;
 txtWidth.Text = LineWidth.ToString();
}

private void btnSetColor_Click(object sender, EventArgs e)
{
 ColorDialog dlg;

 dlg = new ColorDialog();
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   RectColor = dlg.Color;
   picColor.BackColor = RectColor;
  }
 dlg.Dispose();
}

private void btnOK_Click(object sender, EventArgs e)
{
 string txt = txtWidth.Text.Trim();
 int w;

 if (int.TryParse(txt, out w) == false)
  {
   MainWnd.Response("Line width is not a number");
   return;
  }

 if (w < 1)
  {
   MainWnd.Response("Line width cannot be 0");
   return;
  }

 LineWidth = w;

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
