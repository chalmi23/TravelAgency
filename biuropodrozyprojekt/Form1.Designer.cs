namespace biuropodrozyprojekt
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.loginBt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBaner = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contactLabel = new System.Windows.Forms.Label();
            this.phoneIcon = new System.Windows.Forms.PictureBox();
            this.mailIcon = new System.Windows.Forms.PictureBox();
            this.logoIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(27, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 193);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(369, 16);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 388);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label1.Location = new System.Drawing.Point(8, 356);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Create account\r\n";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.button1.Location = new System.Drawing.Point(12, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "REGISTER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loginBt
            // 
            this.loginBt.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.loginBt.Location = new System.Drawing.Point(573, 368);
            this.loginBt.Margin = new System.Windows.Forms.Padding(2);
            this.loginBt.Name = "loginBt";
            this.loginBt.Size = new System.Drawing.Size(109, 36);
            this.loginBt.TabIndex = 4;
            this.loginBt.Text = "LOGIN";
            this.loginBt.UseVisualStyleBackColor = true;
            this.loginBt.Visible = false;
            this.loginBt.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(573, 326);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Already have\r\nan account?";
            this.label2.Visible = false;
            // 
            // labelBaner
            // 
            this.labelBaner.AutoSize = true;
            this.labelBaner.Font = new System.Drawing.Font("Freestyle Script", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBaner.Location = new System.Drawing.Point(35, 9);
            this.labelBaner.Name = "labelBaner";
            this.labelBaner.Size = new System.Drawing.Size(187, 94);
            this.labelBaner.TabIndex = 6;
            this.labelBaner.Text = "Plan your trip\r\n   With Us!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(243, -10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(494, 468);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Font = new System.Drawing.Font("Century Gothic", 17F);
            this.contactLabel.Location = new System.Drawing.Point(7, 322);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(340, 81);
            this.contactLabel.TabIndex = 8;
            this.contactLabel.Text = "Contact Us!\r\n     +48213769691\r\n     travelagency@gmail.com\r\n";
            this.contactLabel.Visible = false;
            // 
            // phoneIcon
            // 
            this.phoneIcon.Image = ((System.Drawing.Image)(resources.GetObject("phoneIcon.Image")));
            this.phoneIcon.Location = new System.Drawing.Point(10, 350);
            this.phoneIcon.Name = "phoneIcon";
            this.phoneIcon.Size = new System.Drawing.Size(27, 32);
            this.phoneIcon.TabIndex = 9;
            this.phoneIcon.TabStop = false;
            this.phoneIcon.Visible = false;
            // 
            // mailIcon
            // 
            this.mailIcon.Image = ((System.Drawing.Image)(resources.GetObject("mailIcon.Image")));
            this.mailIcon.Location = new System.Drawing.Point(11, 381);
            this.mailIcon.Name = "mailIcon";
            this.mailIcon.Size = new System.Drawing.Size(26, 22);
            this.mailIcon.TabIndex = 10;
            this.mailIcon.TabStop = false;
            this.mailIcon.Visible = false;
            // 
            // logoIcon
            // 
            this.logoIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoIcon.BackgroundImage")));
            this.logoIcon.Location = new System.Drawing.Point(60, 39);
            this.logoIcon.Name = "logoIcon";
            this.logoIcon.Size = new System.Drawing.Size(190, 240);
            this.logoIcon.TabIndex = 11;
            this.logoIcon.TabStop = false;
            this.logoIcon.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(692, 418);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logoIcon);
            this.Controls.Add(this.mailIcon);
            this.Controls.Add(this.phoneIcon);
            this.Controls.Add(this.labelBaner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loginBt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contactLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(708, 457);
            this.MinimumSize = new System.Drawing.Size(708, 457);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Travel Agency Nowak";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button loginBt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBaner;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.PictureBox phoneIcon;
        private System.Windows.Forms.PictureBox mailIcon;
        private System.Windows.Forms.PictureBox logoIcon;
    }
}

