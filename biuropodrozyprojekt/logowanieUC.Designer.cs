using System.Windows.Forms;

namespace biuropodrozyprojekt
{
    partial class logowanieUC
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
            this.loginTx = new System.Windows.Forms.TextBox();
            this.passwordTx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginTx
            // 
            this.loginTx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.loginTx.Location = new System.Drawing.Point(3, 33);
            this.loginTx.Name = "loginTx";
            this.loginTx.Size = new System.Drawing.Size(174, 30);
            this.loginTx.TabIndex = 1;
            this.loginTx.Text = "admin";
            // 
            // passwordTx
            // 
            this.passwordTx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.passwordTx.Location = new System.Drawing.Point(3, 113);
            this.passwordTx.Name = "passwordTx";
            this.passwordTx.PasswordChar = '*';
            this.passwordTx.Size = new System.Drawing.Size(174, 30);
            this.passwordTx.TabIndex = 2;
            this.passwordTx.Text = "admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "USERNAME";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.label2.Location = new System.Drawing.Point(2, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "PASSWORD";
            // 
            // loginBt
            // 
            this.loginBt.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.loginBt.Location = new System.Drawing.Point(3, 158);
            this.loginBt.Margin = new System.Windows.Forms.Padding(2);
            this.loginBt.Name = "loginBt";
            this.loginBt.Size = new System.Drawing.Size(84, 32);
            this.loginBt.TabIndex = 5;
            this.loginBt.Text = "LOGIN";
            this.loginBt.UseVisualStyleBackColor = true;
            this.loginBt.Click += new System.EventHandler(this.button1_Click);
            // 
            // logowanieUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.loginBt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTx);
            this.Controls.Add(this.loginTx);
            this.Name = "logowanieUC";
            this.Size = new System.Drawing.Size(182, 195);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox loginTx;
        private System.Windows.Forms.TextBox passwordTx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loginBt;

        public TextBox LoginTx { get => loginTx; set => loginTx = value; }
        public TextBox PasswordTx { get => passwordTx; set => passwordTx = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Button LoginBt { get => loginBt; set => loginBt = value; }
    }
}
