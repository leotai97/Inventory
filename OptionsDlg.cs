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
public partial class OptionsDlg : Form
{

public OptionsDlg()
{
 StartPosition = FormStartPosition.CenterScreen;
 Init();
}

public OptionsDlg(Form par)
{
 Owner = par;
 StartPosition = FormStartPosition.CenterParent;
 Init();
}

private void Init()
{
 Random rnd;
 string sr;
 int i;

 InitializeComponent();

 txtPicLoc.Text = Globals.ImageDirectory;
 txtInvFiles.Text = Globals.InventoryFileDirectory;
 txtDownload.Text = Globals.DownloadDirectory;
}

private void btnPicLoc_Click(object sender, EventArgs e)
{
 FolderBrowserDialog dlg;

 dlg = new FolderBrowserDialog();
 dlg.Description = "Choose Picture Location Directory";

 if (dlg.ShowDialog() == DialogResult.OK)
  {
   txtPicLoc.Text = dlg.SelectedPath;
   Globals.SetImageDirectory(dlg.SelectedPath);
  }
 dlg.Dispose();
}

private void btnFileLoc_Click(object sender, EventArgs e)
{
 FolderBrowserDialog dlg;

 dlg = new FolderBrowserDialog();
 dlg.Description = "Choose Inventory Associated Files Directory";
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   txtInvFiles.Text = dlg.SelectedPath;
   Globals.SetInventoryFileDirectory(dlg.SelectedPath);
  }
 dlg.Dispose();
}

private void btnClose_Click(object sender, EventArgs e)
{
 Close();
}

private void btnDownload_Click(object sender, EventArgs e)
{
 FolderBrowserDialog dlg;

 dlg = new FolderBrowserDialog();
 dlg.Description = "Choose Download Directory";
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   txtDownload.Text = dlg.SelectedPath;
   Globals.SetDownloadDirectory(dlg.SelectedPath);
  }
 dlg.Dispose();
}

};
}
