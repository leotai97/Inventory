using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{

public partial class PictureWalkWnd : Form
{
 private List<PictureLocation> listPic;
 private int Indexer = 0;

public PictureWalkWnd(in PictureLocation loc)
{
 InitializeComponent();

 Utility.LoadWindowSetting(this); 

 listPic = new List<PictureLocation>();

 picLoc.Dock = DockStyle.Fill;
 WalkPics(loc);
 
 listPic.Reverse();

 SetPicture();

 timerPics.Enabled = true;
}

protected override void OnClosing(CancelEventArgs e)
{
 base.OnClosing(e);
 Utility.SaveWindowSetting(this);
}

private void WalkPics(in PictureLocation loc)
{
 if (loc.Parent != null)
  {
   listPic.Add(loc);
   WalkPics(loc.Parent);
  }
}

private void timerPics_Tick(object sender, EventArgs e)
{
 AdvanceLocation();
 SetPicture();
}

private void SetPicture()
{
 if (picLoc.Image != null)
   picLoc.Image.Dispose();

 picLoc.Image = Globals.GetLocationPicture(listPic[Indexer].Parent);
 picLoc.Refresh();
}

private void AdvanceLocation()
{
 Indexer++;

 if (Indexer >= listPic.Count)
   Indexer = 0; 
}

private void picLoc_Paint(object sender, PaintEventArgs e)
{
 PictureLocation sl = listPic[Indexer];
 Rectangle rct;
 Brush childBrush;
 Font childFont;
 PointF pt;
 SizeF sz;
 Pen childPen;
 
 rct = sl.Location;
 childPen = new Pen(sl.LineColor, sl.LineWidth);
 childPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
 childFont = new Font(FontFamily.GenericSansSerif, 14);
 childBrush = new SolidBrush(sl.LineColor);
 e.Graphics.DrawRectangle(childPen, rct);
 if (sl.Name.Length > 0)
  {
   sz = e.Graphics.MeasureString(sl.Name, childFont);
   pt = new PointF((float)rct.X + (rct.Width/2 - sz.Width/2), (float)rct.Y + (rct.Height/2 - sz.Height/2));
   e.Graphics.DrawString(sl.Name, childFont, childBrush, pt);
  }
 childFont.Dispose();
 childPen.Dispose();
 childBrush.Dispose();
}

};
}
