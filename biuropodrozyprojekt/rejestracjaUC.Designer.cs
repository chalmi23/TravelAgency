using System.Windows.Forms;

namespace biuropodrozyprojekt
{
    partial class rejestracjaUC
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
            this.registerPasswdTx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.registerEmailTx = new System.Windows.Forms.TextBox();
            this.createAccBt = new System.Windows.Forms.Button();
            this.registerUsernameTx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // registerPasswdTx
            // 
            this.registerPasswdTx.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.registerPasswdTx.Location = new System.Drawing.Point(6, 169);
            this.registerPasswdTx.Margin = new System.Windows.Forms.Padding(2);
            this.registerPasswdTx.Name = "registerPasswdTx";
            this.registerPasswdTx.Size = new System.Drawing.Size(188, 32);
            this.registerPasswdTx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 30F);
            this.label1.Location = new System.Drawing.Point(2, -1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 49);
            this.label1.TabIndex = 2;
            this.label1.Text = "REGISTER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label2.Location = new System.Drawing.Point(41, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "USERNAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label3.Location = new System.Drawing.Point(37, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "PASSWORD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label4.Location = new System.Drawing.Point(64, 214);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "EMAIL";
            // 
            // registerEmailTx
            // 
            this.registerEmailTx.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.registerEmailTx.Location = new System.Drawing.Point(6, 242);
            this.registerEmailTx.Margin = new System.Windows.Forms.Padding(2);
            this.registerEmailTx.Name = "registerEmailTx";
            this.registerEmailTx.Size = new System.Drawing.Size(188, 32);
            this.registerEmailTx.TabIndex = 6;
            // 
            // createAccBt
            // 
            this.createAccBt.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.createAccBt.Location = new System.Drawing.Point(31, 289);
            this.createAccBt.Margin = new System.Windows.Forms.Padding(2);
            this.createAccBt.Name = "createAccBt";
            this.createAccBt.Size = new System.Drawing.Size(136, 62);
            this.createAccBt.TabIndex = 7;
            this.createAccBt.Text = "CREATE ACCOUNT";
            this.createAccBt.UseVisualStyleBackColor = true;
            this.createAccBt.Click += new System.EventHandler(this.registerButtonClick);
            // 
            // registerUsernameTx
            // 
            this.registerUsernameTx.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.registerUsernameTx.Location = new System.Drawing.Point(6, 89);
            this.registerUsernameTx.Margin = new System.Windows.Forms.Padding(2);
            this.registerUsernameTx.Name = "registerUsernameTx";
            this.registerUsernameTx.Size = new System.Drawing.Size(188, 32);
            this.registerUsernameTx.TabIndex = 8;
            // 
            // rejestracjaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.registerUsernameTx);
            this.Controls.Add(this.createAccBt);
            this.Controls.Add(this.registerEmailTx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registerPasswdTx);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "rejestracjaUC";
            this.Size = new System.Drawing.Size(200, 358);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox registerPasswdTx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox registerEmailTx;
        private System.Windows.Forms.Button createAccBt;
        private TextBox registerUsernameTx;

        public TextBox RegisterUsernameTx { get => registerUsernameTx; set => registerUsernameTx = value; }
        public TextBox RegisterPasswdTx { get => registerPasswdTx; set => registerPasswdTx = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public TextBox RegisterEmailTx { get => registerEmailTx; set => registerEmailTx = value; }
        public Button CreateAccBt { get => createAccBt; set => createAccBt = value; }
    }
}
