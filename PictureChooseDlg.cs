using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{

public partial class PictureChooseDlg : Form
{

public PictureChooseDlg(Form par)
{
 
 Owner = par;
 
 InitializeComponent();

 LoadItems();

}

private void LoadItems()
{
 List<PictureLocation> list;
 LVPicLoc item;
 Image thumb;

 listPics.Items.Clear();

 list = PictureLocation.GetParentLocations();
 
 Cursor = Cursors.WaitCursor;

 imageList1.Images.Clear();
 
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

private void OpenItem()
{
 PictureDlg dlg;
 PictureLocation loc;

 if (listPics.SelectedItems.Count == 0)
   return;

 loc = ((LVPicLoc)listPics.SelectedItems[0]).PicLoc;
 dlg = new PictureDlg(loc);
 dlg.ShowDialog();
 dlg.Dispose();

 LoadItems();
}

// events

private void listPics_DoubleClick(object sender, EventArgs e)
{
 OpenItem();
}

private void btnAddPic_Click(object sender, EventArgs e) // add a new top level picture location
{

 MainWnd.AddParentPictureLocation(this);

 LoadItems();
}

private void btnDropLoc_Click(object sender, EventArgs e)
{
 PictureLocation loc;

 if (listPics.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a picture location to delete");
   return;
  }

 loc = ((LVPicLoc)listPics.SelectedItems[0]).PicLoc;

 if (PictureLocation.CheckForInventory(loc) == true)
  {
   MainWnd.Response("The selected picture location has inventory assigned to any number of sub locations underneath it, those items must be moved to another location before this one can be deleted.");
   return;
  }

 if (MainWnd.Question("Delete parent picture location '" + loc.Name + "' ID=" + loc.ID.ToString() + " ?", MessageBoxButtons.OKCancel) == DialogResult.OK)
  {
   PictureLocation.DeleteRow(loc);
   LoadItems();
  }

 PictureLocation.DeleteRow(loc);

}

private void btnEdit_Click(object sender, EventArgs e)
{
 OpenItem();
}

private void btnClose_Click(object sender, EventArgs e)
{
 Close();
}

};
}
