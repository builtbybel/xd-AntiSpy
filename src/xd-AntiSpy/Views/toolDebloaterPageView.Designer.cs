namespace Views
{
    partial class toolDebloaterPageView
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.checkedListBoxApps = new System.Windows.Forms.CheckedListBox();
            this.btnChooseDB = new System.Windows.Forms.Button();
            this.linkLabelSelectAll = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(5, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBack.Location = new System.Drawing.Point(0, 464);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(95, 28);
            this.btnBack.TabIndex = 197;
            this.btnBack.Text = "< Back";
            this.btnBack.UseCompatibleTextRendering = true;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveSelected.AutoEllipsis = true;
            this.btnRemoveSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveSelected.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRemoveSelected.Location = new System.Drawing.Point(95, 464);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(331, 28);
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
            this.btnChooseDB.UseCompatibleTextRendering = true;
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
            // toolDebloaterPageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.linkLabelSelectAll);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnChooseDB);
            this.Controls.Add(this.checkedListBoxApps);
            this.Controls.Add(this.lblStatus);
            this.Name = "toolDebloaterPageView";
            this.Size = new System.Drawing.Size(423, 492);
            this.Load += new System.EventHandler(this.toolDebloaterPageView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.CheckedListBox checkedListBoxApps;
        private System.Windows.Forms.Button btnChooseDB;
        private System.Windows.Forms.LinkLabel linkLabelSelectAll;
    }
}
