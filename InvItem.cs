using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Google.Protobuf;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace Inventory
{

public class PictureLocation // hierarchy drill down pictures describing where something is located
{
 public uint    ID { get; private set; }
 public PictureLocation Parent { get; private set; }  // Parent picture location, can be null

 public string Name { get; private set; }    
 public string Desc { get; private set; }    
 public string File { get; private set; }    // picture of location
 public int    Order { get; private set; }   // so user can order the list of children

 public Rectangle Location { get; private set; }  // location on parent picture, can be empty, square showing where 
 public Color     LineColor { get; private set; } // color of the square drawn on the picture
 public int       LineWidth { get; private set; } // width of the square's lines

 public List<PictureLocation> Children { get; private set; } 

 public bool IsTopLevel { get => ParentIsNull(); }
 public bool IsBottomLevel { get => GetBottomLevel(); }

 public string FullPath { get => GetFullPath(); }

 public string Key { get => "p" + ID; }

public PictureLocation(string file) // insert a top level pic loc
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 
 cmd = new MySqlCommand("INSERT INTO picture_location(parent_id, loc_name, loc_desc, loc_file) VALUES (0, '', '', @file); SELECT LAST_INSERT_ID();", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@file", file));
 
 rs = cmd.ExecuteReader();
 rs.Read();
 ID = rs.GetUInt32(0);
 rs.Close();

 File = file;

 Children = new List<PictureLocation>();

}

public PictureLocation(in PictureLocation parent, string name, int order, string desc, string file, Rectangle rct, Color rc, int wl)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 uint par;

 
 cmd = new MySqlCommand("INSERT INTO picture_location(parent_id, loc_name, loc_desc, loc_file, loc_x, loc_y, loc_w, loc_h, rct_color, rct_width, loc_order) VALUES (@par, @name, @desc, @file, @x, @y, @w, @h, @c, @wl, @ord); SELECT LAST_INSERT_ID();", DB.Con);

 if (parent == null)
   par = 0;
 else
   par = parent.ID;

 cmd.Parameters.Add(new MySqlParameter("@par", par));
 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@desc", desc));
 cmd.Parameters.Add(new MySqlParameter("@file", file));
 cmd.Parameters.Add(new MySqlParameter("@x", rct.X));
 cmd.Parameters.Add(new MySqlParameter("@y", rct.Y));
 cmd.Parameters.Add(new MySqlParameter("@w", rct.Width));
 cmd.Parameters.Add(new MySqlParameter("@h", rct.Height));
 cmd.Parameters.Add(new MySqlParameter("@c", rc.ToArgb()));
 cmd.Parameters.Add(new MySqlParameter("@wl", wl));
 cmd.Parameters.Add(new MySqlParameter("@ord", order));

 rs = cmd.ExecuteReader();
 rs.Read();
 ID = rs.GetUInt32(0);
 rs.Close();

 Parent = parent;
 Name = name;
 Desc = desc;
 File = file;
 Location = rct;
 LineColor = rc;
 LineWidth = wl;
 Order = order;

 Children = new List<PictureLocation>();
}

public PictureLocation(uint id)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 uint parentId;
 bool notfound;

 parentId = 0;
 notfound = false;

 cmd = new MySqlCommand("SELECT parent_id, loc_name, loc_desc, loc_file, loc_x, loc_y, loc_w, loc_h, parent_id, rct_color, rct_width, loc_order FROM picture_location WHERE pic_loc_id=@loc", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@loc", id));
 rs = cmd.ExecuteReader();

 if (rs.Read() == false)
   notfound = true;
 else
  {
   ID = id;
   parentId = rs.GetUInt32(0);
   Name = rs.GetString(1);
   Desc = rs.GetString(2);
   File = rs.GetString(3);
   Location = new Rectangle(rs.GetInt32(4), rs.GetInt32(5), rs.GetInt32(6), rs.GetInt32(7));
   LineColor = Color.FromArgb(rs.GetInt32(8));
   LineWidth = rs.GetInt32(9);
   Order = rs.GetInt32(10);
  }
 rs.Close();

 if (notfound == true)
   throw new ArgumentException("picture location id " + id.ToString() + " not found on database");
 else
  {
   if (parentId > 0)
     Parent = new PictureLocation(parentId);
   else
     Parent = null;
  }

 Children = new List<PictureLocation>();
}

public PictureLocation(uint id, in PictureLocation parent, string name, string desc, string file, Rectangle rct, Color rc, int wl, int ord)
{
 ID = id;
 Parent = parent;
 Name = name;
 Desc = desc;
 File = file;
 Location = rct;
 LineColor = rc;
 LineWidth = wl;
 Order = ord;
 Children = new List<PictureLocation>();
}

public override string ToString()
{
 string val = "";

 if (Parent != null)
  val = Parent.ToString() + " >> ";
 
 if (Name.Length == 0)
   val += "Unnamed location #" + Order.ToString() + " (" + ID.ToString() + ")";
 else
   val += Name + " #" + Order.ToString() + " (" + ID.ToString() + ")";

 return val;
}

private string GetFullPath()
{
 return Globals.ImageDirectory + "\\" + File;
}

public void UpdateText(string name, string desc)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE picture_location SET loc_name=@name, loc_desc=@desc WHERE pic_loc_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@desc", desc));
 cmd.Parameters.Add(new MySqlParameter("@id", ID));

 cmd.ExecuteNonQuery();

 Name = name;
 Desc = desc;
}

public void UpdateFile(string file)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE picture_location SET loc_file=@file WHERE pic_loc_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@file", file));
 cmd.Parameters.Add(new MySqlParameter("@id", ID));

 cmd.ExecuteNonQuery();

 File = file;
}

public void UpdateOrder(int ord)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE picture_location SET loc_order=@ord WHERE pic_loc_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@ord", ord));
 cmd.Parameters.Add(new MySqlParameter("@id", ID));

 cmd.ExecuteNonQuery();

 Order = ord;
}


public void UpdateRect(Rectangle rct, Color rc, int wl)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE picture_location SET loc_x=@x, loc_y=@y, loc_w=@w, loc_h=@h, rct_color=@c, rct_width=@wl WHERE pic_loc_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@x", rct.X));
 cmd.Parameters.Add(new MySqlParameter("@y", rct.Y));
 cmd.Parameters.Add(new MySqlParameter("@w", rct.Width));
 cmd.Parameters.Add(new MySqlParameter("@h", rct.Height));
 cmd.Parameters.Add(new MySqlParameter("@c", rc.ToArgb()));
 cmd.Parameters.Add(new MySqlParameter("@wl", wl));
 cmd.Parameters.Add(new MySqlParameter("@id", ID));

 cmd.ExecuteNonQuery();

 Location = rct;
 LineColor  = rc;
 LineWidth = wl;

}

public uint GetInvCount()
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 uint count;

 if (IsBottomLevel == false)
   return 0;

 cmd = new MySqlCommand("SELECT COUNT(*) FROM inventory_item WHERE pic_loc_id=@loc;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@loc", ID));
 rs = cmd.ExecuteReader();
 rs.Read();
 count = rs.GetUInt32(0);
 rs.Close();
 
 return count;
}

public static bool CheckForInventory(PictureLocation loc) // check a location and it's children for inventory
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 uint count;

 foreach(PictureLocation sl in loc.Children)
  {
   if (PictureLocation.CheckForInventory(sl) == true)
     return true;
  }

 cmd = new MySqlCommand("SELECT COUNT(*) FROM inventory_item WHERE pic_loc_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", loc.ID));
 rs = cmd.ExecuteReader();
 rs.Read();
 count = rs.GetUInt32(0);
 rs.Close();
 
 return count > 0;
}

public static void DeleteRow(PictureLocation loc)
{
 MySqlCommand cmd;
 
 foreach(PictureLocation sl in loc.Children)
  {
   PictureLocation.DeleteRow(sl);
  }

 cmd = new MySqlCommand("DELETE FROM picture_location WHERE pic_loc_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", loc.ID));
 cmd.ExecuteNonQuery();

}

public void GetChildren()
{
 Children = PictureLocation.GetLocations(this);
}

