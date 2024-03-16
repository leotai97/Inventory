using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Inventory.MainWnd;
using static Org.BouncyCastle.Crypto.Digests.SkeinEngine;
using static System.Net.WebRequestMethods;

namespace Inventory
{
public partial class InventorySearchDlg : Form
{
 public List<CatPropCtrlSet> PropList { get; private set; } = new List<CatPropCtrlSet>();
 
 public List<LVInvItem> Results { get; private set; }

 public InventoryCategory InvCat { get; private set; }

 private static uint idCategory = 0;

 private static string svItemName; 
 private static bool sbItemName = false;

 private static string svItemDesc; 
 private static bool sbItemDesc = false;

 private static string svItemNotes; 
 private static bool sbItemNotes = false;

 private static int cbCount = 0;
 private static string svCount1;
 private static string svCount2;

 private static int cbCost = 0;
 private static string svCost1;
 private static string svCost2;
 
 private static int cbCreate = 0;
 private static string svCreate1;
 private static string svCreate2;

 private static int cbChange = 0;
 private static string svChange1;
 private static string svChange2;

 private static int cbAdded = 0;
 private static string svAdded1;
 private static string svAdded2;

 private static int cbRmv = 0;
 private static string svRmv1;
 private static string svRmv2;

 private static string svFileName;
 private static string svFileDesc;
 private static string svFileOrig;
 private static string svDiskPath;
 private static string svFileURL;
 
