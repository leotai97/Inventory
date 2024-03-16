using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{

partial class AboutDlg : Form
{

public AboutDlg()
{
 InitializeComponent();
}

private void btnOK_Click(object sender, EventArgs e)
{
 Close();
}

private void btnDiscord_Click(object sender, EventArgs e)
{
 System.Diagnostics.Process.Start(txtDiscord.Text);
}

private void btnLike_Click(object sender, EventArgs e)
{
 System.Diagnostics.Process.Start(txtLike.Text);
}

};
}
