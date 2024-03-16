using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Inventory
{
public partial class MainWnd : Form
{
 public enum PropCompare : int { Ignore, LT, LTE, EQ, GT, GTE, Range };

 public PropCompare CurrentCompare { get; private set; }
 public bool NoProperties { get; private set; }

 private LVItemSorter.SortColumn ItemSortColumn;
 private bool ItemSortAscending;

 private const String AppName = "Inventory";

 private InventoryCategory QueryCategory;
 private int QueryPopRow;

public MainWnd()
{
 int i;
 uint cat;

 InitializeComponent();
 
 Globals.SetWnd(this);
 Globals.SetDateFormat("MMM d yyyy");
 Globals.Init();  // establish directories

 //DBTTest test = new DBTTest();
 //test.AddRows();
 //test.GetLists();
 //MessageBox.Show("done");

 LoadCategories();


 ItemSortColumn = LVItemSorter.SortColumn.Name;
 ItemSortAscending = true;

 cat = GetSettingUInt("MainWnd::SelectedCategory");
 if (cat > 0)
  {
   i= 0;
   foreach(CBCategoryItem c in cboCategory.Items)
    {
     if (c.Category.ID == cat)
      {
       cboCategory.SelectedIndex = i;
       break;
      }
     i++;
    }
  }
 else
  {
   cboCategory.SelectedIndex = 0;
  }

 cboCompare.SelectedIndex = 0;

 Utility.LoadWindowSetting(this);

 sbMessage.Text = "";  // blank out the status bar
}

protected override void OnSizeChanged(EventArgs e)
{
 base.OnSizeChanged(e);

 pnlSearch.Top = toolStrip1.Height;
 pnlSearch.Left = 0;
 pnlSearch.Width = ClientSize.Width;

 listInv.Top = pnlSearch.Top + pnlSearch.Height;
 listInv.Left = 0;
 listInv.Width = ClientSize.Width;
 listInv.Height = ClientSize.Height - (toolStrip1.Height + pnlSearch.Height + statusStrip1.Height);

}

// Utility

private void LoadCategories()
{
 List<InventoryCategory> cats = InventoryCategory.GetCategories();
 uint selected = 0;
 bool wasSelected = false;
 int i;

 if (cboCategory.SelectedIndex >= 0)
  {
   selected = ((CBCategoryItem)cboCategory.Items[cboCategory.SelectedIndex]).Category.ID;
   wasSelected = true;
  }

 cboCategory.Items.Clear();

 foreach(InventoryCategory c in cats)
  {
   cboCategory.Items.Add(new CBCategoryItem(c));
  }

 if (wasSelected == true)
  {
   i = 0;
   foreach(CBCategoryItem c in cboCategory.Items)
    {
     if (c.Category.ID == selected)
      {
       cboCategory.SelectedIndex = i;
       break;
      }
     i++;
    }
  }

}

public static string GetDateString(DateTime date)
{
 if (date == DateTime.MinValue)
   return "";
 else 
   return date.ToString(Globals.DateFormat);
}


// Local Machine Specific Settings (Using the Microsoft.VisualBasic library to write to the registry)

public static void SaveRegSetting(string strThing, String strVal)
{  
 Microsoft.VisualBasic.Interaction.SaveSetting(AppName, "Setting", strThing, strVal);
}

public static void SaveRegSettingInt(string strThing,int nVal)
{
 Microsoft.VisualBasic.Interaction.SaveSetting(AppName, "Setting", strThing, nVal.ToString());
}

public static void SaveRegSettingDbl(string strthing,double dbl)
{
 Microsoft.VisualBasic.Interaction.SaveSetting(AppName, "Setting", strthing, dbl.ToString());
} 

public static string GetRegSetting(string strThing)
{
 return Microsoft.VisualBasic.Interaction.GetSetting(AppName, "Setting", strThing, "");
}

public static int GetRegSettingInt(string strThing)
{
 string s;
 int i;
  

 s = Microsoft.VisualBasic.Interaction.GetSetting(AppName, "Setting", strThing, "0");
 if (int.TryParse(s,out i) == false) i = 0;
  return i;
}

public static double GetRegSettingDbl(string strThing)
{
 string s;
 double d;

 s = Microsoft.VisualBasic.Interaction.GetSetting(AppName, "Setting", strThing, "0");
 if (double.TryParse(s,out d) == false) d = 0;
 return d;
}

public static string GetRegSetting(string strThing, string strDefault)
{
 return Microsoft.VisualBasic.Interaction.GetSetting(AppName, "Setting", strThing, strDefault);
}

// User Specific Settings (Using the Microsoft.VisualBasic library to write to the registry)

public static void SaveSettingInt(string strThing,int nVal)
{
 SaveSetting(strThing, nVal.ToString());
}

public static void SaveSettingUInt(string strThing, uint val)
{
 SaveSetting(strThing, val.ToString());
}

public static void SaveSettingBool(string strThing, bool val)
{
 if (val == true)
   SaveSetting(strThing, "T");
 else
   SaveSetting(strThing, "F");
}

public static void SaveSettingDbl(string strthing,double dbl)
{
 SaveSetting(strthing, dbl.ToString());
} 

public static void SaveSetting(string strThing, string strVal)
{
 MySqlCommand cmd;
 string q;

  q="CALL user_settings_update_proc(@app, @name, @set, @val); ";

 cmd = new MySqlCommand(q, DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@app", AppName)); 
 cmd.Parameters.Add(new MySqlParameter("@name", DB.UserName));
 cmd.Parameters.Add(new MySqlParameter("@set", strThing));
 cmd.Parameters.Add(new MySqlParameter("@val", strVal));

 cmd.ExecuteNonQuery();
}

public static int GetSettingInt(string strThing)
{
 string s;
 int i;

 s = GetSetting(strThing, "0");
 if (int.TryParse(s,out i) == false) i = 0;
 return i;
}

public static uint GetSettingUInt(string strThing)
{
 string s;
 uint i;

 s = GetSetting(strThing, "0");
 if (uint.TryParse(s,out i) == false) i = 0;
 return i;
}

public static bool GetSettingBool(string strThing)
{
 string s;

 s = GetSetting(strThing, "F");
 if (s == "T")
   return true;
 else
   return false;
}

public static double GetSettingDbl(string strThing)
{
 string s;
 double d;

 s = GetSetting(strThing, "0");
 if (double.TryParse(s,out d) == false) d = 0;
 return d;
}

public static string GetSetting(string strThing, string strDefault)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 string q, val;

 q="SELECT setting_value ";
 q+="FROM user_settings ";
 q+="WHERE app_name=@app AND user_name=@name AND setting_name=@set;";
 
 cmd = new MySqlCommand(q, DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@app", AppName)); 
 cmd.Parameters.Add(new MySqlParameter("@name", DB.UserName));
 cmd.Parameters.Add(new MySqlParameter("@set", strThing));
 rs=cmd.ExecuteReader();

 val=strDefault;

 if (rs.Read() == true)
   val=rs.GetString(0);
 rs.Close();
 
 return val;
}

// Messsaging

public static DialogResult Question(String strPrompt, MessageBoxButtons btns)
{
 DialogResult res;

 res = MessageBox.Show(strPrompt, AppName, btns, MessageBoxIcon.Question);

 return res;
}

public static void Response(String strResponse)
{
 MessageBox.Show(strResponse, AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
}

// Overrides

protected override void OnClosing(CancelEventArgs e)
{
 base.OnClosing(e);

 if (this.IsDisposed)
   return;

 if (this.WindowState == FormWindowState.Minimized)
   this.WindowState = FormWindowState.Normal;

 if (this.WindowState == FormWindowState.Maximized)
   SaveSettingBool("MainWnd::IsMaximized", true);
 else
  {
   SaveSettingBool("MainWnd::IsMaximized", false);
   SaveSetting("MainWnd::Top", this.Top.ToString());
   SaveSetting("MainWnd::Left", this.Left.ToString());
   SaveSetting("MainWnd::Width", this.Width.ToString());
   SaveSetting("MainWnd::Height", this.Height.ToString());
  }
}

public static PictureLocation AddParentPictureLocation(Form par)
{
 PictureDlg pDlg;
 PictureLocation picLoc;
 List<string> files = new List<string>();
 OpenFileDlg fDlg;

 if (Globals.ImageDirectory.Length == 0)
  {
   Response("Set the image directory path in File > Options");
   return null;
  }

 foreach(PictureLocation pl in PictureLocation.GetParentLocations())
  {
   files.Add(pl.File);
  }

 picLoc = null;

 fDlg = new OpenFileDlg(par, OpenFileDlg.FileTypes.Picture);
 if (fDlg.ShowDialog() == DialogResult.OK)
  {
   picLoc = new PictureLocation(fDlg.FileName);
   pDlg = new PictureDlg(picLoc);
   pDlg.ShowDialog();
   pDlg.Dispose();
  }
 fDlg.Dispose();

 return picLoc;
}


// Control Events

private void mnuFileAddPicLoc_Click(object sender, EventArgs e)
{
 AddParentPictureLocation(this);
}

private void mnuFileAddNameLoc_Click(object sender, EventArgs e)
{
 NameLocEditDlg dlg;
 NameLocation loc;

 dlg = new NameLocEditDlg(this);
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   loc = new NameLocation(dlg.LocName, dlg.LocDesc);   
  }
 dlg.Dispose();
}

private void mnuFileAddCategory_Click(object sender, EventArgs e)
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

private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
{
 InventoryCategoryProperty prop;
 InventoryCategory cat;

 if (cboCategory.SelectedIndex >= 0)
  {
   timerQueryPop.Enabled = false; // don't populate any more items, gonna empty the list
   listInv.Items.Clear();
   cat = ((CBCategoryItem)cboCategory.Items[cboCategory.SelectedIndex]).Category;
   SaveSettingUInt("MainWnd::SelectedCategory", cat.ID); 
   prop = cat.PrimaryProperty;
   if (prop != null)
    {
     cboCompare.Enabled = true;
     ShowCompareControls(CurrentCompare);
     NoProperties = false;
     lblPrimary.Text = cat.GetPrimaryProperty().PropertyName;
    }
   else 
    {
     cboCompare.Enabled = false;
     ShowCompareControls(PropCompare.Ignore);
     NoProperties = true;
    }
  }
}

private bool GetCompareValue(string val, string text, out float output)
{

 if (float.TryParse(val, out output) == false)
  {
   Response(text + " is not numeric");
   return false;
  }
 return true;
}

private void btnSearch_Click(object sender, EventArgs e)
{
 List<LVInvItem> list;
 MySqlCommand cmd;
 MySqlDataReader rs;
 InventoryCategory cat;
 float primaryVal, primaryVal2;
 string name;
 string sql, where, query;

 if (cboCategory.SelectedIndex < 0)
  {
   Response("Select a category to search");
   return;
  }

 cat = ((CBCategoryItem)cboCategory.Items[cboCategory.SelectedIndex]).Category;
 name = txtName.Text.Trim();
 primaryVal = 0;
 primaryVal2 = 0;
 where = "";

 if (NoProperties == true || CurrentCompare == PropCompare.Ignore)
  {
   sql = LVInvItem.SelectClauseNoProps;
  }
 else
  {
   sql = LVInvItem.SelectClauseProps;
   switch(CurrentCompare)
    {
     case PropCompare.Range:
      { 
       if (GetCompareValue(txtPrimary.Text.Trim(), "Range from", out primaryVal) == false) 
         return;
       if (GetCompareValue(txtPrimary2.Text.Trim(), "Range to", out primaryVal2) == false) 
         return;
       where = "AND b.prop_value BETWEEN @prime1 AND @prime2 ";
      } break;
     case PropCompare.LT:
      {
       if (GetCompareValue(txtPrimary.Text.Trim(), "Less than", out primaryVal) == false) 
         return;     
       where = "AND b.prop_value < @prime1 ";
      } break;
     case PropCompare.LTE:
      {
       if (GetCompareValue(txtPrimary.Text.Trim(), "Less than or equal", out primaryVal) == false) 
         return;     
       where = "AND b.prop_value <= @prime1 ";
      } break;
     case PropCompare.EQ:
      {
       if (GetCompareValue(txtPrimary.Text.Trim(), "Equal", out primaryVal) == false) 
         return;     
       where = "AND b.prop_value = @prime1 ";
      } break;
     case PropCompare.GT:
      {
       if (GetCompareValue(txtPrimary.Text.Trim(), "Greater than", out primaryVal) == false) 
         return;     
       where = "AND b.prop_value > @prime1 ";
      } break;
     case PropCompare.GTE:
      {
       if (GetCompareValue(txtPrimary.Text.Trim(), "Greater than or equal", out primaryVal) == false) 
         return;     
       where = "AND b.prop_value >= @prime1 ";
      } break;
     default: throw new Exception("compare not handled");
    }
  }

 if (name.Length > 0)
  {
   if (NoProperties == true || CurrentCompare == PropCompare.Ignore)
     where = "WHERE a.item_name LIKE @name ";
   else
     where += "AND a.item_name LIKE @name ";
  }

 if (where.Length == 0)
   where = "WHERE a.inv_cat_id=@cat;";
 else
   where += "AND a.inv_cat_id=@cat;";  // add termination

 query = sql + where;

 cmd = new MySqlCommand(query, DB.Con);

 if (NoProperties == false)
  {
   switch(CurrentCompare)
    {
     case PropCompare.Range:
      {
       cmd.Parameters.Add(new MySqlParameter("@prime1", primaryVal));
       cmd.Parameters.Add(new MySqlParameter("@prime2", primaryVal2));
      } break;
     case PropCompare.Ignore: break;
     default:
      {
       cmd.Parameters.Add(new MySqlParameter("@prime1", primaryVal));
      } break;
    }
  }
 if (name.Length > 0)
   cmd.Parameters.Add(new MySqlParameter("@name", name));

 cmd.Parameters.Add(new MySqlParameter("@cat", cat.ID)); 

 rs = cmd.ExecuteReader();

 list = LVInvItem.GetItems(cat, rs);
 rs.Close();

 listInv.Items.Clear();

 LVInvItem.AddColumns(listInv, cat);

 listInv.ListViewItemSorter = null;

 listInv.BeginUpdate();

 foreach(LVInvItem item in list)
   listInv.Items.Add(item);
 
 LVInvItem.ResizeColumns(listInv);

 listInv.EndUpdate();

 listInv.ListViewItemSorter = new LVItemSorter(ItemSortColumn, ItemSortAscending);
 listInv.Sort();

 sbMessage.Text = listInv.Items.Count + " " + cat.Name + " Items Found";

 QueryPopRow = 0;
 QueryCategory = cat;

 timerQueryPop.Enabled = true;  // fire off a timer that will populate item primary values and fill in blank inventory names

}

private void timerQueryPop_Tick(object sender, EventArgs e)
{
 LVInvItem item;
 string primaryVal;
 int i;

 if (QueryPopRow >= listInv.Items.Count)  // done querying for extra info?
  {
   timerQueryPop.Enabled = false;
   LVInvItem.ResizeColumns(listInv); // finished, now resize the columns again
   return;
  }
 
 for (i=0; i<100; i++)
  {
   if (QueryPopRow + i < listInv.Items.Count)
    {
     item = (LVInvItem)listInv.Items[QueryPopRow + i];
     primaryVal = LVInvItem.GetPrimaryValue(item.ItemID, item.InvCat);
     if (item.Text.Length == 0)
      {
       listInv.Items[QueryPopRow + i].Text = InventoryItem.GetBlankInvName(item.InvCat.Name, item.InvCat.PrimaryProperty.PropertyName, primaryVal);
      }
     listInv.Items[QueryPopRow + i].SubItems[2].Text = primaryVal;
    }
  }
 QueryPopRow += 100;
}


private void cboCompare_SelectedIndexChanged(object sender, EventArgs e)
{
 string cmp = cboCompare.Items[cboCompare.SelectedIndex].ToString();

 switch(cmp)
  {
   case "N/A": CurrentCompare = PropCompare.Ignore; break;
   case "<": CurrentCompare = PropCompare.LT; break;
   case "<=": CurrentCompare = PropCompare.LTE; break;
   case "=": CurrentCompare = PropCompare.EQ; break;
   case ">": CurrentCompare = PropCompare.GT; break;
   case ">=": CurrentCompare = PropCompare.GTE; break;
   case "RNG": CurrentCompare = PropCompare.Range; break;
   default: throw new Exception("invalid cbo value");
  }
 ShowCompareControls(CurrentCompare);
}

private void ShowCompareControls(PropCompare compare)
{
 switch(compare)
  {
   case PropCompare.Ignore: 
     {
      txtPrimary.Visible = false;
      txtPrimary2.Visible = false;
      btnSearch.Left = cboCompare.Left + cboCompare.Width + 5;
     } break;
   case PropCompare.Range:
    {
     txtPrimary.Visible = true;
     txtPrimary2.Visible = true;
     btnSearch.Left = txtPrimary2.Left + txtPrimary2.Width + 5;
    } break;
   default:
    {
     txtPrimary.Visible = true;
     txtPrimary2.Visible = false;
     btnSearch.Left = txtPrimary.Left + txtPrimary.Width + 5;
    } break;
  }

}

private void listInv_ColumnClick(object sender, ColumnClickEventArgs e)
{
 LVItemSorter.SortColumn newVal;

 newVal = LVInvItem.GetColumn(e.Column);

 if (newVal == ItemSortColumn)
  {
   ItemSortAscending = !ItemSortAscending;
  }
 else
  {
   ItemSortColumn = newVal;
   ItemSortAscending = true;
  }
 listInv.ListViewItemSorter = new LVItemSorter(ItemSortColumn, ItemSortAscending);
 listInv.Sort();

}

private void listInv_DoubleClick(object sender, EventArgs e)
{
 OpenItem();
}

private void OpenItem()
{
 InventoryItem item;
 InvItemDlg dlg;
 LVInvItem lvItem;

 if (listInv.SelectedItems.Count == 0)
   return;

 lvItem = (LVInvItem)listInv.SelectedItems[0];

 item = InventoryItem.GetSingleItem(lvItem.ItemID);

 if (item == null)
  {
   Response("Error retrieveing Item from dateabase");
   return;
  }
 
 dlg = new InvItemDlg(this, item);
 dlg.ShowDialog();
 dlg.Dispose();

 item = InventoryItem.GetSingleItem(lvItem.ItemID);
 
 ((LVInvItem)listInv.SelectedItems[0]).UpdateText(item);

}

private void mnuFileOptions_Click(object sender, EventArgs e)
{
 OptionsDlg dlg;

 dlg = new OptionsDlg(this);

 dlg.ShowDialog();
 dlg.Dispose();
}

private void mnuViewPicLoc_Click(object sender, EventArgs e)
{
 PictureChooseDlg dlg;

 dlg = new PictureChooseDlg(this);
 dlg.ShowDialog();
 dlg.Dispose();
}

private void mnuViewNameLoc_Click(object sender, EventArgs e)
{
 NameLocPickDlg dlg;

 dlg = new NameLocPickDlg(this, false);
 dlg.ShowDialog();
 dlg.Dispose();
}

private void mnuFileAddInvPic_Click(object sender, EventArgs e)
{
 PictureLocPickDlg pDlg;
 InventoryAddDlg iDlg;
 InvItemDlg dlg;
 InventoryLocation loc;
 InventoryItem item; 

 pDlg = new PictureLocPickDlg();

 if (pDlg.ShowDialog() == DialogResult.OK)
  {
   loc = new InventoryLocation(pDlg.SubPicLoc);
   iDlg = new InventoryAddDlg(this, loc);
   if (iDlg.ShowDialog() == DialogResult.OK)
    {
     item = new InventoryItem(iDlg.InvLoc, iDlg.Category, iDlg.Quantity, iDlg.Price, iDlg.InvName, "", "");
     foreach(InventoryCategoryValue v in iDlg.CategoryValues)
      {
       item.CategoryValues.Add(new InventoryCategoryValue(item.ID, iDlg.Category, v.CatProp, v.Value));
      }
     dlg = new InvItemDlg(this, item);
     dlg.ShowDialog();
     dlg.Dispose();
    }
   iDlg.Dispose();
  }
 pDlg.Dispose();
}

private void mnuFileAddInvName_Click(object sender, EventArgs e)
{
 NameLocPickDlg pDlg;
 InventoryAddDlg iDlg;
 InvItemDlg dlg;
 InventoryLocation loc;
 InventoryItem item; 

 pDlg = new NameLocPickDlg(this, true);

 if (pDlg.ShowDialog() == DialogResult.OK)
  {
   loc = new InventoryLocation(pDlg.NameLoc);
   iDlg = new InventoryAddDlg(this, loc);
   if (iDlg.ShowDialog() == DialogResult.OK)
    {
     item = new InventoryItem(iDlg.InvLoc, iDlg.Category, iDlg.Quantity, iDlg.Price, iDlg.InvName, "", "");
     foreach(InventoryCategoryValue v in iDlg.CategoryValues)
      {
       item.CategoryValues.Add(new InventoryCategoryValue(item.ID, iDlg.Category, v.CatProp, v.Value));
      }
     dlg = new InvItemDlg(this, item);
     dlg.ShowDialog();
     dlg.Dispose();
    }
   iDlg.Dispose();
  }
 pDlg.Dispose();
}

private void popUpView_Click(object sender, EventArgs e)
{
 PictureWalkWnd wnd;
 InventoryItem item;
 uint id;

 if (listInv.SelectedItems.Count == 0)
   return;

 id = ((LVInvItem)listInv.SelectedItems[0]).ItemID;

 item = InventoryItem.GetSingleItem(id);

 if (item.InvLoc.InvLocType == InventoryLocation.LocationType.Name)
  {
   MainWnd.Response(item.InvLoc.ToString());
  }
 else
  {
   wnd = new PictureWalkWnd(item.InvLoc.PicLoc);
   wnd.ShowDialog();
   wnd.Dispose();
  }
}

private void popUpRemove_Click(object sender, EventArgs e)
{
 InventoryItem item;
 string q;
 uint id;

 if (listInv.SelectedItems.Count == 0)
   return;

 id = ((LVInvItem)listInv.SelectedItems[0]).ItemID;

 item = InventoryItem.GetSingleItem(id);

 if (item == null)
  {
   Response("Inventory row ID " + id.ToString() + " not found on database");
   return;
  }

 q = "Delete Item " + item.ToString() + " ID " + item.ID.ToString() + "?\n\n";
 q += "All associated files will be deleted as well";

 if (Question(q, MessageBoxButtons.OKCancel) == DialogResult.OK)
  {
   if (item.Delete() == true)
    {
     listInv.Items.Remove(listInv.SelectedItems[0]);
     MainWnd.Response(item.ToString() + " Removed");
    }
  }
}

private void popUpOpen_Click(object sender, EventArgs e)
{
 OpenItem();
}

private void mnuViewAdvancedSearch_Click(object sender, EventArgs e)
{
 InventorySearchDlg dlg;

 dlg = new InventorySearchDlg(this);
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   listInv.Items.Clear();
   LVInvItem.AddColumns(listInv, dlg.InvCat);
   foreach(LVInvItem item in dlg.Results)
     listInv.Items.Add(item);
 
 LVInvItem.ResizeColumns(listInv);

 listInv.ListViewItemSorter = new LVItemSorter(ItemSortColumn, ItemSortAscending);
 listInv.Sort();

 sbMessage.Text = listInv.Items.Count + " Items Found";

 QueryPopRow = 0;
 QueryCategory = null;

 timerQueryPop.Enabled = true;  // fire off a timer that will populate item primary values and fill in blank inventory names

  }
 dlg.Dispose();
}

private void mnuHelpAbout_Click(object sender, EventArgs e)
{
 AboutDlg dlg = new AboutDlg();

 dlg.ShowDialog();
 dlg.Dispose();
}

private void mnuViewCategory_Click(object sender, EventArgs e)
{
 CategoryPickDlg dlg;

 dlg = new CategoryPickDlg(this, false);
 dlg.ShowDialog();
 dlg.Dispose();

 LoadCategories();  // in case names changed, categories removed
}

};

// control items

public class CBCategoryItem
{
 public InventoryCategory Category { get; private set; }

public CBCategoryItem(in InventoryCategory cat)
{
 Category = cat;
}

public override string ToString()
{
 if (Category == null)
   return "<None>";
 else
   return Category.Name;
}
};

}