 private static List<int> cbProps = new List<int>();
 private static List<string> svProps1 = new List<string>();
 private static List<string> svProps2 = new List<string>();

public InventorySearchDlg(Form own)
{
 InitializeComponent();

 Owner = own;
 StartPosition = FormStartPosition.CenterParent;

 LoadCategories();


 LoadFields();

}

private void SaveFields()
{

 if (InvCat != null)
  idCategory = InvCat.ID;
 else
   idCategory = 0;

 if (idCategory > 0)
  {
   cbProps.Clear();
   svProps1.Clear();
   svProps2.Clear();
   foreach(CatPropCtrlSet p in PropList)
    {
     cbProps.Add(p.cboComp.SelectedIndex);
     svProps1.Add(p.txtV1.Text.Trim());
     svProps2.Add(p.txtV2.Text.Trim());
    }
  }

 svItemName = txtInvName.Text.Trim(); 
 sbItemName = chkNameNone.Checked;

 svItemDesc = txtInvDesc.Text.Trim(); 
 sbItemDesc = chkDescNone.Checked;

 svItemNotes = txtInvNotes.Text.Trim(); 
 sbItemNotes = chkNotesNone.Checked;

 cbCount = cboCompCount.SelectedIndex;
 svCount1 = txtInvCount1.Text.Trim();
 svCount2 = txtInvCount2.Text.Trim();

 cbCost = cboCompCost.SelectedIndex;
 svCost1 = txtInvCost1.Text.Trim();
 svCost2 = txtInvCost2.Text.Trim();
 
 cbCreate = cboCompCreated.SelectedIndex;
 svCreate1 = txtCreated1.Text.Trim();
 svCreate2 = txtCreated2.Text.Trim();

 cbChange = cboCompChanged.SelectedIndex;
 svChange1 = txtChanged1.Text.Trim();
 svChange2 = txtChanged2.Text.Trim();

 cbAdded = cboCompAdded.SelectedIndex;
 svAdded1 = txtAdded1.Text.Trim();
 svAdded2 = txtAdded2.Text.Trim();

 cbRmv = cboCompRemoved.SelectedIndex;
 svRmv1 = txtRemoved1.Text.Trim();
 svRmv2 = txtRemoved2.Text.Trim();

 svFileName = txtFilesName.Text.Trim();
 svFileDesc = txtFilesDesc.Text.Trim();
 svFileOrig = txtFilesOriginal.Text.Trim();
 svDiskPath = txtFilesPath.Text.Trim();
 svFileURL = txtURL.Text.Trim();

}

private void LoadFields()
{
 int i;

 if (idCategory > 0) // in case a category is added or removed can't rely on cbo's last selected index
  {
   i = 0;
   foreach(CBCategoryItem cat in cboCategory.Items)
    {
     if (cat.Category != null)
      {
       if (cat.Category.ID == idCategory)
        {
         cboCategory.SelectedIndex = i;
         break;
        }
      }
     i++;
    }
  }
 else 
  {
   cboCategory.SelectedIndex = 0;
  }
 
 if (idCategory > 0)
  {
   i = 0;
   foreach(CatPropCtrlSet p in PropList)
    {
     p.cboComp.SelectedIndex = cbProps[i];
     p.txtV1.Text = svProps1[i];
     p.txtV2.Text = svProps2[i];
     i++;
    }
  }

 txtInvName.Text = svItemName; 
 chkNameNone.Checked = sbItemName;

 txtInvDesc.Text = svItemDesc; 
 chkDescNone.Checked = sbItemDesc;

 txtInvNotes.Text = svItemNotes; 
 chkNotesNone.Checked = sbItemNotes;

 cboCompCount.SelectedIndex = cbCount;
 txtInvCount1.Text = svCount1;
 txtInvCount2.Text = svCount2;

 cboCompCost.SelectedIndex = cbCost;
 txtInvCost1.Text = svCost1;
 txtInvCost2.Text = svCost2;
 
 cboCompCreated.SelectedIndex = cbCreate;
 txtCreated1.Text = svCreate1;
 txtCreated2.Text = svCreate2;

 cboCompChanged.SelectedIndex = cbChange;
 txtChanged1.Text = svChange1;
 txtChanged2.Text = svChange2;

 cboCompAdded.SelectedIndex = cbAdded;
 txtAdded1.Text = svAdded1;
 txtAdded2.Text = svAdded2;

 cboCompRemoved.SelectedIndex = cbRmv;
 txtRemoved1.Text = svRmv1;
 txtRemoved2.Text = svRmv2;

 txtFilesName.Text = svFileName;
 txtFilesDesc.Text = svFileDesc;
 txtFilesOriginal.Text = svFileOrig;
 txtFilesPath.Text = svDiskPath;
 txtURL.Text = svFileURL;
}

private void LoadCategories()
{
 List<InventoryCategory> cats = InventoryCategory.GetCategories();

 cboCategory.Items.Clear();

 cboCategory.Items.Add(new CBCategoryItem(null));  // add the <None> category option

 foreach(InventoryCategory c in cats)
  {
   cboCategory.Items.Add(new CBCategoryItem(c));
  }
 cboCategory.SelectedIndex = 0; // select <None>
}

private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
{
 InventoryCategory cat;
 CatPropCtrlSet set;
 CBCategoryItem item;
 int x, y;

 item = (CBCategoryItem)cboCategory.Items[cboCategory.SelectedIndex];
 
 cat = item.Category;

 foreach(CatPropCtrlSet ctrlSet in PropList)
   ctrlSet.Dispose(this);

 PropList.Clear();

 if (cat != null)
  {
   x = 10;
   y = 18;
   foreach(InventoryCategoryProperty p in cat.Properties)
    {
     set = new CatPropCtrlSet(p, pnlProps, x, y);
     y += set.Height + 6;
     PropList.Add(set);
    }
  }
}

private void cboCompCount_SelectedIndexChanged(object sender, EventArgs e)
{
 MainWnd.PropCompare comp = GetCompare(cboCompCount);
 ShowCompareControls(comp, txtInvCount1, txtInvCount2, null, null);
}

private void cboCompCost_SelectedIndexChanged(object sender, EventArgs e)
{
 MainWnd.PropCompare comp = GetCompare(cboCompCost);
 ShowCompareControls(comp, txtInvCost1, txtInvCost2, null, null);
}

private void cboCompCreated_SelectedIndexChanged(object sender, EventArgs e)
{
 MainWnd.PropCompare comp = GetCompare(cboCompCreated);
 ShowCompareControls(comp, txtCreated1, txtCreated2, btnCreate1, btnCreate2);
}

private void cboCompChanged_SelectedIndexChanged(object sender, EventArgs e)
{
 MainWnd.PropCompare comp = GetCompare(cboCompChanged);
 ShowCompareControls(comp, txtChanged1, txtChanged2, btnChange1, btnChange2);
}

private void cboCompAdded_SelectedIndexChanged(object sender, EventArgs e)
{
 MainWnd.PropCompare comp = GetCompare(cboCompAdded);
 ShowCompareControls(comp, txtAdded1, txtAdded2, btnAdd1, btnAdd2);
}

private void cboCompRemoved_SelectedIndexChanged(object sender, EventArgs e)
{
 MainWnd.PropCompare comp = GetCompare(cboCompRemoved);
 ShowCompareControls(comp, txtRemoved1, txtRemoved2, btnRmv1, btnRmv2);
}

private MainWnd.PropCompare GetCompare(ComboBox cbo)
{
 string cmp;

 cmp = cbo.Items[cbo.SelectedIndex].ToString();

 switch(cmp)
  {
   case "N/A": return PropCompare.Ignore;
   case "<": return PropCompare.LT;
   case "<=": return PropCompare.LTE;
   case "=": return PropCompare.EQ;
   case ">": return PropCompare.GT;
   case ">=": return PropCompare.GTE;
   case "RNG": return PropCompare.Range;
   default: throw new Exception("invalid cbo value");
  }
}

private void ShowCompareControls(PropCompare compare, TextBox txtPrimary, TextBox txtPrimary2, Button btn1, Button btn2)
{
 switch(compare)
  {
   case PropCompare.Ignore: 
     {
      txtPrimary.Visible = false;
      if (btn1 != null) btn1.Visible = false;
      txtPrimary2.Visible = false;
      if (btn2 != null) btn2.Visible = false;
     } break;
   case PropCompare.Range:
    {
     txtPrimary.Visible = true;
     if (btn1 != null) btn1.Visible = true;
     txtPrimary2.Visible = true;
     if (btn2 != null) btn2.Visible = true;
    } break;
   default:
    {
     txtPrimary.Visible = true;
     if (btn1 != null) btn1.Visible = true;
     txtPrimary2.Visible = false;
     if (btn2 != null) btn2.Visible = false;
    } break;
  }
}

private bool TestFields(MainWnd.PropCompare comp, string v1, string v2, string name, out float f1, out float f2)
{
 f1 = 0;
 f2 = 0;

 switch(comp)
  {
   case PropCompare.Ignore: 
     {
      return true;
     } 
   case PropCompare.Range:
    {
     if (float.TryParse(v1, out f1) == false)
      {
       MainWnd.Response(name + " first compare value is not numeric");
       return false;
      }
     if (float.TryParse(v2, out f2) == false)
      {
       MainWnd.Response(name + " second compare value is not numeric");
       return false;
      }
    } break;
   default:
    {
     if (float.TryParse(v1, out f1) == false)
      {
       MainWnd.Response(name + " compare value is not numeric");
       return false;
      }
    } break;
  }

 return true;
}

private bool TestFields(MainWnd.PropCompare comp, string v1, string v2, string name, out DateTime d1, out DateTime d2)
{
 d1 = DateTime.MinValue;
 d2 = DateTime.MinValue;

 switch(comp)
  {
   case PropCompare.Ignore: 
     {
      return true;
     } 
   case PropCompare.Range:
    {
     if (DateTime.TryParse(v1, out d1) == false)
      {
       MainWnd.Response(name + " first compare date could not be parsed");
       return false;
      }
     if (DateTime.TryParse(v2, out d2) == false)
      {
       MainWnd.Response(name + " second compare date could not be parsed");
       return false;
      }
    } break;
   default:
    {
     if (DateTime.TryParse(v1, out d1) == false)
      {
       MainWnd.Response(name + " compare date could not be parsed");
       return false;
      }
    } break;
  }

 return true;
}

private string WhereCompare(MainWnd.PropCompare comp, string col, string param)
{
 string where;

 switch(comp)
  {
   case PropCompare.Ignore:
     return "";
   case PropCompare.Range:
    { 
      where = "AND " + col + " BETWEEN @" + param + "_1 AND @" + param + "_2 ";
    } break;
   case PropCompare.LT:
    {
      where = "AND " + col + " < @" + param + " "; 
    } break;
   case PropCompare.LTE:
    {
      where = "AND " + col + " <= @" + param + " ";
    } break;
   case PropCompare.EQ:
    {
      where = "AND " + col + " = @" + param + " ";
    } break;
   case PropCompare.GT:
    {
      where = "AND " + col + " > @" + param + " ";
    } break;
   case PropCompare.GTE:
    {
      where = "AND " + col + " >= @" + param + " ";
    } break;
   default: throw new Exception("compare not handled");
  }

 return where;
}

private bool DoQueryInventoryFile(string file)
{
 Dictionary<uint, InventoryCategory> categories = new Dictionary<uint, InventoryCategory>();
 MySqlCommand cmd;
 MySqlDataReader rs;
 System.IO.FileInfo fInfo;
 string where, sql, query;
 string sCat, sFile, sExt;
 uint iFile;
 uint iCat;

 InvCat = null;

 foreach(InventoryCategory c in InventoryCategory.GetCategories())
  {
   categories.Add(c.ID, c);
  }

 if (System.IO.File.Exists(file) == false)
  {
   MainWnd.Response("File not found -- " + file);
   return false;
  }

 fInfo = new System.IO.FileInfo(file);

 sFile = Path.GetFileNameWithoutExtension(fInfo.Name);
 sExt = Path.GetExtension(fInfo.Name);
 sCat = fInfo.Directory.Name;
 
 if (uint.TryParse(sFile, System.Globalization.NumberStyles.HexNumber, null, out iFile) == false)
  {
   MainWnd.Response("Unable to convert file name to a integer for search -- " + file);
   return false;
  }

 if (uint.TryParse(sCat, System.Globalization.NumberStyles.HexNumber, null, out iCat) == false)
  {
   MainWnd.Response("Unable to convert file's parent directory name to a integer for search -- " + file);
   return false;
  }

 sql = LVInvItem.SelectClauseFileSearch;

 where = "WHERE a.inv_item_id=c.inv_item_id AND a.inv_cat_id=@cat AND c.item_file_id=@file; ";
 query = sql + where;

 cmd = new MySqlCommand(query, DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@cat", iCat));
 cmd.Parameters.Add(new MySqlParameter("@file", iFile));

 rs = cmd.ExecuteReader();
 
 Results = LVInvItem.GetItems(categories, rs);
 rs.Close();
 
 return true;
}

private bool DoFileSearch()
{
 Dictionary<uint, InventoryCategory> categories = new Dictionary<uint, InventoryCategory>();
 MySqlCommand cmd;
 MySqlDataReader rs;
 InventoryCategory cat;
 string iFileName, iFileDesc, iOrignal, iURL;
 string sql, where, query;

 foreach(InventoryCategory c in InventoryCategory.GetCategories())
  {
   categories.Add(c.ID, c);
  }
 
 cat = ((CBCategoryItem)cboCategory.Items[cboCategory.SelectedIndex]).Category;

 iFileName = txtFilesName.Text.Trim();
 iFileDesc = txtFilesDesc.Text.Trim();
 iOrignal = txtFilesOriginal.Text.Trim();
 iURL = txtURL.Text.Trim();

 sql = LVInvItem.SelectClauseFileSearch;

 where = "WHERE a.inv_item_id=c.inv_item_id ";

 if (cat != null)
   where += "AND a.inv_cat_id=@cat ";
 if (iFileName.Length > 0)
     where += "AND c.file_name LIKE @fName ";
 if (iFileDesc.Length > 0)
     where += "AND c.file_desc LIKE @fDesc ";
 if (iOrignal.Length > 0)
  {
   if (iURL.Length > 0)
    {
     Response("Original File Path and URL cannot be used together, one must be blank");
     return false;
    }
   where += "AND (c.file_path LIKE @fOrig AND file_type!=3) "; // exclude URLs
  }
 else
  {
   if (iURL.Length > 0)
     where += "AND (c.file_path LIKE @fURL AND file_type=3) ";
  }

 query = sql + where;

 cmd = new MySqlCommand(query, DB.Con);

 if (cat != null)
   cmd.Parameters.Add(new MySqlParameter("@cat", cat.ID));
 cmd.Parameters.Add(new MySqlParameter("@fName", iFileName));
 cmd.Parameters.Add(new MySqlParameter("@fDesc", iFileDesc));
 cmd.Parameters.Add(new MySqlParameter("@fOrig", iOrignal));
 cmd.Parameters.Add(new MySqlParameter("@fURL", iURL));

 rs = cmd.ExecuteReader();
 
 Results = LVInvItem.GetItems(categories, rs);
 rs.Close();
 
 return true;
}


private bool DoQuery()
{
 Dictionary<uint, InventoryCategory> categories = new Dictionary<uint, InventoryCategory>();
 MySqlCommand cmd;
 MySqlDataReader rs;

 string iName, iDesc, iNotes;
 bool bNameNone, bDescNone, bNotesNone;
 string iCost1, iCost2, iCount1, iCount2;
 float fCost1, fCost2, fCount1, fCount2;
 string iCrt1, iCrt2, iChg1, iChg2, iAdd1, iAdd2, iRmv1, iRmv2;
 DateTime dCrt1, dCrt2, dChg1, dChg2, dAdd1, dAdd2, dRmv1, dRmv2;

 MainWnd.PropCompare cCost, cCount, cCrt, cChg, cAdd, cRmv;

 string sql, where, query;

 bool noProperties = true;

 InvCat = ((CBCategoryItem)cboCategory.Items[cboCategory.SelectedIndex]).Category;

 foreach(InventoryCategory c in InventoryCategory.GetCategories())
  {
   categories.Add(c.ID, c);
  }

 iName = txtInvName.Text.Trim();
 bNameNone = chkNameNone.Checked;
 iDesc = txtInvDesc.Text.Trim();
 bDescNone = chkDescNone.Checked;
 iNotes = txtInvNotes.Text.Trim();
 bNotesNone = chkNotesNone.Checked;

 cCount = GetCompare(cboCompCount);
 iCount1 = txtInvCount1.Text.Trim();
 iCount2 = txtInvCount2.Text.Trim();

 cCost = GetCompare(cboCompCost);
 iCost1 = txtInvCost1.Text.Trim();
 iCost2 = txtInvCost2.Text.Trim();

 cCrt = GetCompare(cboCompCreated); 
 iCrt1 = txtCreated1.Text.Trim();
 iCrt2 = txtCreated2.Text.Trim();

 cChg = GetCompare(cboCompChanged);
 iChg1 = txtChanged1.Text.Trim();
 iChg2 = txtChanged1.Text.Trim();

 cAdd = GetCompare(cboCompAdded);
 iAdd1 = txtAdded1.Text.Trim();
 iAdd2 = txtAdded2.Text.Trim();

 cRmv = GetCompare(cboCompRemoved);
 iRmv1 = txtRemoved1.Text.Trim();
 iRmv2 = txtRemoved1.Text.Trim();

 if (TestFields(cCount, iCount1, iCount2, "Inventory Count", out fCount1, out fCount2) == false)
   return false;

 if (TestFields(cCost, iCost1, iCost2, "Estimated Cost", out fCost1, out fCost2) == false)
   return false;

 if (TestFields(cCrt, iCrt1, iCrt2, "Create Date", out dCrt1, out dCrt2) == false)
   return false;

 if (TestFields(cChg, iChg1, iChg2, "Last Change Date", out dChg1, out dChg2) == false)
   return false;

 if (TestFields(cAdd, iAdd1, iAdd2, "Inventory Added Date", out dAdd1, out dAdd2) == false)
   return false;

 if (TestFields(cRmv, iRmv1, iRmv2, "Inventory Removed Date", out dRmv1, out dRmv2) == false)
   return false;

 where = "WHERE 1=1 ";

 if (PropList.Count == 0)
   noProperties = true;
 else
  {
   foreach(CatPropCtrlSet s in PropList)
    {
     if (s.ValidateData() == false)
       return false;
     if (s.CurrentCompare != PropCompare.Ignore)
      {
       noProperties = false;  // find out if any properties were compared
      }
    }
  }

 if (noProperties == true)
  {
   sql = LVInvItem.SelectClauseNoProps;
  }
 else
  {
   sql = LVInvItem.SelectClauseAdvProps;  // this doesn't limit the query to the primary property value like the mainwnd search
  }

 foreach(CatPropCtrlSet s in PropList)
  {
   if (s.ValidateData() == false)
    return false;
   switch(s.CurrentCompare)
    {
     case PropCompare.Range:
      { 
       where = "AND (b.cat_prop_id=@" + s.PropParam + " AND b.prop_value BETWEEN @" + s.Parameter + "_1 AND @" + s.Parameter + "_2) ";
      } break;
     case PropCompare.LT:
      {
       where = "AND (b.cat_prop_id=@" + s.PropParam + " AND b.prop_value < @" + s.Parameter + ") "; 
      } break;
     case PropCompare.LTE:
      {
       where = "AND (b.cat_prop_id=@" + s.PropParam + " AND b.prop_value <= @" + s.Parameter + ") ";
      } break;
     case PropCompare.EQ:
      {
       where = "AND (b.cat_prop_id=@" + s.PropParam + " AND b.prop_value = @" + s.Parameter + ") ";
      } break;
     case PropCompare.GT:
      {
       where = "AND (b.cat_prop_id=@" + s.PropParam + " AND b.prop_value > @" + s.Parameter + ") ";
      } break;
     case PropCompare.GTE:
      {
       where = "AND (b.cat_prop_id=@" + s.PropParam + " AND b.prop_value >= @" + s.Parameter + ") ";
      } break;
     case PropCompare.Ignore: break;  // do nothing
     default: throw new Exception("compare not handled");
    }
  }

 if (bNameNone == true)
  {
   where += "AND CHAR_LENGTH(a.item_name)=0 ";
  }
 else
  {
   if (iName.Length > 0)
    {
     where += "AND a.item_name LIKE @name ";
    }
  }
 if (bDescNone == true)
  {
   where += "AND CHAR_LENGTH(a.item_desc)=0 ";
  }
 else
  {
   if (iDesc.Length > 0)
    {
     where += "AND a.item_desc LIKE @desc ";
    }
  }
 if (bNotesNone == true)
  {
   where += "AND CHAR_LENGTH(a.notes)=0 ";
  }
 else
  {
   if (iNotes.Length > 0)
    {
     where += "AND a.notes LIKE @notes ";
    }
  }

 where += WhereCompare(cCost, "a.est_cost", "cost");
 where += WhereCompare(cCount, "a.inv_count", "count");
 where += WhereCompare(cCrt, "a.item_created", "create");
 where += WhereCompare(cChg, "a.item_changed", "change");
 where += WhereCompare(cAdd, "a.item_added", "added");
 where += WhereCompare(cRmv, "a.item_removed", "removed");

 if (InvCat != null)
   where += "AND a.inv_cat_id=@cat;";  // add termination
 else
   where += ";";

 query = sql + where;

 cmd = new MySqlCommand(query, DB.Con);

 foreach(CatPropCtrlSet s in PropList)
  {
   switch(s.CurrentCompare)
    {
     case PropCompare.Range:
      {
       cmd.Parameters.Add(new MySqlParameter("@" + s.PropParam, s.CatProp.ID));
       cmd.Parameters.Add(new MySqlParameter("@" + s.Parameter + "_1", s.V1));
       cmd.Parameters.Add(new MySqlParameter("@" + s.Parameter + "_2", s.V2));
      } break;
     case PropCompare.Ignore: break;  // do nothing
     default:
      {
       cmd.Parameters.Add(new MySqlParameter("@" + s.PropParam, s.CatProp.ID));
       cmd.Parameters.Add(new MySqlParameter("@" + s.Parameter, s.V1));
      } break;
    }
  }

 if (iName.Length > 0)
  {
   cmd.Parameters.Add(new MySqlParameter("@name", iName));
  }
 if (iDesc.Length > 0)
  {
   cmd.Parameters.Add(new MySqlParameter("@desc", iDesc));
  }
 if (iNotes.Length > 0)
  {
   cmd.Parameters.Add(new MySqlParameter("@notes", iNotes));
  }

 switch(cCost)
  {
   case PropCompare.Range:
    {
     cmd.Parameters.Add(new MySqlParameter("@cost_1", fCost1));
     cmd.Parameters.Add(new MySqlParameter("@cost_2", fCost2));
    } break;
   default:
    {
     cmd.Parameters.Add(new MySqlParameter("@cost", fCost1));
    } break;  
  }
 switch(cCount)
  {
   case PropCompare.Range:
    {
     cmd.Parameters.Add(new MySqlParameter("@count_1", fCount1));
     cmd.Parameters.Add(new MySqlParameter("@count_2", fCount2));
    } break;
  default:
   {
    cmd.Parameters.Add(new MySqlParameter("@count", fCount1));
   } break;  
  }
 switch(cCrt)
  {
   case PropCompare.Range:
    {
     cmd.Parameters.Add(new MySqlParameter("@create_1", dCrt1));
     cmd.Parameters.Add(new MySqlParameter("@create_2", dCrt2));
    } break;
   default:
    {
     cmd.Parameters.Add(new MySqlParameter("@create", dCrt1));
    } break;  
  }
 switch(cChg)
  {
   case PropCompare.Range:
    {
     cmd.Parameters.Add(new MySqlParameter("@change_1", dChg1));
     cmd.Parameters.Add(new MySqlParameter("@change_2", dChg2));
    } break;
   default:
    {
     cmd.Parameters.Add(new MySqlParameter("@change", dChg1));
    } break;  
  }
 switch(cAdd)
  {
   case PropCompare.Range:
    {
     cmd.Parameters.Add(new MySqlParameter("@added_1", dAdd1));
     cmd.Parameters.Add(new MySqlParameter("@added_2", dAdd2));
    } break;
   default:
    {
     cmd.Parameters.Add(new MySqlParameter("@added", dAdd1));
    } break;  
  }
 switch(cRmv)
  {
   case PropCompare.Range:
    {
     cmd.Parameters.Add(new MySqlParameter("@removed_1", dRmv1));
     cmd.Parameters.Add(new MySqlParameter("@removed_2", dRmv2));
    } break;
   default:
    {
     cmd.Parameters.Add(new MySqlParameter("@removed", dRmv1));
    } break;  
  }

 if (InvCat != null)
   cmd.Parameters.Add(new MySqlParameter("@cat", InvCat.ID)); 

 rs = cmd.ExecuteReader();


 Results = LVInvItem.GetItems(categories, rs);
 rs.Close();
 
 return true;
}


private void btnOK_Click(object sender, EventArgs e)
{
 string invFile;
 bool bFiles;

 invFile = txtFilesPath.Text.Trim();

 if (invFile.Length > 0) // very specific query looking up item by file's name
  {
   if (DoQueryInventoryFile(invFile) == false)
     return;
  }
 else
  {
   bFiles = false;
   if (txtFilesName.Text.Trim().Length > 0) bFiles = true;
   if (txtFilesDesc.Text.Trim().Length > 0) bFiles = true;
   if (txtFilesOriginal.Text.Trim().Length > 0) bFiles = true;
   if (txtURL.Text.Trim().Length > 0) bFiles = true;
   if (bFiles == true)
    {
     if (DoFileSearch() == false)
       return;
    }
   else 
    {
     if (DoQuery() == false)
       return;
    }
  }

 SaveFields();
 
 DialogResult = DialogResult.OK;
 Close();
}

private void Cancel_Click(object sender, EventArgs e)
{
 DialogResult = DialogResult.Cancel;
 Close();
}

private void btnPickFile_Click(object sender, EventArgs e)
{
 OpenFileDialog dlg;

 dlg = new OpenFileDialog();
 dlg.Title = "Browse For Inventory File";
 dlg.Multiselect = false;
 dlg.CheckFileExists = true;
 dlg.CheckPathExists = true;
 dlg.Filter = "All Files (*.*)|*.*";
 dlg.InitialDirectory = Globals.InventoryFileDirectory;

 if (dlg.ShowDialog() == DialogResult.OK)
   txtFilesPath.Text = dlg.FileName;

 dlg.Dispose();
}

private void DoDate(TextBox txt)
{
 DateTimeDlg dlg;
 DateTime date;

 if (DateTime.TryParse(txt.Text.Trim(), out date) == true)
   dlg = new DateTimeDlg(this, date);
 else
   dlg = new DateTimeDlg(this);

 if (dlg.ShowDialog() == DialogResult.OK)
  {
   txt.Text = dlg.CurrentDate.ToString(Globals.DateFormat);
  }
 dlg.Dispose();

}

private void btnCreate1_Click(object sender, EventArgs e)
{
 DoDate(txtCreated1);
}

private void btnCreate2_Click(object sender, EventArgs e)
{
 DoDate(txtCreated2);
}

private void btnChange1_Click(object sender, EventArgs e)
{
 DoDate(txtChanged1);
}

private void btnChange2_Click(object sender, EventArgs e)
{
 DoDate(txtChanged2);
}

private void btnAdd1_Click(object sender, EventArgs e)
{
 DoDate(txtAdded1);
}

private void btnAdd2_Click(object sender, EventArgs e)
{
 DoDate(txtAdded2);
}

private void btnRmv1_Click(object sender, EventArgs e)
{
 DoDate(txtRemoved1);
}

private void btnRmv2_Click(object sender, EventArgs e)
{
 DoDate(txtRemoved2);
}

};

public class CatPropCtrlSet
{
 public InventoryCategoryProperty CatProp { get; private set; }
 public MainWnd.PropCompare CurrentCompare { get; private set; }
 public float V1 { get; private set; }
 public float V2 { get; private set; }

