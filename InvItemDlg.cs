using System;
using System.Collections;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Inventory
{

public partial class InvItemDlg : Form
{
 public InventoryItem Item { get; private set; }
 public InventoryLocation InvLoc { get; private set; }
 public InventoryCategory InvCat { get; private set; }

 private InventoryCategoryValue CurrentValue = null;

 private LVFileItemSorter.SortColumn FileListSort = LVFileItemSorter.SortColumn.Type;
 private bool FileListSortAscending = true;

 private LVHistItemSorter.SortColumn HistoryListSort = LVHistItemSorter.SortColumn.Date;
 private bool HistoryListSortAscending = true;

public InvItemDlg(Form par, in InventoryItem item)
{
 bool found;

 Owner = par;

 InitializeComponent();

 Item = item;
 InvCat = Item.InvCat;
 InvLoc = item.InvLoc;

 txtCat.Text = Item.InvCat.Name;
 txtLoc.Text = Item.InvLoc.ToString();
 txtID.Text = Item.ID.ToString();
 
 foreach(InventoryCategoryProperty p in Item.InvCat.Properties)
  {
   found = false;
   foreach(InventoryCategoryValue v in item.CategoryValues)
    {
     if (v.CatProp.ID == p.ID)  // have to check if a item property value doens't exisdt
      {
       listVals.Items.Add(new LVPropValue(v));
       found = true;
       break;
      }
    }
   if (found == false)
    {
     listVals.Items.Add(new LVPropValue(Item, p)); // a new category property was added insert the new property value
    }
  }

 listVals.ListViewItemSorter = new LVPropValueSorter();
 listVals.Sort();
 LVPropValue.ResizeColumns(listVals);

 txtName.Text = Item.InvName;
 txtDesc.Text = Item.Desc;
 txtNotes.Text = Item.Notes;
 
 LVFileItem.AddHeaders(listFiles);

 foreach(InventoryFile f in Item.Files)
  {
   listFiles.Items.Add(new LVFileItem(f));
  }
 LVFileItem.ResizeColumns(listFiles);
 listFiles.ListViewItemSorter = new LVFileItemSorter(FileListSort, FileListSortAscending);
 listFiles.Sort();

 LVHistItem.AddHeaders(listHistory);

 foreach(PurchaseHistory h in Item.History)
  {
   listHistory.Items.Add(new LVHistItem(h));
  }
 LVHistItem.ResizeColumns(listHistory);
 listHistory.ListViewItemSorter = new LVHistItemSorter(HistoryListSort, HistoryListSortAscending);
 listHistory.Sort();

 txtCost.Text = Item.EstimatedCost.ToString("0.00");
 txtCount.Text = Item.InventoryCount.ToString();

 txtCreated.Text = Item.Created.ToString(Globals.DateFormat);
 txtChanged.Text = Item.Changed.ToString(Globals.DateFormat);
 txtInvAdded.Text = MainWnd.GetDateString(Item.InvAdded);
 txtInvRemoved.Text = MainWnd.GetDateString(Item.InvRemoved);

 Icons.TransparentColor = Color.Magenta;
 Icons.Images.Add("View", Properties.Resources.View);
 btnViewLoc.Image = Icons.Images["View"];
}

private void btnViewLoc_Click(object sender, EventArgs e)
{
 PictureWalkWnd dlg;

 if (InvLoc == null)
  {
   MainWnd.Response("Item's location is not set");
   return;
  }

 if (InvLoc.InvLocType != InventoryLocation.LocationType.Picture)
  {
   MainWnd.Response("Item's location is not picture based");
   return;
  }

 dlg = new PictureWalkWnd(InvLoc.PicLoc);
 dlg.ShowDialog();
 dlg.Dispose();

}

private void btnLocSet_Click(object sender, EventArgs e)
{
 PictureLocPickDlg pDlg;
 
 if (Item.InvLoc.InvLocType == InventoryLocation.LocationType.Picture)
  {
   pDlg = new PictureLocPickDlg();
   if (pDlg.ShowDialog() == DialogResult.OK)
    {
     Item.UpdateLocation(pDlg.SubPicLoc);
     txtLoc.Text = Item.InvLoc.ToString();
    }
   pDlg.Dispose();
  }
 else
  {
  }
}

private void listFiles_ColumnClick(object sender, ColumnClickEventArgs e)
{
 LVFileItemSorter.SortColumn sort;

 sort = LVFileItem.GetColumn(e.Column);

 if (FileListSort == sort)
  {
   FileListSortAscending = !FileListSortAscending;
  }
 else
  {
   FileListSort = sort;
   FileListSortAscending = true;
  }
 listFiles.ListViewItemSorter = new LVFileItemSorter(FileListSort, FileListSortAscending);
 listFiles.Sort();
}

private void listFiles_DoubleClick(object sender, EventArgs e)
{
 btnFileOpen_Click(sender,e);
}

private void listHistory_ColumnClick(object sender, ColumnClickEventArgs e)
{
 LVHistItemSorter.SortColumn sort;

 sort = LVHistItem.GetColumn(e.Column);
 
 if (HistoryListSort == sort)
  {
   HistoryListSortAscending = !HistoryListSortAscending;
  }
 else
  {
   HistoryListSort = sort;
   HistoryListSortAscending = true;
  }

 listHistory.ListViewItemSorter = new LVHistItemSorter(HistoryListSort, HistoryListSortAscending);
 listHistory.Sort();
}

private void listHistory_DoubleClick(object sender, EventArgs e)
{
 btnHistEdit_Click(sender,e);
}

private void listVals_SelectedIndexChanged(object sender, EventArgs e)
{

 if (listVals.SelectedItems.Count == 0)
   return;
 
 CurrentValue = ((LVPropValue)listVals.SelectedItems[0]).Value;
 lblProp.Text = CurrentValue.CatProp.PropertyName;
 txtProp.Text = CurrentValue.Value.ToString();
 
}

private void btnProp_Click(object sender, EventArgs e)
{
 SavePropValue();
}

private void txtProp_KeyDown(object sender, KeyEventArgs e)
{
 if (e.KeyCode == Keys.Enter)
  {
   SavePropValue();
   e.SuppressKeyPress = true;
  }
}

private void SavePropValue()
{
 float val;
 string s;

 if (CurrentValue == null)
  {
   MainWnd.Response("Click on a property value, change the value, then try again");
   return;
  }

 s = txtProp.Text.Trim();
 if (s.Length == 0)
  {
   MainWnd.Response("The property value cannot be blank");
   return;
  }

 if (float.TryParse(s, out val) == false)
  {
   MainWnd.Response("The property value is not numeric");
   return;
  }

 InventoryCategoryValue.UpdateValue(CurrentValue, Item.ID, val);

 listVals.SelectedItems[0].SubItems[1].Text = val.ToString("0.0000");
}

private void btnTextSave_Click(object sender, EventArgs e)
{
 string name, desc, notes, sCost;
 float fCost;

 name = txtName.Text.Trim();
 desc = txtDesc.Text.Trim();
 notes = txtNotes.Text.Trim();
 sCost = txtCost.Text.Trim();

 if (sCost.Length == 0)
   fCost = 0;
 else
  {
   if (float.TryParse(sCost, out fCost) == false)
    {
     MainWnd.Response("Estimated cost is not numeric or blank");
     return;
    }
  }

 Item.UpdateText(name, desc, notes, fCost);

 txtChanged.Text = Item.Changed.ToString(Globals.DateFormat);

}

private void btnFileAdd_Click(object sender, EventArgs e)
{
 InventoryAddFileDlg dlg;
 InventoryFile file;

 dlg = new InventoryAddFileDlg(this);
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   file = new InventoryFile(Item, dlg.FileType, dlg.URLorPath, dlg.ItemName, dlg.ItemDesc, dlg.ItemExt);
   if (file.Type != InventoryFile.FileTypes.URL)
    {
     if (file.CopyFile(Item, dlg.URLorPath) == true) // if this fails the row for it will already be deleted
      {
       listFiles.Items.Add(new LVFileItem(file));
       listFiles.Sort();
       LVFileItem.ResizeColumns(listFiles);
      }
    }
  else
   {
    listFiles.Items.Add(new LVFileItem(file));  // it's just a URL
    listFiles.Sort();
    LVFileItem.ResizeColumns(listFiles);
   }
  }
 dlg.Dispose();
}

private void btnFileEdit_Click(object sender, EventArgs e)
{
 InventoryEditFileDlg dlg;
 InventoryFile file;

 if (listFiles.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a file or URL to remove then try again");
   return;
  }

 file = ((LVFileItem)listFiles.SelectedItems[0]).FileItem;

 dlg = new InventoryEditFileDlg(this, file);

 if (dlg.ShowDialog() == DialogResult.OK)
  {
   file.Update(dlg.FileName, dlg.FileDesc);
   listFiles.SelectedItems[0].SubItems[1].Text = dlg.FileName;
   listFiles.SelectedItems[0].SubItems[2].Text = dlg.FileDesc;
  }
 dlg.Dispose();
}

private void btnFileRemove_Click(object sender, EventArgs e)
{
 InventoryFile file;
 string q;

 if (listFiles.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a file or URL to remove then try again");
   return;
  }

 file = ((LVFileItem)listFiles.SelectedItems[0]).FileItem;

 q = "Remove " + InventoryFile.GetTypeName(file.Type) + " ID=" + file.ID + " ?\n\n";
 q += "Name: " + file.Name + "\n\n";
 if (file.Type == InventoryFile.FileTypes.URL)
   q += "URL: " + file.Path;
 else
  {
   q += file.FullPath + "\n\n";
   q += "Original " + file.Path;
  }
 if (MainWnd.Question(q, MessageBoxButtons.OKCancel) == DialogResult.OK)
  {
   if (file.Type != InventoryFile.FileTypes.URL)
    {
     if (file.DeleteFile() == false)
       return;
    }
   file.Delete();
   listFiles.Items.Remove(listFiles.SelectedItems[0]);
   LVFileItem.ResizeColumns(listFiles);
  }
}

private void btnHistAdd_Click(object sender, EventArgs e)
{
 PurchaseHistoryDlg dlg;
 PurchaseHistory hist;

 dlg = new PurchaseHistoryDlg(this);

 if (dlg.ShowDialog() == DialogResult.OK)
  {
   hist = new PurchaseHistory(Item, dlg.PurchaseSource, dlg.PurchaseLink, dlg.PurchaseDate, dlg.PurchasePrice, dlg.PurchaseCount);
   listHistory.Items.Add(new LVHistItem(hist));
   listHistory.Sort();
   LVHistItem.ResizeColumns(listHistory);
   txtChanged.Text = Item.Changed.ToString(Globals.DateFormat);
   txtInvAdded.Text = Item.InvAdded.ToString(Globals.DateFormat);
   txtCount.Text = Item.InventoryCount.ToString();
  }
 dlg.Dispose();
}

private void btnHistEdit_Click(object sender, EventArgs e)
{
 PurchaseHistoryDlg dlg;
 PurchaseHistory hist;

 if (listHistory.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a history item to edit and try again");
   return;
  }

 hist = ((LVHistItem)listHistory.SelectedItems[0]).PurchHist;

 dlg = new PurchaseHistoryDlg(this, hist);
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   hist.Update(dlg.PurchaseSource, dlg.PurchaseLink, dlg.PurchaseDate, dlg.PurchasePrice, dlg.PurchaseCount);
   ((LVHistItem)listHistory.SelectedItems[0]).UpdateText(hist);
   listHistory.Sort();
   LVHistItem.ResizeColumns(listHistory);
  }
 dlg.Dispose();
}

