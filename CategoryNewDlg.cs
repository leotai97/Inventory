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

public partial class CategoryNewDlg : Form
{
 public string CategoryName { get; private set; }

public CategoryNewDlg(Form own)
{
 InitializeComponent();

 Owner = own;
 StartPosition = FormStartPosition.CenterParent;

}

private void btnOK_Click(object sender, EventArgs e)
{
 List<InventoryCategory> list = InventoryCategory.GetCategories();
 string name;

 name = txtName.Text.Trim();

 if (name.Length == 0)
  {
   MainWnd.Response("New category name cannot be blank");
   return;
  }

 foreach(InventoryCategory cat in list)
  {
   if (string.Compare(cat.Name, name) == 0)
    {
     MainWnd.Response("Category '" + cat.Name + "' already exists");
     return;
    }
  }

 CategoryName = name;

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
