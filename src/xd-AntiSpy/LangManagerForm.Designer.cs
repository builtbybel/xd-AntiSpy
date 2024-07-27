namespace xdAntiSpy
{
    partial class LangManagerForm
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
            this.checkedListBoxLanguages = new System.Windows.Forms.CheckedListBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.linkTranslate = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // checkedListBoxLanguages
            // 
            this.checkedListBoxLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxLanguages.CheckOnClick = true;
            this.checkedListBoxLanguages.FormattingEnabled = true;
            this.checkedListBoxLanguages.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxLanguages.Name = "checkedListBoxLanguages";
            this.checkedListBoxLanguages.Size = new System.Drawing.Size(251, 274);
            this.checkedListBoxLanguages.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(188, 299);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Install";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // linkTranslate
            // 
            this.linkTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkTranslate.AutoSize = true;
            this.linkTranslate.Location = new System.Drawing.Point(12, 304);
            this.linkTranslate.Name = "linkTranslate";
            this.linkTranslate.Size = new System.Drawing.Size(104, 13);
            this.linkTranslate.TabIndex = 2;
            this.linkTranslate.TabStop = true;
            this.linkTranslate.Text = "Missing a language?";
            this.linkTranslate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTranslate_LinkClicked);
            // 
            // LangManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 334);
            this.Controls.Add(this.linkTranslate);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.checkedListBoxLanguages);
            this.Name = "LangManagerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxLanguages;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.LinkLabel linkTranslate;
    }
}