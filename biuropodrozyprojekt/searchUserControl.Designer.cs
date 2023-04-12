using System.Windows.Forms;

namespace biuropodrozyprojekt
{
    partial class searchUserControl
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
            this.searchTx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nationalButton = new System.Windows.Forms.Button();
            this.internationalButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTx
            // 
            this.searchTx.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.searchTx.Location = new System.Drawing.Point(26, 48);
            this.searchTx.Margin = new System.Windows.Forms.Padding(2);
            this.searchTx.Name = "searchTx";
            this.searchTx.Size = new System.Drawing.Size(188, 37);
            this.searchTx.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.button1.Location = new System.Drawing.Point(112, 105);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.search);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search trips here";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label2.Location = new System.Drawing.Point(22, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "e.g. Poland, Warsaw";
            // 
            // nationalButton
            // 
            this.nationalButton.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nationalButton.Location = new System.Drawing.Point(732, 51);
            this.nationalButton.Margin = new System.Windows.Forms.Padding(2);
            this.nationalButton.Name = "nationalButton";
            this.nationalButton.Size = new System.Drawing.Size(78, 28);
            this.nationalButton.TabIndex = 6;
            this.nationalButton.Text = "apply";
            this.nationalButton.UseVisualStyleBackColor = true;
            this.nationalButton.Click += new System.EventHandler(this.nationalButton_Click);
            // 
            // internationalButton
            // 
            this.internationalButton.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.internationalButton.Location = new System.Drawing.Point(734, 108);
            this.internationalButton.Margin = new System.Windows.Forms.Padding(2);
            this.internationalButton.Name = "internationalButton";
            this.internationalButton.Size = new System.Drawing.Size(76, 28);
            this.internationalButton.TabIndex = 7;
            this.internationalButton.Text = "apply";
            this.internationalButton.UseVisualStyleBackColor = true;
            this.internationalButton.Click += new System.EventHandler(this.internationalButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.label4.Location = new System.Drawing.Point(728, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Show national trips";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.label5.Location = new System.Drawing.Point(730, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Show international trips";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(930, 446);
            this.dataGridView1.TabIndex = 10;
            // 
            // searchUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.internationalButton);
            this.Controls.Add(this.nationalButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchTx);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(968, 628);
            this.MinimumSize = new System.Drawing.Size(968, 628);
            this.Name = "searchUserControl";
            this.Size = new System.Drawing.Size(968, 628);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button nationalButton;
        private System.Windows.Forms.Button internationalButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DataGridView dataGridView1;

        public Button NationalButton { get => nationalButton; set => nationalButton = value; }
        public Button InternationalButton { get => internationalButton; set => internationalButton = value; }
    }
}
