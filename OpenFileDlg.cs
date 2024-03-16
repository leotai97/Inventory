using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
public partial class OpenFileDlg : Form
{
 public enum FileTypes { Picture, InventoryFile };

 public string FileName { get; private set; }
 public FileTypes FileType { get; private set; }

 private LVFileSorter.SortColumn FileSort;
 private bool SortAscending;


public OpenFileDlg(Form par, FileTypes type)
{
 FileType = type;
 Owner = par;

 InitializeComponent();

 switch(FileType)
  {
   case FileTypes.Picture: Text = "Select Picture Location File"; break;
   case FileTypes.InventoryFile: Text = "Select Inventory Item File"; break;
   default: throw new Exception("unhandled case");
  }

 RefreshList();
}

private void RefreshList()
{
 DirectoryInfo dir = null;
 string files;

 switch(FileType)
  {
   case FileTypes.Picture:
    {
     dir = new DirectoryInfo(Globals.ImageDirectory); 
     files = "*.jpg";
    } break;
   case FileTypes.InventoryFile:
    {
     dir = new DirectoryInfo(Globals.DownloadDirectory);
     files = "*.*";
    } break;
   default: throw new Exception("unhandled case");
  }
 
 listFiles.Items.Clear();

 foreach(FileInfo f in dir.GetFiles(files))
  {
   listFiles.Items.Add(new LVFile(f.Name, f.LastWriteTime, f.Length));
  } 
 listFiles.ListViewItemSorter = new LVFileSorter(LVFileSorter.SortColumn.Name, true);

 FileSort = LVFileSorter.SortColumn.Name;
 SortAscending = true;

 c1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 c2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 c3.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
}

private void listFiles_ColumnClick(object sender, ColumnClickEventArgs e)
{
 LVFileSorter.SortColumn sort;

 switch(e.Column)
  {
   case 0: sort = LVFileSorter.SortColumn.Name; break;
   case 1: sort = LVFileSorter.SortColumn.Modified; break;
   case 2: sort = LVFileSorter.SortColumn.Size; break;
   default: throw new Exception("unhandled column click");
  }

 if (sort == FileSort)
  {
   SortAscending = !SortAscending;
  }
 else
  {
   FileSort = sort;
   SortAscending = true;
  }
 listFiles.ListViewItemSorter = new LVFileSorter(FileSort, SortAscending);
 listFiles.Sort();
}

private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
{
 if (listFiles.SelectedItems.Count == 0)
   return;

 txtFile.Text = ((LVFile)listFiles.SelectedItems[0]).File;
}

private void btnOK_Click(object sender, EventArgs e)
{

 if (listFiles.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a file");
   return;
  }

 FileName = ((LVFile)listFiles.SelectedItems[0]).File;

 DialogResult = DialogResult.OK;
 Close();
}

private void btnCancel_Click(object sender, EventArgs e)
{
 DialogResult = DialogResult.Cancel;
 Close();
}

private void btnRefresh_Click(object sender, EventArgs e)
{
 RefreshList();
}

public static string GetNewestDownloadFile()
{
 DirectoryInfo dir;
 DateTime newest;
 string newFile = "";

 dir = new DirectoryInfo(Globals.DownloadDirectory);

 newest = DateTime.MinValue;

 foreach(FileInfo f in dir.GetFiles("*.*"))
  {
   if (f.CreationTime > newest)
    {
     newFile = f.Name;
     newest = f.CreationTime;
    }
  } 

 return Globals.DownloadDirectory + "\\" + newFile;
}

private void btnView_Click(object sender, EventArgs e)
{
 string path;
 string file;

 if (listFiles.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a file");
   return;
  }

 file = ((LVFile)listFiles.SelectedItems[0]).File;

 path = Globals.ImageDirectory + "\\" + file;

 System.Diagnostics.Process.Start(path);

}

};

public class LVFile : ListViewItem
{
 public string File { get; private set; }
 public DateTime Modified { get; private set; }
 public long FileSize { get; private set; }

public LVFile(string name, DateTime mod, long size)
{
 File = name;
 Modified = mod;
 FileSize = size;

 Text = File;
 SubItems.Add(Modified.ToString("MMM dd yyyy h:mm:ss tt"));
 SubItems.Add((FileSize / 1024).ToString() + " KB");
}

};

public class LVFileSorter : IComparer
{
 public enum SortColumn : int { Name, Modified, Size }
 
 public SortColumn Column { get; private set; }
 public bool Ascending { get; private set; }

public LVFileSorter(SortColumn col, bool asc)
{
 Column = col;
 Ascending = asc;
}

public int Compare(Object x, Object y)
{
 LVFile lvx, lvy;
 
 if (Ascending == true)
  {
   lvx = (LVFile)x;
   lvy = (LVFile)y;
  }
 else
  {
   lvx = (LVFile)y;
   lvy = (LVFile)x;   
  }

 switch(Column)
  {
   case SortColumn.Name: return string.Compare(lvx.Text, lvy.Text);
   case SortColumn.Modified:
    {
     if (lvx.Modified > lvy.Modified) return 1;
     if (lvx.Modified < lvy.Modified) return -1;
     return 0;
    } 
   case SortColumn.Size:
    {
     if (lvx.FileSize > lvy.FileSize) return 1;
     if (lvx.FileSize < lvy.FileSize) return -1;
     return 0;
    } 
   default: throw new Exception("sort case not handled");
  }
}

};


}