private void btnHistRemove_Click(object sender, EventArgs e)
{
 PurchaseHistory hist;
 string q;

 if (listHistory.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a history item to delete and try again");
   return;
  }

 hist = ((LVHistItem)listHistory.SelectedItems[0]).PurchHist;

 q = "Delete Purchase History Entry ?\n\n";
 q += "Source: " + hist.Source + "\n";
 q += "Date: " + hist.PurchaseDate.ToString(Globals.DateFormat) + "\n";
 q += "Price: " + hist.Price.ToString("0.00") + "\n";
 q += "Amount: " + hist.Amount.ToString() + "\n\n";
 q += "ID: " + hist.ID.ToString();

 if (MainWnd.Question(q, MessageBoxButtons.OKCancel) == DialogResult.OK)
  {
   hist.Delete();
   listHistory.Items.Remove(listHistory.SelectedItems[0]);
  }
}

private void btnFileOpen_Click(object sender, EventArgs e)
{
 SaveFileDialog dlg;
 InventoryFile file;

 if (listFiles.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a file or URL to open then try again");
   return;
  }

 file = ((LVFileItem)listFiles.SelectedItems[0]).FileItem;

 switch(file.Type)
  {
   case InventoryFile.FileTypes.Image:
    {
     System.Diagnostics.Process.Start(file.FullPath);
    } break;
   case InventoryFile.FileTypes.URL:
    {
     System.Diagnostics.Process.Start(file.Path);
    } break;
   case InventoryFile.FileTypes.PDF:
    {
     System.Diagnostics.Process.Start(file.FullPath);
    } break;
   default:
    {
     dlg = new SaveFileDialog();
     dlg.Title = "Copy " + file.FullPath;
     dlg.Filter = file.Extension + " *." + file.Extension + "|*" + file.Extension;
     dlg.CheckPathExists = true;
     dlg.OverwritePrompt = true;
     dlg.InitialDirectory = Globals.DownloadDirectory;
     if (dlg.ShowDialog() == DialogResult.OK)
      {
       try 
        {
         System.IO.File.Copy(file.FullPath, dlg.FileName);
        }
       catch(Exception ex)
        {
         MainWnd.Response("Unable to copy '" + file.FullPath + "' to '" + dlg.FileName + "'.\n\n" + ex.Message);
        }
      }
    } break;
  }
}