// get all top level locations

public static List<PictureLocation> GetParentLocations()
{
 List<PictureLocation> list = new List<PictureLocation>();
 PictureLocation loc;
 MySqlCommand cmd;
 MySqlDataReader rs;
 
 Color c;
 int x, y, w, h, wl, ord;

 cmd = new MySqlCommand("SELECT pic_loc_id, loc_name, loc_desc, loc_file, loc_x, loc_y, loc_w, loc_h, rct_color, rct_width, loc_order FROM picture_location WHERE parent_id=0", DB.Con);
 rs = cmd.ExecuteReader();
 
 while (rs.Read() != false)
  {
   if (rs.IsDBNull(4) == false) x = rs.GetInt32(4); else x = 0;
   if (rs.IsDBNull(5) == false) y = rs.GetInt32(5); else y = 0;
   if (rs.IsDBNull(6) == false) w = rs.GetInt32(6); else w = 0;
   if (rs.IsDBNull(7) == false) h = rs.GetInt32(7); else h = 0;
   if (rs.IsDBNull(8) == false) c = Color.FromArgb(rs.GetInt32(8)); else c = Color.Black;
   if (rs.IsDBNull(9) == false) wl = rs.GetInt32(9); else wl = 1;
   if (rs.IsDBNull(10) == false) ord = rs.GetInt32(10); else ord = 0;
   loc = new PictureLocation(rs.GetUInt32(0), null, rs.GetString(1), rs.GetString(2),rs.GetString(3), new Rectangle(x, y, w, h), c, wl, ord);
   list.Add(loc);
  }
 rs.Close();

 foreach(PictureLocation pl in list)
  {
   pl.GetChildren();
  }

 return list; 
}

// get all locations belonging to a parent

public static List<PictureLocation> GetLocations(in PictureLocation parent)
{
 List<PictureLocation> list = new List<PictureLocation>();
 PictureLocation loc;
 MySqlCommand cmd;
 MySqlDataReader rs;
 
 cmd = new MySqlCommand("SELECT pic_loc_id, loc_name, loc_desc, loc_file, loc_x, loc_y, loc_w, loc_h, rct_color, rct_width, loc_order FROM picture_location WHERE parent_id=@parent", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@parent", parent.ID));
 rs = cmd.ExecuteReader();
 
 while (rs.Read() != false)
  {
   loc = new PictureLocation(rs.GetUInt32(0), parent, rs.GetString(1), rs.GetString(2),rs.GetString(3), new Rectangle(rs.GetInt32(4), rs.GetInt32(5), rs.GetInt32(6), rs.GetInt32(7)), Color.FromArgb(rs.GetInt32(8)), rs.GetInt32(9), rs.GetInt32(10));
   list.Add(loc);
  }
 rs.Close();

 foreach(PictureLocation pl in list)
  {
   pl.GetChildren();
  }

 return list;
}

private bool ParentIsNull()
{
 return Parent == null;
}

private bool GetBottomLevel()
{
 if (File.Length == 0 || Children.Count == 0)
   return true;
 else
   return false;
}

public static PictureLocation GetSingleLocation(uint id)
{
 PictureLocation loc, parent;
 MySqlCommand cmd1, cmd2;
 MySqlDataReader rs;
 uint parentId;

 cmd1 = new MySqlCommand("SELECT parent_id FROM picture_location WHERE pic_loc_id=@loc", DB.Con);
 cmd1.Parameters.Add(new MySqlParameter("@loc", id));
 rs = cmd1.ExecuteReader();
 if (rs.Read() == true)
   parentId = rs.GetUInt32(0);
 else
   parentId = 0;
 rs.Close();

 if (parentId > 0)
   parent = PictureLocation.GetSingleLocation(parentId);
 else
   parent = null;

 loc = null; 

 cmd2 = new MySqlCommand("SELECT pic_loc_id, loc_name, loc_desc, loc_file, loc_x, loc_y, loc_w, loc_h, rct_color, rct_width, loc_order FROM picture_location WHERE pic_loc_id=@loc", DB.Con);
 cmd2.Parameters.Add(new MySqlParameter("@loc", id));
 rs = cmd2.ExecuteReader();  
 
 if (rs.Read() == true)
  {
   loc = new PictureLocation(rs.GetUInt32(0), parent, rs.GetString(1), rs.GetString(2),rs.GetString(3), new Rectangle(rs.GetInt32(4), rs.GetInt32(5), rs.GetInt32(6), rs.GetInt32(7)), Color.FromArgb(rs.GetInt32(8)), rs.GetInt32(9), rs.GetInt32(10));
  }
 rs.Close();

 return loc;
}

};

// ///////////////////////////////////////////////////////////////////////////////////

public class PictureLocationImage : IDisposable
{
 public uint ID { get; private set; }
 public Image Thumb { get; private set; }     // 128 x 128 square of the image with control background color fill
 public Image Original { get; private set; }  // scaled down verison of image 
 public Image Picture { get; private set; }   // Actual Image
 public int Width { get; private set; }
 public int Height { get; private set; }
 public double Ratio { get; private set; }

 private bool IsDisposed = false;

public PictureLocationImage(uint id)
{
 ID = id;
}

~PictureLocationImage()
{
 if (null != Picture)
   MainWnd.Response("PictureLocation Picture not disposed");
}

public void Dispose()
{
 Dispose(true);
 GC.SuppressFinalize(this);
}

protected void Dispose(bool disposing)
{
 if (IsDisposed == false)
  {
   if (disposing)
    { 
     if (null != Thumb) Thumb.Dispose();             //release managed resources
     if (null != Original) Original.Dispose(); 
     if (null != Picture) Picture.Dispose();
    }
   IsDisposed = true;
  }
}

public bool GetPicture(string fullPath, out string errmsg)
{
 Graphics gr;
 int sw, sh;

 errmsg = "";

 if (null !=Thumb)
  {
   Thumb.Dispose(); 
   Thumb = null;
  }
 if (null != Original)
  {
   Original.Dispose();
   Original = null;
  }
 if (null != Picture)
  {
   Picture.Dispose();
   Picture = null;
  }

 try
  {
   Picture = (Bitmap)Bitmap.FromFile(fullPath, true);
  }
 catch(Exception ex)
  {
   errmsg = ex.Message;
   return false;
  } 

  Width = Picture.Width;
  Height = Picture.Height;
  Ratio = Width / Height;

  if (Width > Height)
   {
    sw = 128;
    sh = (int)(128.0 * (double)Height / (double)Width);
   }
  else
   {
    sh = 128;
    sw = (int)(128.0 * (double)Width / (double)Height);
   }

  Original = new Bitmap(sw, sh, System.Drawing.Imaging.PixelFormat.Format32bppArgb); // imgThumb is a smaller version of the original pic
  gr = Graphics.FromImage(Original);
  gr.DrawImage(Picture, new RectangleF(0, 0, sw, sh), new RectangleF(0, 0, Width, Height), GraphicsUnit.Pixel);
  gr.Dispose();

  Thumb = new Bitmap(128, 128, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
  gr = Graphics.FromImage(Thumb);
  gr.FillRectangle(SystemBrushes.Window, new Rectangle(0, 0, 128, 128));
  gr.DrawImage(Original, new Point(0, 0));
  gr.Dispose();
 
 return true;
}

};


// ///////////////////////////////////////////////////////////////////////////////////

public class NameLocation  // a simple name location for an item, "box #10"
{
 public uint ID { get; private set; }
 public string Name {get; private set; }
 public string Desc { get; private set; }
 public uint InvCount { get; private set; }

public NameLocation(string name, string desc)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 
 cmd = new MySqlCommand("INSERT INTO name_location(loc_name, loc_desc) VALUES (@name, @desc); SELECT LAST_INSERT_ID();", DB.Con);
 
 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@desc", desc));

 rs = cmd.ExecuteReader();
 rs.Read();
 ID = rs.GetUInt32(0);
 rs.Close();

