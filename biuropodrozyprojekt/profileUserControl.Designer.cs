namespace biuropodrozyprojekt
{
    partial class profileUserControl
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

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(profileUserControl));
            this.label1 = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.reservedLabel = new System.Windows.Forms.Label();
            this.showInfBtn = new System.Windows.Forms.Button();
            this.changeEmailLabel = new System.Windows.Forms.Label();
            this.changeEmailBtn = new System.Windows.Forms.Button();
            this.changeEmailTx = new System.Windows.Forms.TextBox();
            this.changePasswordLabel = new System.Windows.Forms.Label();
            this.changePasswordTx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.changeLoginTx = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.cancelReservationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile informations";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Century Gothic", 17F);
            this.usernameLabel.Location = new System.Drawing.Point(15, 106);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(136, 27);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "username: ";

            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Century Gothic", 17F);
            this.emailLabel.Location = new System.Drawing.Point(15, 147);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(83, 27);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "email:";
            // 
            // reservedLabel
            // 
            this.reservedLabel.AutoSize = true;
            this.reservedLabel.Font = new System.Drawing.Font("Century Gothic", 17F);
            this.reservedLabel.Location = new System.Drawing.Point(15, 242);
            this.reservedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.reservedLabel.Name = "reservedLabel";
            this.reservedLabel.Size = new System.Drawing.Size(169, 27);
            this.reservedLabel.TabIndex = 3;
            this.reservedLabel.Text = "reserved trips:";
            // 
            // showInfBtn
            // 
            this.showInfBtn.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.showInfBtn.Location = new System.Drawing.Point(20, 62);
            this.showInfBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showInfBtn.Name = "showInfBtn";
            this.showInfBtn.Size = new System.Drawing.Size(97, 28);
            this.showInfBtn.TabIndex = 5;
            this.showInfBtn.Text = "Show";
            this.showInfBtn.UseVisualStyleBackColor = true;
            this.showInfBtn.Click += new System.EventHandler(this.showProfileInformations);
            // 
            // changeEmailLabel
            // 
            this.changeEmailLabel.AutoSize = true;
            this.changeEmailLabel.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.changeEmailLabel.Location = new System.Drawing.Point(698, 453);
            this.changeEmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.changeEmailLabel.Name = "changeEmailLabel";
            this.changeEmailLabel.Size = new System.Drawing.Size(132, 21);
            this.changeEmailLabel.TabIndex = 35;
            this.changeEmailLabel.Text = "change email";
            // 
            // changeEmailBtn
            // 
            this.changeEmailBtn.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.changeEmailBtn.Location = new System.Drawing.Point(768, 524);
            this.changeEmailBtn.Margin = new System.Windows.Forms.Padding(2);
            this.changeEmailBtn.Name = "changeEmailBtn";
            this.changeEmailBtn.Size = new System.Drawing.Size(102, 43);
            this.changeEmailBtn.TabIndex = 34;
            this.changeEmailBtn.Text = "update";
            this.changeEmailBtn.UseVisualStyleBackColor = true;
            this.changeEmailBtn.Click += new System.EventHandler(this.changeEmailBtn_Click);
            // 
            // changeEmailTx
            // 
            this.changeEmailTx.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.changeEmailTx.Location = new System.Drawing.Point(702, 476);
            this.changeEmailTx.Margin = new System.Windows.Forms.Padding(2);
            this.changeEmailTx.Name = "changeEmailTx";
            this.changeEmailTx.Size = new System.Drawing.Size(168, 29);
            this.changeEmailTx.TabIndex = 33;
            // 
            // changePasswordLabel
            // 
            this.changePasswordLabel.AutoSize = true;
            this.changePasswordLabel.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.changePasswordLabel.Location = new System.Drawing.Point(698, 378);
            this.changePasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.changePasswordLabel.Name = "changePasswordLabel";
            this.changePasswordLabel.Size = new System.Drawing.Size(166, 21);
            this.changePasswordLabel.TabIndex = 32;
            this.changePasswordLabel.Text = "change password";
            // 
            // changePasswordTx
            // 
            this.changePasswordTx.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.changePasswordTx.Location = new System.Drawing.Point(702, 413);
            this.changePasswordTx.Margin = new System.Windows.Forms.Padding(2);
            this.changePasswordTx.Name = "changePasswordTx";
            this.changePasswordTx.Size = new System.Drawing.Size(168, 29);
            this.changePasswordTx.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label2.Location = new System.Drawing.Point(698, 299);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "change username";
            // 
            // changeLoginTx
            // 
            this.changeLoginTx.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.changeLoginTx.Location = new System.Drawing.Point(702, 333);
            this.changeLoginTx.Margin = new System.Windows.Forms.Padding(2);
            this.changeLoginTx.Name = "changeLoginTx";
            this.changeLoginTx.Size = new System.Drawing.Size(168, 29);
            this.changeLoginTx.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(645, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 143);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Century Gothic", 17F);
            this.passwordLabel.Location = new System.Drawing.Point(15, 191);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(126, 27);
            this.passwordLabel.TabIndex = 37;
            this.passwordLabel.Text = "password:";
            // 
            // cancelReservationButton
            // 
            this.cancelReservationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(84)))), ((int)(((byte)(6)))));
            this.cancelReservationButton.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.cancelReservationButton.Location = new System.Drawing.Point(184, 450);
            this.cancelReservationButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelReservationButton.Name = "cancelReservationButton";
            this.cancelReservationButton.Size = new System.Drawing.Size(144, 64);
            this.cancelReservationButton.TabIndex = 38;
            this.cancelReservationButton.Text = "Cancel reservation";
            this.cancelReservationButton.UseVisualStyleBackColor = false;
            this.cancelReservationButton.Visible = false;
            this.cancelReservationButton.Click += new System.EventHandler(this.cancelReservationButton_Click);
            // 
            // profileUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.cancelReservationButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.changeEmailLabel);
            this.Controls.Add(this.changeEmailBtn);
            this.Controls.Add(this.changeEmailTx);
            this.Controls.Add(this.changePasswordLabel);
            this.Controls.Add(this.changePasswordTx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.changeLoginTx);
            this.Controls.Add(this.showInfBtn);
            this.Controls.Add(this.reservedLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(968, 628);
            this.MinimumSize = new System.Drawing.Size(968, 628);
            this.Name = "profileUserControl";
            this.Size = new System.Drawing.Size(968, 628);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label reservedLabel;
        private System.Windows.Forms.Button showInfBtn;
        private System.Windows.Forms.Label changeEmailLabel;
        private System.Windows.Forms.Button changeEmailBtn;
        private System.Windows.Forms.TextBox changeEmailTx;
        private System.Windows.Forms.Label changePasswordLabel;
        private System.Windows.Forms.TextBox changePasswordTx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox changeLoginTx;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button cancelReservationButton;
    }
}
