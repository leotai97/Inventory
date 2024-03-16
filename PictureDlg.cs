using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Inventory
{
public partial class PictureDlg : Form
{
 public PictureLocation PicLoc { get; private set; }

 private Point StartPoint;
 private Point EndPoint;
 bool RectPresent;
 bool MouseCaptured;

 private Font  ChildFont = new Font(FontFamily.GenericSansSerif, 14);
 private Brush ChildBrush;
 private Pen   ChildPen;
 private Color PenColor = Color.Red;
 private int   PenWidth = 4;

 private LVPicLocSorter.SortColumn CurrentSort = LVPicLocSorter.SortColumn.Name;
 private bool CurrentAscending = true;

 private bool InhibitOrderUpdate = false;

public PictureDlg(in PictureLocation loc)
{

 InitializeComponent();

 PicLoc = loc;

 txtName.Text = PicLoc.Name;
 txtFile.Text = PicLoc.File;
 txtDesc.Text = PicLoc.Desc;

 LVPicLoc.AddHeaders(listChildren);

 foreach(PictureLocation c in PicLoc.Children)
  {
   listChildren.Items.Add(new LVPicLoc(c));
  }
 listChildren.ListViewItemSorter = new LVPicLocSorter(CurrentSort, CurrentAscending);
 listChildren.Sort();
 LVPicLoc.ResizeColumns(listChildren);

 picLoc.Image = Globals.GetLocationPicture(PicLoc);

 ChildBrush = new SolidBrush(PenColor);
 ChildPen = new Pen(PenColor, PenWidth);

 Utility.LoadWindowSetting(this);
}

private bool GetChildLocationRectangle(out Rectangle rct)
{
 
 rct = new Rectangle();

 if (RectPresent == false)
  {
   MainWnd.Response("Draw a rectangle on the picture where the sub location is located with the mouse and try again");
   return false;
  }
 
 rct = Utility.GetRect(StartPoint, EndPoint);

 return true;
}

protected override void OnClosing(CancelEventArgs e)
{
 base.OnClosing(e);

 if (picLoc.Image != null)
   picLoc.Image.Dispose();

 ChildFont.Dispose();
 ChildBrush.Dispose();
 ChildPen.Dispose();

 Utility.SaveWindowSetting(this);

}

private void btnAddChild_Click(object sender, EventArgs e) // add a child "parent" location to the dialog's current parent
{
 PictureLocation loc;
 PictureDlg pDlg;
 OpenFileDlg fDlg;
 Rectangle rct;
 int ord;

 if (GetChildLocationRectangle(out rct) == false)
   return;

 ord = listChildren.Items.Count + 1;

 fDlg = new OpenFileDlg(this, OpenFileDlg.FileTypes.Picture);
 if (fDlg.ShowDialog() == DialogResult.OK)
  {
   loc = new PictureLocation(PicLoc, txtSubName.Text.Trim(), ord, txtSubDesc.Text.Trim(), fDlg.FileName, rct, PenColor, PenWidth);  
   listChildren.Items.Add(new LVPicLoc(loc));
   LVPicLoc.ResizeColumns(listChildren);
   pDlg = new PictureDlg(loc);
   pDlg.ShowDialog();
   pDlg.Dispose();
  }
 fDlg.Dispose();
 
}

private void btnAddNoPicChild_Click(object sender, EventArgs e) // add a non-parent end child location to the current parent
{
 PictureLocation loc;
 Rectangle rct;
 int ord;

 if (GetChildLocationRectangle(out rct) == false)
   return;
 
 ord = listChildren.Items.Count + 1;

 loc = new PictureLocation(PicLoc, txtSubName.Text.Trim(), ord, txtSubDesc.Text.Trim(), "", rct, PenColor, PenWidth);
 listChildren.Items.Add(new LVPicLoc(loc));
 LVPicLoc.ResizeColumns(listChildren);

}

private void btnSetChildLoc_Click(object sender, EventArgs e) // save the current drawn rectangle and text of the selected sub loc
{
 PictureLocation loc;
 Rectangle rct;
 string s;

 if (listChildren.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a sub location, draw a new rectangle with the mouse, then try again");
   return;
  }

 if (GetChildLocationRectangle(out rct) == false)
   return;

 loc = ((LVPicLoc)listChildren.SelectedItems[0]).PicLoc;

 loc.UpdateRect(rct, PenColor, PenWidth);
 loc.UpdateText(txtSubName.Text.Trim(), txtSubDesc.Text.Trim());

 if (loc.Name.Length == 0) s="<none>"; else s = loc.Name;
 listChildren.SelectedItems[0].Text = s;
 
 if (loc.Desc.Length == 0) s="<none>"; else s = loc.Desc;
 listChildren.SelectedItems[0].SubItems[1].Text = loc.Desc;

 LVPicLoc.ResizeColumns(listChildren);

 picLoc.Refresh();
}

private void btnEditLocation_Click(object sender, EventArgs e) // open the selected sub "parent" location in a new instance of the this dialog
{
 PictureDlg dlg;
 PictureLocation loc;

 if (listChildren.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a sub location to edit then try again");
   return;
  }

 loc = ((LVPicLoc)listChildren.SelectedItems[0]).PicLoc;

 if (loc.File.Length == 0)
  {
   MainWnd.Response("The selected sub location has no picture, it's a final destintation location for inventory.  It doesn't need to be opened, sub locations cannot be added to it.");
   return;
  }

 dlg = new PictureDlg(loc);
 dlg.ShowDialog();
 dlg.Dispose();

 listChildren.Items.Remove(listChildren.SelectedItems[0]);
 listChildren.Items.Add(new LVPicLoc(loc));
 listChildren.Sort();
 LVPicLoc.ResizeColumns(listChildren);

 picLoc.Refresh();
}

private void btnDropChild_Click(object sender, EventArgs e) // delete the selected sub location
{
 PictureLocation loc;

 if (listChildren.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a sub location to delete then try again");
   return;
  }

 loc = ((LVPicLoc)listChildren.SelectedItems[0]).PicLoc;

 if (PictureLocation.CheckForInventory(loc) == true)
  {
   MainWnd.Response("The selected sub location has inventory items assigned to it, they must be moved to a different location before this sub location can be dropped.");
   return;
  }

 if (MainWnd.Question("Delete sub location '" + loc.Name + "' ID=" + loc.ID.ToString() + " ?", MessageBoxButtons.OKCancel) == DialogResult.OK)
  {
   PictureLocation.DeleteRow(loc);
   listChildren.Items.Remove(listChildren.SelectedItems[0]);
  }

 picLoc.Refresh();
}

private void btnSetPic_Click(object sender, EventArgs e) // set the picture of the dialog's current parent location
{
 OpenFileDlg dlg;
 Image jpg;
 string img;

 dlg = new OpenFileDlg(this, OpenFileDlg.FileTypes.Picture);

 if (dlg.ShowDialog() == DialogResult.OK)
  {
   txtFile.Text = dlg.FileName;
   img = Globals.ImageDirectory + "\\" + txtFile.Text;
   try
    {
     jpg = Image.FromFile(img);
     if (picLoc.Image != null)
       picLoc.Image.Dispose();
     picLoc.Image = (Image)jpg.Clone();
     jpg.Dispose();
     if (PicLoc != null)
      {
       PicLoc.UpdateFile(img);
      }
    }
   catch(Exception)
    {
     MainWnd.Response("Unable to open image '" + img + "'");
     return;
    }
      
  }

 dlg.Dispose();

 picLoc.Refresh();
}

private void listChildren_ColumnClick(object sender, ColumnClickEventArgs e)
{
 LVPicLocSorter.SortColumn sort = LVPicLoc.GetColumn(e.Column);

 if (CurrentSort == sort)
   CurrentAscending = !CurrentAscending;
 else
  {
   CurrentSort = sort;
   CurrentAscending = true;
  }

 listChildren.ListViewItemSorter = new LVPicLocSorter(CurrentSort, CurrentAscending); 
 listChildren.Sort();
}

private void listChildren_SelectedIndexChanged(object sender, EventArgs e)
{
 PictureLocation loc;

 if (listChildren.SelectedItems.Count == 0)
   return;

 loc = ((LVPicLoc)listChildren.SelectedItems[0]).PicLoc;

 txtSubName.Text = loc.Name;

 InhibitOrderUpdate = true;
 if (loc.Order == 0)
   txtOrder.Text = "";
 else
   txtOrder.Text = loc.Order.ToString();
 InhibitOrderUpdate = false;

 txtSubDesc.Text = loc.Desc;

 StartPoint = new Point(loc.Location.X, loc.Location.Y);
 EndPoint = new Point(loc.Location.X + loc.Location.Width, loc.Location.Y + loc.Location.Height);

 RectPresent = true; 
 picLoc.Refresh();
}

private void btnSave_Click(object sender, EventArgs e) // save the text of the current parent location 
{
 string name, desc;

 name = txtName.Text.Trim();
 desc = txtDesc.Text.Trim();

 PicLoc.UpdateText(name, desc);
}

private void btnOK_Click(object sender, EventArgs e)
{
 Close();
}

protected override void OnResize(EventArgs e)
{
 base.OnResize(e);

 int h, g, w;

 g = 5;
 w = ClientSize.Width - g * 2;
 h = ClientSize.Height - (pnlControls.Height + listChildren.Height + g * 4);

 picLoc.Location = new Point(g, g);
 picLoc.Size = new Size(w, h); 

 listChildren.Location = new Point(g, picLoc.Height + g);
 listChildren.Size= new Size(w, listChildren.Height);

 pnlControls.Location = new Point(g, listChildren.Top + listChildren.Height + g);
 pnlControls.Size = new Size(w, pnlControls.Height);

 picLoc.Refresh();

}

private void picLoc_MouseDown(object sender, MouseEventArgs e)
{
 StartPoint = e.Location;
 MouseCaptured = true;
}

private void picLoc_MouseMove(object sender, MouseEventArgs e)
{
 if (MouseCaptured == true)
  {
   EndPoint = e.Location;
   RectPresent = true;
   picLoc.Refresh();
  }
}

private void picLoc_MouseLeave(object sender, EventArgs e)
{
 MouseCaptured = false;
}

private void picLoc_MouseUp(object sender, MouseEventArgs e)
{
 if (MouseCaptured == true)
  {
   EndPoint = e.Location;
   picLoc.Refresh();
  }
 MouseCaptured = false;
}

private void picLoc_Paint(object sender, PaintEventArgs e)
{
 Rectangle rct;
 string name;
 PointF pt;
 SizeF sz;

 base.OnPaint(e);

 name = txtSubName.Text.Trim();

 if (RectPresent == true)
  {
   rct = Utility.GetRect(StartPoint, EndPoint);
   e.Graphics.DrawRectangle(ChildPen, rct);
   if (name.Length > 0)
    {
     sz = e.Graphics.MeasureString(name, ChildFont);
     pt = new PointF((float)rct.X + (rct.Width/2 - sz.Width/2), (float)rct.Y + (rct.Height/2 - sz.Height/2));
     e.Graphics.DrawString(name, ChildFont, ChildBrush, pt);
    }
  }
}

private void btnSetRect_Click(object sender, EventArgs e)  // this saves the selected sub loc rectangle & line with and color
{
 RectDlg dlg;

 dlg = new RectDlg(this, PenColor, PenWidth);
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   PenColor = dlg.RectColor;
   PenWidth = dlg.LineWidth;
   ChildBrush.Dispose();
   ChildBrush = new SolidBrush(PenColor);
   ChildPen.Dispose();
   ChildPen = new Pen(PenColor,PenWidth);
   picLoc.Refresh();
  }
}

private void btnMoveSubItems_Click(object sender, EventArgs e) // change all inventory from one location to another
{
 PictureLocPickDlg dlg;
 PictureLocation plFrom, plTo;
 uint c;
 string txt;

 if (listChildren.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a child sub location in the list to move inventory items from then try again");
   return;
  }

 plFrom = ((LVPicLoc)listChildren.SelectedItems[0]).PicLoc;

 if (plFrom.IsBottomLevel == false)
  {
   MainWnd.Response("The selected picture location is not the final destination bottom level for storing inventory items.");
   return;
  }

 c = plFrom.GetInvCount();

 if (c == 0)
  {
   MainWnd.Response("The selected picture location does not contain any inventory items");
   return;
  }

 dlg = new PictureLocPickDlg();
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   plTo = dlg.SubPicLoc;

   txt = "Move " + c.ToString() + " inventory items from " + plFrom.ToString() + " ID " + plFrom.ID.ToString() + "\n\n";
   txt += "To " + plTo.ToString() + " ID " + plTo.ID.ToString() + " ???";
 
   if (MainWnd.Question(txt, MessageBoxButtons.OKCancel) == DialogResult.OK)
    {
     InventoryItem.MoveInventory(plFrom, plTo);
     listChildren.SelectedItems[0].SubItems[3].Text = "0";
     listChildren.Sort();
    }
  }
 dlg.Dispose();

}

