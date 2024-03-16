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

public partial class CategoryDlg : Form
{
 public InventoryCategory Category { get; private set; }
 
public CategoryDlg(Form parent, in InventoryCategory cat)
{
 Owner = parent;

 InitializeComponent();

 Category = cat;

 txtName.Text = Category.Name;
 txtDesc.Text = Category.Desc;
 txtNotes.Text = Category.Notes;

 txtDir.Text = Category.FilePath;
 txtID.Text = Category.ID.ToString();

 listProps.ListViewItemSorter = new LVCatPropSorter();

 LoadProperties();
}

private void LoadProperties()
{

 Category.GetProperties();

 listProps.Items.Clear();

 foreach(InventoryCategoryProperty prop in Category.Properties)
  {
   listProps.Items.Add(new LVCatProp(prop));
  }
 listProps.Sort();  // sort by listviewitem Text
}

private void btnOK_Click(object sender, EventArgs e)  // button is just close
{
 DialogResult = DialogResult.OK;
 Close();
}

private void btnPropAdd_Click(object sender, EventArgs e)
{
 List<string> existing = new List<string>();
 InventoryCategoryProperty prop;
 CategoryPropertyDlg dlg;

 dlg = new CategoryPropertyDlg(this, Category);
 
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   prop = new InventoryCategoryProperty(Category.ID, dlg.PropName, dlg.PropPrimary);
   if (prop.PrimaryProperty == true)
    {
     foreach(InventoryCategoryProperty p in Category.Properties)
      {
       if (p.PrimaryProperty == true) // automatically adjust primary in list
         p.UpdatePrimary(false);
      }
    }
   Category.Properties.Add(prop);
   LoadProperties();
  }

 dlg.Dispose();
}

private void btnPropEdit_Click(object sender, EventArgs e)
{
 CategoryPropertyDlg dlg;
 InventoryCategoryProperty prop;

 if (listProps.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a Category Property to edit");
   return;
  }

 prop = ((LVCatProp)listProps.SelectedItems[0]).Property;

 dlg = new CategoryPropertyDlg(this, Category, prop);
 if (dlg.ShowDialog() == DialogResult.OK)
  {
   prop.UpdateText(dlg.PropName);
   prop.UpdatePrimary(dlg.PropPrimary);
   if (prop.PrimaryProperty == true)
    {
     foreach(InventoryCategoryProperty p in Category.Properties)
      {
       if (p.ID != prop.ID && p.PrimaryProperty == true) // automatically adjust primary in list
         p.UpdatePrimary(false);
      }
    }
  }

 LoadProperties();  // just reload the list, too much work to try to update it
 dlg.Dispose(); 
}

private void btnPropDel_Click(object sender, EventArgs e)
{
 InventoryCategoryProperty prop;
 uint c;
 string q;

 if (listProps.SelectedItems.Count == 0)
  {
   MainWnd.Response("Select a Category Property to delete");
   return;
  }

 prop = ((LVCatProp)listProps.SelectedItems[0]).Property;

 q = "Delete category property '" + prop.PropertyName + "' ID " + prop.ID.ToString() + " ?";

 c = InventoryCategory.GetInvCount(Category.ID);

 if (c > 0)
  {
   q += "\n\nCategory '" + Category.Name + "' ID " + Category.ID.ToString() + " has " + c1 + " items under it.";
   q += "\n\nThe individual property values for " + prop.PropertyName + " will be deleted as well.";
  }
 
 if (MainWnd.Question(q, MessageBoxButtons.OKCancel) == DialogResult.OK)
  {
   prop.Delete();
   Category.Properties.Remove(prop);
   if (prop.PrimaryProperty == true)
     Category.Properties[0].UpdatePrimary(true);  // just set the top one as primary, let the user sort it out
  }

 LoadProperties();
}

private void btnSave_Click(object sender, EventArgs e) // save text
{
 string name, desc, notes;

 name = txtName.Text.Trim();
 desc = txtDesc.Text.Trim();
 notes = txtNotes.Text.Trim();

 if (name.Length == 0)
  {
   MainWnd.Response("Category name cannot be blank");
   return;
  }

 Category.UpdateText(name, desc, notes);
}

};

public class LVCatProp : ListViewItem
{
 public InventoryCategoryProperty Property { get; private set; }

public LVCatProp(in InventoryCategoryProperty prop)
{
 Property = prop;

 Text = prop.PropertyName;

 if (Property.PrimaryProperty == true)
   SubItems.Add("Yes");
 else
   SubItems.Add("");

 SubItems.Add(prop.ID.ToString());
}


public void UpdateText(in InventoryCategoryProperty prop)
{
 Text = prop.PropertyName;
 if (prop.PrimaryProperty == true)
   SubItems[1].Text = "Yes";
 else
  SubItems[1].Text = "";
}
 
};

public class LVCatPropSorter : IComparer
{

public int Compare(Object x, Object y)
{
 LVCatProp lvx, lvy;
 
 lvx = (LVCatProp)x;
 lvy = (LVCatProp)y;

 return string.Compare(lvx.Text, lvy.Text);
}

};

}