 Name = name;
 Desc = desc;
}

public NameLocation(uint id, string name, string desc)
{
 ID = id;
 Name = name;
 Desc = desc;
 InvCount = 0;
}

public void UpdateText(string name, string desc)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE name_location SET loc_name=@name, loc_desc=@desc WHERE name_loc_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@desc", desc));
 cmd.Parameters.Add(new MySqlParameter("@id", ID));

 cmd.ExecuteNonQuery();

 Name = name;
 Desc = desc;
}

public void DeleteRow()
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("DELETE FROM name_location WHERE name_loc_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@id", ID));

 cmd.ExecuteNonQuery();
}

public static List<NameLocation> GetAllNames()
{
 List<NameLocation> list = new List<NameLocation>();
 MySqlCommand cmd;
 MySqlDataReader rs;
 
 cmd = new MySqlCommand("SELECT name_loc_id, loc_name, loc_desc FROM name_location;", DB.Con);
 rs = cmd.ExecuteReader();
 while (rs.Read() != false)
  {
   list.Add(new NameLocation(rs.GetUInt32(0), rs.GetString(1), rs.GetString(2)));
  }
 rs.Close();

 foreach(NameLocation loc in list)
   loc.InvCount = GetCount(loc.ID);

 return list;
}

public static NameLocation GetLocation(uint id)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 NameLocation loc;

 cmd = new MySqlCommand("SELECT loc_name, loc_desc FROM name_location WHERE name_loc_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", id));
 rs = cmd.ExecuteReader();
 if (rs.Read() == true)
  {
   loc = new NameLocation(id, rs.GetString(0), rs.GetString(1));
  }
 else
  {
   loc = null;
  }
 rs.Close();

 if (loc != null)
   loc.InvCount = GetCount(loc.ID);

 return loc;
}

public static uint GetCount(uint id)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 uint c;

 cmd = new MySqlCommand("SELECT COUNT(*) FROM inventory_item WHERE name_loc_id=@name;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@name", id));
 rs = cmd.ExecuteReader();
 rs.Read();
 c = rs.GetUInt32(0);
 rs.Close();

 return c;
}

};

// ///////////////////////////////////////////////////////////////////////////////////

public class InventoryLocation  
{
 public enum LocationType { Picture, Name, None };  

 public LocationType InvLocType { get; private set; }

 public PictureLocation PicLoc { get; private set; }    // can be null
 public NameLocation    NameLoc { get; private set; }   // can be null 

public InventoryLocation()
{
 InvLocType = LocationType.None;
 PicLoc = null;
 NameLoc = null;
}

public InventoryLocation(in PictureLocation picloc)
{
 InvLocType = LocationType.Picture;
 PicLoc = picloc;
 NameLoc = null;
}

public InventoryLocation(in NameLocation nameloc)
{
 InvLocType = LocationType.Name;
 PicLoc = null;
 NameLoc = nameloc;
}

public static InventoryLocation GetLocation(LocationType type, uint id)
{
 switch(type)
  {
   case LocationType.Picture: return new InventoryLocation(PictureLocation.GetSingleLocation(id));
   case LocationType.Name:    return new InventoryLocation(NameLocation.GetLocation(id));
   case LocationType.None:    return new InventoryLocation();
   default: throw new Exception("unhandled loc type");
  }
}

public override string ToString()
{
 switch(InvLocType)
  {
   case LocationType.Picture: return PicLoc.ToString();
   case LocationType.Name: return NameLoc.Name;
   case LocationType.None: return "None";
   default: throw new Exception("unhandled loc");
  }
}

};

// ///////////////////////////////////////////////////////////////////////////////////

public class InventoryCategoryProperty   // thinngs like resistor ohms, capacitor farads
{
 public uint CategoryID { get; private set; }
 public uint ID { get; private set; }
 public string PropertyName { get; private set; }
 public bool PrimaryProperty { get; private set; }  // ohms, capacitance

public InventoryCategoryProperty(uint cat, string name, bool primary)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 
 cmd = new MySqlCommand("INSERT INTO category_property(inv_cat_id, property_name, primary_prop) VALUES (@cat, @name, @primary); SELECT LAST_INSERT_ID();", DB.Con);
 
 cmd.Parameters.Add(new MySqlParameter("@cat", cat));
 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@primary", primary));

 rs = cmd.ExecuteReader();
 rs.Read();
 ID = rs.GetUInt32(0);
 rs.Close();
 
 CategoryID = cat;
 PropertyName = name;
 PrimaryProperty = primary;
}

public InventoryCategoryProperty(uint cat, uint id, string name, bool primary)
{
 CategoryID = cat;
 ID = id;
 PropertyName = name;
 PrimaryProperty = primary;
}

public void UpdateText(string name)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE category_property SET property_name=@name WHERE cat_prop_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.ExecuteNonQuery();

 PropertyName = name;
}

public void UpdatePrimary(bool primary)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE category_property SET primary_prop=@primary WHERE cat_prop_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@primary", primary));
 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.ExecuteNonQuery();

 PrimaryProperty = primary;
}

public void Delete()
{
 MySqlCommand cmd1, cmd2;

 cmd1 = new MySqlCommand("DELETE FROM inventory_item_prop_value WHERE cat_prop_id=@id;", DB.Con);
 cmd1.Parameters.Add(new MySqlParameter("@id", ID));
 cmd1.ExecuteNonQuery();


 cmd2 = new MySqlCommand("DELETE FROM category_property WHERE cat_prop_id=@id;", DB.Con);
 cmd2.Parameters.Add(new MySqlParameter("@id", ID));
 cmd2.ExecuteNonQuery();
}

public static List<InventoryCategoryProperty> GetProps(uint cat_id)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 List<InventoryCategoryProperty> list = new List<InventoryCategoryProperty>();

 cmd = new MySqlCommand("SELECT cat_prop_id, property_name, primary_prop FROM category_property WHERE inv_cat_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", cat_id));
 rs = cmd.ExecuteReader();
 while(rs.Read() == true)
  {
   list.Add(new InventoryCategoryProperty(cat_id, rs.GetUInt32(0), rs.GetString(1), rs.GetInt16(2) == 1));
  }
 rs.Close();

 return list;
}

};

// ///////////////////////////////////////////////////////////////////////////////////

public class InventoryCategory // capacitor, resistor, ic, etc
{
 public uint ID { get; private set; }

 public string Name { get; private set; }
 public string Desc { get; private set; }
 public string Notes{ get; private set; }

 public string FilePath { get => ID.ToString("X8"); }

 public InventoryCategoryProperty PrimaryProperty { get => GetPrimaryProperty(); }

 public List<InventoryCategoryProperty> Properties { get; private set; }
 
public InventoryCategory(string name, string desc, string notes)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 
 cmd = new MySqlCommand("INSERT INTO inventory_category(cat_name, cat_desc, notes) VALUES (@name, @desc, @notes); SELECT LAST_INSERT_ID();", DB.Con);
 
 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@desc", desc));
 cmd.Parameters.Add(new MySqlParameter("@notes", notes));

 rs = cmd.ExecuteReader();
 rs.Read();
 ID = rs.GetUInt32(0);
 rs.Close();
 
 Name = name;
 Desc = desc;
 Notes = notes;

 Properties = new List<InventoryCategoryProperty>();
}

public bool CreateDirectory()
{
 string path, err;

 if (Directory.Exists(Globals.InventoryFileDirectory) == false)
  {
   MainWnd.Response("Inventory File Directory '" + Globals.InventoryFileDirectory + "' doesn't exist or is inaccessible");
   return false;
  }

 path = Globals.InventoryFileDirectory + "\\" + FilePath;

 if (Directory.Exists(path) == true)
   return true;

 try
  {
   Directory.CreateDirectory(path);
  }
 catch(Exception ex)
  {
   err = "Unable to create Inventory File Directory '" + path + "' for category '" + Name + "'.\n\n";
   err += ex.Message;
   MainWnd.Response(err);
   return false;
  }

 return true;
}

public InventoryCategory(uint id, string name, string desc, string notes)
{
 ID = id;
 Name = name;
 Desc = desc;
 Notes = notes;
 Properties = new List<InventoryCategoryProperty>();
}

public void GetProperties()
{
 Properties = InventoryCategoryProperty.GetProps(ID);
}