private void txtOrder_TextChanged(object sender, EventArgs e)
{
 PictureLocation loc;
 string s;
 int ord;

 if (InhibitOrderUpdate == true)
   return;

 if (listChildren.SelectedItems.Count == 0)
   return;

 s = txtOrder.Text.Trim();

 if (s.Length == 0)
   ord = 0;
 else
  {
   if (int.TryParse(s, out ord) == false)
     return;
   if (ord < 0)
   return;
  }

 loc = ((LVPicLoc)listChildren.SelectedItems[0]).PicLoc;

 loc.UpdateOrder(ord);

 if (ord == 0)
   s = "";
 else
   s = ord.ToString();

 listChildren.SelectedItems[0].SubItems[1].Text = s;
 listChildren.Sort();

}

private void btnMoveToName_Click(object sender, EventArgs e)
{
 NameLocPickDlg dlg;
 PictureLocation plFrom;
 NameLocation nlTo;
 string txt;
 uint c;

 if (listChildren.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a child sub location in the list to move inventory items from then try again");
   return;
  }

 plFrom = ((LVPicLoc)listChildren.SelectedItems[0]).PicLoc;

 if (plFrom.IsBottomLevel == false)
  {
   MainWnd.Response("The selected picture location is not the final destination bottom level for storing inventory items.");
   return;
  }

 c = plFrom.GetInvCount();

 if (c == 0)
  {
   MainWnd.Response("The selected picture location does not contain any inventory items");
   return;
  }

 dlg = new NameLocPickDlg(this, true);
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   nlTo = dlg.NameLoc;

   txt = "Move " + c.ToString() + " inventory items from " + plFrom.ToString() + " ID " + plFrom.ID.ToString() + "\n\n";
   txt += "To " + nlTo.Name + " ID " + nlTo.ID.ToString() + " ???";
 
   if (MainWnd.Question(txt, MessageBoxButtons.OKCancel) == DialogResult.OK)
    {
     InventoryItem.MoveInventory(plFrom, nlTo);
     listChildren.SelectedItems[0].SubItems[3].Text = "0";
     listChildren.Sort();
    }
  }
 dlg.Dispose();

}

};

