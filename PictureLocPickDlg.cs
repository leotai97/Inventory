using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZstdSharp.Unsafe;

namespace Inventory
{
public partial class PictureLocPickDlg : Form
{
 public PictureLocation SubPicLoc { get; private set; }

 private Stack<PictureLocation> LocStack = new Stack<PictureLocation>();

 private Font ChildFont = new Font(FontFamily.GenericSansSerif, 14);

 private PictureLocation HoveredSubLoc = null;

public PictureLocPickDlg()
{
 InitializeComponent();
 
 LoadItems();
 
 listPics.Visible = true;
 listPics.Dock = DockStyle.Fill;

 picLocation.Visible = false;
 picLocation.Dock = DockStyle.Fill;

 Utility.LoadWindowSetting(this);

}

protected override void OnClosing(CancelEventArgs e)
{
 base.OnClosing(e);
 Utility.SaveWindowSetting(this);
 ChildFont.Dispose();
}

protected override void OnResizeEnd(EventArgs e)
{
 base.OnResizeEnd(e);  
 picLocation.Refresh();
}

private void LoadItems()
{
 List<PictureLocation> list;
 Image thumb;
 LVPicLoc item;

 listPics.Items.Clear();

 list = PictureLocation.GetParentLocations();
 
 imageList1.Images.Clear();
 
 Cursor = Cursors.WaitCursor;
 
 foreach(PictureLocation pl in list)
  {
   thumb = Globals.GeLocationThumb(pl);
   if (thumb == null)
     break;  // problem loading images
   else
    {
     imageList1.Images.Add(pl.Key, thumb);
    }
   item = new LVPicLoc(pl);
   item.ImageKey = pl.Key;
   listPics.Items.Add(item);
  }

 listPics.LargeImageList = imageList1;

 Cursor = Cursors.Default;
}

private void SetPicture(in PictureLocation loc)
{
 if (picLocation.Image != null)
  {
   picLocation.Image.Dispose();
  }

 picLocation.Image = (Image)Globals.GetLocationPicture(loc);

}

private void PushPicLoc(in PictureLocation loc)
{

 LocStack.Push(loc);

 listPics.Visible = false;
 picLocation.Visible = true;
 picLocation.Image = Globals.GetLocationPicture(loc);
 picLocation.Refresh(); 
  
}

private void PopPicLoc()
{
 LocStack.Pop();
 if (LocStack.Count == 0)
  {
   picLocation.Visible = false;
   listPics.Visible = true;
  }
 else
  {
   if (picLocation.Image != null)
     picLocation.Image.Dispose();
   picLocation.Image = Globals.GetLocationPicture(LocStack.Peek());
   picLocation.Refresh();
  }
}

// events

private void listPics_SelectedIndexChanged(object sender, EventArgs e)
{
 PictureLocation loc;

 if (listPics.SelectedItems.Count == 0)
   return;

 loc = ((LVPicLoc)listPics.SelectedItems[0]).PicLoc;

 LocStack.Push(loc);

 listPics.Visible = false;
 picLocation.Visible = true;
 picLocation.Image = Globals.GetLocationPicture(loc);

 listPics.SelectedItems[0].Selected = false;

}

private void picLocation_MouseDown(object sender, MouseEventArgs e)
{
 PictureLocation loc = null;

 if (e.Button == MouseButtons.Right)
  {
   PopPicLoc();
  }
 if (e.Button == MouseButtons.Left)
  {
   if (LocStack.Count == 0)
     throw new Exception("picture should not be visible");
   foreach(PictureLocation sl in LocStack.Peek().Children)
    {
     if (sl.Location.Contains(e.Location) == true)
      {
       if (sl.IsBottomLevel == true)
        {
         loc = sl;
         break;
        }
       else
         PushPicLoc(sl); 
      }
    }
  }
 if (loc != null)
  {
   SubPicLoc = loc;
   DialogResult = DialogResult.OK;
  }
}

private void picLocation_MouseLeave(object sender, EventArgs e)
{
}

private void picLocation_MouseMove(object sender, MouseEventArgs e)
{
 bool found = false;
 bool change = false;

 if (LocStack.Count == 0)
   return;

 foreach(PictureLocation sl in LocStack.Peek().Children)
  {
   if (sl.Location.Contains(e.Location) == true)
    {
     if (HoveredSubLoc == null) 
       change = true;
     else
      {
       if (HoveredSubLoc.ID != sl.ID)
         change = true;
      }
     HoveredSubLoc = sl;
     found = true;
     break;
    }
  }

 if (found == false)
  {
   if (HoveredSubLoc != null)
     change = true;
   HoveredSubLoc = null;
  }

 if (change == true)
   picLocation.Refresh();
 
}

private void picLocation_MouseUp(object sender, MouseEventArgs e)
{

}

private void picLocation_Paint(object sender, PaintEventArgs e)
{
 Brush childBrush;
 Pen childPen;
 Rectangle rct;
 PointF pt;
 SizeF sz;

 base.OnPaint(e);

 if (LocStack.Count == 0)
   return;

 foreach(PictureLocation sl in LocStack.Peek().Children)
  {
   rct = sl.Location;
   childPen = new Pen(sl.LineColor, sl.LineWidth);
   childPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
   if (HoveredSubLoc != null)
    {
     if (HoveredSubLoc.ID == sl.ID)
       childPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
    }
   childBrush = new SolidBrush(sl.LineColor);
   e.Graphics.DrawRectangle(childPen, rct);
   if (sl.Name.Length > 0)
    {
     sz = e.Graphics.MeasureString(sl.Name, ChildFont);
     pt = new PointF((float)rct.X + (rct.Width/2 - sz.Width/2), (float)rct.Y + (rct.Height/2 - sz.Height/2));
     e.Graphics.DrawString(sl.Name, ChildFont, childBrush, pt);
    }
   childPen.Dispose();
   childBrush.Dispose();
  }
}

};

}
