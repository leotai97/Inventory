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
public partial class InventoryEditFileDlg : Form
{
 public string FileName { get; private set; }
 public string FileDesc { get; private set; }

public InventoryEditFileDlg(Form owner,in InventoryFile file)
{
 InitializeComponent();

 Owner = owner;
 StartPosition = FormStartPosition.CenterParent;

 txtName.Text = file.Name;
 txtDesc.Text = file.Desc;
 txtID.Text = file.ID.ToString();
}

private void btnOK_Click(object sender, EventArgs e)
{
 FileName = txtName.Text.Trim();
 FileDesc = txtDesc.Text.Trim();
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
