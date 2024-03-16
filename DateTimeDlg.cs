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
public partial class DateTimeDlg : Form
{
 public DateTime CurrentDate { get; private set; }

public DateTimeDlg(Form owner)
{
 InitializeComponent();

 Owner = owner;
 StartPosition = FormStartPosition.CenterParent;
 ctrlCalendar.SetDate(DateTime.Now);
}

public DateTimeDlg(Form own, DateTime date)
{
 InitializeComponent();

 Owner = own;
 StartPosition = FormStartPosition.CenterParent;

 ctrlCalendar.SetDate(date);
}

private void btnOK_Click(object sender, EventArgs e)
{
 CurrentDate = ctrlCalendar.SelectionStart;
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
