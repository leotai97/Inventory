using Microsoft.VisualBasic.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections;
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

public partial class NameLocPickDlg : Form
{

 public NameLocation NameLoc { get; private set; }

 private LVNameSort.SortColumn CurrentSortCol = LVNameSort.SortColumn.Name;
 private bool CurrentSortAscending = true;

 private bool ChoosingName;

public NameLocPickDlg(Form own, bool choosing)
{
 List<NameLocation> names;
 
 InitializeComponent();

 Owner = own;
 StartPosition = FormStartPosition.CenterParent;
 
 ChoosingName = choosing;
 
 if (ChoosingName == true)
  {
   Text = "Choose Named Location";
  }
 else
  {
   Text = "Named Locations";
   btnCancel.Visible = false;
   btnOK.Left = ClientSize.Width / 2 - btnOK.Width / 2;
  }

 names = NameLocation.GetAllNames();

 LVNameItem.AddHeaders(listNamed);

 foreach(NameLocation n in names)
  {
   listNamed.Items.Add(new LVNameItem(n));
  }
 LVNameItem.ResizeColumns(listNamed);
 listNamed.ListViewItemSorter = new LVNameSort(CurrentSortCol, CurrentSortAscending);
 listNamed.Sort();
}

private void listNamed_DoubleClick(object sender, EventArgs e)
{
 if (listNamed.SelectedItems.Count == 0)
   return;

 NameLoc = ((LVNameItem)listNamed.SelectedItems[0]).NameLoc;

 if (ChoosingName == true)
  {
   DialogResult = DialogResult.OK;
   Close();
  }
 else
  {
   EditItem(NameLoc);
  }
}

private void listNamed_ColumnClick(object sender, ColumnClickEventArgs e)
{
 LVNameSort.SortColumn sort;

 sort = LVNameItem.GetColumn(e.Column);

 if (sort == CurrentSortCol)
  {
   CurrentSortAscending = ! CurrentSortAscending;
  }
 else
  {
   CurrentSortCol = sort;
   CurrentSortAscending = true;
  }
 listNamed.ListViewItemSorter = new LVNameSort(CurrentSortCol, CurrentSortAscending);
 listNamed.Sort();
}

private void btnNameAdd_Click(object sender, EventArgs e)
{
 NameLocation loc;
 NameLocEditDlg dlg;

 dlg = new NameLocEditDlg(this);

 if (dlg.ShowDialog() == DialogResult.OK)
  {
   loc = new NameLocation(dlg.LocName, dlg.LocDesc);
   listNamed.Items.Add(new LVNameItem(loc));
   LVNameItem.ResizeColumns(listNamed);
   listNamed.Sort();
  }
 dlg.Dispose();

}

private void btnNameEdit_Click(object sender, EventArgs e)
{
 NameLocation loc;

 if (listNamed.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a name location to edit and try again");
   return;
  }

 loc = ((LVNameItem)listNamed.SelectedItems[0]).NameLoc;
 EditItem(loc);

}

private void EditItem(in NameLocation loc)
{
 NameLocEditDlg dlg;
 
 dlg = new NameLocEditDlg(this, loc);
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   loc.UpdateText(dlg.LocName, dlg.LocDesc);
   ((LVNameItem)listNamed.SelectedItems[0]).UpdateText(loc);
  }
 dlg.Dispose();
}

private void btnNameRemove_Click(object sender, EventArgs e)
{
 NameLocation loc;
 string q;
 uint c;

 if (listNamed.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a name location to delete and try again");
   return;
  }

 loc = ((LVNameItem)listNamed.SelectedItems[0]).NameLoc;
 
 c = NameLocation.GetCount(loc.ID);

 if (c > 0)
  {
   MainWnd.Response("The named location '" + loc.Name + "' has " + c.ToString() + " items assigned to it.  The items must be moved to another location before it can be deleted");
   return;
  }

 q = "Delete named location '" + loc.Name + "' ID " + loc.ID.ToString() + " ?";

 if (MainWnd.Question(q, MessageBoxButtons.OKCancel) == DialogResult.OK)
  {
   loc.DeleteRow();
   listNamed.Items.Remove(listNamed.SelectedItems[0]);
   LVNameItem.ResizeColumns(listNamed);
  }
}

private void btnOK_Click(object sender, EventArgs e)
{
 if (listNamed.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a name location to delete and try again");
   return;
  }

 NameLoc = ((LVNameItem)listNamed.SelectedItems[0]).NameLoc;

 DialogResult = DialogResult.OK;
 Close();
}

private void btnCancel_Click(object sender, EventArgs e)
{
 DialogResult = DialogResult.Cancel;
 Close();
}