public void UpdateText(string name, string desc, string notes)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE inventory_category SET cat_name=@name, cat_desc=@desc, notes=@notes WHERE inv_cat_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@desc", desc));
 cmd.Parameters.Add(new MySqlParameter("@notes", notes)); 
 cmd.Parameters.Add(new MySqlParameter("@id", ID));

 cmd.ExecuteNonQuery();

 Name= name;
 Desc = desc;
 Notes = notes;
}

public bool Delete()
{
 MySqlCommand  cmd1, cmd2, cmd3;
 MySqlDataReader rs;
 List<uint> ids = new List<uint>();
 InventoryItem item;
 string path, err;


 cmd1 = new MySqlCommand("SELECT inv_item_id FROM inventory_item WHERE inv_cat_id=@id;", DB.Con);
 cmd1.Parameters.Add(new MySqlParameter("@id", ID));
 rs = cmd1.ExecuteReader();
 while(rs.Read() == true)
   ids.Add(rs.GetUInt32(0));
 rs.Close();

 foreach(uint id in ids)
  {
   item = InventoryItem.GetSingleItem(id);
   if (item.Delete() == false)
    {
     MainWnd.Response("Warning: some inventory items may have been deleted before the error occurred");
     return false;
    }
  }

 path = Globals.InventoryFileDirectory + "\\" + FilePath;

 try
  {
   System.IO.Directory.Delete(path);
  }
 catch(Exception ex)
  {
   err = "Unable to delete category directory " + path + "\n\n";
   err += ex.Message + "\n\n";
   err += "Delete it manually";
   MainWnd.Response(err);
  }

 cmd2 = new MySqlCommand("DELETE FROM category_property WHERE inv_cat_id=@id;", DB.Con);
 cmd2.Parameters.Add(new MySqlParameter("@id", ID));
 cmd2.ExecuteNonQuery();

 cmd3 = new MySqlCommand("DELETE FROM inventory_category WHERE inv_cat_id=@id;", DB.Con);
 cmd3.Parameters.Add(new MySqlParameter("@id", ID));
 cmd3.ExecuteNonQuery();

 return true;
}

public InventoryCategoryProperty GetPrimaryProperty()
{
 foreach(InventoryCategoryProperty p in Properties)
  {
   if (p.PrimaryProperty == true)
     return p;
  }

 return null;
}

public static List<InventoryCategory> GetCategories()
{
 List<InventoryCategory> list = new List<InventoryCategory>();
 List<InventoryCategoryProperty> props;
 MySqlCommand cmd;
 MySqlDataReader rs;

 cmd = new MySqlCommand("SELECT inv_cat_id, cat_name, cat_desc, notes FROM inventory_category; ", DB.Con);
 rs = cmd.ExecuteReader();
 while(rs.Read() == true)
  {
   list.Add(new InventoryCategory(rs.GetUInt32(0), rs.GetString(1), rs.GetString(2), rs.GetString(3)));
  }
 rs.Close();

 foreach(InventoryCategory c in list)
  {
   props = InventoryCategoryProperty.GetProps(c.ID);
   foreach(InventoryCategoryProperty p in props)
    {
     c.Properties.Add(p);
    }
  }

 return list;
}

public static List<string> GetNames()
{
 List<string> list = new List<string>();
 MySqlCommand cmd;
 MySqlDataReader rs;

 cmd = new MySqlCommand("SELECT cat_name FROM inventory_category; ", DB.Con);
 rs = cmd.ExecuteReader();
 while(rs.Read() == true)
  {
   list.Add(rs.GetString(0));
  }
 rs.Close();

 return list;
}

public static InventoryCategory GetCategory(uint id)
{
 List<InventoryCategoryProperty> props;
 MySqlCommand cmd;
 MySqlDataReader rs;
 InventoryCategory cat;

 props = InventoryCategoryProperty.GetProps(id);

 cmd = new MySqlCommand("SELECT cat_name, cat_desc, notes FROM inventory_category WHERE inv_cat_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", id));
 rs = cmd.ExecuteReader();
 if (rs.Read() == true)
  {
   cat = new InventoryCategory(id, rs.GetString(0), rs.GetString(1), rs.GetString(2));
  }
 else
  {
   cat = null;
  }
 rs.Close();

 cat.Properties = InventoryCategoryProperty.GetProps(cat.ID);

 return cat;
}

public static uint GetInvCount(uint id)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 uint c; 

 cmd = new MySqlCommand("SELECT COUNT(*) FROM inventory_item WHERE inv_cat_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", id));
 rs = cmd.ExecuteReader();
 rs.Read();
 c = rs.GetUInt32(0);
 rs.Close();

 return c;

}

};

// ///////////////////////////////////////////////////////////////////////////////////

public class InventoryCategoryValue
{
 public InventoryCategoryProperty CatProp { get; private set; }
 public float Value { get; private set; }

public InventoryCategoryValue(in InventoryCategoryProperty cp, float val)
{
 CatProp = cp;
 Value = val;
}

public InventoryCategoryValue(uint item_id, in InventoryCategory cat, in InventoryCategoryProperty prop, float val)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("INSERT INTO inventory_item_prop_value (inv_item_id, inv_cat_id, cat_prop_id, prop_value) VALUES (@item, @cat, @prop, @val); ", DB.Con);
 
 cmd.Parameters.Add(new MySqlParameter("@item", item_id));
 cmd.Parameters.Add(new MySqlParameter("@cat", cat.ID));
 cmd.Parameters.Add(new MySqlParameter("@prop", prop.ID));
 cmd.Parameters.Add(new MySqlParameter("@val", val));
 
 cmd.ExecuteNonQuery();

 CatProp = prop;
 Value = val;

}

public static List<InventoryCategoryValue> GetValues(InventoryItem item)
{
 List<InventoryCategoryValue> list = new List<InventoryCategoryValue>();
 MySqlCommand cmd;
 MySqlDataReader rs;
 bool found;

 cmd = new MySqlCommand("SELECT cat_prop_id, prop_value FROM inventory_item_prop_value WHERE inv_item_id=@item AND inv_cat_id=@cat; ", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@item", item.ID));
 cmd.Parameters.Add(new MySqlParameter("@cat", item.InvCat.ID));
 rs = cmd.ExecuteReader();
 while(rs.Read() == true)
  {
   found = false;
   foreach(InventoryCategoryProperty prop in item.InvCat.Properties)
    {
     if (prop.ID == rs.GetUInt32(0))
      {
       list.Add(new InventoryCategoryValue(prop, rs.GetFloat(1)));
       found = true;
      }
    }
   if (found == false)
     throw new Exception("didn't find cat prop value");
  }
 rs.Close();

 return list;
}

public static void UpdateValue(InventoryCategoryValue cv, uint item, float val)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE inventory_item_prop_value SET prop_value=@val WHERE inv_item_id=@item AND inv_cat_id=@cat AND cat_prop_id=@prop;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@val", val));
 cmd.Parameters.Add(new MySqlParameter("@item", item));
 cmd.Parameters.Add(new MySqlParameter("@cat", cv.CatProp.CategoryID));
 cmd.Parameters.Add(new MySqlParameter("@prop", cv.CatProp.ID));
 
 cmd.ExecuteNonQuery();

}

};

// ///////////////////////////////////////////////////////////////////////////////////

