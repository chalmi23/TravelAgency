namespace biuropodrozyprojekt
{
    partial class UserForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.discoverTripsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTripsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discoverPanel = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 17F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.discoverTripsToolStripMenuItem,
            this.eXITToolStripMenuItem,
            this.searchTripsToolStripMenuItem,
            this.myProfileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(952, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // discoverTripsToolStripMenuItem
            // 
            this.discoverTripsToolStripMenuItem.Name = "discoverTripsToolStripMenuItem";
            this.discoverTripsToolStripMenuItem.Size = new System.Drawing.Size(147, 31);
            this.discoverTripsToolStripMenuItem.Text = "Book a Trip";
            this.discoverTripsToolStripMenuItem.Click += new System.EventHandler(this.discoverTripsToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(61, 31);
            this.eXITToolStripMenuItem.Text = "Exit";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // searchTripsToolStripMenuItem
            // 
            this.searchTripsToolStripMenuItem.Name = "searchTripsToolStripMenuItem";
            this.searchTripsToolStripMenuItem.Size = new System.Drawing.Size(102, 31);
            this.searchTripsToolStripMenuItem.Text = "Search";
            this.searchTripsToolStripMenuItem.Click += new System.EventHandler(this.searchTripsToolStripMenuItem_Click);
            // 
            // myProfileToolStripMenuItem
            // 
            this.myProfileToolStripMenuItem.Name = "myProfileToolStripMenuItem";
            this.myProfileToolStripMenuItem.Size = new System.Drawing.Size(136, 31);
            this.myProfileToolStripMenuItem.Text = "My Profile";
            this.myProfileToolStripMenuItem.Click += new System.EventHandler(this.myProfileToolStripMenuItem_Click);
            // 
            // discoverPanel
            // 
            this.discoverPanel.Location = new System.Drawing.Point(0, 37);
            this.discoverPanel.Margin = new System.Windows.Forms.Padding(2);
            this.discoverPanel.Name = "discoverPanel";
            this.discoverPanel.Size = new System.Drawing.Size(968, 628);
            this.discoverPanel.TabIndex = 1;
            // 
            // panelSearch
            // 
            this.panelSearch.Location = new System.Drawing.Point(0, 37);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(2);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(968, 628);
            this.panelSearch.TabIndex = 2;
            // 
            // panelProfile
            // 
            this.panelProfile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelProfile.Location = new System.Drawing.Point(0, 37);
            this.panelProfile.Margin = new System.Windows.Forms.Padding(2);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(968, 628);
            this.panelProfile.TabIndex = 3;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 662);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.discoverPanel);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelProfile);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(968, 701);
            this.MinimumSize = new System.Drawing.Size(968, 701);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem discoverTripsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchTripsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myProfileToolStripMenuItem;
        private System.Windows.Forms.Panel discoverPanel;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Panel panelProfile;
    }
}