private void btnOK_Click(object sender, EventArgs e)
{
 Close();
}

private void btnLocPicSet_Click(object sender, EventArgs e)
{
 PictureLocPickDlg dlg;

 dlg = new PictureLocPickDlg();
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   Item.UpdateLocation(dlg.SubPicLoc);
   txtLoc.Text = Item.InvLoc.ToString();
   txtChanged.Text = Item.Changed.ToString(Globals.DateFormat);
  }
 dlg.Dispose();
}

private void btnLocNameSet_Click(object sender, EventArgs e)
{
 NameLocPickDlg dlg;

 dlg = new NameLocPickDlg(this, true);
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   Item.UpdateLocation(dlg.NameLoc);
   txtLoc.Text = Item.InvLoc.ToString();
   txtChanged.Text = Item.Changed.ToString(Globals.DateFormat);
  }
 dlg.Dispose();
 
}

private void btnSaveStock_Click(object sender, EventArgs e)
{
 string s;
 int c;

 s = txtCount.Text.Trim();
 if (s.Length == 0)
  {
   MainWnd.Response("Stock count cannot be blank");
   return;
  }

 if (int.TryParse(s, out c) == false)
  {
   MainWnd.Response("Stock count is not numeric");
   return;
  }

 Item.UpdateCount(c);
 txtChanged.Text = Item.Changed.ToString(Globals.DateFormat);

}