public class PurchaseHistory
{
 public uint    ID { get; private set; }
 public InventoryItem Item { get; private set; }
 public string Source { get; private set; }                 // company name
 public string Link   { get; private set; }                 // url link
 public DateTime PurchaseDate { get; private set; }
 public float Price { get; private set; }           // when bought the price per item
 public int Amount { get; private set; }            // when bought the amount purchased

public PurchaseHistory(uint id, in InventoryItem item, string src, string url, DateTime date, float price, int amount)
{
 ID = id;
 Item = item;
 Source = src;
 Link = url;
 PurchaseDate = date;
 Price = price;
 Amount = amount;
}

public PurchaseHistory(in InventoryItem item, string src, string url, DateTime date, float price, int amount)
{
 MySqlCommand cmd1;
 MySqlDataReader rs;
 
 cmd1 = new MySqlCommand("INSERT INTO purchase_history(inv_item_id, hist_source, hist_link, purchase_date, units_price, units_amount) VALUES (@item, @src, @url, @date, @price, @amount); SELECT LAST_INSERT_ID();", DB.Con);
 
 cmd1.Parameters.Add(new MySqlParameter("@item", item.ID));
 cmd1.Parameters.Add(new MySqlParameter("@src", src));
 cmd1.Parameters.Add(new MySqlParameter("@url", url));
 cmd1.Parameters.Add(new MySqlParameter("@date", date));
 cmd1.Parameters.Add(new MySqlParameter("@price", price));
 cmd1.Parameters.Add(new MySqlParameter("@amount", amount));

 rs = cmd1.ExecuteReader();
 rs.Read();
 ID = rs.GetUInt32(0);
 rs.Close();

 item.AddInventory(amount);
 
 Item = item;
 Source = src;
 Link = url;
 PurchaseDate = DateTime.Now;  // close enough 
 Price = price;
 Amount = amount;
}

public static List<PurchaseHistory> Read(in InventoryItem item)
{
 List<PurchaseHistory> list = new List<PurchaseHistory>();
 MySqlCommand cmd;
 MySqlDataReader rs;
 
 cmd = new MySqlCommand("SELECT purch_hist_id, hist_source, hist_link, purchase_date, units_price, units_amount FROM purchase_history WHERE inv_item_id=@item", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@item", item.ID));
 rs = cmd.ExecuteReader();
 
 while(rs.Read() == true)
  {
   list.Add(new PurchaseHistory(rs.GetUInt32(0), item, rs.GetString(1), rs.GetString(2), rs.GetDateTime(3), rs.GetFloat(4), rs.GetInt32(5)));
  }
 rs.Close();

 return list;
}

public void Update(string src, string url, DateTime date, float price, int amount)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE purchase_history SET hist_source=@hs, hist_link=@hl, purchase_date=@hd, units_price=@hp, units_amount=@ha WHERE purch_hist_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.Parameters.Add(new MySqlParameter("@hs", src));
 cmd.Parameters.Add(new MySqlParameter("@hl", url));
 cmd.Parameters.Add(new MySqlParameter("@hd", date));
 cmd.Parameters.Add(new MySqlParameter("@hp", price));
 cmd.Parameters.Add(new MySqlParameter("@ha", amount));

 cmd.ExecuteNonQuery();

 Source = src;
 Link = url;
 PurchaseDate = date;
 Price = price;
 Amount = amount;
}

public void Delete()
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("DELETE FROM purchase_history WHERE purch_hist_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.ExecuteNonQuery();
}

public static List<string> GetUniqueSources()
{
 List<string> sources = new List<string>();
 MySqlCommand cmd;
 MySqlDataReader rs;

 cmd = new MySqlCommand("SELECT DISTINCT hist_source FROM purchase_history ORDER BY hist_source;", DB.Con);
 rs = cmd.ExecuteReader();
 while(rs.Read() == true)
   sources.Add(rs.GetString(0));
 rs.Close();
 return sources;
}

};

// ///////////////////////////////////////////////////////////////////////////////////


public class InventoryFile
{
 public enum FileTypes : int { Image=1, PDF=2, URL=3, Other=4 };

 public uint ID { get; private set; }
 public InventoryItem Item { get; private set; }
 public FileTypes Type { get; private set; }
 public string Path { get; private set; }
 public string Name { get; private set; }
 public string Desc { get; private set; }
 public string Extension { get; private set; }
 
 public string FilePath { get =>  ID.ToString("X8") + Extension; }
 public string FullPath { get => Globals.InventoryFileDirectory + "\\" + Item.InvCat.FilePath + "\\" + FilePath; }


public InventoryFile(uint id, in InventoryItem item, int type, string path, string name, string desc, string ext)
{
 ID = id;
 Item = item;
 Path = path;
 Name = name;
 Desc = desc;
 Extension = ext;
 Type = GetType(type); 
}

public InventoryFile(InventoryItem item, FileTypes type, string path, string name, string desc, string ext)
{
 MySqlCommand cmd;
 MySqlDataReader rs;

 cmd = new MySqlCommand("INSERT INTO inventory_item_file(inv_item_id, file_type, file_path, file_name, file_desc, file_ext) VALUES (@item, @type, @path, @name, @desc, @ext); SELECT LAST_INSERT_ID();", DB.Con);
 
 cmd.Parameters.Add(new MySqlParameter("@item", item.ID));
 cmd.Parameters.Add(new MySqlParameter("@type", (int)type));
 cmd.Parameters.Add(new MySqlParameter("@path", path));
 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@desc", desc));
 cmd.Parameters.Add(new MySqlParameter("@ext", ext));

 rs = cmd.ExecuteReader();
 rs.Read();
 ID = rs.GetUInt32(0);
 rs.Close();

 Item = item;
 Path = path;
 Name = name;
 Desc = desc;
 Extension = ext;
 Type = type;

}

public bool CopyFile(in InventoryItem item, string path)
{
 string newPath;
 string err;

 if (item.InvCat.CreateDirectory() == false)
  {
   Delete();
   return false;
  }
 newPath = Globals.InventoryFileDirectory + "\\" + item.InvCat.FilePath + "\\" + FilePath;

 try
  {
   File.Copy(path, newPath);
  }
 catch(Exception ex)
  {
   err = "Unable to Move Inventory File Directory from '" + path + "' to '" + newPath + "'.\n\n";
   err += ex.Message;
   MainWnd.Response(err);
   Delete();
   return false;
  }

 return true;
}

public void Update(string name, string desc)
{
 MySqlCommand cmd;
 
 cmd = new MySqlCommand("UPDATE inventory_item_file SET file_name=@name, file_desc=@desc WHERE item_file_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@desc", desc));

 cmd.ExecuteNonQuery();

 Name = name;
 Desc = desc;
}

public bool DeleteFile()
{
 DialogResult r;
 bool tryAgain = true;
 string err, fullPath;

 fullPath = FullPath;

 do
  {
   if (System.IO.File.Exists(fullPath) == false)
    {
     err = "Warning, file " + fullPath + " Not Found!\n\n";
     err += "Fix Network Problems. Try to delete file again ?\n\n";
     r =MainWnd.Question(err, MessageBoxButtons.YesNoCancel);
     switch(r)
      {
       case DialogResult.Yes:    tryAgain = true;  break;    
       case DialogResult.No:     tryAgain = false; break;    // delete will succeed;
       case DialogResult.Cancel: return false;               // cancel delete
      }
    }
   else
    {
     break;
    }
  }
 while(tryAgain == true);
 do
  {
   try 
    {
     System.IO.File.Delete(fullPath);
     return true;
    }
   catch(Exception ex)
    {
     err = "Unable to delete associated file " + fullPath + "\n\n";
     err += ex.Message + "\n\n";
     err += "Close any open files. Fix Network Problems. Try to delete file again ?";
     r =MainWnd.Question(err, MessageBoxButtons.YesNoCancel);
     switch(r)
      {
       case DialogResult.Yes:    tryAgain = true; break; // retry
       case DialogResult.No:     return true;            // delete item anyway
       case DialogResult.Cancel: return false;           // cancel delete
      }
    }
  }
 while(tryAgain == true);
 return false;
}

public void Delete()
{
 MySqlCommand cmd;
 
 cmd = new MySqlCommand("DELETE FROM inventory_item_file WHERE item_file_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@id", ID));

 cmd.ExecuteNonQuery();
}

public static List<InventoryFile> GetFiles(in InventoryItem item)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 List<InventoryFile> list = new List<InventoryFile>();
 string ext;

 cmd = new MySqlCommand("SELECT item_file_id, file_type, file_path, file_name, file_desc, file_ext FROM inventory_item_file WHERE inv_item_id=@item;", DB.Con);
 
 cmd.Parameters.Add(new MySqlParameter("@item", item.ID));

 rs = cmd.ExecuteReader();

 while(rs.Read() == true)
  {
   if (rs.IsDBNull(5) == true) 
     ext = "";
   else
     ext = rs.GetString(5);
   list.Add(new InventoryFile(rs.GetUInt32(0), item, rs.GetInt32(1), rs.GetString(2), rs.GetString(3), rs.GetString(4), ext));
  }
 rs.Close();

 return list;
}

