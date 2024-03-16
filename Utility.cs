using Inventory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.Remoting.Messaging;
using System.IO;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

namespace Inventory
{

public static class Globals
{
 public static MainWnd Wnd { get; private set; }
 public static string DateFormat { get; private set; }
 public static string ImageDirectory { get; private set; }
 public static string InventoryFileDirectory { get; private set; }
 public static string DownloadDirectory { get; private set; }

 private static Dictionary<uint, PictureLocationImage > PicLocImages; // cache pic loc images

public static void SetWnd(in MainWnd wnd)
{
 Wnd=wnd;
}

public static void SetDateFormat(string fmt)
{
 DateFormat = fmt;
}

public static void SetImageDirectory(string dir)
{
 ImageDirectory = dir;
 MainWnd.SaveRegSetting("ImageDirectory", dir);
}

public static void SetInventoryFileDirectory(string dir)
{
 InventoryFileDirectory = dir;
 MainWnd.SaveRegSetting("InventoryFileDirectory", dir);
}

public static void SetDownloadDirectory(string dir)
{
 DownloadDirectory = dir;
 MainWnd.SaveRegSetting("DownloadDirectory", dir);
}

public static void Init()
{
 OptionsDlg dlg;

 PicLocImages = new Dictionary<uint, PictureLocationImage>();

 ImageDirectory = MainWnd.GetRegSetting("ImageDirectory");
 InventoryFileDirectory = MainWnd.GetRegSetting("InventoryFileDirectory");
 DownloadDirectory = MainWnd.GetRegSetting("DownloadDirectory");

 if (ImageDirectory.Length == 0 || InventoryFileDirectory.Length == 0 || DownloadDirectory.Length == 0)
  {
   dlg = new OptionsDlg();
   dlg.ShowDialog();
   dlg.Dispose();
  }
 
 if (Directory.Exists(ImageDirectory) == false)
  {
   MainWnd.Response("Warning: Cannot access Picture Location JPG directory '" + ImageDirectory + "'!");
  }

 if (Directory.Exists(InventoryFileDirectory) == false)
  {
   MainWnd.Response("Warning: Cannot access Inventory File Image, PDF, Misc File Directory '" + InventoryFileDirectory + "'!");
  } 
}

public static System.Drawing.Image GetLocationPicture(in PictureLocation loc)
{
 string errmsg;

 if (PicLocImages.ContainsKey(loc.ID) == false)
  {
   PicLocImages.Add(loc.ID, new PictureLocationImage(loc.ID));
   if (PicLocImages[loc.ID].GetPicture(loc.FullPath, out errmsg) == false)
    {
     MainWnd.Response("Error loading Picture Location " + loc.FullPath + "\n\n " + errmsg);
     return null;
    }
  }
 return (System.Drawing.Image)PicLocImages[loc.ID].Picture.Clone();
}

public static System.Drawing.Image GeLocationThumb(in PictureLocation loc)
{
 string errmsg;

 if (PicLocImages.ContainsKey(loc.ID) == false)
  {
   PicLocImages.Add(loc.ID, new PictureLocationImage(loc.ID));
   if (PicLocImages[loc.ID].GetPicture(loc.FullPath, out errmsg) == false)
    {
     MainWnd.Response("Error loading Picture Location " + loc.FullPath + "\n\n " + errmsg);
     return null;
    }
  }
 return (System.Drawing.Image)PicLocImages[loc.ID].Thumb.Clone();
}


private static bool AddPictureLocation(in PictureLocation loc) // caches the images so they don't have to load everytime
{
 string errmsg;

 if (PicLocImages.ContainsKey(loc.ID) == false)
  {
   PicLocImages.Add(loc.ID, new PictureLocationImage(loc.ID));
   if (PicLocImages[loc.ID].GetPicture(loc.FullPath, out errmsg) == false)
    {
     MainWnd.Response("Error loading Picture Location " + loc.FullPath + "\n\n " + errmsg);
     return false;
    }
  }
 return true;
}

public static void Dispose()
{
 foreach(PictureLocationImage img in PicLocImages.Values)
   img.Dispose();

 PicLocImages.Clear();
}

};

public class Utility
{

public static bool DateTimeParse(string sDate, out DateTime value)
{
 value = DateTime.MinValue;

 return DateTime.TryParseExact(sDate, Globals.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out value);
}

public static Rectangle GetRect(Point start, Point end)
{
 Rectangle rct;
 int t, b, l, r;

 t = Math.Min(start.Y, end.Y);
 b = Math.Max(start.Y, end.Y);
 l = Math.Min(start.X, end.X);
 r = Math.Max(start.X, end.X);

 rct = Rectangle.FromLTRB(l, t, r, b);

 return rct;
}

public static void SaveWindowSetting(System.Windows.Forms.Form wnd)
{
 if (wnd.WindowState == FormWindowState.Maximized)
   MainWnd.SaveSettingBool(wnd.Name + "::IsMaximized", true);
 else
  {
   MainWnd.SaveSettingBool(wnd.Name + "::IsMaximized", false);
   MainWnd.SaveSettingInt(wnd.Name + "::Top", wnd.Top);
   MainWnd.SaveSettingInt(wnd.Name + "::Left", wnd.Left);
   MainWnd.SaveSettingInt(wnd.Name + "::Width", wnd.Width);
   MainWnd.SaveSettingInt(wnd.Name + "::Height", wnd.Height);
  }
}

public static void LoadWindowSetting(System.Windows.Forms.Form wnd)
{
 int x, y, w, h, i;
 bool err = false;

 if (MainWnd.GetSettingBool(wnd.Name + "::IsMaximized") == true) 
   wnd.WindowState = FormWindowState.Maximized;
 else
  {
   x = -1;  // have to make sure invalid values aren't passed to location and size
   y = -1;
   w = -1;
   h = -1;   
   if (int.TryParse(MainWnd.GetSetting(wnd.Name + "::Top", "0"),out i) == true) y = i; else err = true;
   if (int.TryParse(MainWnd.GetSetting(wnd.Name + "::Left", "0"),out i) == true) x = i; else err = true;
   if (int.TryParse(MainWnd.GetSetting(wnd.Name + "::Width", "0"),out i) == true) w = i; else err = true;
   if (int.TryParse(MainWnd.GetSetting(wnd.Name + "::Height", "0"),out i) == true) h = i; else err = true;
   if (err == false)
    {
     if (x >=0 && y >=0)
       wnd.Location = new Point(x, y);
     if (w > 100 && h > 100)
       wnd.Size = new Size(w, h);
    }
  }
}


};

public class Encrypt
{
 private System.Security.Cryptography.TripleDESCryptoServiceProvider tdes;


public Encrypt(String pwd)
{
 Byte [] key =  System.Text.Encoding.ASCII.GetBytes(pwd);

 Debug.Assert(pwd.Length > 0);

 tdes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
 tdes.Key = key;
 tdes.Mode = System.Security.Cryptography.CipherMode.ECB;
 tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
}
 
public Byte[] Encryption(String strText)
{
 byte [] text = System.Text.Encoding.ASCII.GetBytes(strText);
 System.Security.Cryptography.ICryptoTransform enc;
 Byte [] ov;

 if (strText.Length == 0)
   return null;

  enc = tdes.CreateEncryptor();
  ov = enc.TransformFinalBlock(text, 0, strText.Length);
  enc.Dispose();
  return ov;
}

public String Decrypt(in Byte[] text)
{
 System.Security.Cryptography.ICryptoTransform enc;
 Byte [] ov;
 String str;


 if (text == null) return "";
 if (text.Length == 0) return "";

 enc = tdes.CreateDecryptor();
 try
  {
   ov = enc.TransformFinalBlock(text, 0, text.Length);
  }   
 catch
  {
   enc.Dispose();
   return "";
  }

str = new String(System.Text.Encoding.ASCII.GetChars(ov));
enc.Dispose();
return str;
}

public void Dispose()
{
 tdes.Dispose();
}

public static String Encode(in Byte [] inv) 
{
 String str;
 int i;

 str = "";
 for (i = 0; i < inv.Length; i++)
  {
   if (i > 0) str += ",";
   str += inv[i].ToString();
  }
 return str;
}

public static Byte [] Decode(String str)
{
 Byte [] ov;
 String [] chrs;
 int i;
 Byte v;
 bool bValid;
 List<Byte> list=new List<byte>();
 
 chrs = str.Split(',');
 for (i = 0; i <chrs.Length;i++)
  {
   bValid = Byte.TryParse(chrs[i],out v);
   if (bValid == false) return null;
   list.Add(v);
  }

 ov = new byte[list.Count];
 for (i = 0; i< list.Count; i++)
  {
   ov[i] = list[i];
  }
 return ov;
}

};

public static class DB
{
 private static String m_ConnectionString;
 private static MySql.Data.MySqlClient.MySqlConnection m_Connection;

