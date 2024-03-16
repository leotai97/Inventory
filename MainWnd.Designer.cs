namespace Inventory
{
  partial class MainWnd
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileAddInvPic = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileAddInvName = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuFileAddPicLoc = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileAddNameLoc = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuFileAddCategory = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuFileOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuViewPicLoc = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuViewNameLoc = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuViewCategory = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuViewAdvancedSearch = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.sbMessage = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.pnlSearch = new System.Windows.Forms.Panel();
      this.txtPrimary2 = new System.Windows.Forms.TextBox();
      this.cboCompare = new System.Windows.Forms.ComboBox();
      this.txtPrimary = new System.Windows.Forms.TextBox();
      this.lblPrimary = new System.Windows.Forms.Label();
      this.btnSearch = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cboCategory = new System.Windows.Forms.ComboBox();
      this.listInv = new System.Windows.Forms.ListView();
      this.listInvPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.popUpOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.popUpView = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
      this.popUpRemove = new System.Windows.Forms.ToolStripMenuItem();
      this.timerQueryPop = new System.Windows.Forms.Timer(this.components);
      this.menuStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.pnlSearch.SuspendLayout();
      this.listInvPopup.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.mnuHelp});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1011, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.mnuFileOptions,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileAddInvPic,
            this.mnuFileAddInvName,
            this.toolStripMenuItem4,
            this.mnuFileAddPicLoc,
            this.mnuFileAddNameLoc,
            this.toolStripMenuItem2,
            this.mnuFileAddCategory,
            this.toolStripMenuItem5});
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
      this.toolStripMenuItem3.Text = "Add";
      // 
      // mnuFileAddInvPic
      // 
      this.mnuFileAddInvPic.Name = "mnuFileAddInvPic";
      this.mnuFileAddInvPic.Size = new System.Drawing.Size(228, 22);
      this.mnuFileAddInvPic.Text = "Inventory To Picture Location";
      this.mnuFileAddInvPic.Click += new System.EventHandler(this.mnuFileAddInvPic_Click);
      // 
      // mnuFileAddInvName
      // 
      this.mnuFileAddInvName.Name = "mnuFileAddInvName";
      this.mnuFileAddInvName.Size = new System.Drawing.Size(228, 22);
      this.mnuFileAddInvName.Text = "Inventory To Name Location";
      this.mnuFileAddInvName.Click += new System.EventHandler(this.mnuFileAddInvName_Click);
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(225, 6);
      // 
      // mnuFileAddPicLoc
      // 
      this.mnuFileAddPicLoc.Name = "mnuFileAddPicLoc";
      this.mnuFileAddPicLoc.Size = new System.Drawing.Size(228, 22);
      this.mnuFileAddPicLoc.Text = "New Picture Location";
      this.mnuFileAddPicLoc.Click += new System.EventHandler(this.mnuFileAddPicLoc_Click);
      // 
      // mnuFileAddNameLoc
      // 
      this.mnuFileAddNameLoc.Name = "mnuFileAddNameLoc";
      this.mnuFileAddNameLoc.Size = new System.Drawing.Size(228, 22);
      this.mnuFileAddNameLoc.Text = "New Name Location";
      this.mnuFileAddNameLoc.Click += new System.EventHandler(this.mnuFileAddNameLoc_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(225, 6);
      // 
      // mnuFileAddCategory
      // 
      this.mnuFileAddCategory.Name = "mnuFileAddCategory";
      this.mnuFileAddCategory.Size = new System.Drawing.Size(228, 22);
      this.mnuFileAddCategory.Text = "New Category";
      this.mnuFileAddCategory.Click += new System.EventHandler(this.mnuFileAddCategory_Click);
      // 
      // toolStripMenuItem5
      // 
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new System.Drawing.Size(225, 6);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
      // 
      // mnuFileOptions
      // 
      this.mnuFileOptions.Name = "mnuFileOptions";
      this.mnuFileOptions.Size = new System.Drawing.Size(180, 22);
      this.mnuFileOptions.Text = "Options";
      this.mnuFileOptions.Click += new System.EventHandler(this.mnuFileOptions_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewPicLoc,
            this.mnuViewNameLoc,
            this.mnuViewCategory,
            this.toolStripMenuItem8,
            this.mnuViewAdvancedSearch});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "&View";
      // 
      // mnuViewPicLoc
      // 
      this.mnuViewPicLoc.Name = "mnuViewPicLoc";
      this.mnuViewPicLoc.Size = new System.Drawing.Size(165, 22);
      this.mnuViewPicLoc.Text = "Picture Locations";
      this.mnuViewPicLoc.Click += new System.EventHandler(this.mnuViewPicLoc_Click);
      // 
      // mnuViewNameLoc
      // 
      this.mnuViewNameLoc.Name = "mnuViewNameLoc";
      this.mnuViewNameLoc.Size = new System.Drawing.Size(165, 22);
      this.mnuViewNameLoc.Text = "Name Locations";
      this.mnuViewNameLoc.Click += new System.EventHandler(this.mnuViewNameLoc_Click);
      // 
      // mnuViewCategory
      // 
      this.mnuViewCategory.Name = "mnuViewCategory";
      this.mnuViewCategory.Size = new System.Drawing.Size(165, 22);
      this.mnuViewCategory.Text = "Categories";
      this.mnuViewCategory.Click += new System.EventHandler(this.mnuViewCategory_Click);
      // 
      // toolStripMenuItem8
      // 
      this.toolStripMenuItem8.Name = "toolStripMenuItem8";
      this.toolStripMenuItem8.Size = new System.Drawing.Size(162, 6);
      // 
      // mnuViewAdvancedSearch
      // 
      this.mnuViewAdvancedSearch.Name = "mnuViewAdvancedSearch";
      this.mnuViewAdvancedSearch.Size = new System.Drawing.Size(165, 22);
      this.mnuViewAdvancedSearch.Text = "Advanced Search";
      this.mnuViewAdvancedSearch.Click += new System.EventHandler(this.mnuViewAdvancedSearch_Click);
      // 
      // mnuHelp
      // 
      this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
      this.mnuHelp.Name = "mnuHelp";
      this.mnuHelp.Size = new System.Drawing.Size(44, 20);
      this.mnuHelp.Text = "&Help";
      // 
      // mnuHelpAbout
      // 
      this.mnuHelpAbout.Name = "mnuHelpAbout";
      this.mnuHelpAbout.Size = new System.Drawing.Size(156, 22);
      this.mnuHelpAbout.Text = "About Program";
      this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbMessage});
      this.statusStrip1.Location = new System.Drawing.Point(0, 603);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(1011, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // sbMessage
      // 
      this.sbMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.sbMessage.Name = "sbMessage";
      this.sbMessage.Size = new System.Drawing.Size(996, 17);
      this.sbMessage.Spring = true;
      this.sbMessage.Text = "toolStripStatusLabel1";
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
      this.toolStrip1.Location = new System.Drawing.Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(1011, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // pnlSearch
      // 
      this.pnlSearch.Controls.Add(this.txtPrimary2);
      this.pnlSearch.Controls.Add(this.cboCompare);
      this.pnlSearch.Controls.Add(this.txtPrimary);
      this.pnlSearch.Controls.Add(this.lblPrimary);
      this.pnlSearch.Controls.Add(this.btnSearch);
      this.pnlSearch.Controls.Add(this.label2);
      this.pnlSearch.Controls.Add(this.txtName);
      this.pnlSearch.Controls.Add(this.label1);
      this.pnlSearch.Controls.Add(this.cboCategory);
      this.pnlSearch.Location = new System.Drawing.Point(12, 63);
      this.pnlSearch.Name = "pnlSearch";
      this.pnlSearch.Size = new System.Drawing.Size(979, 72);
      this.pnlSearch.TabIndex = 3;
      // 
      // txtPrimary2
      // 
      this.txtPrimary2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPrimary2.Location = new System.Drawing.Point(754, 28);
      this.txtPrimary2.Name = "txtPrimary2";
      this.txtPrimary2.Size = new System.Drawing.Size(87, 20);
      this.txtPrimary2.TabIndex = 7;
      // 
      // cboCompare
      // 
      this.cboCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cboCompare.FormattingEnabled = true;
      this.cboCompare.Items.AddRange(new object[] {
            "N/A",
            "<",
            "<=",
            "=",
            ">=",
            ">",
            "RNG"});
      this.cboCompare.Location = new System.Drawing.Point(602, 28);
      this.cboCompare.Name = "cboCompare";
      this.cboCompare.Size = new System.Drawing.Size(53, 21);
      this.cboCompare.TabIndex = 5;
      this.cboCompare.SelectedIndexChanged += new System.EventHandler(this.cboCompare_SelectedIndexChanged);
      // 
      // txtPrimary
      // 
      this.txtPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPrimary.Location = new System.Drawing.Point(661, 28);
      this.txtPrimary.Name = "txtPrimary";
      this.txtPrimary.Size = new System.Drawing.Size(87, 20);
      this.txtPrimary.TabIndex = 6;
      // 
      // lblPrimary
      // 
      this.lblPrimary.AutoSize = true;
      this.lblPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPrimary.Location = new System.Drawing.Point(599, 7);
      this.lblPrimary.Name = "lblPrimary";
      this.lblPrimary.Size = new System.Drawing.Size(53, 13);
      this.lblPrimary.TabIndex = 4;
      this.lblPrimary.Text = "Run Time";
      // 
      // btnSearch
      // 
      this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSearch.Location = new System.Drawing.Point(847, 26);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(81, 24);
      this.btnSearch.TabIndex = 8;
      this.btnSearch.Text = "Search";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(290, 7);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Name";
      // 
      // txtName
      // 
      this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtName.Location = new System.Drawing.Point(293, 28);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(303, 20);
      this.txtName.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Category";
      // 
      // cboCategory
      // 
      this.cboCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cboCategory.FormattingEnabled = true;
      this.cboCategory.Location = new System.Drawing.Point(12, 28);
      this.cboCategory.Name = "cboCategory";
      this.cboCategory.Size = new System.Drawing.Size(272, 21);
      this.cboCategory.TabIndex = 1;
      this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
      // 
      // listInv
      // 
      this.listInv.ContextMenuStrip = this.listInvPopup;
      this.listInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.listInv.FullRowSelect = true;
      this.listInv.GridLines = true;
      this.listInv.HideSelection = false;
      this.listInv.Location = new System.Drawing.Point(12, 154);
      this.listInv.Name = "listInv";
      this.listInv.Size = new System.Drawing.Size(979, 436);
      this.listInv.TabIndex = 1;
      this.listInv.UseCompatibleStateImageBehavior = false;
      this.listInv.View = System.Windows.Forms.View.Details;
      this.listInv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listInv_ColumnClick);
      this.listInv.DoubleClick += new System.EventHandler(this.listInv_DoubleClick);
      // 
      // listInvPopup
      // 
      this.listInvPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popUpOpen,
            this.popUpView,
            this.toolStripMenuItem7,
            this.popUpRemove});
      this.listInvPopup.Name = "listInvPopup";
      this.listInvPopup.Size = new System.Drawing.Size(171, 76);
      // 
      // popUpOpen
      // 
      this.popUpOpen.Name = "popUpOpen";
      this.popUpOpen.Size = new System.Drawing.Size(170, 22);
      this.popUpOpen.Text = "Open Item";
      this.popUpOpen.Click += new System.EventHandler(this.popUpOpen_Click);
      // 
      // popUpView
      // 
      this.popUpView.Name = "popUpView";
      this.popUpView.Size = new System.Drawing.Size(170, 22);
      this.popUpView.Text = "View Location";
      this.popUpView.Click += new System.EventHandler(this.popUpView_Click);
      // 
      // toolStripMenuItem7
      // 
      this.toolStripMenuItem7.Name = "toolStripMenuItem7";
      this.toolStripMenuItem7.Size = new System.Drawing.Size(167, 6);
      // 
      // popUpRemove
      // 
      this.popUpRemove.Name = "popUpRemove";
      this.popUpRemove.Size = new System.Drawing.Size(170, 22);
      this.popUpRemove.Text = "Remove Inventory";
      this.popUpRemove.Click += new System.EventHandler(this.popUpRemove_Click);
      // 
      // timerQueryPop
      // 
      this.timerQueryPop.Interval = 200;
      this.timerQueryPop.Tick += new System.EventHandler(this.timerQueryPop_Tick);
      // 
      // MainWnd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1011, 625);
      this.Controls.Add(this.listInv);
      this.Controls.Add(this.pnlSearch);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainWnd";
      this.Text = "Inventory";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.pnlSearch.ResumeLayout(false);
      this.pnlSearch.PerformLayout();
      this.listInvPopup.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mnuHelp;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.Panel pnlSearch;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cboCategory;
    private System.Windows.Forms.ListView listInv;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.TextBox txtPrimary;
    private System.Windows.Forms.Label lblPrimary;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem mnuFileAddPicLoc;
    private System.Windows.Forms.ToolStripMenuItem mnuFileAddNameLoc;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem mnuFileAddCategory;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    private System.Windows.Forms.ToolStripMenuItem mnuFileAddInvPic;
    private System.Windows.Forms.TextBox txtPrimary2;
    private System.Windows.Forms.ComboBox cboCompare;
    private System.Windows.Forms.ToolStripStatusLabel sbMessage;
    private System.Windows.Forms.ToolStripMenuItem mnuFileOptions;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem mnuViewPicLoc;
    private System.Windows.Forms.ToolStripMenuItem mnuViewNameLoc;
    private System.Windows.Forms.ToolStripMenuItem mnuFileAddInvName;
    private System.Windows.Forms.Timer timerQueryPop;
    private System.Windows.Forms.ContextMenuStrip listInvPopup;
    private System.Windows.Forms.ToolStripMenuItem popUpView;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
    private System.Windows.Forms.ToolStripMenuItem popUpRemove;
    private System.Windows.Forms.ToolStripMenuItem popUpOpen;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
    private System.Windows.Forms.ToolStripMenuItem mnuViewAdvancedSearch;
    private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
    private System.Windows.Forms.ToolStripMenuItem mnuViewCategory;
  }
}