public static string GetTypeName(FileTypes type)
{
 switch(type)
  {
   case FileTypes.Image: return "Image";
   case FileTypes.PDF: return "PDF";
   case FileTypes.URL: return "URL";
   case FileTypes.Other: return "Other";
   default: throw new Exception("un-handled enum value");
  }
}

public static FileTypes GetType(int type)
{
 switch(type)
  {
   case 1: return FileTypes.Image;
   case 2: return FileTypes.PDF;
   case 3: return FileTypes.URL;
   case 4: return FileTypes.Other;
   default: throw new Exception("un-handled enum value");
  }
}

};

// ///////////////////////////////////////////////////////////////////////////////////

public class LVInvItem : ListViewItem  // this class is designed to be fast, the InventoryItem is not used
{
 public uint ItemID { get; private set; }
 public const string SelectClauseProps = "SELECT a.inv_item_id, a.item_name, a.inv_count, a.item_created, a.item_changed, a.item_added, a.item_removed, a.inv_cat_id FROM inventory_item a, inventory_item_prop_value b, category_property c WHERE a.inv_item_id=b.inv_item_id AND b.cat_prop_id=c.cat_prop_id AND c.primary_prop=1 ";
 public const string SelectClauseAdvProps = "SELECT a.inv_item_id, a.item_name, a.inv_count, a.item_created, a.item_changed, a.item_added, a.item_removed, a.inv_cat_id FROM inventory_item a, inventory_item_prop_value b WHERE a.inv_item_id=b.inv_item_id ";
 public const string SelectClauseNoProps = "SELECT a.inv_item_id, a.item_name, a.inv_count, a.item_created, a.item_changed, a.item_added, a.item_removed, a.inv_cat_id FROM inventory_item a ";
 public const string SelectClauseFileSearch = "SELECT a.inv_item_id, a.item_name, a.inv_count, a.item_created, a.item_changed, a.item_added, a.item_removed, a.inv_cat_id FROM inventory_item a, inventory_item_file c ";


 public float PrimaryValue { get; private set; }
 public float InvCount { get; private set; }

 public DateTime Created { get; private set; }
 public DateTime Changed { get; private set; }
 public DateTime InvAdded { get; private set; }
 public DateTime InvRemoved { get; private set; }

 public InventoryCategory InvCat { get; private set; }

public LVInvItem(uint id, InventoryCategory invcat, string name, string count, DateTime create, DateTime chg, DateTime added, DateTime rmv)
{
 float v;

 Text = name;
 InvCat = invcat;

 SubItems.Add(invcat.Name);
 SubItems.Add("");
 SubItems.Add(count);

 if (count.Length > 0)
  {
   if (float.TryParse(count, out v) == true)
     InvCount = v;
   else
     InvCount = 0;
  }

 ItemID = id;
 Created = create;
 Changed = chg;
 InvAdded = added;
 InvRemoved = rmv;

 SubItems.Add(Created.ToString(Globals.DateFormat));
 SubItems.Add(Changed.ToString(Globals.DateFormat));
 SubItems.Add(MainWnd.GetDateString(InvAdded));
 SubItems.Add(MainWnd.GetDateString(InvRemoved));

 SubItems.Add(id.ToString());
}

public void UpdateText(in InventoryItem item)
{
 int index;
 bool found = false;

 InvCat = item.InvCat;

 Text = item.ToString();

 SubItems[1].Text = item.InvCat.Name;

 index = 0;
 foreach(InventoryCategoryProperty prop in item.InvCat.Properties)
  {
   if (prop.PrimaryProperty == true)
    {
     SubItems[2].Text = item.CategoryValues[index].Value.ToString("0.0000");
     found = true;
    }
   if (found == false)
     SubItems[2].Text = "N/A";
  }
 SubItems[3].Text = item.InventoryCount.ToString();
 SubItems[4].Text = item.Created.ToString(Globals.DateFormat);
 SubItems[5].Text = item.Changed.ToString(Globals.DateFormat);
 SubItems[6].Text = item.InvAdded.ToString(Globals.DateFormat);
 SubItems[7].Text = item.InvRemoved.ToString(Globals.DateFormat);

}

public static string GetPrimaryValue(uint id, in InventoryCategory cat)  // called after loading ListView
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 bool found = false;
 float v = 0;

 if (cat.PrimaryProperty == null)
   return "";

 cmd = new MySqlCommand("SELECT prop_value FROM inventory_item_prop_value WHERE inv_item_id=@item AND inv_cat_id=@cat AND cat_prop_id=@prop;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@item", id));
 cmd.Parameters.Add(new MySqlParameter("@cat", cat.ID));
 cmd.Parameters.Add(new MySqlParameter("@prop", cat.PrimaryProperty.ID));
 rs = cmd.ExecuteReader();
 if (rs.Read() == true)
  {
   v = rs.GetFloat(0);
   found = true;
  }
 rs.Close();

 if (found == true)
   return v.ToString("0.0000");
 else
   return "N/A";
}

public static List<LVInvItem> GetItems(in InventoryCategory cat, in MySqlDataReader rs)
{
 List<LVInvItem> items = new List<LVInvItem>();
 LVInvItem item;
 DateTime created, changed, invadd, invremove;
 string name;
 string sCount;
 uint id;

 while(rs.Read() == true)
  {
   id = rs.GetUInt32(0);
   name = rs.GetString(1); // name cannot be null
   if (rs.IsDBNull(2) == false) sCount = rs.GetFloat(2).ToString("0.00"); else sCount = "";
   created = rs.GetDateTime(3); 
   changed = rs.GetDateTime(4); 
   if (rs.IsDBNull(5) == false) invadd = rs.GetDateTime(5); else invadd = DateTime.MinValue;
   if (rs.IsDBNull(6) == false) invremove = rs.GetDateTime(6); else invremove = DateTime.MinValue;
   item = new LVInvItem(id, cat, name, sCount, created, changed, invadd, invremove);
   items.Add(item);
  }

 return items;
}

public static List<LVInvItem> GetItems(in Dictionary<uint, InventoryCategory> cats, in MySqlDataReader rs)
{
 List<LVInvItem> items = new List<LVInvItem>();
 LVInvItem item;
 DateTime created, changed, invadd, invremove;
 string name;
 string sCount;
 uint id, cat;

 while(rs.Read() == true)
  {
   id = rs.GetUInt32(0);
   name = rs.GetString(1); // name cannot be null
   if (rs.IsDBNull(2) == false) sCount = rs.GetFloat(2).ToString("0.00"); else sCount = "";
   created = rs.GetDateTime(3); 
   changed = rs.GetDateTime(4); 
   if (rs.IsDBNull(5) == false) invadd = rs.GetDateTime(5); else invadd = DateTime.MinValue;
   if (rs.IsDBNull(6) == false) invremove = rs.GetDateTime(6); else invremove = DateTime.MinValue;
   cat = rs.GetUInt32(7);
   item = new LVInvItem(id, cats[cat], name, sCount, created, changed, invadd, invremove);
   items.Add(item);
  }

 return items;
}


public static void AddColumns(in ListView lv, in InventoryCategory cat)
{

 lv.Columns.Clear();
 
 lv.Columns.Add("c1", "Item");
 lv.Columns.Add("c2", "Category");
 if (cat != null)
  {
   if (cat.PrimaryProperty == null)
     lv.Columns.Add("c3", "N/A");
   else
     lv.Columns.Add("c3", cat.PrimaryProperty.PropertyName);
  }
 else
  {
   lv.Columns.Add("c3", "Property");
  }
 lv.Columns.Add("c4", "Count");
 lv.Columns.Add("c5", "Created");
 lv.Columns.Add("c6", "Changed");
 lv.Columns.Add("c7", "Inv Added");
 lv.Columns.Add("c8", "Inv Removed");
 lv.Columns.Add("c9", "ID");
}

public static void ResizeColumns(in ListView lv)
{
 lv.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
 lv.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
 lv.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[7].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
 lv.Columns[8].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
}

