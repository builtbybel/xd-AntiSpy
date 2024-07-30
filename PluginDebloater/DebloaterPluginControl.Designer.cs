namespace PluginDebloater
{
    partial class DebloaterPluginControl
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.checkedListBoxApps = new System.Windows.Forms.CheckedListBox();
            this.btnChooseDB = new System.Windows.Forms.Button();
            this.linkLabelSelectAll = new System.Windows.Forms.LinkLabel();
            this.checkBoxShowAllApps = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(5, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(185, 21);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.AutoEllipsis = true;
            this.btnRemoveSelected.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRemoveSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveSelected.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRemoveSelected.Location = new System.Drawing.Point(0, 464);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(423, 28);
            this.btnRemoveSelected.TabIndex = 198;
            this.btnRemoveSelected.Text = "Remove selected apps";
            this.btnRemoveSelected.UseCompatibleTextRendering = true;
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // checkedListBoxApps
            // 
            this.checkedListBoxApps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxApps.CheckOnClick = true;
            this.checkedListBoxApps.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxApps.FormattingEnabled = true;
            this.checkedListBoxApps.Location = new System.Drawing.Point(0, 39);
            this.checkedListBoxApps.Name = "checkedListBoxApps";
            this.checkedListBoxApps.Size = new System.Drawing.Size(422, 436);
            this.checkedListBoxApps.Sorted = true;
            this.checkedListBoxApps.TabIndex = 199;
            // 
            // btnChooseDB
            // 
            this.btnChooseDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseDB.AutoEllipsis = true;
            this.btnChooseDB.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnChooseDB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChooseDB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseDB.Location = new System.Drawing.Point(303, 12);
            this.btnChooseDB.Name = "btnChooseDB";
            this.btnChooseDB.Size = new System.Drawing.Size(119, 21);
            this.btnChooseDB.TabIndex = 200;
            this.btnChooseDB.Text = "Select custom db...";
            this.btnChooseDB.UseVisualStyleBackColor = true;
            this.btnChooseDB.Click += new System.EventHandler(this.btnChooseDB_Click);
            // 
            // linkLabelSelectAll
            // 
            this.linkLabelSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelSelectAll.AutoEllipsis = true;
            this.linkLabelSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelSelectAll.ForeColor = System.Drawing.Color.Black;
            this.linkLabelSelectAll.LinkColor = System.Drawing.Color.Black;
            this.linkLabelSelectAll.Location = new System.Drawing.Point(346, 472);
            this.linkLabelSelectAll.Name = "linkLabelSelectAll";
            this.linkLabelSelectAll.Size = new System.Drawing.Size(74, 13);
            this.linkLabelSelectAll.TabIndex = 201;
            this.linkLabelSelectAll.TabStop = true;
            this.linkLabelSelectAll.Text = "Select all";
            this.linkLabelSelectAll.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabelSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSelectAll_LinkClicked);
            // 
            // checkBoxShowAllApps
            // 
            this.checkBoxShowAllApps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowAllApps.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxShowAllApps.AutoEllipsis = true;
            this.checkBoxShowAllApps.FlatAppearance.BorderSize = 0;
            this.checkBoxShowAllApps.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxShowAllApps.Font = new System.Drawing.Font("Arial", 8.25F);
            this.checkBoxShowAllApps.Location = new System.Drawing.Point(196, 12);
            this.checkBoxShowAllApps.Name = "checkBoxShowAllApps";
            this.checkBoxShowAllApps.Size = new System.Drawing.Size(101, 21);
            this.checkBoxShowAllApps.TabIndex = 202;
            this.checkBoxShowAllApps.Text = "Show all installed";
            this.checkBoxShowAllApps.UseVisualStyleBackColor = true;
            this.checkBoxShowAllApps.CheckedChanged += new System.EventHandler(this.checkBoxShowAllApps_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 203;
            this.label1.Text = "Belims Debloater V1.0";
            // 
            // DebloaterPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxShowAllApps);
            this.Controls.Add(this.linkLabelSelectAll);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnChooseDB);
            this.Controls.Add(this.checkedListBoxApps);
            this.Controls.Add(this.lblStatus);
            this.Name = "DebloaterPluginControl";
            this.Size = new System.Drawing.Size(423, 492);
            this.Load += new System.EventHandler(this.toolDebloaterPageView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.CheckedListBox checkedListBoxApps;
        private System.Windows.Forms.Button btnChooseDB;
        private System.Windows.Forms.LinkLabel linkLabelSelectAll;
        private System.Windows.Forms.CheckBox checkBoxShowAllApps;
        private System.Windows.Forms.Label label1;
    }
}