private void btnTakeInv_Click(object sender, EventArgs e)
{
 string s;
 int c;

 s = txtTake.Text.Trim();
 if (s.Length == 0)
  {
   MainWnd.Response("Add/Remove cannot be blank");
   return;
  }

 if (int.TryParse(s, out c) == false)
  {
   MainWnd.Response("Add/Remove is not numeric");
   return;
  }

 if (Item.InventoryCount - c < 0)
  {
   if (MainWnd.Question("Amount entered would result in negative stock count, set inventory stock to zero ?", MessageBoxButtons.YesNo) == DialogResult.No)
    {
     return;
    }
  }

 Item.TakeInventory(c);
 txtChanged.Text = Item.Changed.ToString(Globals.DateFormat);
 txtInvRemoved.Text = Item.InvRemoved.ToString(Globals.DateFormat);
 txtCount.Text = Item.InventoryCount.ToString();
}

private void btnAddInv_Click(object sender, EventArgs e)
{
 string s;
 int c;

 s = txtTake.Text.Trim();
 if (s.Length == 0)
  {
   MainWnd.Response("Add/Remove cannot be blank");
   return;
  }

 if (int.TryParse(s, out c) == false)
  {
   MainWnd.Response("Add/Remove is not numeric");
   return;
  }

 Item.AddInventory(c);
 txtChanged.Text = Item.Changed.ToString(Globals.DateFormat);
 txtInvAdded.Text = Item.InvAdded.ToString(Globals.DateFormat);
 txtCount.Text = Item.InventoryCount.ToString();
 
}

};