 public int Height { get => lblProp.Height + 2 + cboComp.Height; }

 public string Parameter { get => "PV_" + CatProp.ID.ToString(); }
 public string PropParam { get => "PI_" + CatProp.ID.ToString(); }

 private Label   lblProp;
 public ComboBox cboComp { get; private set; }
 public TextBox  txtV1 { get; private set; }
 public TextBox  txtV2 { get; private set; }

public CatPropCtrlSet(in InventoryCategoryProperty prop, GroupBox parent, int xPos, int yPos)
{
 CatProp  = prop;

 lblProp = new Label();
 parent.Controls.Add(lblProp);
 lblProp.Name = "lblProp" + prop.ID.ToString();
 lblProp.AutoSize = true;
 lblProp.Text = prop.PropertyName;
 lblProp.Visible = true;
 lblProp.Parent = parent;

 cboComp = new ComboBox();
 parent.Controls.Add(cboComp);
 cboComp.Name = "cboProp" + prop.ID.ToString();
 cboComp.DropDownStyle = ComboBoxStyle.DropDownList;
 cboComp.Items.Add("N/A");
 cboComp.Items.Add("<");
 cboComp.Items.Add("<=");
 cboComp.Items.Add("=");
 cboComp.Items.Add(">=");
 cboComp.Items.Add(">");
 cboComp.Items.Add("RNG");
 cboComp.Visible = true;
 cboComp.Parent = parent;
 cboComp.SelectedIndexChanged += new EventHandler(cboComp_SelectedIndexChanged);

 txtV1 = new TextBox();
 parent.Controls.Add(txtV1);
 txtV1.Visible = true;
 txtV1.Parent = parent;

 txtV2 = new TextBox();
 parent.Controls.Add(txtV2);
 txtV2.Visible = true;
 txtV2.Parent = parent;
 
 lblProp.Location = new Point(xPos, yPos);

 cboComp.Location = new Point(xPos, yPos + lblProp.Size.Height + 2);
 cboComp.Size = new Size(53,21);

 txtV1.Location = new Point(cboComp.Location.X + cboComp.Size.Width + 7, cboComp.Location.Y);
 txtV1.Size = new Size(101, 20);

 txtV2.Location = new Point(txtV1.Location.X + txtV1.Size.Width + 7, cboComp.Location.Y);
 txtV2.Size = new Size(101, 20);

 cboComp.SelectedIndex = 0; // have to do this last when all controls are ready
}

public void Dispose(Form parent)
{
 parent.Controls.Remove(lblProp);
 parent.Controls.Remove(cboComp);
 parent.Controls.Remove(txtV1);
 parent.Controls.Remove(txtV2);

 lblProp.Dispose();
 cboComp.Dispose();
 txtV1.Dispose();
 txtV2.Dispose();
}

private void cboComp_SelectedIndexChanged(object sender, EventArgs e)
{
 string cmp = cboComp.Items[cboComp.SelectedIndex].ToString();

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
      txtV1.Visible = false;
      txtV2.Visible = false;
     } break;
   case PropCompare.Range:
    {
     txtV1.Visible = true;
     txtV2.Visible = true;
    } break;
   default:
    {
     txtV1.Visible = true;
     txtV2.Visible = false;
    } break;
  }
}

public bool ValidateData()
{
 float t1, t2;

 switch(CurrentCompare)
  {
   case PropCompare.Ignore: return true;
   case PropCompare.Range:
    {
     if (float.TryParse(txtV1.Text.Trim(), out t1) == false)
      {
       MainWnd.Response(lblProp.Text + " first value is not numeric");
       return false;
      }
     V1 = t1;
     if (float.TryParse(txtV2.Text.Trim(), out t2) == false)
      {
       MainWnd.Response(lblProp.Text + " second value is not numeric");
       return false;
      }
     V2 = t2;
    } break;
   default:
    {
     if (float.TryParse(txtV1.Text.Trim(), out t1) == false)
      {
       MainWnd.Response(lblProp.Text + " value is not numeric");
       return false;
      }
     V1 = t1;
    } break;  
  }

 return true;
}

};
}