private void btnMovePic_Click(object sender, EventArgs e)
{
 NameLocation loc;
 PictureLocPickDlg dlg;
 PictureLocation pic;
 uint c;
 string q;

 if (listNamed.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a name location to move from and try again");
   return;
  }

 loc = ((LVNameItem)listNamed.SelectedItems[0]).NameLoc;
 c = NameLocation.GetCount(loc.ID);

 if (c == 0)
  {
   MainWnd.Response("Name location '" + loc.Name + "' ID " + loc.ID.ToString() + " has no inventory assigned to it");
   return;
  }

 dlg = new PictureLocPickDlg();
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   pic = dlg.SubPicLoc;
   q = "Move " + c + " items from named location '" + loc.Name + "' to Picture Location '" + pic.ToString() + "' ?";
   if (MainWnd.Question(q, MessageBoxButtons.OKCancel) == DialogResult.OK)
    {
     InventoryItem.MoveInventory(loc, pic);
     listNamed.SelectedItems[0].SubItems[1].Text = "0";
    }
  }
 dlg.Dispose();
}

private void btnMoveName_Click(object sender, EventArgs e)
{
 NameLocation loc;
 NameLocPickDlg dlg;
 NameLocation name;
 uint c;
 string q;

 if (listNamed.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a name location to move from and try again");
   return;
  }

 loc = ((LVNameItem)listNamed.SelectedItems[0]).NameLoc;
 c = NameLocation.GetCount(loc.ID);

 if (c == 0)
  {
   MainWnd.Response("Name location '" + loc.Name + "' ID " + loc.ID.ToString() + " has no inventory assigned to it");
   return;
  }

 dlg = new NameLocPickDlg(this, true);
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   name = dlg.NameLoc;
   if (name.ID == loc.ID)
    {
     MainWnd.Response("The named locations are the same");
     return;
    }
   q = "Move " + c + " items from named location '" + loc.Name + "' to name Location '" + name.ToString() + "' ?";
   if (MainWnd.Question(q, MessageBoxButtons.OKCancel) == DialogResult.OK)
    {
     InventoryItem.MoveInventory(loc, name);
     listNamed.SelectedItems[0].SubItems[1].Text = "0";
    }
  }
 dlg.Dispose();
}

};

public class LVNameItem : ListViewItem
{
 public NameLocation NameLoc { get; private set; }

public LVNameItem(in NameLocation nl)
{
 NameLoc = nl;

 Text = NameLoc.Name;
 SubItems.Add(NameLoc.InvCount.ToString());
 SubItems.Add(NameLoc.Desc);
 SubItems.Add(NameLoc.ID.ToString());
}

public static void AddHeaders(ListView list)
{
 list.Columns.Clear();
 list.Columns.Add("c1", "Name");
 list.Columns.Add("c2", "Count", 10, HorizontalAlignment.Right, "");
 list.Columns.Add("c3", "Description");
 list.Columns.Add("c4", "ID");
}

public static LVNameSort.SortColumn GetColumn(int col)
{
 switch(col)
  {
   case 0: return LVNameSort.SortColumn.Name; 
   case 1: return LVNameSort.SortColumn.Count;
   case 2: return LVNameSort.SortColumn.Desc;
   case 3: return LVNameSort.SortColumn.ID;
   default: throw new Exception("unhandled case");
  }
}

public static void ResizeColumns(ListView lv)
{
 lv.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
 lv.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
}

public void UpdateText(in NameLocation loc)
{
 NameLoc = loc;
 Text = loc.Name;
 SubItems[2].Text = loc.Desc;
}

};

public class LVNameSort : IComparer
{
 public enum SortColumn : int { Name, Desc, Count, ID }
 
 public SortColumn Column { get; private set; }
 public bool Ascending { get; private set; }

public LVNameSort(SortColumn col, bool asc)
{
 Column = col;
 Ascending = asc;
}

public int Compare(Object x, Object y)
{
 LVNameItem cx, cy;

 if (Ascending == true)
  {
   cx = (LVNameItem)x;
   cy = (LVNameItem)y;
  }
 else 
  {
   cx = (LVNameItem)y;
   cy = (LVNameItem)x;
  }

 switch(Column)
  {
   case SortColumn.Name: return string.Compare(cx.NameLoc.Name, cy.NameLoc.Name);
   case SortColumn.Count:
    {
     if (cx.NameLoc.InvCount > cy.NameLoc.InvCount) return 1;
     if (cx.NameLoc.InvCount < cy.NameLoc.InvCount) return -1;
     return 0;
    }
   case SortColumn.Desc: return string.Compare(cx.NameLoc.Desc, cy.NameLoc.Desc);
   case SortColumn.ID:
    {
     if (cx.NameLoc.ID > cy.NameLoc.ID) return 1;
     if (cx.NameLoc.ID < cy.NameLoc.ID) return -1;
     return 0;
    }  
   default: throw new Exception("unhandled column");
  }
}
};
}