 public static MySql.Data.MySqlClient.MySqlConnection Con { get =>m_Connection; }

 public static string UserName { get; private set; }
 public static string Database { get; private set; }

static DB()
{
 m_ConnectionString="";
 m_Connection=null;
}

public static MySql.Data.MySqlClient.MySqlConnection Connection()
{
 MySql.Data.MySqlClient.MySqlConnection con;
 con=new MySql.Data.MySqlClient.MySqlConnection(m_ConnectionString);
 con.Open();
 return con;
}

private static bool TestConnect(String cs)
{
 MySql.Data.MySqlClient.MySqlConnection con;
 try 
  {
   con = new MySql.Data.MySqlClient.MySqlConnection(cs);
   con.Open();
  }
 catch 
  {
   return false;
  }
 con.Close();
 con.Dispose();
 return true;
}

public static bool Connect(bool bSilent)
{
 DialogResult r;
 LoginDlg login;
 bool resolved;
 bool good=false;

 if (m_Connection!=null)
  {
   m_Connection.Dispose();
   m_Connection=null;
  }

 // loop until database connectoin is made or connection prompt is dismissed
 
 do
  {
   resolved = false;
   login = new LoginDlg();
   login.StartPosition = FormStartPosition.CenterScreen;
   login.ShowInTaskbar = true;  // helps find login dialog if alt-tabbed
   if (login.chkRemember.Checked == true && bSilent == true)
    {
     resolved = TestConnect(login.Connection()); // bypass login dialog if possible
     if (resolved == false)
      {  
       if (MainWnd.Question("Retry/Redefine database connection?", MessageBoxButtons.YesNo) != DialogResult.Yes)
        {
         return false;
        }
      }
     else
      {
       m_ConnectionString=login.Connection();
       m_Connection=new MySqlConnection(m_ConnectionString);
       try
        {
         m_Connection.Open();
         UserName = login.txtName.Text.Trim();
         good=true;
        }
       catch
        {
         good=false;
        }
      }
    }
   if (resolved == false)
    {
     r = login.ShowDialog();
     if (r == DialogResult.OK) 
      {
       if (TestConnect(login.Connection()) == true)
        {
         login.SaveSettings();
         m_ConnectionString=login.Connection();
         UserName = login.txtName.Text.Trim();
         m_Connection=new MySqlConnection(m_ConnectionString);
         m_Connection.Open();
         good=true;
        }
      }
     else
      {
       if (MainWnd.Question("Retry database connection?", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
         return false;
      }
    }
   login.Dispose();
  }
 while( good == false);
 return true;
}
};


}
