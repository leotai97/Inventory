using System;
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

public partial class CategoryPropertyDlg : Form
{
 public InventoryCategory InvCat { get; private set; }
 public InventoryCategoryProperty CatProp { get; private set; }

 public string PropName { get; private set; }
 public bool   PropPrimary { get; private set; }

public CategoryPropertyDlg(Form own, in InventoryCategory cat)
{
 InitializeComponent();
 Owner = own;
 StartPosition = FormStartPosition.CenterParent;

 InvCat = cat;
}

public CategoryPropertyDlg(Form own, in InventoryCategory cat, in InventoryCategoryProperty prop)
{
 InitializeComponent();

 Owner = own;
 StartPosition = FormStartPosition.CenterParent;

 InvCat = cat;
 CatProp = prop;

 txtName.Text = CatProp.PropertyName;
 chkPrimary.Checked = CatProp.PrimaryProperty;
}

private void btnOK_Click(object sender, EventArgs e)
{
 string name;
 bool primary;
 bool fail = false;

 name = txtName.Text.Trim();
 primary = chkPrimary.Checked;

 if (name.Length == 0)
  {
   MainWnd.Response("Property Name cannnot be blank");
   return;
  }

 foreach(InventoryCategoryProperty p in InvCat.Properties)
  {
   if (CatProp == null)
    {
     if (string.Compare(name, p.PropertyName) == 0)
      {
       fail = true;
       break;
      }
    }
   else
    {
     if (CatProp.ID != p.ID)
      {
       if (string.Compare(name, p.PropertyName) == 0)
        {
         fail = true;
         break;
        }
      }
    }
  }

 if (fail == true)
  {
   MainWnd.Response("Property Name '" + name + "' already exists");
   return;
  } 

 if (primary == false)
  {  
   fail = true;  // one of the properties has to be primary
   foreach(InventoryCategoryProperty p in InvCat.Properties)
    {
     if (p.PrimaryProperty == true)
       fail = false;
    }
   if (fail == true)
    {
     primary = true;  // just make this one primary
    }
  }
 PropName = name;
 PropPrimary = primary;
 
 DialogResult = DialogResult.OK;
 Close();
}

private void btnCancel_Click(object sender, EventArgs e)
{
 DialogResult = DialogResult.Cancel;
 Close();
}

};
}
