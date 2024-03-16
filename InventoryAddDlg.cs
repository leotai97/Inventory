using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
public partial class InventoryAddDlg : Form
{
 public InventoryLocation InvLoc { get; private set; }
 public InventoryCategory Category { get; private set; } = null;
 public List<InventoryCategoryValue> CategoryValues { get; private set; }
 public int Quantity { get; private set; }
 public float Price { get; private set; }
 public string InvName { get; private set; }

 private List<InvPropCtrl> listProps = new List<InvPropCtrl>();

public InventoryAddDlg(Form parent, in InventoryLocation loc)
{

 Owner = parent;
 StartPosition = FormStartPosition.CenterParent;

 InitializeComponent();

 LoadCats();

 InvLoc = loc;
 txtLocation.Text = loc.ToString();
}

private void LoadCats()
{
 cboCat.Items.Clear();

 foreach(InventoryCategory c in InventoryCategory.GetCategories())
  {
   cboCat.Items.Add(new CBCategoryItem(c));   
  }
}

private void cboCat_SelectedIndexChanged(object sender, EventArgs e)
{
 InvPropCtrl ctrl;
 int x, y, g, count;

 g = 7;

 if (cboCat.SelectedIndex < 0)
   return;

 Category = ((CBCategoryItem)cboCat.Items[cboCat.SelectedIndex]).Category;

 foreach(InvPropCtrl c in listProps)
  {
   Controls.Remove(c.PropLabel);
   Controls.Remove(c.PropText);
   c.PropLabel.Dispose();
   c.PropText.Dispose();
  }
 
 x = pnlProps.Location.X + g * 2;
 y = pnlProps.Location.Y + g * 3;
 count = 0;

 listProps = new List<InvPropCtrl>();
 foreach(InventoryCategoryProperty prop in Category.Properties)
  {
   ctrl = new InvPropCtrl(Category, prop, pnlProps);
   listProps.Add(ctrl);
   Controls.Add(ctrl.PropLabel);
   Controls.Add(ctrl.PropText);
   ctrl.PropLabel.Location = new Point(x, y);
   ctrl.PropText.Location = new Point(x, y + ctrl.PropLabel.Height + 2);
   ctrl.PropText.Width = 90;
   y += ctrl.PropLabel.Height + ctrl.PropText.Height + g;
   count++;
  if (count == 3)
   {
    x += ctrl.PropText.Width + g;
    y = pnlProps.Location.Y + g * 3;
   }

  }
 pnlProps.SendToBack();
}

private void btnCancel_Click(object sender, EventArgs e)
{
 DialogResult = DialogResult.Cancel;
 Close();
}

private void btnChangeLoc_Click(object sender, EventArgs e)
{
}

private void btnCatAdd_Click(object sender, EventArgs e)
{
}

private void btnOK_Click(object sender, EventArgs e)
{
 string s;
 float v;
 int c;

 if (Category == null)
  {
   MainWnd.Response("Select a category");
   return;
  }

 CategoryValues = new List<InventoryCategoryValue>();
 
 foreach(InvPropCtrl ctrl in listProps)
  {
   s = ctrl.PropText.Text.Trim();
   if (float.TryParse(s, out v) == false)
    {
     MainWnd.Response("Property " + ctrl.PropLabel.Text + " is not numeric");
     return;
    }
   CategoryValues.Add(new InventoryCategoryValue(ctrl.Property, v));
  }
 
 s = txtName.Text.Trim();

 InvName = s;

 s = txtQuantity.Text.Trim();
 if (s.Length > 0)
  {
   if (int.TryParse(s, out c) == false)
    {
     MainWnd.Response("Quantity not numeric");
     return;
    }
   Quantity = c;
  }
 else
  {
   Quantity = 0;
  }

 s = txtPrice.Text.Trim();
 if (s.Length > 0)
  {
   if (float.TryParse(s, out v) == false)
    {
     MainWnd.Response("Price not numeric");
     return;
    }
   Price = v;
  }
 else
  {
   Price = 0;
  }

 DialogResult = DialogResult.OK;
 Close();
}

};


public class InvPropCtrl
{
 public InventoryCategory Category { get; private set; }
 public InventoryCategoryProperty Property { get; private set; }

 public Label PropLabel { get; private set; }
 public TextBox PropText { get; private set; }

public InvPropCtrl(in InventoryCategory cat, in InventoryCategoryProperty prop, GroupBox grp)
{
 Category = cat;
 Property = prop;

 PropLabel = new Label();
 PropLabel.Text = prop.PropertyName;
 PropLabel.AutoSize = true;
 PropLabel.Parent = grp;

 PropText = new TextBox();
 PropText.Parent = grp;
}

};

}
