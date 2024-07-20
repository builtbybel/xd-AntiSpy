namespace xdAntiSpy
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.treeSettings = new System.Windows.Forms.TreeView();
            this.menuMainStrip = new System.Windows.Forms.MenuStrip();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileShareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsDebloaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsOpenPluginsDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSymbolReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextManualMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pinContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlForm.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.menuMainStrip.SuspendLayout();
            this.contextManualMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDescription.Location = new System.Drawing.Point(0, 270);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbDescription.Size = new System.Drawing.Size(425, 120);
            this.rtbDescription.TabIndex = 195;
            this.rtbDescription.Text = "";
            this.rtbDescription.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDescription_LinkClicked);
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnApply.Enabled = false;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnApply.Location = new System.Drawing.Point(0, 391);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(426, 28);
            this.btnApply.TabIndex = 196;
            this.btnApply.Text = "Apply Settings";
            this.btnApply.UseCompatibleTextRendering = true;
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.pnlMain);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(426, 419);
            this.pnlForm.TabIndex = 199;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.treeSettings);
            this.pnlMain.Controls.Add(this.btnApply);
            this.pnlMain.Controls.Add(this.rtbDescription);
            this.pnlMain.Controls.Add(this.menuMainStrip);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(426, 419);
            this.pnlMain.TabIndex = 198;
            // 
            // treeSettings
            // 
            this.treeSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeSettings.CheckBoxes = true;
            this.treeSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.treeSettings.FullRowSelect = true;
            this.treeSettings.HideSelection = false;
            this.treeSettings.HotTracking = true;
            this.treeSettings.Indent = 5;
            this.treeSettings.Location = new System.Drawing.Point(0, 22);
            this.treeSettings.Name = "treeSettings";
            this.treeSettings.ShowLines = false;
            this.treeSettings.ShowNodeToolTips = true;
            this.treeSettings.ShowPlusMinus = false;
            this.treeSettings.ShowRootLines = false;
            this.treeSettings.Size = new System.Drawing.Size(425, 245);
            this.treeSettings.TabIndex = 198;
            this.treeSettings.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeSettings_AfterCheck);
            this.treeSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeSettings_MouseDown);
            this.treeSettings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeSettings_MouseMove);
            // 
            // menuMainStrip
            // 
            this.menuMainStrip.BackColor = System.Drawing.Color.White;
            this.menuMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilesToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.statusToolStripMenuItem});
            this.menuMainStrip.Location = new System.Drawing.Point(0, 0);
            this.menuMainStrip.Name = "menuMainStrip";
            this.menuMainStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuMainStrip.Size = new System.Drawing.Size(426, 24);
            this.menuMainStrip.TabIndex = 205;
            this.menuMainStrip.Text = "menuStrip1";
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileImportToolStripMenuItem,
            this.profileExportToolStripMenuItem,
            this.profileCopyToolStripMenuItem,
            this.profileShareToolStripMenuItem});
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // profileImportToolStripMenuItem
            // 
            this.profileImportToolStripMenuItem.Name = "profileImportToolStripMenuItem";
            this.profileImportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.profileImportToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.profileImportToolStripMenuItem.Text = "Import";
            this.profileImportToolStripMenuItem.Click += new System.EventHandler(this.profileImportToolStripMenuItem_Click);
            // 
            // profileExportToolStripMenuItem
            // 
            this.profileExportToolStripMenuItem.Name = "profileExportToolStripMenuItem";
            this.profileExportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.profileExportToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.profileExportToolStripMenuItem.Text = "Export current";
            this.profileExportToolStripMenuItem.Click += new System.EventHandler(this.profileExportToolStripMenuItem_Click);
            // 
            // profileCopyToolStripMenuItem
            // 
            this.profileCopyToolStripMenuItem.Name = "profileCopyToolStripMenuItem";
            this.profileCopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.profileCopyToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.profileCopyToolStripMenuItem.Text = "Copy to clipboard";
            this.profileCopyToolStripMenuItem.Click += new System.EventHandler(this.profileCopyToolStripMenuItem_Click);
            // 
            // profileShareToolStripMenuItem
            // 
            this.profileShareToolStripMenuItem.Name = "profileShareToolStripMenuItem";
            this.profileShareToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.profileShareToolStripMenuItem.Text = "Share";
            this.profileShareToolStripMenuItem.Click += new System.EventHandler(this.profileShareToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsRefreshToolStripMenuItem,
            this.toolsDebloaterToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolsOpenPluginsDirToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // toolsRefreshToolStripMenuItem
            // 
            this.toolsRefreshToolStripMenuItem.Name = "toolsRefreshToolStripMenuItem";
            this.toolsRefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.toolsRefreshToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.toolsRefreshToolStripMenuItem.Text = "Refresh";
            this.toolsRefreshToolStripMenuItem.Click += new System.EventHandler(this.toolsRefreshToolStripMenuItem_Click);
            // 
            // toolsDebloaterToolStripMenuItem
            // 
            this.toolsDebloaterToolStripMenuItem.Name = "toolsDebloaterToolStripMenuItem";
            this.toolsDebloaterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.toolsDebloaterToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.toolsDebloaterToolStripMenuItem.Text = "Search for crappy apps";
            this.toolsDebloaterToolStripMenuItem.Click += new System.EventHandler(this.toolsDebloaterToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            // 
            // toolsOpenPluginsDirToolStripMenuItem
            // 
            this.toolsOpenPluginsDirToolStripMenuItem.Name = "toolsOpenPluginsDirToolStripMenuItem";
            this.toolsOpenPluginsDirToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.toolsOpenPluginsDirToolStripMenuItem.Text = "Open plugins directory";
            this.toolsOpenPluginsDirToolStripMenuItem.Click += new System.EventHandler(this.toolsOpenPluginsDirToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutAppToolStripMenuItem,
            this.aboutWebsiteToolStripMenuItem,
            this.aboutUpdateToolStripMenuItem,
            this.aboutSymbolReferenceToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.aboutToolStripMenuItem.Text = "?";
            // 
            // aboutAppToolStripMenuItem
            // 
            this.aboutAppToolStripMenuItem.Name = "aboutAppToolStripMenuItem";
            this.aboutAppToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutAppToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aboutAppToolStripMenuItem.Text = "About XDAntispy...";
            this.aboutAppToolStripMenuItem.Click += new System.EventHandler(this.aboutAppToolStripMenuItem_Click);
            // 
            // aboutWebsiteToolStripMenuItem
            // 
            this.aboutWebsiteToolStripMenuItem.Name = "aboutWebsiteToolStripMenuItem";
            this.aboutWebsiteToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aboutWebsiteToolStripMenuItem.Text = "Visit GitHub site";
            this.aboutWebsiteToolStripMenuItem.Click += new System.EventHandler(this.aboutWebsiteToolStripMenuItem_Click);
            // 
            // aboutUpdateToolStripMenuItem
            // 
            this.aboutUpdateToolStripMenuItem.Name = "aboutUpdateToolStripMenuItem";
            this.aboutUpdateToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aboutUpdateToolStripMenuItem.Text = "Update...";
            this.aboutUpdateToolStripMenuItem.Click += new System.EventHandler(this.aboutUpdateToolStripMenuItem_Click);
            // 
            // aboutSymbolReferenceToolStripMenuItem
            // 
            this.aboutSymbolReferenceToolStripMenuItem.Name = "aboutSymbolReferenceToolStripMenuItem";
            this.aboutSymbolReferenceToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aboutSymbolReferenceToolStripMenuItem.Text = "Symbol Reference...";
            this.aboutSymbolReferenceToolStripMenuItem.Click += new System.EventHandler(this.aboutSymbolReferenceToolStripMenuItem_Click);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusToolStripMenuItem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.statusToolStripMenuItem.Text = "Status";
            // 
            // contextManualMenu
            // 
            this.contextManualMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoContextItem,
            this.doContextItem,
            this.pinContextItem});
            this.contextManualMenu.Name = "contextManualMenu";
            this.contextManualMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextManualMenu.Size = new System.Drawing.Size(183, 70);
            // 
            // undoContextItem
            // 
            this.undoContextItem.Name = "undoContextItem";
            this.undoContextItem.Size = new System.Drawing.Size(182, 22);
            this.undoContextItem.Text = "Reset Setting";
            this.undoContextItem.Click += new System.EventHandler(this.contextMenuUndo_Click);
            // 
            // doContextItem
            // 
            this.doContextItem.Name = "doContextItem";
            this.doContextItem.Size = new System.Drawing.Size(182, 22);
            this.doContextItem.Text = "Set Setting Manually";
            this.doContextItem.Click += new System.EventHandler(this.contextMenuDo_Click);
            // 
            // pinContextItem
            // 
            this.pinContextItem.CheckOnClick = true;
            this.pinContextItem.Name = "pinContextItem";
            this.pinContextItem.Size = new System.Drawing.Size(182, 22);
            this.pinContextItem.Text = "Pin";
            this.pinContextItem.CheckedChanged += new System.EventHandler(this.pinContextItem_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(426, 419);
            this.Controls.Add(this.pnlForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMainStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.pnlForm.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.menuMainStrip.ResumeLayout(false);
            this.menuMainStrip.PerformLayout();
            this.contextManualMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnApply;
        public System.Windows.Forms.RichTextBox rtbDescription;
        public System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ContextMenuStrip contextManualMenu;
        private System.Windows.Forms.ToolStripMenuItem doContextItem;
        private System.Windows.Forms.ToolStripMenuItem undoContextItem;
        private System.Windows.Forms.ToolStripMenuItem pinContextItem;
        private System.Windows.Forms.TreeView treeSettings;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileShareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsDebloaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolsOpenPluginsDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSymbolReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuMainStrip;
    }
}