public class LVPicLoc : ListViewItem
{
 public PictureLocation PicLoc { get; private set; }
 public uint InvCount { get; private set; }

public LVPicLoc(PictureLocation loc)
{
 string sr;

 PicLoc = loc;

 if (PicLoc.Name.Length == 0)
   Text = "<none>";
 else
   Text = PicLoc.Name;

 if (PicLoc.Order == 0)
   SubItems.Add("");
 else
   SubItems.Add(PicLoc.Order.ToString());

 if (PicLoc.File.Length == 0)
   SubItems.Add("<none>");
 else
   SubItems.Add(PicLoc.File);

 if (loc.IsBottomLevel == false)
  {
   SubItems.Add("N/A");
   InvCount = 0;
  }
 else
  {
   InvCount = loc.GetInvCount();
   SubItems.Add(InvCount.ToString());
  }

 if (PicLoc.Location.Width > 0 && PicLoc.Location.Height > 0)
  {
   sr = PicLoc.Location.X.ToString() + ", ";
   sr += PicLoc.Location.Y.ToString() + ", ";
   sr += PicLoc.Location.Width.ToString() + ", ";
   sr += PicLoc.Location.Height.ToString();
  }
 else
   sr = "None";
 SubItems.Add(sr);

 SubItems.Add(PicLoc.ID.ToString());

}

public static void AddHeaders(ListView list)
{
 list.Columns.Clear();

 list.Columns.Add("c1", "Name");
 list.Columns.Add("c2", "Order", 40, HorizontalAlignment.Right, "");
 list.Columns.Add("c3", "File Name");
 list.Columns.Add("c4", "Inv Count", 40, HorizontalAlignment.Right, "");
 list.Columns.Add("c5", "Rectangle");
 list.Columns.Add("c6", "ID");
}

public static void ResizeColumns(ListView lv)
{
 lv.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
 lv.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
 lv.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
}

public static LVPicLocSorter.SortColumn GetColumn(int headerClicked)
{
 switch(headerClicked)
  {
   case 0: return LVPicLocSorter.SortColumn.Name;
   case 1: return LVPicLocSorter.SortColumn.Order;
   case 2: return LVPicLocSorter.SortColumn.FileName;
   case 3: return LVPicLocSorter.SortColumn.Count;
   case 4: return LVPicLocSorter.SortColumn.Rectangle;
   case 5: return LVPicLocSorter.SortColumn.ID;
   default: throw new Exception("un-handled sort column");
  }
}

};

