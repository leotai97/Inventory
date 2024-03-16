using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
public partial class CategoryPickDlg : Form
{
 public InventoryCategory Category { get; private set; }

 private LVCatSorter.SortColumn CurrentSort = LVCatSorter.SortColumn.Name;
 private bool CurrentAscending = true;

 private bool ChoosingCategory;

public CategoryPickDlg(Form parent, bool forceToChoose)
{

 ChoosingCategory = forceToChoose;

 Owner = parent;
 StartPosition = FormStartPosition.CenterParent;

 InitializeComponent();

 if (ChoosingCategory == true)
  {
   Text = "Select Category";
  }
 else
  {
   Text = "Category List";
   btnCancel.Visible = false;
   btnOK.Text = "Close";
   btnOK.Left = ClientSize.Width / 2 - btnOK.Width / 2;
  }

 LVCat.AddHeaders(listCat);
 
 LoadCategories();
}

private void LoadCategories()
{
 List<InventoryCategory> items;

 items = InventoryCategory.GetCategories();

 listCat.Items.Clear();

 foreach(InventoryCategory cat in items)
  {
   listCat.Items.Add(new LVCat(cat));
  }

 listCat.ListViewItemSorter = new LVCatSorter(CurrentSort, CurrentAscending);
 listCat.Sort();

 LVCat.ResizeColumns(listCat);

 
}

private void listCat_ColumnClick(object sender, ColumnClickEventArgs e)
{
 LVCatSorter.SortColumn sort;

 sort = LVCat.GetColumn(e.Column);

 if (CurrentSort == sort)
   CurrentAscending = !CurrentAscending;
 else
  {
   CurrentSort = sort;
   CurrentAscending = true;
  }
 listCat.ListViewItemSorter =  new LVCatSorter(CurrentSort, CurrentAscending);
 listCat.Sort();
}

private void listCat_DoubleClick(object sender, EventArgs e)
{
 InventoryCategory cat;

 if (listCat.SelectedItems.Count == 0)
   return;
 
 cat = ((LVCat)listCat.SelectedItems[0]).Category;
 if (ChoosingCategory == true)
  {
   Category = cat;
   DialogResult = DialogResult.OK;
   Close();
  }
 else
  {
   EditCategory(cat);
  }
}

private void btnOK_Click(object sender, EventArgs e)
{
 if (ChoosingCategory == true)
  {
   if (listCat.SelectedItems.Count == 0)
    {
     MainWnd.Response("Select a category then click OK");
     return;
    }
   Category = ((LVCat)listCat.SelectedItems[0]).Category;
  }
 DialogResult = DialogResult.OK;
 Close();
}

private void btnCancel_Click(object sender, EventArgs e)
{
 DialogResult = DialogResult.Cancel;
 Close();
}

private void btnCatAdd_Click(object sender, EventArgs e)
{
 CategoryNewDlg nDlg;
 CategoryDlg cDlg;
 InventoryCategory cat;

 nDlg = new CategoryNewDlg(this);
 
 if (nDlg.ShowDialog() == DialogResult.OK)
  {
   cat = new InventoryCategory(nDlg.CategoryName, "", "");
   cDlg = new CategoryDlg(this, cat);
   cDlg.ShowDialog();
   cDlg.Dispose();
   LoadCategories();
  }
 nDlg.Dispose();
}

private void EditCategory(in InventoryCategory cat)
{
 CategoryDlg dlg;

 dlg = new CategoryDlg(this, cat);
 dlg.ShowDialog();
 dlg.Dispose();

 ((LVCat)listCat.SelectedItems[0]).UpdateText(cat);
}

private void btnCatEdit_Click(object sender, EventArgs e)
{
 InventoryCategory cat;

 if (listCat.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a category to edit then try again");
   return;
  }

 cat = ((LVCat)listCat.SelectedItems[0]).Category;

 EditCategory(cat);
}

private void btnCatRemove_Click(object sender, EventArgs e)
{
 InventoryCategory cat;
 string q;
 uint c;

 if (listCat.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a category to delete then try again");
   return;
  }

 cat = ((LVCat)listCat.SelectedItems[0]).Category;

 c = InventoryCategory.GetInvCount(cat.ID);

 q = "Delete inventory category '" + cat.Name  + " ID " + cat.ID.ToString() + "?";

 if (c > 0)
  {
   q += "\n\nWarning: the category has " + c.ToString() + " inventory items and possibly linked files underneath it which will be deleted as well!";
  }

 Cursor = Cursors.WaitCursor;

 if (MainWnd.Question(q, MessageBoxButtons.OKCancel) == DialogResult.OK)
  {
   if (cat.Delete() == true)
     listCat.Items.Remove(listCat.SelectedItems[0]); 
  }

 Cursor = Cursors.Default;

}

};

public class LVCat : ListViewItem
{
 public InventoryCategory Category { get; private set; }
 public uint InvCount { get; private set; }

public LVCat(in InventoryCategory cat)
{
 Category = cat;
 Text = Category.Name;
 InvCount = InventoryCategory.GetInvCount(cat.ID);
 SubItems.Add(Category.Desc);
 SubItems.Add(InvCount.ToString());
 SubItems.Add(Category.ID.ToString());
}

public static void AddHeaders(ListView list)
{
 list.Columns.Clear();

 list.Columns.Add("c1", "Name");
 list.Columns.Add("c2", "Description");
 list.Columns.Add("c3", "Count", 10, HorizontalAlignment.Right, "");
 list.Columns.Add("c4", "ID");
}

public static void ResizeColumns(ListView lv)
{
 lv.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
 lv.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
}

public static LVCatSorter.SortColumn GetColumn(int headerClicked)
{
 switch(headerClicked)
  {
   case 0: return LVCatSorter.SortColumn.Name;
   case 1: return LVCatSorter.SortColumn.Desc;
   case 2: return LVCatSorter.SortColumn.Count;
   case 3: return LVCatSorter.SortColumn.ID;
   default: throw new Exception("un-handled sort column");
  }
}

public void UpdateText(in InventoryCategory cat)
{
 Category = cat;
 Text = Category.Name;
 SubItems[1].Text = Category.Desc;
 SubItems[2].Text = InvCount.ToString();
 SubItems[3].Text = Category.ID.ToString();
}

};

public class LVCatSorter : IComparer
{
 public enum SortColumn : int {  Name, Desc, Count, ID }
 
 public SortColumn Column { get; private set; }
 public bool Ascending { get; private set; }

public LVCatSorter(SortColumn col, bool asc)
{
 Column = col;
 Ascending = asc;
}

public int Compare(Object x, Object y)
{
 LVCat cx, cy;

 if (Ascending == true)
  {
   cx = (LVCat)x;
   cy = (LVCat)y;
  }
 else 
  {
   cx = (LVCat)y;
   cy = (LVCat)x;
  }

 switch(Column)
  {
   case SortColumn.Name: return string.Compare(cx.Category.Name, cy.Category.Name);
   case SortColumn.Desc: return string.Compare(cx.Category.Desc, cy.Category.Desc);
   case SortColumn.Count:
    {
     if (cx.InvCount > cy.InvCount) return 1;
     if (cx.InvCount < cy.InvCount) return -1;
     return 0;
    }
   case SortColumn.ID:
    {
     if (cx.Category.ID > cy.Category.ID) return 1;
     if (cx.Category.ID < cy.Category.ID) return -1;
     return 0;
    } 
   default: throw new Exception("unhandled sort compare case");
  }
}

};

}