public static LVItemSorter.SortColumn GetColumn(int headerClicked)
{
 switch(headerClicked)
  {
   case 0: return LVItemSorter.SortColumn.Name;
   case 1: return LVItemSorter.SortColumn.Category;
   case 2: return LVItemSorter.SortColumn.PrimaryValue;
   case 3: return LVItemSorter.SortColumn.Count;
   case 4: return LVItemSorter.SortColumn.Create;
   case 5: return LVItemSorter.SortColumn.Changed;
   case 6: return LVItemSorter.SortColumn.InvAdded;
   case 7: return LVItemSorter.SortColumn.InvRemoved;
   case 8: return LVItemSorter.SortColumn.ID;
  }
 throw new Exception("header column click value not handled");
}

};

public class LVItemSorter : IComparer
{
 public enum SortColumn : int { Name, Category, PrimaryValue, Count, Create, Changed, InvAdded, InvRemoved, ID }
 
 public SortColumn Column { get; private set; }
 public bool Ascending { get; private set; }

public LVItemSorter(SortColumn col, bool asc)
{
 Column = col;
 Ascending = asc;
}

public int Compare(Object x, Object y)
{
 LVInvItem lvx, lvy;
 
 if (Ascending == true)
  {
   lvx = (LVInvItem)x;
   lvy = (LVInvItem)y;
  }
 else
  {
   lvx = (LVInvItem)y;
   lvy = (LVInvItem)x;   
  }

 switch(Column)
  {
   case SortColumn.Name: return string.Compare(lvx.Text, lvy.Text);
   case SortColumn.Category: return string.Compare(lvx.SubItems[1].Text, lvy.SubItems[1].Text);
   case SortColumn.PrimaryValue:
    {
     if (lvx.PrimaryValue > lvy.PrimaryValue) return 1;
     if (lvx.PrimaryValue < lvy.PrimaryValue) return -1;
     return 0;
    } 
   case SortColumn.Count:
    {
     if (lvx.InvCount > lvy.InvCount) return 1;
     if (lvx.InvCount < lvy.InvCount) return -1;
     return 0;
    } 
   case SortColumn.Create:
    {
     if (lvx.Created > lvy.Created) return 1;
     if (lvx.Created < lvy.Created) return -1;
     return 0;
    } 
   case SortColumn.Changed:
    {
     if (lvx.Changed > lvy.Changed) return 1;
     if (lvx.Changed < lvy.Changed) return -1;
     return 0;
    } 
   case SortColumn.InvAdded:
    {
     if (lvx.InvAdded > lvy.InvAdded) return 1;
     if (lvx.InvAdded < lvy.InvAdded) return -1;
     return 0;
    } 
   case SortColumn.InvRemoved:
    {
     if (lvx.InvRemoved > lvy.InvRemoved) return 1;
     if (lvx.InvRemoved < lvy.InvRemoved) return -1;
     return 0;
    } 
   case SortColumn.ID:
    {
     if (lvx.ItemID > lvy.ItemID) return 1;
     if (lvx.ItemID < lvy.ItemID) return -1;
     return 0;
    } 
   default: throw new Exception("sort case not handled");
  }
}

};

// ///////////////////////////////////////////////////////////////////////////////////

public class InventoryItem
{

 public uint ID { get; private set; }

 public InventoryCategory InvCat { get; private set; }
 public InventoryLocation InvLoc { get; private set; }

 public List<InventoryCategoryValue> CategoryValues { get; private set; } // list of values described by category
 public List<PurchaseHistory> History { get; private set; } // record of purchases

 public int InventoryCount { get; private set; } // amount on hand

 public float EstimatedCost { get; private set; }

 public string InvName { get; private set; }
 public string Desc    { get; private set; }
 public string Notes   { get; private set; }

 public List<InventoryFile> Files { get; private set; }   // list different types of files associated with an item

 public DateTime Created { get; private set; }     // date record added
 public DateTime Changed { get; private set; }     // last date record changed
 public DateTime InvAdded { get; private set; }    // last date inv count added to
 public DateTime InvRemoved { get; private set; }  // laste date inv count subtracted from

 public float Weight { get; private set; }                  // weight per unit
 public float Volume { get; private set; }                  // volume per unit

public InventoryItem(uint id, in InventoryLocation loc, in InventoryCategory cat, in List<InventoryCategoryValue> values, int count, float cost, string name, string desc, string notes, DateTime create, DateTime chg, DateTime added, DateTime removed)
{
 ID = id;

 InvLoc = loc;
 InvCat = cat;
 CategoryValues = values;
 History = new List<PurchaseHistory>();
 InventoryCount = count;
 EstimatedCost = cost;
 InvName = name;
 Desc = desc;
 Notes = notes;

 Created = create; 
 Changed = chg;
 InvAdded = added;
 InvRemoved = removed;
 Files = new List<InventoryFile>();
 
}

public InventoryItem(in InventoryLocation loc, in InventoryCategory cat, int count, float cost, string name, string desc, string notes)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 List<InventoryFile> filelist = new List<InventoryFile>();
 
 cmd = new MySqlCommand("INSERT INTO inventory_item(inv_cat_id, pic_loc_id, name_loc_id, inv_count, est_cost, item_name, item_desc, notes, item_created, item_changed) VALUES (@cat_id, @pic_id, @name_id, @count, @cost, @name, @desc, @notes, NOW(), NOW() ); SELECT LAST_INSERT_ID();", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@cat_id", cat.ID));
 if (loc.InvLocType == InventoryLocation.LocationType.Picture)
  {
   cmd.Parameters.Add(new MySqlParameter("@pic_id", loc.PicLoc.ID));
   cmd.Parameters.Add(new MySqlParameter("@name_id", null));
  }
 else
  {
   cmd.Parameters.Add(new MySqlParameter("@pic_id", null));
   cmd.Parameters.Add(new MySqlParameter("@name_id", loc.NameLoc.ID));
  }
 cmd.Parameters.Add(new MySqlParameter("@count", count));
 cmd.Parameters.Add(new MySqlParameter("@cost", cost));
 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@desc", desc));
 cmd.Parameters.Add(new MySqlParameter("@notes", notes));

 rs = cmd.ExecuteReader();
 rs.Read();
 ID = rs.GetUInt32(0);
 rs.Close();

 Files = new List<InventoryFile>();

 CategoryValues = new List<InventoryCategoryValue>();

 InvLoc = loc;
 InvCat = cat;
 History = new List<PurchaseHistory>();
 InventoryCount = count;
 EstimatedCost = cost;
 InvName = name;
 Desc = desc;
 Notes = notes;
 Created = DateTime.Now; // close enough

}

public void UpdateLocation(in PictureLocation pLoc)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE inventory_item SET pic_loc_id=@pic, name_loc_id=NULL, item_changed=NOW() WHERE inv_item_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.Parameters.Add(new MySqlParameter("@pic", pLoc.ID));
 cmd.ExecuteNonQuery();
 
 InvLoc = new InventoryLocation(pLoc);
 Changed = DateTime.Now; // close enough
}

public void UpdateLocation(in NameLocation nLoc)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE inventory_item SET pic_loc_id=NULL, name_loc_id=@nli, item_changed=NOW() WHERE inv_item_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.Parameters.Add(new MySqlParameter("@nli", nLoc.ID));
 cmd.ExecuteNonQuery();
 
 InvLoc = new InventoryLocation(nLoc);
 Changed = DateTime.Now;  // close enough
}


public void UpdateText(string name, string desc, string notes, float cost)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE inventory_item SET item_name=@name, item_desc=@desc, notes=@notes, est_cost=@cost, item_changed=NOW() WHERE inv_item_id=@id;", DB.Con);

 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.Parameters.Add(new MySqlParameter("@name", name));
 cmd.Parameters.Add(new MySqlParameter("@desc", desc));
 cmd.Parameters.Add(new MySqlParameter("@notes", notes));
 cmd.Parameters.Add(new MySqlParameter("@cost", cost));

 cmd.ExecuteNonQuery();

 InvName = name;
 Desc = desc;
 Notes = notes;
 EstimatedCost = cost;

 Changed = DateTime.Now;  // close enough

}