public class LVPropValue : ListViewItem
{
 public InventoryCategoryValue Value { get; private set; }

public LVPropValue(in InventoryCategoryValue val)
{
 Value = val;
 Text = val.CatProp.PropertyName;
 SubItems.Add(val.Value.ToString("0.0000"));
 if (Value.CatProp.PrimaryProperty == true)
   SubItems.Add("Yes");
 else
   SubItems.Add("");
}

public LVPropValue(in InventoryItem item, in InventoryCategoryProperty p)
{
 Value = new InventoryCategoryValue(item.ID, item.InvCat, p, 0.0F);
 Text = Value.CatProp.PropertyName;
 SubItems.Add("0.0000");
 if (Value.CatProp.PrimaryProperty == true)
   SubItems.Add("Yes");
 else
   SubItems.Add("");
}

public static void ResizeColumns(ListView list)
{
 list.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 list.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
 list.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
}

};

public class LVPropValueSorter : IComparer
{

public LVPropValueSorter() // have to have a constructor
{
}

public int Compare(Object x, Object y)
{
 LVPropValue cx, cy;

 cx = (LVPropValue)x;
 cy = (LVPropValue)y;

 return string.Compare(cx.Value.CatProp.PropertyName, cy.Value.CatProp.PropertyName);
}
};

public class LVFileItem : ListViewItem
{
 public InventoryFile FileItem { get; private set; }
 
public LVFileItem(in InventoryFile file)
{
 FileItem = file;
 
 Text = InventoryFile.GetTypeName(FileItem.Type);
 SubItems.Add(FileItem.Name);
 SubItems.Add(FileItem.Desc);
 if (FileItem.Type == InventoryFile.FileTypes.URL)
  {
   SubItems.Add(FileItem.Path);
   SubItems.Add("N/A");
  }
 else
  {
   SubItems.Add(FileItem.FullPath);
   SubItems.Add(FileItem.Path);
  }

 SubItems.Add(file.ID.ToString("0"));
}

public static void AddHeaders(ListView list)
{
 list.Columns.Clear();

 list.Columns.Add("f1", "File Type");
 list.Columns.Add("f2", "Name");
 list.Columns.Add("f3", "Desc");
 list.Columns.Add("f4", "Path");
 list.Columns.Add("f5", "Original Path");
 list.Columns.Add("f6", "ID");
}

public static void ResizeColumns(ListView lv)
{
 lv.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
 lv.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
}

public static LVFileItemSorter.SortColumn GetColumn(int headerClicked)
{
 switch(headerClicked)
  {
   case 0: return LVFileItemSorter.SortColumn.Type;
   case 1: return LVFileItemSorter.SortColumn.Name;
   case 2: return LVFileItemSorter.SortColumn.Desc;
   case 3: return LVFileItemSorter.SortColumn.Path;
   case 4: return LVFileItemSorter.SortColumn.Orignal;
   case 5: return LVFileItemSorter.SortColumn.ID;
   default: throw new Exception("un-handled sort column");
  }
}
};

public class LVFileItemSorter : IComparer
{
 public enum SortColumn : int { Path, Name, Desc, Type, Orignal, ID }
 
 public SortColumn Column { get; private set; }
 public bool Ascending { get; private set; }

public LVFileItemSorter(SortColumn col, bool asc)
{
 Column = col;
 Ascending = asc;
}

public int Compare(Object x, Object y)
{
 LVFileItem cx, cy;
 string sx, sy;

 if (Ascending == true)
  {
   cx = (LVFileItem)x;
   cy = (LVFileItem)y;
  }
 else 
  {
   cx = (LVFileItem)y;
   cy = (LVFileItem)x;
  }

 switch(Column)
  {
   case SortColumn.Path:
    {
     if (cx.FileItem.Type == InventoryFile.FileTypes.URL) sx = cx.FileItem.Path; else sx = cx.FileItem.FilePath;
     if (cy.FileItem.Type == InventoryFile.FileTypes.URL) sy = cy.FileItem.Path; else sy = cy.FileItem.FilePath;
     return string.Compare(sx, sy);
    } 
   case SortColumn.Name: return string.Compare(cx.FileItem.Name, cy.FileItem.Name);
   case SortColumn.Desc: return string.Compare(cx.FileItem.Desc, cy.FileItem.Desc);
   case SortColumn.Type:
    {
     return string.Compare(InventoryFile.GetTypeName(cx.FileItem.Type), InventoryFile.GetTypeName(cy.FileItem.Type));
    }
   case SortColumn.Orignal:
    {
     if (cx.FileItem.Type == InventoryFile.FileTypes.URL) sx = "N/A"; else sx = cx.FileItem.Path;
     if (cy.FileItem.Type == InventoryFile.FileTypes.URL) sy = "N/A"; else sy = cy.FileItem.Path;
     return string.Compare(sx, sy);
    } 
   case SortColumn.ID:
    {
     if (cx.FileItem.ID > cy.FileItem.ID) return 1;
     if (cx.FileItem.ID < cx.FileItem.ID) return -1;
     return 0;
    }
   default: throw new Exception("unhandled sort");
  }
}

};

