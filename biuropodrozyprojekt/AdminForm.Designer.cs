namespace biuropodrozyprojekt
{
    partial class AdminForm
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
            this.addNewTripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tripAddPanel = new System.Windows.Forms.Panel();
            this.editTripsPanel = new System.Windows.Forms.Panel();
            this.editUsersPanel = new System.Windows.Forms.Panel();
            this.panelAdminCheckInf = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addNewTripToolStripMenuItem
            // 
            this.addNewTripToolStripMenuItem.Name = "addNewTripToolStripMenuItem";
            this.addNewTripToolStripMenuItem.Size = new System.Drawing.Size(171, 31);
            this.addNewTripToolStripMenuItem.Text = "Add new trip";
            this.addNewTripToolStripMenuItem.Click += new System.EventHandler(this.addNewTripToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(61, 31);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 17F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTripToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.userFormToolStripMenuItem,
            this.checkInformationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(952, 35);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userFormToolStripMenuItem
            // 
            this.userFormToolStripMenuItem.Name = "userFormToolStripMenuItem";
            this.userFormToolStripMenuItem.Size = new System.Drawing.Size(126, 31);
            this.userFormToolStripMenuItem.Text = "UserForm";
            this.userFormToolStripMenuItem.Click += new System.EventHandler(this.userFormToolStripMenuItem_Click);
            // 
            // checkInformationsToolStripMenuItem
            // 
            this.checkInformationsToolStripMenuItem.Name = "checkInformationsToolStripMenuItem";
            this.checkInformationsToolStripMenuItem.Size = new System.Drawing.Size(92, 31);
            this.checkInformationsToolStripMenuItem.Text = "MENU";
            this.checkInformationsToolStripMenuItem.Click += new System.EventHandler(this.checkInformationsToolStripMenuItem_Click);
            // 
            // tripAddPanel
            // 
            this.tripAddPanel.Location = new System.Drawing.Point(0, 38);
            this.tripAddPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tripAddPanel.Name = "tripAddPanel";
            this.tripAddPanel.Size = new System.Drawing.Size(968, 628);
            this.tripAddPanel.TabIndex = 5;
            // 
            // editTripsPanel
            // 
            this.editTripsPanel.Location = new System.Drawing.Point(0, 38);
            this.editTripsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.editTripsPanel.Name = "editTripsPanel";
            this.editTripsPanel.Size = new System.Drawing.Size(968, 628);
            this.editTripsPanel.TabIndex = 0;
            this.editTripsPanel.Visible = false;
            // 
            // editUsersPanel
            // 
            this.editUsersPanel.Location = new System.Drawing.Point(0, 38);
            this.editUsersPanel.Margin = new System.Windows.Forms.Padding(2);
            this.editUsersPanel.Name = "editUsersPanel";
            this.editUsersPanel.Size = new System.Drawing.Size(968, 628);
            this.editUsersPanel.TabIndex = 0;
            this.editUsersPanel.Visible = false;
            // 
            // panelAdminCheckInf
            // 
            this.panelAdminCheckInf.Location = new System.Drawing.Point(0, 38);
            this.panelAdminCheckInf.Name = "panelAdminCheckInf";
            this.panelAdminCheckInf.Size = new System.Drawing.Size(968, 628);
            this.panelAdminCheckInf.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(952, 662);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelAdminCheckInf);
            this.Controls.Add(this.editTripsPanel);
            this.Controls.Add(this.editUsersPanel);
            this.Controls.Add(this.tripAddPanel);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(968, 628);
            this.Name = "AdminForm";
            this.Text = "TravelAgencyAdminPanel";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem addNewTripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel tripAddPanel;
        private System.Windows.Forms.Panel editTripsPanel;
        private System.Windows.Forms.Panel editUsersPanel;
        private System.Windows.Forms.ToolStripMenuItem userFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkInformationsToolStripMenuItem;
        private System.Windows.Forms.Panel panelAdminCheckInf;
    }
}