public void UpdateCount(int count)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE inventory_item SET inv_count=@c, item_changed=NOW() WHERE inv_item_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@c", count));
 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.ExecuteNonQuery();

 InventoryCount = count;

 Changed = DateTime.Now;
}

public void AddInventory(int count)
{
 MySqlCommand cmd;
 int newCount;

 newCount = InventoryCount + count;
 

 cmd = new MySqlCommand("UPDATE inventory_item SET inv_count=@c, item_changed=NOW(), item_added=NOW() WHERE inv_item_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@c", newCount));
 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.ExecuteNonQuery();

 InventoryCount = newCount;
 Changed = DateTime.Now;
 InvAdded = DateTime.Now;
}

public void TakeInventory(int count)
{
 MySqlCommand cmd;
 int newCount;

 newCount = InventoryCount - count;
 if (newCount < 0)
   newCount = 0;
 
 cmd = new MySqlCommand("UPDATE inventory_item SET inv_count=@c, item_changed=NOW(), item_added=NOW() WHERE inv_item_id=@id;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@c", newCount));
 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.ExecuteNonQuery();

 InventoryCount = newCount;
 Changed = DateTime.Now;
 InvRemoved = DateTime.Now;
}

public bool Delete()
{
 MySqlCommand cmd;
 string err;
 string q;

 q = "";
 foreach(InventoryFile file in Files)
  {
   if (file.DeleteFile() == true)
    {
     q += "File Deleted " + file.FullPath + "\n";
    }
   else
    {
     if (q.Length == 0)
      {
       err = "Inventory Item " + ID.ToString() + " will not removed from database\n\n"; 
      }
     else
      {
       err = "Inventory Item " + ID.ToString() + " not removed from database\n\n"; 
       err += "The following files were already removed\n\n";
       err += q;
      }
     MainWnd.Response(err);
     return false;
    }
  }

 q = "DELETE FROM inventory_item_prop_value WHERE inv_item_id=@id; ";
 q += "DELETE FROM purchase_history WHERE inv_item_id=@id; ";
 q += "DELETE FROM inventory_item_file WHERE inv_item_id=@id; ";
 q += "DELETE FROM inventory_item WHERE inv_item_id=@id;";

 cmd = new MySqlCommand(q, DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", ID));
 cmd.ExecuteNonQuery();
 
 return true;
}

public void AddValue(InventoryCategoryProperty prop, float val) // does SQL insert
{
 CategoryValues.Add(new InventoryCategoryValue(ID, InvCat, prop, val)); 
}

public static InventoryItem GetSingleItem(uint id)
{
 MySqlCommand cmd;
 MySqlDataReader rs;
 InventoryItem invItem = null;
 InventoryCategory cat = null;
 InventoryLocation loc = null;
 uint cat_id = 0;
 uint loc_id = 0;
 int count = 0;
 float cost = 0;
 string name = "";
 string desc = "";
 string notes = "";
 DateTime created, changed, added, removed;
 InventoryLocation.LocationType locType = InventoryLocation.LocationType.Picture;
 List<InventoryCategoryValue> values = new List<InventoryCategoryValue>();
 List<InventoryFile> filelist;
 bool found = false;

 created = DateTime.MinValue;
 changed = DateTime.MinValue;
 added = DateTime.MinValue;
 removed = DateTime.MinValue;

 cmd = new MySqlCommand("SELECT inv_cat_id, pic_loc_id, name_loc_id, inv_count, est_cost, item_name, item_desc, notes, item_created, item_changed, item_added, item_removed FROM inventory_item WHERE inv_item_id=@id; ", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@id", id));
 rs = cmd.ExecuteReader();
 if (rs.Read() == true)
  {
   cat_id = rs.GetUInt32(0);
   if (rs.IsDBNull(1) == true && rs.IsDBNull(2) == true)
    {
     loc_id = 0;
     locType = InventoryLocation.LocationType.None;
    }
   else
    {
     if (rs.IsDBNull(2) == true) 
      {
       loc_id = rs.GetUInt32(1);
       locType = InventoryLocation.LocationType.Picture;
       }
     else
      {
       loc_id = rs.GetUInt32(2);
       locType = InventoryLocation.LocationType.Name;
      }
    }
   count = rs.GetInt32(3);
   cost = rs.GetFloat(4);
   name = rs.GetString(5);
   desc = rs.GetString(6);
   notes = rs.GetString(7);
   created = rs.GetDateTime(8);
   changed = rs.GetDateTime(9);
   if (rs.IsDBNull(10) == false) added = rs.GetDateTime(10);
   if (rs.IsDBNull(11) == false) removed = rs.GetDateTime(11);
   found = true;
  }
 else
  {
   cat_id = 0;
   found = false;
  }
 rs.Close();

 if (found == false)
  {
   return null;
  }

 loc = InventoryLocation.GetLocation(locType, loc_id);
 
 cat = InventoryCategory.GetCategory(cat_id);

 invItem = new InventoryItem(id, loc, cat, values, count, cost, name, desc, notes, created, changed, added, removed);

 
 filelist = InventoryFile.GetFiles(invItem);
 foreach(InventoryFile file in filelist) // sort them into their houses
  {
   invItem.Files.Add(file);
  }

 invItem.History = PurchaseHistory.Read(invItem); 

 invItem.CategoryValues = InventoryCategoryValue.GetValues(invItem);

 return invItem;
}

public static string GetBlankInvName(string cat, string primaryProp, string propVal)
{
 string finalProp;
 string finalVal;

 if (primaryProp.Length == 0)
   finalProp = "N/A";
 else
   finalProp = primaryProp;

 if (propVal.Length == 0)
   finalVal = "N/A";
 else  
   finalVal = propVal;

 return "<" + finalVal + " " + finalProp + " " + cat + ">";

}

public override string ToString()
{
 bool found = false;
 string v = "";

 if (InvName.Length == 0)
  {
   foreach(InventoryCategoryValue val in CategoryValues)
    {
     if (val.CatProp.PrimaryProperty == true)
      {
       v = val.Value.ToString("0.0000");
       found = true;
       break;
      }
    }
   if (found == true)
    {
     return GetBlankInvName(InvCat.Name, InvCat.PrimaryProperty.PropertyName, v);
    }
   else
     return "<none>";
  }
 else
  {
   return InvName;
  }
}

public static void MoveInventory(in PictureLocation plFrom, in PictureLocation plTo)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE inventory_item SET pic_loc_id=@p2, name_loc_id=NULL, item_changed=NOW() WHERE pic_loc_id=@p1;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@p1", plFrom.ID));
 cmd.Parameters.Add(new MySqlParameter("@p2", plTo.ID));
 cmd.ExecuteNonQuery();

}

public static void MoveInventory(in PictureLocation plFrom, in NameLocation nlTo)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE inventory_item SET pic_loc_id=NULL, name_loc_id=@n2, item_changed=NOW() WHERE pic_loc_id=@p1;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@p1", plFrom.ID));
 cmd.Parameters.Add(new MySqlParameter("@n2", nlTo.ID));
 cmd.ExecuteNonQuery();

}

public static void MoveInventory(in NameLocation nlFrom, in PictureLocation plTo)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE inventory_item SET pic_loc_id=@p2, name_loc_id=NULL, item_changed=NOW() WHERE name_loc_id=@n1;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@n1", nlFrom.ID));
 cmd.Parameters.Add(new MySqlParameter("@p2", plTo.ID));
 cmd.ExecuteNonQuery();

}

public static void MoveInventory(in NameLocation nlFrom, in NameLocation nlTo)
{
 MySqlCommand cmd;

 cmd = new MySqlCommand("UPDATE inventory_item SET pic_loc_id=NULL, name_loc_id=@n2, item_changed=NOW() WHERE name_loc_id=@n1;", DB.Con);
 cmd.Parameters.Add(new MySqlParameter("@n1", nlFrom.ID));
 cmd.Parameters.Add(new MySqlParameter("@n2", nlTo.ID));
 cmd.ExecuteNonQuery();

}

};


}
