namespace xdAntiSpy
{
    partial class SymbolRefForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbolRefForm));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.lblInactive = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.checkInfoPlugins = new System.Windows.Forms.CheckBox();
            this.lblRed = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::xdAntiSpy.Properties.Resources.asset_Uncheck;
            this.pictureBox2.Location = new System.Drawing.Point(12, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 35);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::xdAntiSpy.Properties.Resources.asset_Check;
            this.pictureBox1.Location = new System.Drawing.Point(12, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 37);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblActive
            // 
            this.lblActive.AutoEllipsis = true;
            this.lblActive.Location = new System.Drawing.Point(58, 75);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(295, 47);
            this.lblActive.TabIndex = 2;
            this.lblActive.Text = "Active: When an option is checked and grayed out, it means the setting is active." +
    "";
            // 
            // lblInactive
            // 
            this.lblInactive.AutoEllipsis = true;
            this.lblInactive.Location = new System.Drawing.Point(58, 22);
            this.lblInactive.Name = "lblInactive";
            this.lblInactive.Size = new System.Drawing.Size(295, 47);
            this.lblInactive.TabIndex = 3;
            this.lblInactive.Text = "Inactive: If an option is unchecked and the text is in a normal color, the settin" +
    "g is inactive. You can enable it by simply checking the box and pressing the app" +
    "ly button.";
            // 
            // lblGreen
            // 
            this.lblGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblGreen.Location = new System.Drawing.Point(-2, 148);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(381, 47);
            this.lblGreen.TabIndex = 4;
            this.lblGreen.Text = "Remember, keeping certain settings active can enhance your system\'s privacy and p" +
    "erformance. Adjust these options according to your needs, and enjoy a more secur" +
    "e computing experience!";
            // 
            // checkInfoPlugins
            // 
            this.checkInfoPlugins.AutoEllipsis = true;
            this.checkInfoPlugins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.checkInfoPlugins.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkInfoPlugins.Checked = true;
            this.checkInfoPlugins.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkInfoPlugins.Location = new System.Drawing.Point(0, 295);
            this.checkInfoPlugins.Name = "checkInfoPlugins";
            this.checkInfoPlugins.Size = new System.Drawing.Size(379, 92);
            this.checkInfoPlugins.TabIndex = 201;
            this.checkInfoPlugins.Text = resources.GetString("checkInfoPlugins.Text");
            this.checkInfoPlugins.UseVisualStyleBackColor = false;
            // 
            // lblRed
            // 
            this.lblRed.AutoEllipsis = true;
            this.lblRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblRed.Location = new System.Drawing.Point(-2, 204);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(381, 83);
            this.lblRed.TabIndex = 202;
            this.lblRed.Text = resources.GetString("lblRed.Text");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.lblInactive);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lblActive);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 140);
            this.panel1.TabIndex = 203;
            // 
            // SymbolRefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(379, 445);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRed);
            this.Controls.Add(this.checkInfoPlugins);
            this.Controls.Add(this.lblGreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SymbolRefForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Symbol Reference";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblInactive;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.CheckBox checkInfoPlugins;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Panel panel1;
    }
}