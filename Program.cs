using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{

internal static class Program
{

[STAThread]
static void Main()
{

 Application.EnableVisualStyles();
 Application.SetCompatibleTextRenderingDefault(false);

 if (DB.Connect(true)==false) // user refused attempt to login
   return; 

 Application.Run(new MainWnd());
 Globals.Dispose();
}

};
}
