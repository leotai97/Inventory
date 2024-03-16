namespace Inventory
{
  partial class InvItemDlg
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
    if (disposing && (components != null))
    {
    components.Dispose();
    }
    base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.txtCat = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.txtDesc = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtLoc = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.btnViewLoc = new System.Windows.Forms.Button();
      this.txtNotes = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.listFiles = new System.Windows.Forms.ListView();
      this.c1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.c2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.c3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.c4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label6 = new System.Windows.Forms.Label();
      this.txtCreated = new System.Windows.Forms.TextBox();
      this.txtChanged = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.txtInvAdded = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtInvRemoved = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.txtCost = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.txtCount = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.listHistory = new System.Windows.Forms.ListView();
      this.h1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.h2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.h3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.h4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.h5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btnOK = new System.Windows.Forms.Button();
      this.listVals = new System.Windows.Forms.ListView();
      this.v1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.v2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btnLocPicSet = new System.Windows.Forms.Button();
      this.Icons = new System.Windows.Forms.ImageList(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnFileRemove = new System.Windows.Forms.Button();
      this.btnFileAdd = new System.Windows.Forms.Button();
      this.btnFileEdit = new System.Windows.Forms.Button();
      this.btnHistEdit = new System.Windows.Forms.Button();
      this.btnHistRemove = new System.Windows.Forms.Button();
      this.btnHistAdd = new System.Windows.Forms.Button();
      this.btnProp = new System.Windows.Forms.Button();
      this.btnFileOpen = new System.Windows.Forms.Button();
      this.btnTakeInv = new System.Windows.Forms.Button();
      this.btnLocNameSet = new System.Windows.Forms.Button();
      this.btnSaveStock = new System.Windows.Forms.Button();
      this.btnAddInv = new System.Windows.Forms.Button();
      this.lblProp = new System.Windows.Forms.Label();
      this.txtProp = new System.Windows.Forms.TextBox();
      this.btnTextSave = new System.Windows.Forms.Button();
      this.txtID = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.txtTake = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.v3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Category";
      // 
      // txtCat
      // 
      this.txtCat.Location = new System.Drawing.Point(12, 25);
      this.txtCat.Name = "txtCat";
      this.txtCat.ReadOnly = true;
      this.txtCat.Size = new System.Drawing.Size(281, 20);
      this.txtCat.TabIndex = 1;
      this.toolTip1.SetToolTip(this.txtCat, "Category cannot be changed since the property values are unique to a category");
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 57);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(58, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Item Name";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(15, 73);
      this.txtName.MaxLength = 512;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(411, 20);
      this.txtName.TabIndex = 12;
      // 
      // txtDesc
      // 
      this.txtDesc.Location = new System.Drawing.Point(15, 121);
      this.txtDesc.MaxLength = 1024;
      this.txtDesc.Multiline = true;
      this.txtDesc.Name = "txtDesc";
      this.txtDesc.Size = new System.Drawing.Size(887, 59);
      this.txtDesc.TabIndex = 17;
      this.txtDesc.Text = "A\r\nB\r\nC\r\nD\r\nE\r\nF\r\nG";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 105);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(60, 13);
      this.label3.TabIndex = 16;
      this.label3.Text = "Description";
      // 
      // txtLoc
      // 
      this.txtLoc.Location = new System.Drawing.Point(299, 25);
      this.txtLoc.Name = "txtLoc";
      this.txtLoc.ReadOnly = true;
      this.txtLoc.Size = new System.Drawing.Size(230, 20);
      this.txtLoc.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(296, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(48, 13);
      this.label4.TabIndex = 2;
      this.label4.Text = "Location";
      // 
      // btnViewLoc
      // 
      this.btnViewLoc.Location = new System.Drawing.Point(535, 23);
      this.btnViewLoc.Name = "btnViewLoc";
      this.btnViewLoc.Size = new System.Drawing.Size(23, 23);
      this.btnViewLoc.TabIndex = 4;
      this.toolTip1.SetToolTip(this.btnViewLoc, "View the inventory item\'s location");
      this.btnViewLoc.UseVisualStyleBackColor = true;
      this.btnViewLoc.Click += new System.EventHandler(this.btnViewLoc_Click);
      // 
      // txtNotes
      // 
      this.txtNotes.Location = new System.Drawing.Point(15, 208);
      this.txtNotes.MaxLength = 32000;
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.Size = new System.Drawing.Size(887, 136);
      this.txtNotes.TabIndex = 19;
      this.txtNotes.Text = "A\r\nB\r\nC\r\nD\r\nE\r\nF\r\nG\r\nH\r\nI\r\nJ\r\nK";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 192);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(35, 13);
      this.label5.TabIndex = 18;
      this.label5.Text = "Notes";
      // 
      // listFiles
      // 
      this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c1,
            this.c2,
            this.c3,
            this.c4});
      this.listFiles.FullRowSelect = true;
      this.listFiles.GridLines = true;
      this.listFiles.HideSelection = false;
      this.listFiles.Location = new System.Drawing.Point(12, 409);
      this.listFiles.MultiSelect = false;
      this.listFiles.Name = "listFiles";
      this.listFiles.Size = new System.Drawing.Size(823, 132);
      this.listFiles.TabIndex = 37;
      this.listFiles.UseCompatibleStateImageBehavior = false;
      this.listFiles.View = System.Windows.Forms.View.Details;
      this.listFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listFiles_ColumnClick);
      this.listFiles.DoubleClick += new System.EventHandler(this.listFiles_DoubleClick);
      // 
      // c1
      // 
      this.c1.Text = "File Name";
      // 
      // c2
      // 
      this.c2.Text = "Path";
      // 
      // c3
      // 
      this.c3.Text = "File Type";
      // 
      // c4
      // 
      this.c4.Text = "Description";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 357);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(44, 13);
      this.label6.TabIndex = 20;
      this.label6.Text = "Created";
      // 
      // txtCreated
      // 
      this.txtCreated.Location = new System.Drawing.Point(15, 373);
      this.txtCreated.Name = "txtCreated";
      this.txtCreated.ReadOnly = true;
      this.txtCreated.Size = new System.Drawing.Size(89, 20);
      this.txtCreated.TabIndex = 21;
      this.txtCreated.Text = "MMM dd YYYY";
      // 
      // txtChanged
      // 
      this.txtChanged.Location = new System.Drawing.Point(110, 373);
      this.txtChanged.Name = "txtChanged";
      this.txtChanged.ReadOnly = true;
      this.txtChanged.Size = new System.Drawing.Size(89, 20);
      this.txtChanged.TabIndex = 23;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(107, 357);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(50, 13);
      this.label7.TabIndex = 22;
      this.label7.Text = "Changed";
      // 
      // txtInvAdded
      // 
      this.txtInvAdded.Location = new System.Drawing.Point(205, 373);
      this.txtInvAdded.Name = "txtInvAdded";
      this.txtInvAdded.ReadOnly = true;
      this.txtInvAdded.Size = new System.Drawing.Size(89, 20);
      this.txtInvAdded.TabIndex = 25;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(202, 357);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(64, 13);
      this.label8.TabIndex = 24;
      this.label8.Text = "Date Added";
      // 
      // txtInvRemoved
      // 
      this.txtInvRemoved.Location = new System.Drawing.Point(300, 373);
      this.txtInvRemoved.Name = "txtInvRemoved";
      this.txtInvRemoved.ReadOnly = true;
      this.txtInvRemoved.Size = new System.Drawing.Size(89, 20);
      this.txtInvRemoved.TabIndex = 27;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(299, 357);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(79, 13);
      this.label9.TabIndex = 26;
      this.label9.Text = "Date Removed";
      // 
      // txtCost
      // 
      this.txtCost.Location = new System.Drawing.Point(436, 73);
      this.txtCost.Name = "txtCost";
      this.txtCost.Size = new System.Drawing.Size(84, 20);
      this.txtCost.TabIndex = 14;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(433, 57);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(77, 13);
      this.label10.TabIndex = 13;
      this.label10.Text = "Estimated Cost";
      // 
      // txtCount
      // 
      this.txtCount.Location = new System.Drawing.Point(494, 373);
      this.txtCount.Name = "txtCount";
      this.txtCount.Size = new System.Drawing.Size(57, 20);
      this.txtCount.TabIndex = 31;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(491, 357);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(66, 13);
      this.label11.TabIndex = 30;
      this.label11.Text = "Stock Count";
      // 
      // listHistory
      // 
      this.listHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.h1,
            this.h2,
            this.h3,
            this.h4,
            this.h5});
      this.listHistory.FullRowSelect = true;
      this.listHistory.GridLines = true;
      this.listHistory.HideSelection = false;
      this.listHistory.Location = new System.Drawing.Point(12, 557);
      this.listHistory.MultiSelect = false;
      this.listHistory.Name = "listHistory";
      this.listHistory.Size = new System.Drawing.Size(823, 133);
      this.listHistory.TabIndex = 42;
      this.listHistory.UseCompatibleStateImageBehavior = false;
      this.listHistory.View = System.Windows.Forms.View.Details;
      this.listHistory.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listHistory_ColumnClick);
      this.listHistory.DoubleClick += new System.EventHandler(this.listHistory_DoubleClick);
      // 
      // h1
      // 
      this.h1.Text = "Source";
      // 
      // h2
      // 
      this.h2.Text = "URL";
      // 
      // h3
      // 
      this.h3.Text = "Date";
      // 
      // h4
      // 
      this.h4.Text = "Price Each";
      this.h4.Width = 69;
      // 
      // h5
      // 
      this.h5.Text = "Quantity";
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(844, 661);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(58, 23);
      this.btnOK.TabIndex = 46;
      this.btnOK.Text = "Close";
      this.toolTip1.SetToolTip(this.btnOK, "Changes made on this form update the DB immediately, there is no Cancel button.");
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // listVals
      // 
      this.listVals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.v1,
            this.v2,
            this.v3});
      this.listVals.FullRowSelect = true;
      this.listVals.GridLines = true;
      this.listVals.HideSelection = false;
      this.listVals.Location = new System.Drawing.Point(621, 12);
      this.listVals.MultiSelect = false;
      this.listVals.Name = "listVals";
      this.listVals.Size = new System.Drawing.Size(189, 97);
      this.listVals.TabIndex = 7;
      this.listVals.UseCompatibleStateImageBehavior = false;
      this.listVals.View = System.Windows.Forms.View.Details;
      this.listVals.SelectedIndexChanged += new System.EventHandler(this.listVals_SelectedIndexChanged);
      // 
      // v1
      // 
      this.v1.Text = "Property";
      // 
      // v2
      // 
      this.v2.Text = "Value";
      // 
      // btnLocPicSet
      // 
      this.btnLocPicSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnLocPicSet.Location = new System.Drawing.Point(563, 23);
      this.btnLocPicSet.Name = "btnLocPicSet";
      this.btnLocPicSet.Size = new System.Drawing.Size(23, 23);
      this.btnLocPicSet.TabIndex = 5;
      this.btnLocPicSet.Tag = "";
      this.btnLocPicSet.Text = "P";
      this.toolTip1.SetToolTip(this.btnLocPicSet, "Set the inventory item\'s location to a pictured location");
      this.btnLocPicSet.UseVisualStyleBackColor = true;
      this.btnLocPicSet.Click += new System.EventHandler(this.btnLocPicSet_Click);
      // 
      // Icons
      // 
      this.Icons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.Icons.ImageSize = new System.Drawing.Size(16, 16);
      this.Icons.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // btnFileRemove
      // 
      this.btnFileRemove.Location = new System.Drawing.Point(844, 496);
      this.btnFileRemove.Name = "btnFileRemove";
      this.btnFileRemove.Size = new System.Drawing.Size(59, 23);
      this.btnFileRemove.TabIndex = 41;
      this.btnFileRemove.Text = "Remove";
      this.toolTip1.SetToolTip(this.btnFileRemove, "Remove selected file");
      this.btnFileRemove.UseVisualStyleBackColor = true;
      this.btnFileRemove.Click += new System.EventHandler(this.btnFileRemove_Click);
      // 
      // btnFileAdd
      // 
      this.btnFileAdd.Location = new System.Drawing.Point(844, 409);
      this.btnFileAdd.Name = "btnFileAdd";
      this.btnFileAdd.Size = new System.Drawing.Size(58, 23);
      this.btnFileAdd.TabIndex = 38;
      this.btnFileAdd.Text = "Add";
      this.toolTip1.SetToolTip(this.btnFileAdd, "Add a new file");
      this.btnFileAdd.UseVisualStyleBackColor = true;
      this.btnFileAdd.Click += new System.EventHandler(this.btnFileAdd_Click);
      // 
      // btnFileEdit
      // 
      this.btnFileEdit.Location = new System.Drawing.Point(844, 438);
      this.btnFileEdit.Name = "btnFileEdit";
      this.btnFileEdit.Size = new System.Drawing.Size(58, 23);
      this.btnFileEdit.TabIndex = 39;
      this.btnFileEdit.Text = "Edit";
      this.toolTip1.SetToolTip(this.btnFileEdit, "Edit selected file");
      this.btnFileEdit.UseVisualStyleBackColor = true;
      this.btnFileEdit.Click += new System.EventHandler(this.btnFileEdit_Click);
      // 
      // btnHistEdit
      // 
      this.btnHistEdit.Location = new System.Drawing.Point(844, 586);
      this.btnHistEdit.Name = "btnHistEdit";
      this.btnHistEdit.Size = new System.Drawing.Size(58, 23);
      this.btnHistEdit.TabIndex = 44;
      this.btnHistEdit.Text = "Edit";
      this.toolTip1.SetToolTip(this.btnHistEdit, "Edit purchase history");
      this.btnHistEdit.UseVisualStyleBackColor = true;
      this.btnHistEdit.Click += new System.EventHandler(this.btnHistEdit_Click);
      // 
      // btnHistRemove
      // 
      this.btnHistRemove.Location = new System.Drawing.Point(843, 615);
      this.btnHistRemove.Name = "btnHistRemove";
      this.btnHistRemove.Size = new System.Drawing.Size(59, 23);
      this.btnHistRemove.TabIndex = 45;
      this.btnHistRemove.Text = "Remove";
      this.toolTip1.SetToolTip(this.btnHistRemove, "Remove purchase history");
      this.btnHistRemove.UseVisualStyleBackColor = true;
      this.btnHistRemove.Click += new System.EventHandler(this.btnHistRemove_Click);
      // 
      // btnHistAdd
      // 
      this.btnHistAdd.Location = new System.Drawing.Point(844, 557);
      this.btnHistAdd.Name = "btnHistAdd";
      this.btnHistAdd.Size = new System.Drawing.Size(58, 23);
      this.btnHistAdd.TabIndex = 43;
      this.btnHistAdd.Text = "Add";
      this.toolTip1.SetToolTip(this.btnHistAdd, "Add to inventory");
      this.btnHistAdd.UseVisualStyleBackColor = true;
      this.btnHistAdd.Click += new System.EventHandler(this.btnHistAdd_Click);
      // 
      // btnProp
      // 
      this.btnProp.Location = new System.Drawing.Point(835, 57);
      this.btnProp.Name = "btnProp";
      this.btnProp.Size = new System.Drawing.Size(67, 23);
      this.btnProp.TabIndex = 10;
      this.btnProp.Text = "Save Value";
      this.toolTip1.SetToolTip(this.btnProp, "Save change to value, you can also press Enter");
      this.btnProp.UseVisualStyleBackColor = true;
      this.btnProp.Click += new System.EventHandler(this.btnProp_Click);
      // 
      // btnFileOpen
      // 
      this.btnFileOpen.Location = new System.Drawing.Point(844, 467);
      this.btnFileOpen.Name = "btnFileOpen";
      this.btnFileOpen.Size = new System.Drawing.Size(59, 23);
      this.btnFileOpen.TabIndex = 40;
      this.btnFileOpen.Text = "Open";
      this.toolTip1.SetToolTip(this.btnFileOpen, "Open selected file or URL");
      this.btnFileOpen.UseVisualStyleBackColor = true;
      this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
      // 
      // btnTakeInv
      // 
      this.btnTakeInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnTakeInv.Location = new System.Drawing.Point(713, 370);
      this.btnTakeInv.Name = "btnTakeInv";
      this.btnTakeInv.Size = new System.Drawing.Size(26, 23);
      this.btnTakeInv.TabIndex = 36;
      this.btnTakeInv.Text = "R";
      this.toolTip1.SetToolTip(this.btnTakeInv, "Remove From Stock Count");
      this.btnTakeInv.UseVisualStyleBackColor = true;
      this.btnTakeInv.Click += new System.EventHandler(this.btnTakeInv_Click);
      // 
      // btnLocNameSet
      // 
      this.btnLocNameSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnLocNameSet.Location = new System.Drawing.Point(592, 23);
      this.btnLocNameSet.Name = "btnLocNameSet";
      this.btnLocNameSet.Size = new System.Drawing.Size(23, 23);
      this.btnLocNameSet.TabIndex = 6;
      this.btnLocNameSet.Text = "N";
      this.toolTip1.SetToolTip(this.btnLocNameSet, "Set the inventory item\'s location to a named location");
      this.btnLocNameSet.UseVisualStyleBackColor = true;
      this.btnLocNameSet.Click += new System.EventHandler(this.btnLocNameSet_Click);
      // 
      // btnSaveStock
      // 
      this.btnSaveStock.Location = new System.Drawing.Point(557, 371);
      this.btnSaveStock.Name = "btnSaveStock";
      this.btnSaveStock.Size = new System.Drawing.Size(42, 23);
      this.btnSaveStock.TabIndex = 32;
      this.btnSaveStock.Text = "Save";
      this.toolTip1.SetToolTip(this.btnSaveStock, "Manually adjust the stock count");
      this.btnSaveStock.UseVisualStyleBackColor = true;
      this.btnSaveStock.Click += new System.EventHandler(this.btnSaveStock_Click);
      // 
      // btnAddInv
      // 
      this.btnAddInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnAddInv.Location = new System.Drawing.Point(682, 370);
      this.btnAddInv.Name = "btnAddInv";
      this.btnAddInv.Size = new System.Drawing.Size(25, 23);
      this.btnAddInv.TabIndex = 35;
      this.btnAddInv.Text = "A";
      this.toolTip1.SetToolTip(this.btnAddInv, "Manually Add To Stock Count");
      this.btnAddInv.UseVisualStyleBackColor = true;
      this.btnAddInv.Click += new System.EventHandler(this.btnAddInv_Click);
      // 
      // lblProp
      // 
      this.lblProp.AutoSize = true;
      this.lblProp.Location = new System.Drawing.Point(816, 12);
      this.lblProp.Name = "lblProp";
      this.lblProp.Size = new System.Drawing.Size(76, 13);
      this.lblProp.TabIndex = 8;
      this.lblProp.Text = "Property Value";
      // 
      // txtProp
      // 
      this.txtProp.AcceptsReturn = true;
      this.txtProp.Location = new System.Drawing.Point(816, 28);
      this.txtProp.Name = "txtProp";
      this.txtProp.Size = new System.Drawing.Size(86, 20);
      this.txtProp.TabIndex = 9;
      this.txtProp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProp_KeyDown);
      // 
      // btnTextSave
      // 
      this.btnTextSave.Location = new System.Drawing.Point(531, 71);
      this.btnTextSave.Name = "btnTextSave";
      this.btnTextSave.Size = new System.Drawing.Size(77, 23);
      this.btnTextSave.TabIndex = 15;
      this.btnTextSave.Text = "Save Text";
      this.btnTextSave.UseVisualStyleBackColor = true;
      this.btnTextSave.Click += new System.EventHandler(this.btnTextSave_Click);
      // 
      // txtID
      // 
      this.txtID.Location = new System.Drawing.Point(402, 373);
      this.txtID.Name = "txtID";
      this.txtID.ReadOnly = true;
      this.txtID.Size = new System.Drawing.Size(76, 20);
      this.txtID.TabIndex = 29;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(399, 357);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(18, 13);
      this.label12.TabIndex = 28;
      this.label12.Text = "ID";
      // 
      // txtTake
      // 
      this.txtTake.Location = new System.Drawing.Point(616, 373);
      this.txtTake.Name = "txtTake";
      this.txtTake.Size = new System.Drawing.Size(60, 20);
      this.txtTake.TabIndex = 34;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(613, 356);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(71, 13);
      this.label13.TabIndex = 33;
      this.label13.Text = "Add/Remove";
      // 
      // v3
      // 
      this.v3.Text = "Primary";
      // 
      // InvItemDlg
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(914, 698);
      this.Controls.Add(this.btnAddInv);
      this.Controls.Add(this.btnSaveStock);
      this.Controls.Add(this.txtTake);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.btnLocNameSet);
      this.Controls.Add(this.btnTakeInv);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.btnFileOpen);
      this.Controls.Add(this.btnTextSave);
      this.Controls.Add(this.btnHistEdit);
      this.Controls.Add(this.btnHistRemove);
      this.Controls.Add(this.btnHistAdd);
      this.Controls.Add(this.btnFileEdit);
      this.Controls.Add(this.btnFileRemove);
      this.Controls.Add(this.btnFileAdd);
      this.Controls.Add(this.btnProp);
      this.Controls.Add(this.txtProp);
      this.Controls.Add(this.lblProp);
      this.Controls.Add(this.btnLocPicSet);
      this.Controls.Add(this.listVals);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.listHistory);
      this.Controls.Add(this.txtCount);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.txtCost);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.txtInvRemoved);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.txtInvAdded);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.txtChanged);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.txtCreated);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.listFiles);
      this.Controls.Add(this.txtNotes);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.btnViewLoc);
      this.Controls.Add(this.txtLoc);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtDesc);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtCat);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "InvItemDlg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Inventory Item";
      this.toolTip1.SetToolTip(this, "`");
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtCat;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.TextBox txtDesc;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtLoc;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnViewLoc;
    private System.Windows.Forms.TextBox txtNotes;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ListView listFiles;
    private System.Windows.Forms.ColumnHeader c1;
    private System.Windows.Forms.ColumnHeader c2;
    private System.Windows.Forms.ColumnHeader c3;
    private System.Windows.Forms.ColumnHeader c4;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtCreated;
    private System.Windows.Forms.TextBox txtChanged;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtInvAdded;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtInvRemoved;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txtCost;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtCount;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.ListView listHistory;
    private System.Windows.Forms.ColumnHeader h1;
    private System.Windows.Forms.ColumnHeader h2;
    private System.Windows.Forms.ColumnHeader h3;
    private System.Windows.Forms.ColumnHeader h4;
    private System.Windows.Forms.ColumnHeader h5;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.ListView listVals;
    private System.Windows.Forms.ColumnHeader v1;
    private System.Windows.Forms.ColumnHeader v2;
    private System.Windows.Forms.Button btnLocPicSet;
    private System.Windows.Forms.ImageList Icons;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label lblProp;
    private System.Windows.Forms.TextBox txtProp;
    private System.Windows.Forms.Button btnProp;
    private System.Windows.Forms.Button btnFileRemove;
    private System.Windows.Forms.Button btnFileAdd;
    private System.Windows.Forms.Button btnFileEdit;
    private System.Windows.Forms.Button btnHistEdit;
    private System.Windows.Forms.Button btnHistRemove;
    private System.Windows.Forms.Button btnHistAdd;
    private System.Windows.Forms.Button btnTextSave;
    private System.Windows.Forms.Button btnFileOpen;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Button btnTakeInv;
    private System.Windows.Forms.Button btnLocNameSet;
    private System.Windows.Forms.TextBox txtTake;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Button btnSaveStock;
    private System.Windows.Forms.Button btnAddInv;
    private System.Windows.Forms.ColumnHeader v3;
  }
}