public class LVHistItem : ListViewItem
{
 public PurchaseHistory PurchHist { get; private set; }

public LVHistItem(in PurchaseHistory hist)
{

 PurchHist = hist;

 Text = PurchHist.PurchaseDate.ToString(Globals.DateFormat);
 SubItems.Add(PurchHist.Amount.ToString("0.00"));
 SubItems.Add(PurchHist.Price.ToString("0.00"));
 SubItems.Add(PurchHist.Source);
 SubItems.Add(PurchHist.Link);
 SubItems.Add(PurchHist.ID.ToString());
}

public void UpdateText(in PurchaseHistory hist)
{
 PurchHist = hist;
 Text = PurchHist.PurchaseDate.ToString(Globals.DateFormat);
 SubItems[1].Text = PurchHist.Amount.ToString("0.00");
 SubItems[2].Text = PurchHist.Price.ToString("0.00");
 SubItems[3].Text = PurchHist.Source;
 SubItems[4].Text = PurchHist.Link;
 // id won't change
}

public static void AddHeaders(ListView list)
{
 list.Columns.Clear();

 list.Columns.Add("h1", "Date");
 list.Columns.Add("h2", "Quantity", 10, HorizontalAlignment.Right, "");
 list.Columns.Add("h3", "Price", 10, HorizontalAlignment.Right, "");
 list.Columns.Add("h4", "Source");
 list.Columns.Add("h5", "URL");
 list.Columns.Add("h6", "ID");
}

public static void ResizeColumns(ListView lv)
{
 lv.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
 lv.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
 lv.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
}

public static LVHistItemSorter.SortColumn GetColumn(int headerClicked)
{
 switch(headerClicked)
  {
   case 0: return LVHistItemSorter.SortColumn.Date;
   case 1: return LVHistItemSorter.SortColumn.Amount;
   case 2: return LVHistItemSorter.SortColumn.Price;
   case 3: return LVHistItemSorter.SortColumn.Source;
   case 4: return LVHistItemSorter.SortColumn.Link;
   case 5: return LVHistItemSorter.SortColumn.ID;
   default: throw new Exception("un-handled sort column");
  }
}


};

public class LVHistItemSorter : IComparer
{
 public enum SortColumn : int { Source, Link, Date, Price, Amount, ID }
 
 public SortColumn Column { get; private set; }
 public bool Ascending { get; private set; }

public LVHistItemSorter(SortColumn col, bool asc)
{
 Column = col;
 Ascending = asc;
}

public int Compare(Object x, Object y)
{
 LVHistItem cx, cy;

 if (Ascending == true)
  {
   cx = (LVHistItem)x;
   cy = (LVHistItem)y;
  }
 else 
  {
   cx = (LVHistItem)y;
   cy = (LVHistItem)x;
  }

 switch(Column)
  {
   case SortColumn.Source: return string.Compare(cx.PurchHist.Source, cy.PurchHist.Source);
   case SortColumn.Link: return string.Compare(cx.PurchHist.Link, cy.PurchHist.Link);
   case SortColumn.Date: return DateTime.Compare(cx.PurchHist.PurchaseDate, cy.PurchHist.PurchaseDate);
   case SortColumn.Price:
    {
     if (cx.PurchHist.Price > cy.PurchHist.Price) return 1;
     if (cx.PurchHist.Price < cy.PurchHist.Price) return -1;
     return 0;
    }
   case SortColumn.Amount:
    {
     if (cx.PurchHist.Amount > cy.PurchHist.Amount) return 1;
     if (cx.PurchHist.Amount < cy.PurchHist.Amount) return -1;
     return 0;
    }
   case SortColumn.ID:
    {
     if (cx.PurchHist.ID > cy.PurchHist.ID) return 1;
     if (cx.PurchHist.ID < cy.PurchHist.ID) return -1;
     return 0;
    }
   default: throw new Exception("unhandled sort case");
  }
}

};

}
