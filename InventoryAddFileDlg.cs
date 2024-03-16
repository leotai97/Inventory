using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Org.BouncyCastle.Asn1.Esf;

namespace Inventory
{
public partial class InventoryAddFileDlg : Form
{
 public InventoryFile.FileTypes FileType { get; private set; } 
 public string URLorPath { get; private set; }
 public string ItemName { get; private set; }
 public string ItemDesc { get; private set; } 
 public string ItemExt { get; private set; }

public InventoryAddFileDlg(Form owner)
{
 
 Owner = owner;
 
 InitializeComponent();

 cboType.Items.Clear();
 cboType.Items.Add("Image");
 cboType.Items.Add("PDF");
 cboType.Items.Add("Other");

 txtFilePath.Text = OpenFileDlg.GetNewestDownloadFile();
 SetCboIndex();
 
 txtURL.Text = Clipboard.GetText();
}

private void btnFile_Click(object sender, EventArgs e)
{
 OpenFileDialog dlg;

 dlg = new OpenFileDialog();

 dlg.Title = "Select Associated Inventory Item File";
 dlg.Filter = "JPG Image (*.jpg)|*.jpg|PDF File (*.pdf)|*.pdf|Other File (*.*)|*.*";
 dlg.Multiselect = false;
 dlg.CheckFileExists = true;
 dlg.InitialDirectory = Globals.DownloadDirectory;

 if (dlg.ShowDialog() == DialogResult.OK)
  {
   txtFilePath.Text = dlg.FileName;
   SetCboIndex();
  }
 dlg.Dispose();
}

private void btnFileOK_Click(object sender, EventArgs e)
{
 FileInfo info;
 string file, name, desc;

 file = txtFilePath.Text.Trim();
 name = txtFileName.Text.Trim();
 desc = txtFileDesc.Text.Trim();

 if (file.Length == 0)
  {
   MainWnd.Response("File path cannot be blank");
   return;
  }

 if (File.Exists(file) == false)
  {
   MainWnd.Response("File '" + file + "' does not exist or cannot be accessed");
   return;
  }

 info = new FileInfo(file);
 ItemExt = info.Extension;

 switch(cboType.SelectedIndex)
  {
   case 0: FileType = InventoryFile.FileTypes.Image; break;
   case 1: FileType = InventoryFile.FileTypes.PDF; break;
   case 2: FileType = InventoryFile.FileTypes.Other; break;
   default: throw new Exception("unhandled case");
  }

 URLorPath = file;
 ItemName = name;
 ItemDesc = desc;

 DialogResult = DialogResult.OK;
 Close();
}

private void btnFileCancel_Click(object sender, EventArgs e)
{
 DialogResult = DialogResult.Cancel;
 Close();
}

private void btnURLOK_Click(object sender, EventArgs e)
{
 string url, name, desc;
 

 url = txtURL.Text.Trim();
 name = txtURLName.Text.Trim();
 desc = txtURLDesc.Text.Trim();


 if (url.Length == 0)
  {
   MainWnd.Response("URL cannot be blank");
   return;
  }

 FileType = InventoryFile.FileTypes.URL;
 URLorPath = url;
 ItemName = name;
 ItemDesc = desc;
 ItemExt = "";

 DialogResult = DialogResult.OK;
 Close();
}

private void btnURLCancel_Click(object sender, EventArgs e)
{
 DialogResult = DialogResult.Cancel;
 Close();
}

private InventoryFile.FileTypes GetFileTypeByExt(string extz)
{
 string ext = extz.ToLower();

 switch(ext)
  {
   case ".jpeg": return InventoryFile.FileTypes.Image;
   case ".jpg": return InventoryFile.FileTypes.Image;
   case ".bmp": return InventoryFile.FileTypes.Image;
   case ".webp": return InventoryFile.FileTypes.Image;
   case ".png": return InventoryFile.FileTypes.Image;
   case ".svg": return InventoryFile.FileTypes.Image;
   case ".tiff": return InventoryFile.FileTypes.Image;
   case ".pdf": return InventoryFile.FileTypes.PDF;
   default: return InventoryFile.FileTypes.Other;
  }
}

private void SetCboIndex()
{
 FileInfo file;
 string sFile;
 string ext;

 sFile = txtFilePath.Text.Trim();

 if (File.Exists(sFile) == true)
  {
   file = new FileInfo(sFile);
   ext = file.Extension;
   switch(GetFileTypeByExt(ext))
    {
     case InventoryFile.FileTypes.Image: cboType.SelectedIndex = 0; break;
     case InventoryFile.FileTypes.PDF: cboType.SelectedIndex = 1; break;
     case InventoryFile.FileTypes.Other: cboType.SelectedIndex = 2; break;
     default: throw new Exception("unhandled case");
    }
  }
 else
  {
   cboType.SelectedIndex = 2;
  }
}


};
}