public class LVPicLocSorter : IComparer
{
 public enum SortColumn : int { Order, Name, FileName, Count, Rectangle, ID }
 
 public SortColumn Column { get; private set; }
 public bool Ascending { get; private set; }

public LVPicLocSorter(SortColumn col, bool asc)
{
 Column = col;
 Ascending = asc;
}

public int Compare(Object x, Object y)
{
 LVPicLoc cx, cy;

 if (Ascending == true)
  {
   cx = (LVPicLoc)x;
   cy = (LVPicLoc)y;
  }
 else 
  {
   cx = (LVPicLoc)y;
   cy = (LVPicLoc)x;
  }

 switch(Column)
  {
   case SortColumn.Order:
    {
     if (cx.PicLoc.Order > cy.PicLoc.Order) return 1;
     if (cx.PicLoc.Order < cy.PicLoc.Order) return -1;
     return 0;
    }
   case SortColumn.Name: return string.Compare(cx.PicLoc.Name, cy.PicLoc.Name);
   case SortColumn.FileName: return string.Compare(cx.PicLoc.File, cy.PicLoc.File);
   case SortColumn.Count:
    {
     if (cx.InvCount > cy.InvCount) return 1;
     if (cx.InvCount < cy.InvCount) return -1;
     return 0;
    }
   case SortColumn.Rectangle:
    {
     if (cx.PicLoc.Location.Y > cy.PicLoc.Location.Y) return 1;
     if (cx.PicLoc.Location.Y < cy.PicLoc.Location.Y) return -1;
     if (cy.PicLoc.Location.X > cy.PicLoc.Location.X) return 1;
     if (cy.PicLoc.Location.X < cy.PicLoc.Location.X) return -1;
     return 0;
    }
   case SortColumn.ID:
    {
     if (cx.PicLoc.ID > cy.PicLoc.ID) return 1;
     if (cx.PicLoc.ID < cy.PicLoc.ID) return -1;
     return 0;
    }
   default: throw new Exception("unhandled sort enum");
  }
}

};

}